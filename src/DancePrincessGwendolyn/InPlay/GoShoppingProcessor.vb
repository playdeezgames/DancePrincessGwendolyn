Module GoShoppingProcessor
    Friend Sub Run()
        Dim done = False
        While Not done
            AnsiConsole.Clear()
            Dim character = World.PlayerCharacter
            AnsiConsole.MarkupLine($"{character.Name} goes shopping!")
            AnsiConsole.MarkupLine($"{character.Name} has {character.Bux} Bux to spend!")
            Dim itemTypes As IEnumerable(Of ItemType) = character.Location.ShoppeItems
            Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]What Should {character.Name} Buy?[/]"}
            prompt.AddChoice(NeverMindText)
            Dim table = itemTypes.ToDictionary(Function(x) $"{x.Name} ({x.Price} Bux)", Function(x) x)
            prompt.AddChoices(table.Keys.ToArray)
            Select Case AnsiConsole.Prompt(prompt)
                Case NeverMindText
                    done = True
                Case Else

            End Select
        End While
    End Sub
End Module
