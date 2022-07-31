Module WinGameProcessor
    Friend Sub Run(character As Character)
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"{character.Name} has put on the {ItemType.DiamondTiara.Name} and become the new {CharacterType.DanceQueen.Name}!")
        AnsiConsole.MarkupLine($"Congratulations!")
        OkPrompt()
    End Sub
End Module
