Friend Class BalletSkillUsesDescriptor
    Inherits CharacterStatisticTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Ballet Uses"
        End Get
    End Property

    Public Overrides Function Minimum(character As Character) As Long
        Return 0
    End Function

    Public Overrides Function Maximum(character As Character) As Long
        Return character.GetStatistic(CharacterStatisticType.BalletSkillMaximumUses).Value
    End Function
End Class
