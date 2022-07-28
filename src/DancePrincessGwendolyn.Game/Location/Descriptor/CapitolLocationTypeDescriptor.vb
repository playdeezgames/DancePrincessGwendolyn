Friend Class CapitolLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "The Capitol"
        End Get
    End Property

    Public Overrides ReadOnly Property HasLifeCoach As Boolean
        Get
            Return True
        End Get
    End Property

    Friend Overrides Sub OnRefresh(location As Location)
    End Sub

    Friend Overrides ReadOnly Property CanBuyIceCream As Boolean
        Get
            Return True
        End Get
    End Property
End Class
