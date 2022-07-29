Friend Class CowboyBootsDescriptor
    Inherits ItemTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Cowboy Boots"
        End Get
    End Property

    Public Overrides ReadOnly Property Price As Long
        Get
            Return 50
        End Get
    End Property
End Class
