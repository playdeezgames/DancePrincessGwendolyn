Public Class Location
    Public ReadOnly Id As Long
    Public Sub New(locationId As Long)
        Id = locationId
    End Sub
    Public Shared Function FromId(locationId As Long) As Location
        Return New Location(locationId)
    End Function
    Public Shared Function Create(locationType As LocationType) As Location
        Return FromId(LocationData.Create(locationType))
    End Function
End Class
