Friend MustInherit Class CharacterTypeDescriptor
    Friend MustOverride ReadOnly Property Name As String
    Protected Sub InitializeStatistics(character As Character, table As IReadOnlyDictionary(Of CharacterStatisticType, Long))
        For Each entry In table
            CharacterStatisticData.Write(character.Id, entry.Key, entry.Value)
        Next
    End Sub
    Friend MustOverride Sub OnCreate(character As Character)
    Friend MustOverride Function RollDefeatBux(character As Character) As Long
End Class
Friend Module CharacterTypeDescriptorUtility
    Friend ReadOnly CharacterTypeDescriptors As IReadOnlyDictionary(Of CharacterType, CharacterTypeDescriptor) =
        New Dictionary(Of CharacterType, CharacterTypeDescriptor) From
        {
            {CharacterType.BalletN00b, New BalletN00bDescriptor},
            {CharacterType.BollywoodN00b, New BollywoodN00bDescriptor},
            {CharacterType.CheerleadingN00b, New CheerleadingN00bDescriptor},
            {CharacterType.Gwendolyn, New GwendolynDescriptor},
            {CharacterType.HipHopN00b, New HipHopN00bDescriptor},
            {CharacterType.LineDancingN00b, New LineDancingN00bDescriptor},
            {CharacterType.TapDancingN00b, New TapDancingN00bDescriptor}
        }
End Module