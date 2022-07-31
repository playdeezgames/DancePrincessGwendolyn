Module ConfidenceTrainerProcessor
    Friend Sub Run()
        Dim player = World.PlayerCharacter
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"{player.Name} visits the confidence trainer!")
        AnsiConsole.MarkupLine($"{player.Name} has a maximum confidence of {player.MaximumConfidence}!")
        AnsiConsole.MarkupLine($"An additional point of confidence will cost {player.ConfidenceTrainingCost} sparkle!")
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Pay for training?[/]"}
        prompt.AddChoices(NoText, YesText)
        Select Case AnsiConsole.Prompt(prompt)
            Case YesText
                SfxPlayer.Play(Sfx.Recovery)
                player.TrainConfidence()
                AnsiConsole.MarkupLine($"{player.Name} now has a maximum confidence of {player.MaximumConfidence}!")
                OkPrompt()
        End Select
    End Sub
End Module
