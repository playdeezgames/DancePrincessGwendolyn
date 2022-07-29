Friend MustInherit Class ItemTypeDescriptor
    MustOverride ReadOnly Property Name As String
    MustOverride ReadOnly Property Price As Long
    Overridable ReadOnly Property CanUse As Boolean
        Get
            Return False
        End Get
    End Property

    Overridable Function Use(character As Character) As String
        Return $"{character.Name} cannot use {Name} right now."
    End Function
End Class
Public Module ItemTypeDescriptorUtility
    Friend ReadOnly ItemTypeDescriptors As IReadOnlyDictionary(Of ItemType, ItemTypeDescriptor) =
        New Dictionary(Of ItemType, ItemTypeDescriptor) From
        {
            {ItemType.BalletSlippers, New BalletSlippersDescriptor},
            {ItemType.Chux, New ChuxDescriptor},
            {ItemType.CowboyBoots, New CowboyBootsDescriptor},
            {ItemType.Sandals, New SandalsDescriptor},
            {ItemType.Snax, New SnaxDescriptor},
            {ItemType.Sneakers, New SneakersDescriptor},
            {ItemType.TapShoes, New TapShoesDescriptor}
        }
    Public ReadOnly Property AllItemTypes As IEnumerable(Of ItemType)
        Get
            Return ItemTypeDescriptors.Keys
        End Get
    End Property
End Module
