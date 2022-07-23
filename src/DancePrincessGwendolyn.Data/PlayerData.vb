Public Module PlayerData
    Friend Const TableName = "Players"
    Friend Const PlayerIdColumn = "PlayerId"
    Friend Const CharacterIdColumn = CharacterData.CharacterIdColumn
    Friend Sub Initialize()
        CharacterData.Initialize()
        ExecuteNonQuery(
            $"CREATE TABLE IF NOT EXISTS [{TableName}]
            (
                [{PlayerIdColumn}] INT NOT NULL UNIQUE CHECK([{PlayerIdColumn}]=1),
                [{CharacterIdColumn}] INT NOT NULL,
                FOREIGN KEY ([{CharacterIdColumn}]) REFERENCES [{CharacterData.TableName}]([{CharacterData.CharacterIdColumn}])
            );")
    End Sub
    Public Sub Write(characterId As Long)
        ReplaceRecord(Of Long, Long)(
            AddressOf Initialize,
            TableName,
            (PlayerIdColumn, 1),
            (CharacterIdColumn, characterId))
    End Sub

    Public Function Read() As Long?
        Return ReadColumnValue(Of Long, Long)(
            AddressOf Initialize,
            TableName,
            CharacterIdColumn,
            (PlayerIdColumn, 1))
    End Function
End Module
