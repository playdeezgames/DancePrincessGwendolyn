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

    Private Shared ReadOnly danceStyleShoppeItems As IReadOnlyDictionary(Of DanceStyle, IEnumerable(Of ItemType)) =
        New Dictionary(Of DanceStyle, IEnumerable(Of ItemType)) From
        {
            {
                DanceStyle.Ballet,
                New List(Of ItemType) From
                {
                    ItemType.Snax
                }
            },
            {
                DanceStyle.Bollywood,
                New List(Of ItemType) From
                {
                    ItemType.Snax
                }
            },
            {
                DanceStyle.Cheerleading,
                New List(Of ItemType) From
                {
                    ItemType.Snax
                }
            },
            {
                DanceStyle.HipHop,
                New List(Of ItemType) From
                {
                    ItemType.Snax
                }
            },
            {
                DanceStyle.LineDancing,
                New List(Of ItemType) From
                {
                    ItemType.Snax
                }
            },
            {
                DanceStyle.TapDancing,
                New List(Of ItemType) From
                {
                    ItemType.Snax
                }
            }
        }

    Friend Overrides ReadOnly Property ShoppeItems(location As Location) As IEnumerable(Of ItemType)
        Get
            Return danceStyleShoppeItems(location.DanceStyle.Value)
        End Get
    End Property
End Class
