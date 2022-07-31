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
            Return Not Items.Any
        End Get
    End Property

    Public ReadOnly Property Items As IEnumerable(Of Item)
        Get
            Return InventoryItemData.Read(Id).Select(Function(x) Item.FromId(x))
        End Get
    End Property

    Public Sub Add(item As Item)
        InventoryItemData.Write(Id, item.Id)
    End Sub

    Public ReadOnly Property ItemStacks As IReadOnlyDictionary(Of ItemType, IEnumerable(Of Item))
        Get
            Return Items.
                GroupBy(Function(x) x.ItemType).
                ToDictionary(Of ItemType, IEnumerable(Of Item))(Function(x) x.Key, Function(x) x)
        End Get
    End Property

    Public Function GetItemOfType(itemType As ItemType) As Item
        Dim stacks = ItemStacks
        Return If(stacks.ContainsKey(itemType), stacks(itemType).First, Nothing)
    End Function
End Class
