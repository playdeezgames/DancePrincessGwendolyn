Friend Class BatonDescriptor
    Inherits ItemTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Baton"
        End Get
    End Property

    Public Overrides ReadOnly Property Price As Long
        Get
            Return 25
        End Get
    End Property
End Class
