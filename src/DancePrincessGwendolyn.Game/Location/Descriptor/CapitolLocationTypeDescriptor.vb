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

    Friend Overrides ReadOnly Property HasShoppe As Boolean
        Get
            Return True
        End Get
    End Property

    Private Shared ReadOnly capitolShoppeItems As IReadOnlyList(Of ItemType) =
        New List(Of ItemType) From
        {
            ItemType.Snax
        }

    Friend Overrides ReadOnly Property ShoppeItems(location As Location) As IEnumerable(Of ItemType)
        Get
            Return capitolShoppeItems
        End Get
    End Property
End Class
