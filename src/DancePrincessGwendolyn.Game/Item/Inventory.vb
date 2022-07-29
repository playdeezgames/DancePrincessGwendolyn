Public Class Inventory
    Public ReadOnly Id As Long
    Public Sub New(inventoryId As Long)
        Id = inventoryId
    End Sub
    Public Shared Function FromId(inventoryId As Long?) As Inventory
        Return If(inventoryId.HasValue, New Inventory(inventoryId.Value), Nothing)
    End Function
    Friend ReadOnly Property IsEmpty As Boolean
        Get
            Return True
        End Get
    End Property
    Public ReadOnly Property Items As IEnumerable(Of Item)
        Get
            Return InventoryItemData.Read(Id).Select(Function(x) Item.FromId(x))
        End Get
    End Property

    Friend Sub Add(item As Item)
        InventoryItemData.Write(Id, item.Id)
    End Sub
End Class
