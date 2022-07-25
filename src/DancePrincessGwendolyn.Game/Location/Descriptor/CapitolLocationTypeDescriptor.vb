Friend Class CapitolLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "The Capitol"
        End Get
    End Property

    Friend Overrides Sub OnRefresh(location As Location)
    End Sub
End Class
