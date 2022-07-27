Friend Class DirtPathLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Dirt Path"
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
            CharacterType.BalletStudent,
            CharacterType.BollywoodStudent,
            CharacterType.CheerleadingStudent,
            CharacterType.HipHopStudent,
            CharacterType.LineDancingStudent,
            CharacterType.TapDancingStudent
        }

    Friend Overrides Sub OnRefresh(location As Location)
        If Not location.NonPlayerCharacters.Any Then
            Character.Create(RNG.FromEnumerable(Rivals), location)
        End If
    End Sub
End Class
