Module InPlayProcessor
    Friend Sub Run()
        Dim done = False
        While Not done
            Dim character = World.PlayerCharacter
            Dim location As Location = character.Location
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Location: {location.Name}")
            AnsiConsole.MarkupLine($"TODO: make it possible to do something other than abandon the game!")

            AnsiConsole.MarkupLine("Routes:")
            Dim routes As IEnumerable(Of Route) = location.Routes
            For Each route In routes
                AnsiConsole.MarkupLine(route.Name)
            Next

            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            prompt.AddChoice(MoveText)
            prompt.AddChoice(AbandonGameText)
            Select Case AnsiConsole.Prompt(prompt)
                Case AbandonGameText
                    done = ConfirmProcessor.Run("Are you sure you want to abandon the game?")
                Case MoveText
                    MoveProcessor.Run()
            End Select
        End While
    End Sub
End Module
