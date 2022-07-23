Friend MustInherit Class LocationTypeDescriptor
    MustOverride ReadOnly Property Name As String
End Class
Friend Module LocationTypeDescriptorUtility
    Friend ReadOnly LocationTypeDescriptors As IReadOnlyDictionary(Of LocationType, LocationTypeDescriptor) =
        New Dictionary(Of LocationType, LocationTypeDescriptor) From
        {
            {LocationType.CapitolEntrance, New CapitolEntranceLocationTypeDescriptor},
            {LocationType.Road, New RoadLocationTypeDescriptor},
            {LocationType.TownEntrance, New TownEntranceLocationTypeDescriptor}
        }
End Module
