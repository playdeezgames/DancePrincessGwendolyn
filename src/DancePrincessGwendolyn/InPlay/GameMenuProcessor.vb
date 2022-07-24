Module GameMenuProcessor
    Friend Function Run() As Boolean
        'don't clear
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Game Menu:[/]"}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoice(SaveText)
        prompt.AddChoice(AbandonGameText)
        Select Case AnsiConsole.Prompt(prompt)
            Case AbandonGameText
                Return ConfirmProcessor.Run("Are you sure you want to abandon the game?")
            Case SaveText
                SaveProcessor.Run()
        End Select
        Return False
    End Function
End Module
