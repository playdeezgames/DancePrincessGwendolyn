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
    <Extension>
    Sub OnRefresh(locationType As LocationType, location As Location)
        LocationTypeDescriptors(locationType).OnRefresh(location)
    End Sub
End Module
