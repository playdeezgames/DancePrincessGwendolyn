Friend Class BalletDescriptor
    Inherits DanceStyleDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Ballet"
        End Get
    End Property

    Public Overrides ReadOnly Property CharacterStatisticType As CharacterStatisticType
        Get
            Return CharacterStatisticType.BalletSkill
        End Get
    End Property

    Public Overrides ReadOnly Property UsageStatisticType As CharacterStatisticType
        Get
            Return Game.CharacterStatisticType.BalletSkillUses
        End Get
    End Property

    Public Overrides ReadOnly Property MaximumUsageStatisticType As CharacterStatisticType
        Get
            Return Game.CharacterStatisticType.BalletSkillMaximumUses
        End Get
    End Property

    Public Overrides ReadOnly Property ChampCharacterType As CharacterType
        Get
            Return CharacterType.BalletChamp
        End Get
    End Property

    Public Overrides ReadOnly Property TrophyItemType As ItemType
        Get
            Return ItemType.PearlNecklace
        End Get
    End Property
End Class
