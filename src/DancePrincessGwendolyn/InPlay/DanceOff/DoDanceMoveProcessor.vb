Imports SPLORR.Game

Module DoDanceMoveProcessor
    Friend Function Run(danceStyle As DanceStyle) As Boolean
        Dim player = World.PlayerCharacter
        Dim rival = player.Location.NonPlayerCharacters.First
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"{player.Name} does a {danceStyle.Name} move!")
        Dim playerRoll As Long = DoPlayerRoll(danceStyle, player)
        Dim rivalStyle = rival.PickRandomDanceStyle
        Select Case rivalStyle
            Case DanceStyle.None
                HandleRivalDefeat(rival)
                Return True
            Case Else
                Dim rivalRoll As Long = DoRivalRoll(rivalStyle, rival)
                If playerRoll = rivalRoll Then
                    HandleTie()
                    Return False
                End If
                If playerRoll > rivalRoll Then
                    Return HandleReaction(rival, playerRoll \ rivalRoll, AddressOf RivalDefeat)
                End If
                Return HandleReaction(player, rivalRoll \ playerRoll, AddressOf PlayerDefeat)
        End Select
    End Function

    Private Sub RivalDefeat(character As Character)
        Dim player = World.PlayerCharacter
        Dim sparkle = character.Sparkle
        player.AddSparkle(sparkle)
        AnsiConsole.MarkupLine($"{player.Name} receives {sparkle} sparkle, and now has a total of {player.Sparkle} sparkle!")
        Dim bux As Long = character.RollDefeatBux
        player.AddBux(bux)
        AnsiConsole.MarkupLine($"{player.Name} receives {bux} bux, and now has a total of {player.Bux} bux!")
        If character.HasEquipment Then
            For Each entry In character.EquipSlots
                AnsiConsole.MarkupLine($"{player.Name} receives {character.Name}'s {entry.Value.Name}!")
                player.Inventory.Add(entry.Value)
            Next
        End If
        character.Destroy()
    End Sub

    Private Sub PlayerDefeat(player As Character)
        Dim bux As Long = player.RollDefeatBux
        player.AddBux(-bux)
        AnsiConsole.MarkupLine($"{player.Name} loses {bux} bux, and now has a total of {player.Bux} bux!")
    End Sub

    Private Function HandleReaction(reactor As Character, anxiety As Long, onDefeat As Action(Of Character)) As Boolean
        AnsiConsole.MarkupLine($"{reactor.Name} loses {anxiety} confidence!")
        reactor.AddAnxiety(anxiety)
        AnsiConsole.MarkupLine($"{reactor.Name} has {reactor.Confidence} confidence remaining!")
        If reactor.Confidence < 1 Then
            AnsiConsole.MarkupLine($"{reactor.Name} has been defeated!")
            onDefeat(reactor)
            OkPrompt()
            Return True
        End If
        OkPrompt()
        Return False
    End Function

    Private Sub HandleTie()
        AnsiConsole.MarkupLine($"It's a tie! No confidence lost on either side!")
        OkPrompt()
    End Sub

    Private Sub HandleRivalDefeat(rival As Character)
        AnsiConsole.MarkupLine($"{rival.Name} is out of moves and gives up!")
        OkPrompt()
        rival.Destroy()
    End Sub

    Private Function DoRivalRoll(danceStyle As DanceStyle, rival As Character) As Long
        Dim total As Long = rival.GetStatisticBuff(danceStyle.CharacterStatisticType)
        Dim dieSize = rival.DanceSkills(danceStyle)
        rival.AddUse(danceStyle)
        AnsiConsole.MarkupLine($"{rival.Name} does a {danceStyle.Name} move!")
        Dim done As Boolean
        Do
            done = True
            Dim roll = RNG.RollDice($"1d{dieSize}")
            total += roll
            AnsiConsole.MarkupLine($"{rival.Name} rolls a {roll} for a total of {total}!")
            If dieSize = roll Then
                AnsiConsole.MarkupLine($"Maximum roll! The die explodes and {rival.Name} gets to re-roll!")
                done = False
            End If
        Loop Until done
        Return Math.Max(1, total)
    End Function

    Private Function DoPlayerRoll(danceStyle As DanceStyle, player As Character) As Long
        Dim playerTotal As Long = player.GetStatisticBuff(danceStyle.CharacterStatisticType)
        Dim dieSize = player.DanceSkills(danceStyle)
        player.AddUse(danceStyle)
        Dim done As Boolean
        Do
            done = True
            Dim roll = RNG.RollDice($"1d{dieSize}")
            playerTotal += roll
            AnsiConsole.MarkupLine($"{player.Name} rolls a {roll} for a total of {playerTotal}!")
            If dieSize = roll Then
                AnsiConsole.MarkupLine($"Maximum roll! The die explodes and {player.Name} gets to re-roll!")
                done = False
            End If
        Loop Until done
        Return Math.Max(1, playerTotal)
    End Function
End Module
