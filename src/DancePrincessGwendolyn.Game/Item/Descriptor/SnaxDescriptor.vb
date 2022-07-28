Friend Class SnaxDescriptor
    Inherits ItemTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Snax"
        End Get
    End Property

    Public Overrides ReadOnly Property Price As Long
        Get
            Return 10
        End Get
    End Property
End Class
