Module MainMenuProcessor

    Friend Sub Run()
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim prompt = New SelectionPrompt(Of String) With {.Title = "[olive]Main Menu:[/]"}
            prompt.AddChoice(StartText)
            prompt.AddChoices(ContinueText)
            prompt.AddChoices(QuitText)

            Select Case AnsiConsole.Prompt(prompt)
                Case ContinueText
                    ContinueGameProcessor.Run()
                Case QuitText
                    done = ConfirmProcessor.Run("Are you sure you want to quit?")
                Case StartText
                    StartGameProcessor.Run()
            End Select
        End While
    End Sub
End Module
