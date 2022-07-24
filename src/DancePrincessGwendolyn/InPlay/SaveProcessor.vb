Imports SPLORR.Data

Module SaveProcessor
    Friend Sub Run()
        'don't clear
        Dim fileName = AnsiConsole.Ask(Of String)("[olive]Filename:[/]", "")
        If Not String.IsNullOrWhiteSpace(fileName) Then
            Store.Save(fileName)
        End If
    End Sub
End Module
