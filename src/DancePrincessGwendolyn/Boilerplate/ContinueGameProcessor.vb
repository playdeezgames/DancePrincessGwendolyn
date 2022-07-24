Imports SPLORR.Data

Module ContinueGameProcessor
    Friend Sub Run()
        'don't clear
        Dim fileName = AnsiConsole.Ask(Of String)("[olive]Filename:[/]", "")
        If Not String.IsNullOrWhiteSpace(fileName) Then
            Store.Load(fileName)
            If World.PlayerCharacter IsNot Nothing Then
                InPlayProcessor.Run()
            Else
                AnsiConsole.MarkupLine("[red]Bogus save file![/]")
                OkPrompt()
            End If
        End If
    End Sub
End Module
