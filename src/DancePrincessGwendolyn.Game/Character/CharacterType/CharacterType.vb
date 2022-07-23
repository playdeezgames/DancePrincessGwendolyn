Imports System.Runtime.CompilerServices

Public Enum CharacterType
    None
    Gwendolyn
End Enum
Public Module CharacterTypeExtensions
    <Extension>
    Function Name(characterType As CharacterType) As String
        Return CharacterTypeDescriptors(characterType).Name
    End Function
End Module
