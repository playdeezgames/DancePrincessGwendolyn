Friend Class TownLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Town"
        End Get
    End Property

    Public Overrides ReadOnly Property HasLifeCoach As Boolean
        Get
            Return True
        End Get
    End Property

    Friend Overrides Sub OnRefresh(location As Location)

    End Sub
End Class
