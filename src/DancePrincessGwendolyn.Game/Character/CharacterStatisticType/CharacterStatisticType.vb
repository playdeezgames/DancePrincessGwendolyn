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
End Enum
Public Module CharacterStatisticTypeExtensions
    <Extension>
    Public Function Name(statisticType As CharacterStatisticType) As String
        Return CharacterStatisticTypeDescriptors(statisticType).Name
    End Function
End Module
