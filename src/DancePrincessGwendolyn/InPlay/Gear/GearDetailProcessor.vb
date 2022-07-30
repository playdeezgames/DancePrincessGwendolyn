Module GearDetailProcessor
    Friend Sub Run(character As Character, equipSlot As EquipSlot)
        Dim item = character.EquipSlots(equipSlot)
        AnsiConsole.MarkupLine($"Gear Type: {equipSlot.Name}")
        AnsiConsole.MarkupLine($"Gear: {item.Name}")
        'TODO: description
        'TODO: buffs
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]What should {character.Name} do with the {item.Name}?[/]"}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoice(UnequipText)
        Select Case AnsiConsole.Prompt(prompt)
            Case NeverMindText
                'do nothing!
            Case UnequipText
                character.Unequip(equipSlot)
                AnsiConsole.MarkupLine($"{character.Name} unequips the {item.Name}!")
                OkPrompt()
        End Select
    End Sub
End Module
