Module Program
    Sub Main(args As String())
        Console.Title = "Dance Princess Gwendolyn"
        AddHandler SfxPlayer.PlaySfx, AddressOf SfxHandler.HandleSfx
        TitleProcessor.Run()
        MainMenuProcessor.Run()
    End Sub
End Module
