Friend Class GravelRoadLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Gravel Road"
        End Get
    End Property

    Private ReadOnly Rivals As IReadOnlyList(Of CharacterType) =
        New List(Of CharacterType) From
        {
            CharacterType.BalletN00b,
            CharacterType.BollywoodN00b,
            CharacterType.CheerleadingN00b,
            CharacterType.HipHopN00b,
            CharacterType.LineDancingN00b,
            CharacterType.TapDancingN00b
        }

    Friend Overrides Sub OnRefresh(location As Location)
        If Not location.NonPlayerCharacters.Any Then
            Character.Create(RNG.FromEnumerable(Rivals), location)
        End If
    End Sub
End Class
