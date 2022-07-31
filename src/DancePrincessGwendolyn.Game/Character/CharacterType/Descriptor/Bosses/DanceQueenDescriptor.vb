Friend Class DanceQueenDescriptor
    Inherits CharacterTypeDescriptor

    Friend Overrides ReadOnly Property Name As String
        Get
            Return "Dance Queen"
        End Get
    End Property

    Private Shared ReadOnly statistics As IReadOnlyDictionary(Of CharacterStatisticType, Long) =
        New Dictionary(Of CharacterStatisticType, Long) From
        {
            {CharacterStatisticType.Anxiety, 0},
            {CharacterStatisticType.Confidence, 100},
            {CharacterStatisticType.Ennui, 0},
            {CharacterStatisticType.Enthusiasm, 0},
            {CharacterStatisticType.Sparkle, 100}
        }


    Friend Overrides Sub OnCreate(character As Character)
        InitializeStatistics(character, statistics)
        DetermineDanceSkills(character)
        Dim item = Game.Item.Create(ItemType.DiamondTiara)
        character.Equip(item)
    End Sub

    Private Sub DetermineDanceSkills(character As Character)
        For Each style In AllDanceStyles
            CharacterStatisticData.Write(character.Id, style.CharacterStatisticType, 20)
            CharacterStatisticData.Write(character.Id, style.MaximumUsageStatisticType, 100)
            CharacterStatisticData.Write(character.Id, style.UsageStatisticType, 0)
        Next
    End Sub

    Friend Overrides Function RollDefeatBux(character As Character) As Long
        Return CLng(RNG.RollDice("16d6"))
    End Function
End Class
