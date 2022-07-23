Public Class Character
    Public ReadOnly Id As Long
    Public Sub New(characterId As Long)
        Id = characterId
    End Sub

    Public Property Location As Location
        Get
            Return CharacterData.ReadLocation(Id).Value
        End Get
        Set(value As Location)
            CharacterData.WriteLocation(Id, value.Id)
        End Set
    End Property

    Public Shared Function FromId(characterId As Long) As Character
        Return New Character(characterId)
    End Function
    Public Shared Function Create(characterType As CharacterType, location As Location) As Character
        Return FromId(CharacterData.Create(characterType, location.Id))
    End Function
End Class
