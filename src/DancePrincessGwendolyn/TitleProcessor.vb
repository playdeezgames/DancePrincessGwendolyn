Module TitleProcessor
    Sub Run()
        AnsiConsole.Clear()
        Dim figlet = New FigletText("Dance Princess Gwendolyn") With {
            .Alignment = Justify.Center,
            .Color = Color.Pink1
        }
        AnsiConsole.Write(figlet)

        AnsiConsole.MarkupLine("[green]A Game in VB.NET About Solving Disputes with Dance Instead of Violence[/]")
        AnsiConsole.MarkupLine("A Production of [magenta]TheGrumpyGameDev[/] for [aqua]The Pacifist Jam (Honest Jam IV)[/]")

        OkPrompt()
    End Sub

End Module
