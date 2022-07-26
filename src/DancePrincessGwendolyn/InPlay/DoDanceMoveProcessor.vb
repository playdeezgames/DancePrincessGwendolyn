Imports SPLORR.Game

Module DoDanceMoveProcessor
    Friend Function Run(danceStyle As DanceStyle) As Boolean
        Dim player = World.PlayerCharacter
        Dim rival = player.Location.NonPlayerCharacters.First
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"You do a {danceStyle.Name} move!")
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
                    Return HandleReaction(rival, playerRoll \ rivalRoll)
                End If
                Return HandleReaction(player, rivalRoll \ playerRoll)
        End Select
    End Function

    Private Function HandleReaction(reactor As Character, anxiety As Long) As Boolean
        AnsiConsole.MarkupLine($"{reactor.Name} loses {anxiety} confidence!")
        reactor.AddAnxiety(anxiety)
        AnsiConsole.MarkupLine($"{reactor.Name} has {reactor.Confidence} confidence remaining!")
        If reactor.Confidence < 1 Then
            AnsiConsole.MarkupLine($"{reactor.Name} has been defeated!")
            If Not reactor.IsPlayer Then
                reactor.Destroy()
                OkPrompt()
                Return True
            End If
            Dim route = RNG.FromEnumerable(reactor.Location.Routes)
            AnsiConsole.MarkupLine($"{reactor.Name} goes to {route.DestinationLocation.Name} to recover.")
            reactor.Location = route.DestinationLocation
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
        Dim total As Long = 0
        Dim dieSize = rival.DanceSkills(danceStyle)
        Dim done = True
        rival.AddUse(danceStyle)
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
        Return total
    End Function

    Private Function DoPlayerRoll(danceStyle As DanceStyle, player As Character) As Long
        Dim playerTotal As Long = 0
        Dim dieSize = player.DanceSkills(danceStyle)
        Dim done = True
        player.AddUse(danceStyle)
        Do
            done = True
            Dim roll = RNG.RollDice($"1d{dieSize}")
            playerTotal += roll
            AnsiConsole.MarkupLine($"You roll a {roll} for a total of {playerTotal}!")
            If dieSize = roll Then
                AnsiConsole.MarkupLine("Maximum roll! The die explodes and you get to re-roll!")
                done = False
            End If
        Loop Until done
        Return playerTotal
    End Function
End Module
