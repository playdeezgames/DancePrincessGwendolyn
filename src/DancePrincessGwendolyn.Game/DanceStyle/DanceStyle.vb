Imports System.Runtime.CompilerServices

Public Enum DanceStyle
    None
    Ballet
    Bollywood
    Cheerleading
    HipHop
    LineDancing
    TapDancing
End Enum
Public Module DanceStyleExtensions
    <Extension>
    Function Name(danceStyle As DanceStyle) As String
        Return DanceStyleDescriptors(danceStyle).Name
    End Function
    <Extension>
    Function CharacterStatisticType(danceStyle As DanceStyle) As CharacterStatisticType
        Return DanceStyleDescriptors(danceStyle).CharacterStatisticType
    End Function
    <Extension>
    Function UsageStatisticType(danceStyle As DanceStyle) As CharacterStatisticType
        Return DanceStyleDescriptors(danceStyle).UsageStatisticType
    End Function
    <Extension>
    Function MaximumUsageStatisticType(danceStyle As DanceStyle) As CharacterStatisticType
        Return DanceStyleDescriptors(danceStyle).MaximumUsageStatisticType
    End Function
    <Extension>
    Function ChampCharacterType(danceStyle As DanceStyle) As CharacterType
        Return DanceStyleDescriptors(danceStyle).ChampCharacterType
    End Function
    <Extension>
    Function TrophyItemType(danceStyle As DanceStyle) As ItemType
        Return DanceStyleDescriptors(danceStyle).TrophyItemType
    End Function
End Module
