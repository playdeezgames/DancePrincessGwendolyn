Public Module LocationDanceStyleData
    Friend Const TableName = "LocationDanceStyles"
    Friend Const LocationIdColumn = LocationData.LocationIdColumn
    Friend Const DanceStyleColumn = "DanceStyle"
    Friend Sub Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{LocationIdColumn}] INT NOT NULL UNIQUE,
                [{DanceStyleColumn}] INT NOT NULL,
                FOREIGN KEY ([{LocationIdColumn}]) REFERENCES [{LocationData.TableName}]([{LocationData.LocationIdColumn}])
            );")
    End Sub
    Public Function Read(locationId As Long) As Long?
        Return ReadColumnValue(Of Long, Long)(
            AddressOf Initialize,
            TableName,
            DanceStyleColumn,
            (LocationIdColumn, locationId))
    End Function

    Public Sub Write(locationId As Long, danceStyle As Long)
        ReplaceRecord(
            AddressOf Initialize,
            TableName,
            (LocationIdColumn, locationId),
            (DanceStyleColumn, danceStyle))
    End Sub

    Public Sub Clear(locationId As Long)
        ClearForColumnValue(
            AddressOf Initialize,
            TableName,
            (LocationIdColumn, locationId))
    End Sub
End Module
