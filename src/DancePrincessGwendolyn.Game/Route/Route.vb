﻿Public Class Route
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

End Class
