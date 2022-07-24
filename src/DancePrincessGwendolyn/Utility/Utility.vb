Module Utility
    Sub OkPrompt()
        Dim prompt = New SelectionPrompt(Of String) With {.Title = ""}
        prompt.AddChoices("Ok")
        AnsiConsole.Prompt(prompt)
    End Sub
End Module
