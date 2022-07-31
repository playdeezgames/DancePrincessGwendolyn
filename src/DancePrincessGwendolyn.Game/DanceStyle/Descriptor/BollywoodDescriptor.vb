Friend Class BollywoodDescriptor
    Inherits DanceStyleDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Bollywood"
        End Get
    End Property

    Public Overrides ReadOnly Property CharacterStatisticType As CharacterStatisticType
        Get
            Return CharacterStatisticType.BollywoodSkill
        End Get
    End Property

    Public Overrides ReadOnly Property UsageStatisticType As CharacterStatisticType
        Get
            Return Game.CharacterStatisticType.BollywoodSkillUses
        End Get
    End Property

    Public Overrides ReadOnly Property MaximumUsageStatisticType As CharacterStatisticType
        Get
            Return Game.CharacterStatisticType.BollywoodSkillMaximumUses
        End Get
    End Property

    Public Overrides ReadOnly Property ChampCharacterType As CharacterType
        Get
            Return CharacterType.BollywoodChamp
        End Get
    End Property

    Public Overrides ReadOnly Property TrophyItemType As ItemType
        Get
            Return ItemType.NoseRing
        End Get
    End Property
End Class
