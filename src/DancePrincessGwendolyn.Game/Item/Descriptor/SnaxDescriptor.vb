Friend Class SnaxDescriptor
    Inherits ItemTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Snax"
        End Get
    End Property

    Public Overrides ReadOnly Property Price As Long
        Get
            Return 10
        End Get
    End Property

    Public Overrides ReadOnly Property CanUse As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overrides Function Use(character As Character) As String
        Dim message = $"{character.Name} eats the {Name} and feels more enthusiastic!"
        character.RestoreEnthusiasm()
        Return message
    End Function
End Class
