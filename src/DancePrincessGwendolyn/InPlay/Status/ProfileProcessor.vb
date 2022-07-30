Module ProfileProcessor
    Friend Sub Run()
        AnsiConsole.Clear()
        Dim character = World.PlayerCharacter
        AnsiConsole.MarkupLine($"Name: {character.Name}")
        AnsiConsole.WriteLine()
        AnsiConsole.MarkupLine($"{CharacterStatisticType.Confidence.Name}: {character.Confidence}/{character.MaximumConfidence}")
        AnsiConsole.MarkupLine($"{CharacterStatisticType.Enthusiasm.Name}: {character.Enthusiasm}/{character.MaximumEnthusiasm}")
        AnsiConsole.WriteLine()
        AnsiConsole.MarkupLine("Dance Skills:")
        For Each entry In character.DanceSkills
            Dim buff = character.GetStatisticBuff(entry.Key.CharacterStatisticType)
            AnsiConsole.MarkupLine($"{entry.Key.Name}: d{entry.Value}{If(buff > 0, $"+{buff}", $"{buff}")} ({character.RemainingUses(entry.Key)}/{character.TotalUses(entry.Key)})")
        Next
        AnsiConsole.WriteLine()
        AnsiConsole.MarkupLine($"{CharacterStatisticType.Bux.Name}: {character.Bux}")
        AnsiConsole.MarkupLine($"{CharacterStatisticType.Sparkle.Name}: {character.Sparkle}")
        OkPrompt()
    End Sub
End Module
