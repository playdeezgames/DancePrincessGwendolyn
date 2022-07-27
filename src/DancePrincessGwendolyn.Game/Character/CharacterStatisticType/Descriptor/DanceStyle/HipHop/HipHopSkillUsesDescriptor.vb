Friend Class HipHopSkillUsesDescriptor
    Inherits CharacterStatisticTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Hip Hop Uses"
        End Get
    End Property

    Public Overrides Function Minimum(character As Character) As Long
        Return 0
    End Function

    Public Overrides Function Maximum(character As Character) As Long
        Return character.GetStatistic(CharacterStatisticType.HipHopSkillMaximumUses).Value
    End Function
End Class
