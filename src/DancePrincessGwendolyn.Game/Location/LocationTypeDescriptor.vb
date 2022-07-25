Friend MustInherit Class LocationTypeDescriptor
    MustOverride ReadOnly Property Name As String
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
