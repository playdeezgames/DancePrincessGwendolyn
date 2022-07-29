Imports System.Runtime.CompilerServices

Public Enum EquipSlot
    None
    Feet
    Hands
    Head
    Outfit
End Enum
Public Module EquipSlotExtensions
    <Extension>
    Function Name(equipSlot As EquipSlot) As String
        Return EquipSlotDescriptors(equipSlot).Name
    End Function
End Module
