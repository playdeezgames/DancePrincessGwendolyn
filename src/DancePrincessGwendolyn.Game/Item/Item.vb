Public Class Item
    Public ReadOnly Property Id As Long
    Public Sub New(itemId As Long)
        Id = itemId
    End Sub
    Friend Shared Function FromId(itemId As Long?) As Item
        Return If(itemId.HasValue, New Item(itemId.Value), Nothing)
    End Function
End Class
