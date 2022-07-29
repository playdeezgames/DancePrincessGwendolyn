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
            Dim answer = AnsiConsole.Prompt(prompt)
            Select Case answer
                Case NeverMindText
                    done = True
                Case Else
                    BuyItemType(character, table(answer))
            End Select
        End While
    End Sub

    Private Sub BuyItemType(character As Character, itemType As ItemType)
        If Not character.CanBuy(itemType) Then
            AnsiConsole.MarkupLine($"{character.Name} cannot afford that!")
            OkPrompt()
            Return
        End If
        character.Buy(itemType)
        AnsiConsole.MarkupLine($"{character.Name} buys {itemType.Name}!")
        OkPrompt()
    End Sub
End Module
