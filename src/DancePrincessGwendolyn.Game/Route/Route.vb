Public Class Route
    Public ReadOnly Id As Long
    Public Sub New(routeId As Long)
        Id = routeId
    End Sub
    Public Shared Function FromId(routeId As Long?) As Route
        If Not routeId.HasValue Then
            Return Nothing
        End If
        Return New Route(routeId.Value)
    End Function
    Public Shared Function Create(
                                 routeType As RouteType,
                                 fromLocation As Location,
                                 toLocation As Location,
                                 destinationLocation As Location) As Route
        Return FromId(RouteData.Create(routeType, fromLocation.Id, toLocation.Id, destinationLocation.Id))
    End Function
    Public ReadOnly Property RouteType As RouteType
        Get
            Return CType(RouteData.ReadRouteType(Id).Value, RouteType)
        End Get
    End Property
    Public ReadOnly Property DestinationLocation As Location
        Get
            Return Location.FromId(RouteData.ReadDestinationLocation(Id).Value)
        End Get
    End Property
    Public ReadOnly Property ToLocation As Location
        Get
            Return Location.FromId(RouteData.ReadToLocation(Id).Value)
        End Get
    End Property
    Public ReadOnly Property Name As String
        Get
            Return $"{RouteType.Name} to {DestinationLocation.Name}"
        End Get
    End Property
End Class
