Friend Class BossDescriptor
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
            {CharacterStatisticType.Confidence, 50},
            {CharacterStatisticType.Ennui, 0},
            {CharacterStatisticType.Enthusiasm, 0},
            {CharacterStatisticType.Sparkle, 50}
        }


    Friend Overrides Sub OnCreate(character As Character)
        InitializeStatistics(character, statistics)
        DetermineDanceSkills(character)
        Dim item = Game.Item.Create(DanceStyle.TrophyItemType)
        character.Equip(item)
    End Sub

    Private Sub DetermineDanceSkills(character As Character)
        For Each style In AllDanceStyles
            Dim value = If(style = DanceStyle, 20, 10)
            Dim maximumUses = If(style = DanceStyle, 40, 10)
            CharacterStatisticData.Write(character.Id, style.CharacterStatisticType, value)
            CharacterStatisticData.Write(character.Id, style.MaximumUsageStatisticType, maximumUses)
            CharacterStatisticData.Write(character.Id, style.UsageStatisticType, 0)
        Next
    End Sub

    Friend Overrides Function RollDefeatBux(character As Character) As Long
        Return CLng(RNG.RollDice("8d6"))
    End Function
End Class
