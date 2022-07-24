Public Module World
    Public Sub Start()
        Store.Reset()
        Dim townLocations As List(Of Location) = CreateTownLocations()
        Dim capitolLocation As Location = CreateCapitol()

        For index = 0 To townLocations.Count - 1
            MakeRoad(townLocations(index), townLocations((index + 1) Mod townLocations.Count), 11, RouteType.GravelRoad)
            MakeRoad(townLocations(index), capitolLocation, 11, RouteType.BrickRoad)
            MakeRoad(townLocations(index), townLocations((index + 2) Mod townLocations.Count), 19, RouteType.DirtPath)
        Next

        MakePlayerCharacter(townLocations(0))
    End Sub

    Private Sub MakePlayerCharacter(location As Location)
        Dim playerCharacter = Character.Create(CharacterType.Gwendolyn, location)
        PlayerData.Write(playerCharacter.Id)
    End Sub

    Private Sub MakeRoad(fromLocation As Location, toLocation As Location, locationCount As Integer, routeType As RouteType)
        Dim roadLocations As New List(Of Location)
        While roadLocations.Count < locationCount
            roadLocations.Add(Location.Create(LocationType.Road))
        End While
        Route.Create(routeType, fromLocation, roadLocations(0), toLocation)
        Route.Create(routeType, roadLocations(0), fromLocation, fromLocation)
        Route.Create(routeType, roadLocations(locationCount - 1), toLocation, toLocation)
        Route.Create(routeType, toLocation, roadLocations(locationCount - 1), fromLocation)
        For index = 0 To locationCount - 2
            Route.Create(routeType, roadLocations(index), roadLocations(index + 1), toLocation)
            Route.Create(routeType, roadLocations(index + 1), roadLocations(index), fromLocation)
        Next
    End Sub

    Private Function CreateCapitol() As Location
        Return Location.Create(LocationType.Capitol)
    End Function

    Private Function CreateTownLocations() As List(Of Location)
        Dim danceStyles As New HashSet(Of DanceStyle)(AllDanceStyles)
        Dim result As New List(Of Location)
        While danceStyles.Any
            Dim townLocation = Location.Create(LocationType.Town)
            Dim style = RNG.FromEnumerable(danceStyles)
            danceStyles.Remove(style)
            townLocation.DanceStyle = style
            result.Add(townLocation)
        End While
        Return result
    End Function

    Public ReadOnly Property PlayerCharacter As Character
        Get
            Return Character.FromId(PlayerData.Read())
        End Get
    End Property
End Module
