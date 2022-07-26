Module InPlayProcessor
    Friend Sub Run()
        Dim done = False
        While Not done
            Dim character = World.PlayerCharacter
            Dim location As Location = character.Location
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"Location: {location.Name}")

            For Each npc In location.NonPlayerCharacters
                AnsiConsole.MarkupLine($"There is {npc.Name} here.")
            Next

            AnsiConsole.MarkupLine("Routes:")
            Dim routes As IEnumerable(Of Route) = location.Routes
            For Each route In routes
                AnsiConsole.MarkupLine(route.Name)
            Next

            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now What?[/]"}
            If character.CanDoDanceOff Then
                prompt.AddChoice(DanceOffText)
            End If
            If character.Confidence > 0 Then
                prompt.AddChoice(MoveText)
            End If
            prompt.AddChoice(ProfileText)
            prompt.AddChoice(GameMenuText)
            Select Case AnsiConsole.Prompt(prompt)
                Case GameMenuText
                    done = GameMenuProcessor.Run()
                Case MoveText
                    MoveProcessor.Run()
                Case ProfileText
                    ProfileProcessor.Run()
                Case DanceOffText
                    DanceOffProcessor.Run()
            End Select
        End While
    End Sub
End Module
