Module ProfileProcessor
    Friend Sub Run()
        AnsiConsole.Clear()
        Dim character = World.PlayerCharacter
        AnsiConsole.MarkupLine($"Name: {character.Name}")
        AnsiConsole.MarkupLine($"{CharacterStatisticType.Confidence}: {character.Confidence}/{character.MaximumConfidence}")
        AnsiConsole.MarkupLine($"{CharacterStatisticType.Enthusiasm}: {character.Enthusiasm}/{character.MaximumEnthusiasm}")
        AnsiConsole.MarkupLine("Dance Skills:")
        For Each entry In character.DanceSkills
            AnsiConsole.MarkupLine($"{entry.Key.Name}: d{entry.Value} ({character.RemainingUses(entry.Key)}/{character.TotalUses(entry.Key)})")
        Next
        OkPrompt()
    End Sub
End Module
