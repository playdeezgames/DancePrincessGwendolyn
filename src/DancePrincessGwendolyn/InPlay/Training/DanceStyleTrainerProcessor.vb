Module DanceStyleTrainerProcessor
    Friend Sub Run(danceStyle As DanceStyle)
        Dim player = World.PlayerCharacter
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"{player.Name} visits the {danceStyle.Name} Trainer!")
        AnsiConsole.MarkupLine($"{player.Name} has a skill of {player.DanceSkills(danceStyle)}!")
        AnsiConsole.MarkupLine($"{player.Name} has a maximum uses of {player.TotalUses(danceStyle)}!")

        AnsiConsole.MarkupLine($"An additional point of skill or another use will cost {player.DanceStyleTrainingCost(danceStyle)} sparkle!")
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Now what?[/]"}
        prompt.AddChoices(NeverMindText, IncreaseSkillText, AddUseText)
        Select Case AnsiConsole.Prompt(prompt)
            Case IncreaseSkillText
                player.TrainDanceStyleSkill(danceStyle)
                AnsiConsole.MarkupLine($"{player.Name} now has a skill of {player.DanceSkills(danceStyle)}!")
                OkPrompt()
            Case AddUseText
                player.TrainDanceStyleUse(danceStyle)
                AnsiConsole.MarkupLine($"{player.Name} now has a maximum uses of {player.TotalUses(danceStyle)}!")
                OkPrompt()
        End Select
    End Sub
End Module
