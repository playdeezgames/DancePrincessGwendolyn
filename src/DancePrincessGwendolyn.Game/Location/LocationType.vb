Imports System.Runtime.CompilerServices

Public Enum LocationType
    None
    BrickRoad
    Capitol
    DirtPath
    GravelRoad
    Town
End Enum
Public Module LocationTypeExtensions
    <Extension>
    Function Name(locationType As LocationType) As String
        Return LocationTypeDescriptors(locationType).Name
    End Function
End Module
