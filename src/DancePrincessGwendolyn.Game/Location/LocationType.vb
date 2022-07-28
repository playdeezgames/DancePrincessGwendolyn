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
    <Extension>
    Function HasLifeCoach(locationType As LocationType) As Boolean
        Return LocationTypeDescriptors(locationType).HasLifeCoach
    End Function
    <Extension>
    Function HasShoppe(locationType As LocationType) As Boolean
        Return LocationTypeDescriptors(locationType).HasShoppe
    End Function
    <Extension>
    Function CanBuyIceCream(locationType As LocationType) As Boolean
        Return LocationTypeDescriptors(locationType).CanBuyIceCream
    End Function
    <Extension>
    Function ShoppeItems(locationType As LocationType, location As Location) As IEnumerable(Of ItemType)
        Return LocationTypeDescriptors(locationType).ShoppeItems(location)
    End Function
End Module
