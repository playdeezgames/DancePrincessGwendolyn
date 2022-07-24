Friend MustInherit Class RouteTypeDescriptor
    MustOverride ReadOnly Property Name As String
End Class
Friend Module RouteTypeDescriptorUtility
    Friend ReadOnly RouteTypeDescriptors As IReadOnlyDictionary(Of RouteType, RouteTypeDescriptor) =
        New Dictionary(Of RouteType, RouteTypeDescriptor) From
        {
            {RouteType.BrickRoad, New BrickRoadDescriptor},
            {RouteType.DirtPath, New DirtPathDescriptor},
            {RouteType.GravelRoad, New GravelRoadDescriptor}
        }
End Module