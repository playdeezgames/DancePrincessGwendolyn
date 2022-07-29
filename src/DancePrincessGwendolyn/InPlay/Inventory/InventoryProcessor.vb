Module InventoryProcessor
    Friend Sub Run(character As Character)
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]{character.Name}'s Inventory:[/]"}
            prompt.AddChoice(NeverMindText)
            Dim table As Dictionary(Of String, ItemType) =
            character.Inventory.ItemStacks.
            ToDictionary(Function(x) $"{x.Key.Name}(x{x.Value.Count})", Function(x) x.Key)
            If Not table.Any Then
                Exit Sub
            End If
            prompt.AddChoices(table.Keys.ToArray)
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case NeverMindText
                    done = True
                Case Else
                    Dim item As Item = character.Inventory.GetItemOfType(table(answer))
                    InventoryItemProcessor.Run(character, item)
            End Select
        End While
    End Sub
End Module
