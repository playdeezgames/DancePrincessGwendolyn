Friend Class HipHopDescriptor
    Inherits DanceStyleDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Hip Hop"
        End Get
    End Property

    Public Overrides ReadOnly Property CharacterStatisticType As CharacterStatisticType
        Get
            Return CharacterStatisticType.HipHopSkill
        End Get
    End Property

    Public Overrides ReadOnly Property UsageStatisticType As CharacterStatisticType
        Get
            Return Game.CharacterStatisticType.HipHopSkillUses
        End Get
    End Property

    Public Overrides ReadOnly Property MaximumUsageStatisticType As CharacterStatisticType
        Get
            Return Game.CharacterStatisticType.HipHopSkillMaximumUses
        End Get
    End Property

    Public Overrides ReadOnly Property ChampCharacterType As CharacterType
        Get
            Return CharacterType.HipHopChamp
        End Get
    End Property

    Public Overrides ReadOnly Property TrophyItemType As ItemType
        Get
            Return ItemType.GoldTooth
        End Get
    End Property
End Class
