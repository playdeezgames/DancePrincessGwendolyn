Friend MustInherit Class ItemTypeDescriptor
    ReadOnly BuffTable As IReadOnlyDictionary(Of CharacterStatisticType, Long)
    Sub New(buffTable As IReadOnlyDictionary(Of CharacterStatisticType, Long))
        Me.BuffTable = buffTable
    End Sub
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
    MustOverride ReadOnly Property EquipSlot As EquipSlot

    Function GetBuff(statisticType As CharacterStatisticType) As Long?
        Dim result As Long? = Nothing
        Dim buff As Long
        If BuffTable.TryGetValue(statisticType, buff) Then
            result = buff
        End If
        Return result
    End Function

    Overridable Function CanWin() As Boolean
        Return False
    End Function
End Class
Public Module ItemTypeDescriptorUtility
    Friend ReadOnly ItemTypeDescriptors As IReadOnlyDictionary(Of ItemType, ItemTypeDescriptor) =
        New Dictionary(Of ItemType, ItemTypeDescriptor) From
        {
            {ItemType.Ballcap, New BallcapDescriptor},
            {ItemType.BalletSlippers, New BalletSlippersDescriptor},
            {ItemType.Baton, New BatonDescriptor},
            {ItemType.Bindi, New BindiDescriptor},
            {ItemType.Bullwhip, New BullwhipDescriptor},
            {ItemType.Cane, New CaneDescriptor},
            {ItemType.CheerleaderOutfit, New CheerleaderOutfitDescriptor},
            {ItemType.Chux, New ChuxDescriptor},
            {ItemType.ClassRing, New ClassRingDescriptor},
            {ItemType.CowboyBoots, New CowboyBootsDescriptor},
            {ItemType.CowboyHat, New CowboyHatDescriptor},
            {ItemType.DiamondTiara, New DiamondTiaraDescriptor},
            {ItemType.DoubleDenim, New DoubleDenimDescriptor},
            {ItemType.GoldTooth, New GoldToothDescriptor},
            {ItemType.Headband, New HeadbandDescriptor},
            {ItemType.HennaTattoos, New HennaTattoosDescriptor},
            {ItemType.Hoodie, New HoodieDescriptor},
            {ItemType.Leotard, New LeotardDescriptor},
            {ItemType.Microphone, New MicrophoneDescriptor},
            {ItemType.NoseRing, New NoseRingDescriptor},
            {ItemType.PearlNecklace, New PearlNecklaceDescriptor},
            {ItemType.PlatinumCuffLinks, New PlatinumCuffLinksDescriptor},
            {ItemType.PomPoms, New PomPomsDescriptor},
            {ItemType.Ribbon, New RibbonDescriptor},
            {ItemType.Sandals, New SandalsDescriptor},
            {ItemType.Sari, New SariDescriptor},
            {ItemType.SilverBeltBuckle, New SilverBeltBuckleDescriptor},
            {ItemType.Snax, New SnaxDescriptor},
            {ItemType.Sneakers, New SneakersDescriptor},
            {ItemType.TapShoes, New TapShoesDescriptor},
            {ItemType.Tophat, New TopHatDescriptor},
            {ItemType.TuxedoDress, New TuxedoDressDescriptor}
        }
    Public ReadOnly Property AllItemTypes As IEnumerable(Of ItemType)
        Get
            Return ItemTypeDescriptors.Keys
        End Get
    End Property
End Module
