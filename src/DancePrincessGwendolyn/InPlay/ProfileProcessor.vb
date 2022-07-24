Module ProfileProcessor
    Friend Sub Run()
        AnsiConsole.Clear()
        Dim character = World.PlayerCharacter
        AnsiConsole.MarkupLine($"Name: {character.Name}")
        OkPrompt()
    End Sub
End Module
