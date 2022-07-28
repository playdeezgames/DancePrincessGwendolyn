Module RecoverProcessor
    Friend Sub Run()
        Dim character = World.PlayerCharacter
        Dim result As (Boolean, DanceStyle) = character.Recover()
        AnsiConsole.MarkupLine($"{character.Name} recovers!")
        If result.Item1 Then
            AnsiConsole.MarkupLine($"{character.Name} now has {character.Confidence} confidence!")
        End If
        If result.Item2 <> DanceStyle.None Then
            AnsiConsole.MarkupLine($"{character.Name} recovers some uses of {result.Item2.Name}!")
        End If
        OkPrompt()
    End Sub
End Module
