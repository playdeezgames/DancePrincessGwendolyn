Module BuyIceCreamProcessor
    Friend Sub Run()
        Dim character = World.PlayerCharacter
        AnsiConsole.Clear()
        AnsiConsole.MarkupLine($"{character.Name} goes to the ice cream shoppe!")
        AnsiConsole.MarkupLine($"They have an assortment of flavors. Each cone costs 1 Bux.")
        Dim prompt As New SelectionPrompt(Of String) With {.Title = $"[olive]What flavor would {character.Name} like?[/]"}
        prompt.AddChoice(NeverMindText)
        prompt.AddChoices("Vanilla", "Chocolate", "Strawberry", "Rainbow Sherbet", "Cookie Dough", "Moose Tracks", "Mint Chocolate Chip", "Pistacchio")
        Dim answer = AnsiConsole.Prompt(prompt)
        Select Case answer
            Case NeverMindText
                'do nothing
            Case Else
                character.BuyIceCream()
                AnsiConsole.MarkupLine($"{character.Name} loves the {answer}! {character.Name} feels more enthusiastic!")
                OkPrompt()
        End Select
    End Sub
End Module
