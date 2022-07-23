Public Class Location
    Public ReadOnly Id As Long
    Public Sub New(locationId As Long)
        Id = locationId
    End Sub
    Public ReadOnly Property LocationType As LocationType
        Get
            Return CType(LocationData.ReadLocationType(Id).Value, LocationType)
        End Get
    End Property
    Public Shared Function FromId(locationId As Long?) As Location
        If Not locationId.HasValue Then
            Return Nothing
        End If
        Return New Location(locationId.Value)
    End Function
    Public Shared Function Create(locationType As LocationType) As Location
        Return FromId(LocationData.Create(locationType))
    End Function

    Property DanceStyle As DanceStyle?
        Get
            Dim style As Long? = LocationDanceStyleData.Read(Id)
            Return If(style.HasValue, CType(style.Value, DanceStyle), Nothing)
        End Get
        Set(value As DanceStyle?)
            If value.HasValue Then
                LocationDanceStyleData.Write(Id, value.Value)
                Return
            End If
            LocationDanceStyleData.Clear(Id)
        End Set
    End Property
End Class
