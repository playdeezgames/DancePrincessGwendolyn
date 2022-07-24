Public Module RouteData
    Friend Const TableName = "Routes"
    Friend Const RouteIdColumn = "RouteId"
    Friend Const RouteTypeColumn = "RouteType"
    Friend Const FromLocationIdColumn = "FromLocationId"
    Friend Const ToLocationIdColumn = "ToLocationId"
    Friend Const DestinationLocationIdColumn = "DestinationLocationId"
    Friend Sub Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{RouteIdColumn}] INTEGER PRIMARY KEY AUTOINCREMENT,
                [{RouteTypeColumn}] INT NOT NULL,
                [{FromLocationIdColumn}] INT NOT NULL,
                [{ToLocationIdColumn}] INT NOT NULL,
                [{DestinationLocationIdColumn}] INT NOT NULL,
                UNIQUE([{FromLocationIdColumn}],[{DestinationLocationIdColumn}]),
                FOREIGN KEY ([{FromLocationIdColumn}]) REFERENCES [{LocationData.TableName}]([{LocationData.LocationIdColumn}]),
                FOREIGN KEY ([{ToLocationIdColumn}]) REFERENCES [{LocationData.TableName}]([{LocationData.LocationIdColumn}]),
                FOREIGN KEY ([{DestinationLocationIdColumn}]) REFERENCES [{LocationData.TableName}]([{LocationData.LocationIdColumn}])
            );")
    End Sub

    Public Function ReadToLocation(routeId As Long) As Long?
        Return ReadColumnValue(Of Long, Long)(
            AddressOf Initialize,
            TableName,
            ToLocationIdColumn,
            (RouteIdColumn, routeId))
    End Function

    Public Function ReadDestinationLocation(routeId As Long) As Long?
        Return ReadColumnValue(Of Long, Long)(
            AddressOf Initialize,
            TableName,
            DestinationLocationIdColumn,
            (RouteIdColumn, routeId))
    End Function

    Public Function ReadRouteType(routeId As Long) As Long?
        Return ReadColumnValue(Of Long, Long)(
            AddressOf Initialize,
            TableName,
            RouteTypeColumn,
            (RouteIdColumn, routeId))
    End Function

    Public Function ReadForFromLocation(fromLocationId As Long) As IEnumerable(Of Long)
        Return ReadRecordsWithColumnValue(Of Long, Long)(
            AddressOf Initialize,
            TableName,
            RouteIdColumn,
            (FromLocationIdColumn, fromLocationId))
    End Function

    Public Function Create(routeType As Long, fromLocationId As Long, toLocationId As Long, destinationLocationId As Long) As Long
        Return CreateRecord(
            AddressOf Initialize,
            TableName,
            (RouteTypeColumn, routeType),
            (FromLocationIdColumn, fromLocationId),
            (ToLocationIdColumn, toLocationId),
            (DestinationLocationIdColumn, destinationLocationId))
    End Function
End Module
