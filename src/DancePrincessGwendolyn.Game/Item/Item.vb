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
End Class
