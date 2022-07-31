Module EnthusiasmTrainerProcessor
    Friend Sub Run()
        Dim player = World.PlayerCharacter
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"{player.Name} visits the enthusiasm trainer!")
        AnsiConsole.MarkupLine($"{player.Name} has a maximum enthusiasm of {player.MaximumEnthusiasm}!")
        AnsiConsole.MarkupLine($"An additional point of confidence will cost {player.EnthusiasmTrainingCost} sparkle!")
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Pay for training?[/]"}
        prompt.AddChoices(NoText, YesText)
        Select Case AnsiConsole.Prompt(prompt)
            Case YesText
                SfxPlayer.Play(Sfx.Recovery)
                player.TrainEnthusiasm()
                AnsiConsole.MarkupLine($"{player.Name} now has a maximum enthusiasm of {player.MaximumEnthusiasm}!")
                OkPrompt()
        End Select
    End Sub
End Module
