Module GearProcessor
    Friend Sub Run(character As Character)
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]{character.Name}'s Gear[/]"}
            prompt.AddChoice(NeverMindText)
            Dim table = character.EquipSlots.ToDictionary(Function(x) $"{x.Key.Name}: {x.Value.Name}", Function(x) x.Key)
            If Not table.Any Then
                Exit Sub
            End If
            prompt.AddChoices(table.Keys.ToArray)
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case NeverMindText
                    done = True
                Case Else
                    GearDetailProcessor.Run(character, table(answer))
            End Select
        End While
    End Sub
End Module
