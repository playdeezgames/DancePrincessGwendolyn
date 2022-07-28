Public Module InventoryData
    Friend Const TableName = "Inventories"
    Friend Const InventoryIdColumn = "InventoryId"
    Friend Const CharacterIdColumn = CharacterData.CharacterIdColumn
    Friend Const LocationIdColumn = LocationData.LocationIdColumn
    Friend Sub Initialize()
        CharacterData.Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{InventoryIdColumn}] INTEGER PRIMARY KEY AUTOINCREMENT,
                [{CharacterIdColumn}] INT NULL UNIQUE,
                [{LocationIdColumn}] INT NULL UNIQUE,
                CHECK(([{CharacterIdColumn}] IS NOT NULL AND [{LocationIdColumn}] IS NULL) OR ([{CharacterIdColumn}] IS NULL AND [{LocationIdColumn}] IS NOT NULL)),
                FOREIGN KEY([{CharacterIdColumn}]) REFERENCES [{CharacterData.TableName}]([{CharacterData.CharacterIdColumn}]),
                FOREIGN KEY([{LocationIdColumn}]) REFERENCES [{LocationData.TableName}]([{LocationData.LocationIdColumn}])
            );")
    End Sub
    Public Function ReadForCharacter(characterId As Long) As Long?
        Return ReadColumnValue(Of Long, Long)(
            AddressOf Initialize,
            TableName,
            InventoryIdColumn,
            (CharacterIdColumn, characterId))
    End Function
    Public Function CreateForCharacter(characterId As Long) As Long
        Return CreateRecord(
            AddressOf Initialize,
            TableName,
            (CharacterIdColumn, characterId))
    End Function
    Public Function ReadForLocation(locationId As Long) As Long?
        Return ReadColumnValue(Of Long, Long)(
            AddressOf Initialize,
            TableName,
            InventoryIdColumn,
            (LocationIdColumn, locationId))
    End Function
    Public Function CreateForLocation(locationId As Long) As Long
        Return CreateRecord(
            AddressOf Initialize,
            TableName,
            (LocationIdColumn, locationId))
    End Function
End Module
