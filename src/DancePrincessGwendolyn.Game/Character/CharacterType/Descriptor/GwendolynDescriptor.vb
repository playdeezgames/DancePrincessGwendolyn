Friend Class GwendolynDescriptor
    Inherits CharacterTypeDescriptor

    Friend Overrides ReadOnly Property Name As String
        Get
            Return "Gwendolyn"
        End Get
    End Property

    Private Shared ReadOnly statistics As IReadOnlyDictionary(Of CharacterStatisticType, Long) =
        New Dictionary(Of CharacterStatisticType, Long) From
        {
            {CharacterStatisticType.Anxiety, 0},
            {CharacterStatisticType.Confidence, 5},
            {CharacterStatisticType.Ennui, 0},
            {CharacterStatisticType.Enthusiasm, 5}
        }

    Friend Overrides Sub OnCreate(character As Character)
        For Each statistic In statistics
            CharacterStatisticData.Write(character.Id, statistic.Key, statistic.Value)
        Next
    End Sub
End Class
