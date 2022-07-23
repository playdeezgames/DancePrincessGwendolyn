Public Module World
    Public Sub Start()
        Store.Reset()
        Dim townLocations As List(Of Location) = CreateTownLocations()
        Dim capitolLocation As Location = CreateCapitol()

        'Make The Roads
    End Sub

    Private Function CreateCapitol() As Location
        Return Location.Create(LocationType.CapitolEntrance)
    End Function

    Private Function CreateTownLocations() As List(Of Location)
        Dim danceStyles As New HashSet(Of DanceStyle)(AllDanceStyles)
        Dim result As New List(Of Location)
        While danceStyles.Any
            Dim townLocation = Location.Create(LocationType.TownEntrance)
            Dim style = RNG.FromEnumerable(danceStyles)
            danceStyles.Remove(style)
            townLocation.DanceStyle = style
            result.Add(townLocation)
        End While
        Return result
    End Function
End Module
