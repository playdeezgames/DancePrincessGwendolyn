Friend Class TapDancingDescriptor
    Inherits DanceStyleDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Tap Dancing"
        End Get
    End Property

    Public Overrides ReadOnly Property CharacterStatisticType As CharacterStatisticType
        Get
            Return CharacterStatisticType.TapDancingSkill
        End Get
    End Property

    Public Overrides ReadOnly Property UsageStatisticType As CharacterStatisticType
        Get
            Return Game.CharacterStatisticType.TapDancingSkillUses
        End Get
    End Property

    Public Overrides ReadOnly Property MaximumUsageStatisticType As CharacterStatisticType
        Get
            Return Game.CharacterStatisticType.TapDancingSkillMaximumUses
        End Get
    End Property

    Public Overrides ReadOnly Property ChampCharacterType As CharacterType
        Get
            Return CharacterType.TapDanceChamp
        End Get
    End Property

    Public Overrides ReadOnly Property TrophyItemType As ItemType
        Get
            Return ItemType.PlatinumCuffLinks
        End Get
    End Property
End Class
