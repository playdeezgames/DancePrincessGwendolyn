Imports System.Runtime.CompilerServices

Public Enum RouteType
    None
    GravelRoad
    DirtPath
    BrickRoad
End Enum
Public Module RouteTypeExtensions
    <Extension>
    Public Function Name(routeType As RouteType) As String
        Return RouteTypeDescriptors(routeType).Name
    End Function
End Module
