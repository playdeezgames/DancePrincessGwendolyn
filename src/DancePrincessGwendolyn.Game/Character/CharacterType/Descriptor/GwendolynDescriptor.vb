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
            {CharacterStatisticType.Confidence, 10},
            {CharacterStatisticType.Ennui, 0},
            {CharacterStatisticType.Enthusiasm, 10},
            {CharacterStatisticType.Bux, 0},
            {CharacterStatisticType.Sparkle, 0}
        }

    Friend Overrides Sub OnCreate(character As Character)
        InitializeStatistics(character, statistics)
        DetermineDanceSkills(character)
    End Sub

    Private Shared ReadOnly DanceSkillValues As IReadOnlyList(Of Long) =
        New List(Of Long) From {4, 6, 8, 10, 12, 20}

    Private Const UsageDividend As Long = 24

    Private Sub DetermineDanceSkills(character As Character)
        Dim valuePool As New HashSet(Of Long)(DanceSkillValues)
        For Each style In AllDanceStyles
            Dim value = RNG.FromEnumerable(valuePool)
            Dim maximumUses = UsageDividend \ value
            valuePool.Remove(value)
            CharacterStatisticData.Write(character.Id, style.CharacterStatisticType, value)
            CharacterStatisticData.Write(character.Id, style.MaximumUsageStatisticType, maximumUses)
            CharacterStatisticData.Write(character.Id, style.UsageStatisticType, 0)
        Next
    End Sub
End Class
