Friend MustInherit Class CharacterTypeDescriptor
    Friend MustOverride ReadOnly Property Name As String
    Friend MustOverride Sub OnCreate(character As Character)
End Class
Friend Module CharacterTypeDescriptorUtility
    Friend ReadOnly CharacterTypeDescriptors As IReadOnlyDictionary(Of CharacterType, CharacterTypeDescriptor) =
        New Dictionary(Of CharacterType, CharacterTypeDescriptor) From
        {
            {CharacterType.Gwendolyn, New GwendolynDescriptor}
        }
End Module