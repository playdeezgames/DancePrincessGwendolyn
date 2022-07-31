Friend Class CheerleadingDescriptor
    Inherits DanceStyleDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Cheerleading"
        End Get
    End Property

    Public Overrides ReadOnly Property CharacterStatisticType As CharacterStatisticType
        Get
            Return CharacterStatisticType.CheerleadingSkill
        End Get
    End Property

    Public Overrides ReadOnly Property UsageStatisticType As CharacterStatisticType
        Get
            Return Game.CharacterStatisticType.CheerleadingSkillUses
        End Get
    End Property

    Public Overrides ReadOnly Property MaximumUsageStatisticType As CharacterStatisticType
        Get
            Return Game.CharacterStatisticType.CheerleadingSkillMaximumUses
        End Get
    End Property

    Public Overrides ReadOnly Property ChampCharacterType As CharacterType
        Get
            Return CharacterType.CheerleadingChamp
        End Get
    End Property

    Public Overrides ReadOnly Property TrophyItemType As ItemType
        Get
            Return ItemType.ClassRing
        End Get
    End Property
End Class
