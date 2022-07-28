Friend MustInherit Class LocationTypeDescriptor
    MustOverride ReadOnly Property Name As String
    Friend MustOverride Sub OnRefresh(location As Location)
    MustOverride ReadOnly Property HasLifeCoach As Boolean

    Friend Overridable ReadOnly Property CanBuyIceCream As Boolean
        Get
            Return False
        End Get
    End Property

    Friend Overridable ReadOnly Property HasShoppe As Boolean
        Get
            Return False
        End Get
    End Property

    Friend Overridable ReadOnly Property ShoppeItems(location As Location) As IEnumerable(Of ItemType)
        Get
            Return New List(Of ItemType)
        End Get
    End Property
End Class
Friend Module LocationTypeDescriptorUtility
    Friend ReadOnly LocationTypeDescriptors As IReadOnlyDictionary(Of LocationType, LocationTypeDescriptor) =
        New Dictionary(Of LocationType, LocationTypeDescriptor) From
        {
            {LocationType.BrickRoad, New BrickRoadLocationTypeDescriptor},
            {LocationType.Capitol, New CapitolLocationTypeDescriptor},
            {LocationType.DirtPath, New DirtPathLocationTypeDescriptor},
            {LocationType.GravelRoad, New GravelRoadLocationTypeDescriptor},
            {LocationType.Town, New TownLocationTypeDescriptor}
        }
End Module
