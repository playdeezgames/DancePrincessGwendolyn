Imports System.Runtime.CompilerServices

Public Enum CharacterStatisticType
    None
    Confidence
    Enthusiasm
    Anxiety
    Ennui
    BalletSkill
    BollywoodSkill
    CheerleadingSkill
    HipHopSkill
    LineDancingSkill
    TapDancingSkill
    BalletSkillUses
    BollywoodSkillUses
    CheerleadingSkillUses
    HipHopSkillUses
    LineDancingSkillUses
    TapDancingSkillUses
    BalletSkillMaximumUses
    BollywoodSkillMaximumUses
    CheerleadingSkillMaximumUses
    HipHopSkillMaximumUses
    LineDancingSkillMaximumUses
    TapDancingSkillMaximumUses
End Enum
Public Module CharacterStatisticTypeExtensions
    <Extension>
    Public Function Name(statisticType As CharacterStatisticType) As String
        Return CharacterStatisticTypeDescriptors(statisticType).Name
    End Function
    <Extension>
    Public Function Minimum(statisticType As CharacterStatisticType, character As Character) As Long
        Return CharacterStatisticTypeDescriptors(statisticType).Minimum(character)
    End Function
    <Extension>
    Public Function Maximum(statisticType As CharacterStatisticType, character As Character) As Long
        Return CharacterStatisticTypeDescriptors(statisticType).Maximum(character)
    End Function
End Module
