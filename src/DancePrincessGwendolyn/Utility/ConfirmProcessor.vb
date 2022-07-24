Module ConfirmProcessor
    Friend Function Run(text As String) As Boolean
        AnsiConsole.WriteLine()
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[red]{text}[/]"}
        prompt.AddChoices(NoText, YesText)
        Select Case AnsiConsole.Prompt(prompt)
            Case YesText
                Return True
            Case Else
                Return False
        End Select
    End Function
End Module
