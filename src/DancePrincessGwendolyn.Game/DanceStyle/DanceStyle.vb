﻿Imports System.Runtime.CompilerServices

Public Enum DanceStyle
    None
    Ballet
    Bollywood
    Cheerleading
    HipHop
    LineDancing
    TapDancing
End Enum
Public Module DanceStyleExtensions
    <Extension>
    Function Name(danceStyle As DanceStyle) As String

    End Function
End Module