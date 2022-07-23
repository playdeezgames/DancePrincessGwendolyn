Module InPlayProcessor
    Friend Sub Run()
        Dim done = False
        While Not done
            Dim character = World.PlayerCharacter
            Dim location As Location = character.Location
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Location: {location.LocationType.Name}")
            AnsiConsole.MarkupLine($"TODO: make it possible to do something other than abandon the game!")

            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            prompt.AddChoice(AbandonGameText)
            Select Case AnsiConsole.Prompt(prompt)
                Case AbandonGameText
                    done = ConfirmProcessor.Run("Are you sure you want to abandon the game?")
            End Select
        End While
    End Sub
End Module
