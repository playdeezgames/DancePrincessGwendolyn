Module MainMenuProcessor

    Friend Sub Run()
        Dim done = False
        While Not done
            Dim prompt = New SelectionPrompt(Of String) With {.Title = "[olive]Main Menu:[/]"}
            prompt.AddChoices(QuitText)

            Select Case AnsiConsole.Prompt(prompt)
                Case QuitText
                    done = ConfirmQuitProcessor.Run()
            End Select
        End While
    End Sub
End Module
