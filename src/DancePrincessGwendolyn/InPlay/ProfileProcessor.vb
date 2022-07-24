Module ProfileProcessor
    Friend Sub Run()
        AnsiConsole.Clear()
        Dim character = World.PlayerCharacter
        AnsiConsole.MarkupLine($"Name: {character.Name}")
        AnsiConsole.MarkupLine($"{CharacterStatisticType.Confidence}: {character.Confidence}/{character.MaximumConfidence}")
        AnsiConsole.MarkupLine($"{CharacterStatisticType.Enthusiasm}: {character.Enthusiasm}/{character.MaximumEnthusiasm}")
        OkPrompt()
    End Sub
End Module
