Friend MustInherit Class CharacterTypeDescriptor
    MustOverride ReadOnly Property Name As String
End Class
Friend Module CharacterTypeDescriptorUtility
    Friend ReadOnly CharacterTypeDescriptors As IReadOnlyDictionary(Of CharacterType, CharacterTypeDescriptor) =
        New Dictionary(Of CharacterType, CharacterTypeDescriptor) From
        {
            {CharacterType.Gwendolyn, New GwendolynDescriptor}
        }

End Module