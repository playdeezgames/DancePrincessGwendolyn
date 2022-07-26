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

    Friend Sub Refresh()
        LocationType.OnRefresh(Me)
    End Sub

    Public ReadOnly Property Routes As IEnumerable(Of Route)
        Get
            Return RouteData.ReadForFromLocation(Id).Select(AddressOf Route.FromId)
        End Get
    End Property

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

    Friend ReadOnly Property HasLifeCoach As Boolean
        Get
            Return LocationType.HasLifeCoach
        End Get
    End Property

    Public ReadOnly Property Name As String
        Get
            Select Case LocationType
                Case LocationType.Town
                    Return $"{LocationType.Name} of {DanceStyle.Value.Name}"
                Case Else
                    Return LocationType.Name
            End Select
        End Get
    End Property
    Public ReadOnly Property Characters As IEnumerable(Of Character)
        Get
            Return CharacterData.ForLocation(Id).Select(Function(x) Character.FromId(x))
        End Get
    End Property
    Public ReadOnly Property NonPlayerCharacters As IEnumerable(Of Character)
        Get
            Dim playerCharacterId = World.PlayerCharacter.Id
            Return Characters.Where(Function(x) x.Id <> playerCharacterId)
        End Get
    End Property
End Class
