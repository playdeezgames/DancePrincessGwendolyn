Module DanceOffProcessor
    Friend Sub Run()
        Dim done = False
        While Not done
            Dim player = World.PlayerCharacter
            Dim rival = player.Location.NonPlayerCharacters.First
            AnsiConsole.Clear()
            AnsiConsole.MarkupLine($"{player.Name} is having a DANCE OFF with {rival.Name}!")
            Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now what?[/]"}
            Dim table As New Dictionary(Of String, DanceStyle)
            For Each style In AllDanceStyles
                If player.RemainingUses(style) > 0 Then
                    Dim buff = player.GetStatisticBuff(style.CharacterStatisticType)
                    Dim text = $"Use a {style.Name} move d{player.DanceSkills(style)}{If(buff >= 0, $"+{buff}", $"{buff}")} ({player.RemainingUses(style)} remaining)!"
                    table.Add(text, style)
                    prompt.AddChoice(text)
                End If
            Next
            prompt.AddChoice(GiveUpText)
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case GiveUpText
                    done = True
                Case Else
                    done = DoDanceMoveProcessor.Run(table(answer))
            End Select
        End While
    End Sub
End Module
