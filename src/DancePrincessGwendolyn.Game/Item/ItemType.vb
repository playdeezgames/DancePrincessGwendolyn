Imports System.Runtime.CompilerServices

Public Enum ItemType
    None
    Snax
    BalletSlippers
    Sandals
    Sneakers
    Chux
    CowboyBoots
    TapShoes
    Leotard
    Sari
    CheerleaderOutfit
    Hoodie
    DoubleDenim
    TuxedoDress
    Ribbon
    Bindi
    Headband
    Ballcap
    CowboyHat
    Tophat
    Baton
    HennaTattoos
    PomPoms
    Microphone
    Bullwhip
    Cane
    PearlNecklace
    NoseRing
    ClassRing
    GoldTooth
    SilverBeltBuckle
    PlatinumCuffLinks
    DiamondTiara
End Enum
Public Module ItemTypeExtensions
    <Extension>
    Function Name(itemType As ItemType) As String
        Return ItemTypeDescriptors(itemType).Name
    End Function
    <Extension>
    Function Price(itemType As ItemType) As Long
        Return ItemTypeDescriptors(itemType).Price
    End Function
    <Extension>
    Function CanUse(itemtype As ItemType) As Boolean
        Return ItemTypeDescriptors(itemtype).CanUse
    End Function
    <Extension>
    Function Use(itemType As ItemType, character As Character) As String
        Return ItemTypeDescriptors(itemType).Use(character)
    End Function
    <Extension>
    Function CanEquip(itemType As ItemType) As Boolean
        Return ItemTypeDescriptors(itemType).EquipSlot <> Game.EquipSlot.None
    End Function
    <Extension>
    Function CanWin(itemType As ItemType) As Boolean
        Return ItemTypeDescriptors(itemType).CanWin
    End Function
    <Extension>
    Function EquipSlot(itemType As ItemType) As EquipSlot
        Return ItemTypeDescriptors(itemType).EquipSlot
    End Function
    <Extension>
    Function GetBuff(itemType As ItemType, statisticType As CharacterStatisticType) As Long?
        Return ItemTypeDescriptors(itemType).GetBuff(statisticType)
    End Function
End Module
