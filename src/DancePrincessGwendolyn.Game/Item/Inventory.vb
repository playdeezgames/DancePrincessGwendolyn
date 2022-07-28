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
End Class
