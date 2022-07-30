Public Class Item
    Public ReadOnly Property Id As Long
    Public Sub New(itemId As Long)
        Id = itemId
    End Sub
    Friend Shared Function FromId(itemId As Long?) As Item
        Return If(itemId.HasValue, New Item(itemId.Value), Nothing)
    End Function

    Friend Shared Function Create(itemType As ItemType) As Item
        Return FromId(ItemData.Create(itemType))
    End Function

    Public ReadOnly Property ItemType As ItemType
        Get
            Return CType(ItemData.ReadItemType(Id).Value, ItemType)
        End Get
    End Property
    Public ReadOnly Property Name As String
        Get
            Return ItemType.Name
        End Get
    End Property

    Friend ReadOnly Property CanUse As Boolean
        Get
            Return ItemType.CanUse
        End Get
    End Property

    Friend Function Use(character As Character) As String
        Dim message = ItemType.Use(character)
        Destroy()
        Return message
    End Function

    Private Sub Destroy()
        ItemData.Clear(Id)
    End Sub

    Friend Function CanEquip() As Boolean
        Return ItemType.CanEquip
    End Function

    Friend ReadOnly Property EquipSlot As EquipSlot
        Get
            Return ItemType.EquipSlot
        End Get
    End Property
End Class
