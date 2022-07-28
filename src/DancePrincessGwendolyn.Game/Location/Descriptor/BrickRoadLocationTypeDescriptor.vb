Friend Class BrickRoadLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Brick Road"
        End Get
    End Property

    Public Overrides ReadOnly Property HasLifeCoach As Boolean
        Get
            Return False
        End Get
    End Property

    Private ReadOnly Rivals As IReadOnlyList(Of CharacterType) =
        New List(Of CharacterType) From
        {
            CharacterType.BalletDiva,
            CharacterType.BollywoodDiva,
            CharacterType.CheerleadingDiva,
            CharacterType.HipHopPlaya,
            CharacterType.LineDancingDiva,
            CharacterType.TapDancingDiva
        }

    Friend Overrides Sub OnRefresh(location As Location)
        If Not location.NonPlayerCharacters.Any Then
            Character.Create(RNG.FromEnumerable(Rivals), location)
        End If
    End Sub
End Class
