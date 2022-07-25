Friend Class GravelRoadLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Gravel Road"
        End Get
    End Property

    Friend Overrides Sub OnRefresh(location As Location)

    End Sub
End Class
