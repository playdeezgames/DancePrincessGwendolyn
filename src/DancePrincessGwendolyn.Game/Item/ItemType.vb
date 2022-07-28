Imports System.Runtime.CompilerServices

Public Enum ItemType
    None
    Snax
End Enum
Public Module ItemTypeExtensions
    <Extension>
    Function Name(itemType As ItemType) As String
        Return ItemTypeDescriptors(itemType).Name
    End Function
End Module
