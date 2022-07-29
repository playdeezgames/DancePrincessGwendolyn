Friend MustInherit Class EquipSlotDescriptor
    MustOverride ReadOnly Property Name As String
End Class
Public Module EquipSlotDescriptorUtility
    Friend ReadOnly EquipSlotDescriptors As IReadOnlyDictionary(Of EquipSlot, EquipSlotDescriptor) =
        New Dictionary(Of EquipSlot, EquipSlotDescriptor) From
        {
            {EquipSlot.Bling, New BlindDescriptor},
            {EquipSlot.Feet, New FeetDescriptor},
            {EquipSlot.Hands, New HandsDescriptor},
            {EquipSlot.Head, New HeadDescriptor},
            {EquipSlot.Outfit, New OutfitDescriptor}
        }
End Module
