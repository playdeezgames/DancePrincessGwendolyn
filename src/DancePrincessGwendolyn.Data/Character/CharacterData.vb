﻿Public Module CharacterData
    Friend Const TableName = "Characters"
    Friend Const CharacterIdColumn = "CharacterId"
    Friend Const CharacterTypeColumn = "CharacterType"
    Friend Const LocationIdColumn = LocationData.LocationIdColumn

    Public Function ReadLocation(characterId As Long) As Long?
        Return ReadColumnValue(Of Long, Long)(
            AddressOf Initialize,
            TableName,
            LocationIdColumn,
            (CharacterIdColumn, characterId))
    End Function

    Public Sub WriteLocation(characterId As Long, locationId As Long)
        WriteColumnValue(
            AddressOf Initialize,
            TableName,
            (LocationIdColumn, locationId),
            (CharacterIdColumn, characterId))
    End Sub

    Friend Sub Initialize()
        LocationData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{CharacterIdColumn}] INTEGER PRIMARY KEY AUTOINCREMENT,
                [{CharacterTypeColumn}] INT NOT NULL,
                [{LocationIdColumn}] INT NOT NULL,
                FOREIGN KEY ([{LocationIdColumn}]) REFERENCES [{LocationData.TableName}]([{LocationData.LocationIdColumn}])
            );")
    End Sub

    Public Function ReadCharacterType(characterId As Long) As Long?
        Return ReadColumnValue(Of Long, Long)(
            AddressOf Initialize,
            TableName,
            CharacterTypeColumn,
            (CharacterIdColumn, characterId))
    End Function

    Public Function Create(characterType As Long, locationId As Long) As Long
        Return CreateRecord(
            AddressOf Initialize,
            TableName,
            (CharacterTypeColumn, characterType),
            (LocationIdColumn, locationId))
    End Function

    Public Sub Clear(characterId As Long)
        InventoryData.ClearForCharacter(characterId)
        EquipSlotItemData.ClearForCharacter(characterId)
        CharacterStatisticData.ClearForCharacter(characterId)
        ClearForColumnValue(
            AddressOf Initialize,
            TableName,
            (CharacterIdColumn, characterId))
    End Sub

    Public Function ForLocation(locationId As Long) As IEnumerable(Of Long)
        Return ReadRecordsWithColumnValue(Of Long, Long)(
            AddressOf Initialize,
            TableName,
            CharacterIdColumn,
            (LocationIdColumn, locationId))
    End Function
End Module
