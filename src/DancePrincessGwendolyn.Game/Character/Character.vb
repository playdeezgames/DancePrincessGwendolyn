Public Class Character
    Public ReadOnly Id As Long
    Public Sub New(characterId As Long)
        Id = characterId
    End Sub

    Public Property Location As Location
        Get
            Return Location.FromId(CharacterData.ReadLocation(Id))
        End Get
        Set(value As Location)
            If value.Id <> CharacterData.ReadLocation(Id).Value Then
                value.Refresh()
                CharacterData.WriteLocation(Id, value.Id)
            End If
        End Set
    End Property

    Public Function PickRandomDanceStyle() As DanceStyle
        Dim table As New Dictionary(Of DanceStyle, Integer)
        For Each danceStyle In AllDanceStyles
            Dim uses = RemainingUses(danceStyle)
            If uses > 0 Then
                table(danceStyle) = CInt(uses)
            End If
        Next
        If Not table.Any Then
            Return DanceStyle.None
        End If
        Return RNG.FromGenerator(table)
    End Function

    Public ReadOnly Property CanDoDanceOff As Boolean
        Get
            Return Confidence > 0 AndAlso Location.NonPlayerCharacters.Any
        End Get
    End Property

    Public Shared Function FromId(characterId As Long?) As Character
        If Not characterId.HasValue Then
            Return Nothing
        End If
        Return New Character(characterId.Value)
    End Function
    Public Shared Function Create(characterType As CharacterType, location As Location) As Character
        Dim character = FromId(CharacterData.Create(characterType, location.Id))
        characterType.OnCreate(character)
        Return character
    End Function

    Public Sub AddAnxiety(delta As Long)
        ChangeStatistic(CharacterStatisticType.Anxiety, delta)
    End Sub

    Public ReadOnly Property CharacterType As CharacterType
        Get
            Return CType(CharacterData.ReadCharacterType(Id).Value, CharacterType)
        End Get
    End Property

    Public Sub Destroy()
        CharacterData.Clear(Id)
    End Sub

    Public ReadOnly Property Name As String
        Get
            Return CharacterType.Name
        End Get
    End Property

    Private ReadOnly Property Anxiety As Long
        Get
            Return GetStatistic(CharacterStatisticType.Anxiety).Value
        End Get
    End Property

    Public ReadOnly Property Confidence As Long
        Get
            Return Math.Min(Math.Max(0, MaximumConfidence - Anxiety), MaximumConfidence)
        End Get
    End Property

    Public ReadOnly Property MaximumConfidence As Long
        Get
            Return GetStatistic(CharacterStatisticType.Confidence).Value
        End Get
    End Property

    Private ReadOnly Property Ennui As Long
        Get
            Return GetStatistic(CharacterStatisticType.Ennui).Value
        End Get
    End Property

    Public Sub AddUse(danceStyle As DanceStyle)
        ChangeStatistic(danceStyle.UsageStatisticType, 1)
    End Sub

    Public ReadOnly Property Enthusiasm As Long
        Get
            Return Math.Min(Math.Max(0, MaximumEnthusiasm - Ennui), MaximumEnthusiasm)
        End Get
    End Property

    Public ReadOnly Property MaximumEnthusiasm As Long
        Get
            Return GetStatistic(CharacterStatisticType.Enthusiasm).Value
        End Get
    End Property

    Public Function GetStatistic(statisticType As CharacterStatisticType) As Long?
        Return CharacterStatisticData.Read(Id, statisticType)
    End Function

    Private Sub ChangeStatistic(statisticType As CharacterStatisticType, delta As Long)
        SetStatistic(statisticType, GetStatistic(statisticType).Value + delta)
    End Sub

    Private Sub SetStatistic(statisticType As CharacterStatisticType, value As Long)
        CharacterStatisticData.Write(Id, statisticType, value)
    End Sub

    Public ReadOnly Property DanceSkills As IReadOnlyDictionary(Of DanceStyle, Long)
        Get
            Return AllDanceStyles.ToDictionary(
                Function(x) x,
                Function(x) GetStatistic(x.CharacterStatisticType).Value)
        End Get
    End Property

    Private Function UsageCount(danceStyle As DanceStyle) As Long
        Return GetStatistic(danceStyle.UsageStatisticType).Value
    End Function

    Public Function RemainingUses(danceStyle As DanceStyle) As Long
        Return Math.Min(Math.Max(0, TotalUses(danceStyle) - UsageCount(danceStyle)), TotalUses(danceStyle))
    End Function

    Public Function TotalUses(danceStyle As DanceStyle) As Long
        Return GetStatistic(danceStyle.MaximumUsageStatisticType).Value
    End Function

    Public ReadOnly Property IsPlayer As Boolean
        Get
            Return Id = World.PlayerCharacter.Id
        End Get
    End Property
End Class
