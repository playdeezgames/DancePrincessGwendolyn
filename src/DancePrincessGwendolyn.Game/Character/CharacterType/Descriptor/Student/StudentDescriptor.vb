Friend Class StudentDescriptor
    Inherits CharacterTypeDescriptor

    Private ReadOnly DanceStyle As DanceStyle

    Friend Overrides ReadOnly Property Name As String
    Sub New(name As String, danceStyle As DanceStyle)
        Me.Name = name
        Me.DanceStyle = danceStyle
    End Sub

    Private Shared ReadOnly statistics As IReadOnlyDictionary(Of CharacterStatisticType, Long) =
        New Dictionary(Of CharacterStatisticType, Long) From
        {
            {CharacterStatisticType.Anxiety, 0},
            {CharacterStatisticType.Confidence, 10},
            {CharacterStatisticType.Ennui, 0},
            {CharacterStatisticType.Enthusiasm, 0},
            {CharacterStatisticType.Sparkle, 10}
        }


    Friend Overrides Sub OnCreate(character As Character)
        InitializeStatistics(character, statistics)
        DetermineDanceSkills(character)
    End Sub

    Private Sub DetermineDanceSkills(character As Character)
        For Each style In AllDanceStyles
            Dim value = If(style = DanceStyle, 12, 6)
            Dim maximumUses = If(style = DanceStyle, 20, 2)
            CharacterStatisticData.Write(character.Id, style.CharacterStatisticType, value)
            CharacterStatisticData.Write(character.Id, style.MaximumUsageStatisticType, maximumUses)
            CharacterStatisticData.Write(character.Id, style.UsageStatisticType, 0)
        Next
    End Sub

    Friend Overrides Function RollDefeatBux(character As Character) As Long
        Return CLng(RNG.RollDice("4d6"))
    End Function
End Class
