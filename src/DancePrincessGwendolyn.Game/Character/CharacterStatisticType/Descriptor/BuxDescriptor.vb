Friend Class BuxDescriptor
    Inherits CharacterStatisticTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Bux"
        End Get
    End Property

    Public Overrides Function Minimum(character As Character) As Long
        Return 0
    End Function

    Public Overrides Function Maximum(character As Character) As Long
        Return Long.MaxValue
    End Function
End Class
