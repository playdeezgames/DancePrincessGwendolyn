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
            CharacterData.WriteLocation(Id, value.Id)
        End Set
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
    Public ReadOnly Property CharacterType As CharacterType
        Get
            Return CType(CharacterData.ReadCharacterType(Id).Value, CharacterType)
        End Get
    End Property

    Public ReadOnly Property Name As String
        Get
            Return CharacterType.Name
        End Get
    End Property

    Private ReadOnly Property Anxiety As Long
        Get
            Return CharacterStatisticData.Read(Id, CharacterStatisticType.Anxiety).Value
        End Get
    End Property

    Public ReadOnly Property Confidence As Long
        Get
            Return Math.Min(Math.Max(0, MaximumConfidence - Anxiety), MaximumConfidence)
        End Get
    End Property

    Public ReadOnly Property MaximumConfidence As Long
        Get
            Return CharacterStatisticData.Read(Id, CharacterStatisticType.Confidence).Value
        End Get
    End Property

    Private ReadOnly Property Ennui As Long
        Get
            Return CharacterStatisticData.Read(Id, CharacterStatisticType.Ennui).Value
        End Get
    End Property

    Public ReadOnly Property Enthusiasm As Long
        Get
            Return Math.Min(Math.Max(0, MaximumEnthusiasm - Ennui), MaximumEnthusiasm)
        End Get
    End Property

    Public ReadOnly Property MaximumEnthusiasm As Long
        Get
            Return CharacterStatisticData.Read(Id, CharacterStatisticType.Enthusiasm).Value
        End Get
    End Property
End Class
