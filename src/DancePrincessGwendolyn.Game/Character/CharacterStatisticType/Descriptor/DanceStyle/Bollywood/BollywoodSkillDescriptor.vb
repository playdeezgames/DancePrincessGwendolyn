Friend Class BollywoodSkillDescriptor
    Inherits CharacterStatisticTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Bollywood Skill"
        End Get
    End Property

    Public Overrides Function Minimum(character As Character) As Long
        Return 4
    End Function

    Public Overrides Function Maximum(character As Character) As Long
        Return character.GetStatistic(CharacterStatisticType.BollywoodSkillMaximumUses).Value
    End Function
End Class
