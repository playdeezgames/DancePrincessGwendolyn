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
End Module
