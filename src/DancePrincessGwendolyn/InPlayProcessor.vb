Module InPlayProcessor
    Friend Sub Run()
        Dim character = World.PlayerCharacter
        Dim location As Location = character.Location
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"Location: {location.LocationType.Name}")

        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
        prompt.AddChoice(AbandonGameText)
        Select Case AnsiConsole.Prompt(prompt)
            Case AbandonGameText
                Return
        End Select
    End Sub
End Module
