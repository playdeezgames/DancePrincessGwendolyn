Friend Class BalletN00bDescriptor
    Inherits CharacterTypeDescriptor

    Friend Overrides ReadOnly Property Name As String
        Get
            Return "Ballet N00b"
        End Get
    End Property

    Private Shared ReadOnly statistics As IReadOnlyDictionary(Of CharacterStatisticType, Long) =
        New Dictionary(Of CharacterStatisticType, Long) From
        {
            {CharacterStatisticType.Anxiety, 0},
            {CharacterStatisticType.Confidence, 5},
            {CharacterStatisticType.Ennui, 0},
            {CharacterStatisticType.Enthusiasm, 0}
        }


    Friend Overrides Sub OnCreate(character As Character)
        For Each statistic In statistics
            CharacterStatisticData.Write(character.Id, statistic.Key, statistic.Value)
        Next
        DetermineDanceSkills(character)
    End Sub

    Private Sub DetermineDanceSkills(character As Character)
        For Each style In AllDanceStyles
            Dim value = If(style = DanceStyle.Ballet, 10, 0)
            Dim maximumUses = If(style = DanceStyle.Ballet, 20, 0)
            CharacterStatisticData.Write(character.Id, style.CharacterStatisticType, value)
            CharacterStatisticData.Write(character.Id, style.MaximumUsageStatisticType, maximumUses)
            CharacterStatisticData.Write(character.Id, style.UsageStatisticType, 0)
        Next
    End Sub

End Class
