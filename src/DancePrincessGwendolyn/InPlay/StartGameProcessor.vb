Friend Module StartGameProcessor
    Friend Sub Run()
        World.Start()
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine("It is a world that knows nothing of violence!")
        AnsiConsole.MarkupLine("All disputes are solved with DANCE!")
        AnsiConsole.MarkupLine("But true power lies within the heart of the best dancer in the land!")
        AnsiConsole.MarkupLine("She is called THE DANCE QUEEN!")
        AnsiConsole.MarkupLine("It is not by heredity that the title of Queen is determined, but instead by courage and enthusiasm!")
        AnsiConsole.MarkupLine("You are Gwendolyn, and you have declared yourself a Dance Princess - a claimant to the Dance Throne!")
        AnsiConsole.MarkupLine("You will not stop until YOU are the new Dance Queen!")
        AnsiConsole.MarkupLine("But your journey will not be easy! Others also seek to become the new Queen! They are your rivals!")
        AnsiConsole.MarkupLine("Outdance them! Become the Dance Queen! Make your mark on history!")

        OkPrompt()
        InPlayProcessor.Run()
    End Sub
End Module
