Module LifeCoachProcessor
    Friend Sub Run()
        Dim character = World.PlayerCharacter
        character.RestoreConfidence()
        AnsiConsole.MarkupLine($"{character.Name} visits the life coach!")
        AnsiConsole.MarkupLine($"{character.Name} restores confidence!")

        Dim danceStyle = character.Location.DanceStyle
        If danceStyle.HasValue Then
            character.RestoreUses(danceStyle.Value)
            AnsiConsole.MarkupLine($"{character.Name} restores uses of {danceStyle.Value.Name}")
        End If
        SfxPlayer.Play(Sfx.Recovery)
        OkPrompt()
    End Sub
End Module
