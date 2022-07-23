Module InPlayProcessor
    Friend Sub Run()
        Dim character = World.PlayerCharacter
        Dim location As Location = character.Location
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"Location: {location.LocationType.Name}")
    End Sub
End Module
