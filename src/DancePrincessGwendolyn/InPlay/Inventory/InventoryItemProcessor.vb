Module InventoryItemProcessor
    Friend Sub Run(character As Character, item As Item)
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]What should {character.Name} do with the {item.Name}?[/]"}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoice(DropText)
        If character.CanUse(item) Then
            prompt.AddChoices(UseText)
        End If
        If character.CanEquip(item) Then
            prompt.AddChoice(EquipText)
        End If
        Select Case AnsiConsole.Prompt(prompt)
            Case NeverMindText
                'do nothing!
            Case DropText
                AnsiConsole.MarkupLine($"{character.Name} drops the {item.Name}!")
                character.Drop(item)
                OkPrompt()
            Case UseText
                AnsiConsole.MarkupLine(character.Use(item))
                OkPrompt()
            Case EquipText
                AnsiConsole.MarkupLine($"{character.Name} equips the {item.Name}!")
                character.Equip(item)
                OkPrompt()
        End Select
    End Sub
End Module
