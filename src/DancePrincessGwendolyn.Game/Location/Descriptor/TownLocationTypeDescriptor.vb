Friend Class TownLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Town"
        End Get
    End Property

    Friend Overrides Sub OnRefresh(location As Location)

    End Sub
End Class
