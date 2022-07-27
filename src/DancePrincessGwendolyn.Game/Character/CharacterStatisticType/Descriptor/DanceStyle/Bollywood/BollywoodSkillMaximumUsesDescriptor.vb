Friend Class BollywoodSkillMaximumUsesDescriptor
    Inherits CharacterStatisticTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Bollywood Maximum Uses"
        End Get
    End Property

    Public Overrides Function Minimum(character As Character) As Long
        Return 1
    End Function

    Public Overrides Function Maximum(character As Character) As Long
        Return Long.MaxValue
    End Function
End Class
