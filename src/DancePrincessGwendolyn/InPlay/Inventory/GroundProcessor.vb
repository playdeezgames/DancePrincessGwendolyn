Module GroundProcessor
    Friend Sub Run(character As Character)
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]On the ground:[/]"}
            prompt.AddChoice(NeverMindText)
            Dim table = character.Location.Inventory.ItemStacks.ToDictionary(Function(x) $"{x.Key.Name}(x{x.Value.Count})", Function(x) x.Value.First)
            If Not table.Any Then
                Exit Sub
            End If
            prompt.AddChoices(table.Keys.ToArray)
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case NeverMindText
                    done = True
                Case Else
                    Dim item = table(answer)
                    AnsiConsole.MarkupLine($"{character.Name} picks up {item.Name}!")
                    character.PickUp(item)
            End Select
        End While
    End Sub
End Module
