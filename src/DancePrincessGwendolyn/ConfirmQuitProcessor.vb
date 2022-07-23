Module ConfirmQuitProcessor
    Friend Function Run() As Boolean
        AnsiConsole.WriteLine()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[red]Are you sure you want to quit?[/]"}
        prompt.AddChoices(NoText, YesText)
        Select Case AnsiConsole.Prompt(prompt)
            Case YesText
                Return True
            Case Else
                Return False
        End Select
    End Function
End Module
