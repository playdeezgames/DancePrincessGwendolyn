Friend MustInherit Class ItemTypeDescriptor
    MustOverride ReadOnly Property Name As String
End Class
Public Module ItemTypeDescriptorUtility
    Friend ReadOnly ItemTypeDescriptors As IReadOnlyDictionary(Of ItemType, ItemTypeDescriptor) =
        New Dictionary(Of ItemType, ItemTypeDescriptor) From
        {
            {ItemType.Snax, New SnaxDescriptor}
        }
End Module
