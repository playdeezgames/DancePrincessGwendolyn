Friend Class GravelRoadLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Gravel Road"
        End Get
    End Property

    Friend Overrides Sub OnRefresh(location As Location)
        If Not location.NonPlayerCharacters.Any Then
            Character.Create(CharacterType.BalletN00b, location)
        End If
    End Sub
End Class
