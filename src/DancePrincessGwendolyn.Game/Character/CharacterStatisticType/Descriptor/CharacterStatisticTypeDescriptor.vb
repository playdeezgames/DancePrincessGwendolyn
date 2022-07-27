Friend MustInherit Class CharacterStatisticTypeDescriptor
    MustOverride ReadOnly Property Name As String
    MustOverride Function Minimum(character As Character) As Long
    MustOverride Function Maximum(character As Character) As Long
End Class
Friend Module CharacterStatisticTypeDescriptorUtility
    Friend ReadOnly CharacterStatisticTypeDescriptors As IReadOnlyDictionary(Of CharacterStatisticType, CharacterStatisticTypeDescriptor) =
        New Dictionary(Of CharacterStatisticType, CharacterStatisticTypeDescriptor) From
        {
            {CharacterStatisticType.Anxiety, New AnxietyDescriptor},
            {CharacterStatisticType.Confidence, New ConfidenceDescriptor},
            {CharacterStatisticType.Ennui, New EnnuiDescriptor},
            {CharacterStatisticType.Enthusiasm, New EnthusiasmDescriptor},
            {CharacterStatisticType.BalletSkill, New BalletSkillDescriptor},
            {CharacterStatisticType.BalletSkillUses, New BalletSkillUsesDescriptor},
            {CharacterStatisticType.BalletSkillMaximumUses, New BalletSkillMaximumUsesDescriptor},
            {CharacterStatisticType.BollywoodSkill, New BollywoodSkillDescriptor},
            {CharacterStatisticType.BollywoodSkillUses, New BollywoodSkillUsesDescriptor},
            {CharacterStatisticType.BollywoodSkillMaximumUses, New BollywoodSkillMaximumUsesDescriptor},
            {CharacterStatisticType.CheerleadingSkill, New CheerleadingSkillDescriptor},
            {CharacterStatisticType.CheerleadingSkillUses, New CheerleadingSkillUsesDescriptor},
            {CharacterStatisticType.CheerleadingSkillMaximumUses, New CheerleadingSkillMaximumUsesDescriptor},
            {CharacterStatisticType.HipHopSkill, New HipHopSkillDescriptor},
            {CharacterStatisticType.HipHopSkillUses, New HipHopSkillUsesDescriptor},
            {CharacterStatisticType.HipHopSkillMaximumUses, New HipHopSkillMaximumUsesDescriptor},
            {CharacterStatisticType.LineDancingSkill, New LineDancingSkillDescriptor},
            {CharacterStatisticType.LineDancingSkillUses, New LineDancingSkillUsesDescriptor},
            {CharacterStatisticType.LineDancingSkillMaximumUses, New LineDancingSkillMaximumUsesDescriptor},
            {CharacterStatisticType.TapDancingSkill, New TapDancingSkillDescriptor},
            {CharacterStatisticType.TapDancingSkillUses, New TapDancingSkillUsesDescriptor},
            {CharacterStatisticType.TapDancingSkillMaximumUses, New TapDancingSkillMaximumUsesDescriptor}
        }
End Module