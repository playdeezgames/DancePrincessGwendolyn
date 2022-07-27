Friend Class LineDancingSkillUsesDescriptor
    Inherits CharacterStatisticTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Line Dancing Uses"
        End Get
    End Property

    Public Overrides Function Minimum(character As Character) As Long
        Return 0
    End Function

    Public Overrides Function Maximum(character As Character) As Long
        Return character.GetStatistic(CharacterStatisticType.LineDancingSkillMaximumUses).Value
    End Function
End Class
