Module MainMenuProcessor

    Friend Sub Run()
        Dim done = False
        While Not done
            Dim prompt = New SelectionPrompt(Of String) With {.Title = "[olive]Main Menu:[/]"}
            prompt.AddChoice(StartText)
            prompt.AddChoices(QuitText)

            Select Case AnsiConsole.Prompt(prompt)
                Case QuitText
                    done = ConfirmQuitProcessor.Run()
                Case StartText
                    StartGameProcessor.Run()
            End Select
        End While
    End Sub
End Module
