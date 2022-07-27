Friend Class CheerleadingSkillUsesDescriptor
    Inherits CharacterStatisticTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Cheerleading Uses"
        End Get
    End Property

    Public Overrides Function Minimum(character As Character) As Long
        Return 4
    End Function

    Public Overrides Function Maximum(character As Character) As Long
        Return Long.MaxValue
    End Function
End Class
