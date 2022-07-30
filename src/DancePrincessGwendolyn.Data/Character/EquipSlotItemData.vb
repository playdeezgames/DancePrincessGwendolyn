Public Module EquipSlotItemData
    Friend Const TableName = "EquipSlotItems"
    Friend Const CharacterIdColumn = CharacterData.CharacterIdColumn
    Friend Const EquipSlotColumn = "EquipSlot"
    Friend Const ItemIdColumn = ItemData.ItemIdColumn
    Friend Sub Initialize()
        CharacterData.Initialize()
        ItemData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{CharacterIdColumn}] INT NOT NULL,
                [{EquipSlotColumn}] INT NOT NULL,
                [{ItemIdColumn}] INT NOT NULL UNIQUE,
                UNIQUE([{CharacterIdColumn}],[{EquipSlotColumn}]),
                FOREIGN KEY ([{CharacterIdColumn}]) REFERENCES [{CharacterData.TableName}]([{CharacterData.CharacterIdColumn}]),
                FOREIGN KEY ([{ItemIdColumn}]) REFERENCES [{ItemData.TableName}]([{ItemData.ItemIdColumn}])
            );")
    End Sub
    Public Sub Write(characterId As Long, equipSlot As Long, itemId As Long)
        ReplaceRecord(
            AddressOf Initialize,
            TableName,
            (CharacterIdColumn, characterId),
            (EquipSlotColumn, equipSlot),
            (ItemIdColumn, itemId))
    End Sub

    Public Sub ClearForItem(itemId As Long)
        ClearForColumnValue(
            AddressOf Initialize,
            TableName,
            (ItemIdColumn, itemId))
    End Sub

    Public Function ReadForCharacter(characterId As Long) As IEnumerable(Of Tuple(Of Long, Long))
        Return ReadRecordsWithColumnValue(Of Long, Long, Long)(
            AddressOf Initialize,
            TableName,
            (EquipSlotColumn, ItemIdColumn),
            (CharacterIdColumn, characterId))
    End Function
End Module
