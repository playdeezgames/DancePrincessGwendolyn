Imports System.Runtime.CompilerServices

Public Enum CharacterType
    None
    Gwendolyn
    BalletN00b
    BollywoodN00b
    CheerleadingN00b
    HipHopN00b
    LineDancingN00b
    TapDancingN00b
End Enum
Public Module CharacterTypeExtensions
    <Extension>
    Function Name(characterType As CharacterType) As String
        Return CharacterTypeDescriptors(characterType).Name
    End Function
    <Extension>
    Sub OnCreate(characterType As CharacterType, character As Character)
        CharacterTypeDescriptors(characterType).OnCreate(character)
    End Sub
    <Extension>
    Function RollDefeatBux(characterType As CharacterType, character As Character) As Long
        Return CharacterTypeDescriptors(characterType).RollDefeatBux(character)
    End Function
End Module
