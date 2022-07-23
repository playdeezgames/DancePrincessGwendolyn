Friend Module StartGameProcessor
    Friend Sub Run()
        World.Start()
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine("TODO: write a prolog and put it here!")

        OkPrompt()
        InPlayProcessor.Run()
    End Sub
End Module
