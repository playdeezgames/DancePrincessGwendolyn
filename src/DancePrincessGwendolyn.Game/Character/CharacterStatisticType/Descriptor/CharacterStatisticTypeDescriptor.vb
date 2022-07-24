Friend MustInherit Class CharacterStatisticTypeDescriptor
    MustOverride ReadOnly Property Name As String
End Class
Friend Module CharacterStatisticTypeDescriptorUtility
    Friend ReadOnly CharacterStatisticTypeDescriptors As IReadOnlyDictionary(Of CharacterStatisticType, CharacterStatisticTypeDescriptor) =
        New Dictionary(Of CharacterStatisticType, CharacterStatisticTypeDescriptor) From
        {
            {CharacterStatisticType.Anxiety, New AnxietyDescriptor},
            {CharacterStatisticType.Confidence, New ConfidenceDescriptor},
            {CharacterStatisticType.Ennui, New EnnuiDescriptor},
            {CharacterStatisticType.Enthusiasm, New EnthusiasmDescriptor}
        }
End Module