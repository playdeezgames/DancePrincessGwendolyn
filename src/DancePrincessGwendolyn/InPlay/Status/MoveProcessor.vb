Module MoveProcessor
    Friend Sub Run()
        'do not clear!
        Dim prompt As New SelectionPrompt(Of String) With {.Title = "[olive]Move Which Way?[/]"}
        Dim table As New Dictionary(Of String, Long)
        prompt.AddChoice(NeverMindText)
        For Each route In World.PlayerCharacter.Location.Routes
            table.Add(route.Name, route.Id)
            prompt.AddChoice(route.Name)
        Next
        Dim answer = AnsiConsole.Prompt(prompt)
        Dim routeId As Long
        If table.TryGetValue(answer, routeId) Then
            World.PlayerCharacter.Location = Route.FromId(routeId).ToLocation
        End If
    End Sub
End Module
