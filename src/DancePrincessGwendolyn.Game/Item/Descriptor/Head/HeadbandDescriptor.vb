Friend Class HeadbandDescriptor
    Inherits ItemTypeDescriptor
    Sub New()
        MyBase.New(New Dictionary(Of CharacterStatisticType, Long) From
                   {
                        {CharacterStatisticType.BalletSkill, -4},
                        {CharacterStatisticType.BollywoodSkill, -2},
                        {CharacterStatisticType.CheerleadingSkill, 2},
                        {CharacterStatisticType.HipHopSkill, 0},
                        {CharacterStatisticType.LineDancingSkill, -2},
                        {CharacterStatisticType.TapDancingSkill, 0}
                   })
    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Headband"
        End Get
    End Property

    Public Overrides ReadOnly Property Price As Long
        Get
            Return 50
        End Get
    End Property

    Public Overrides ReadOnly Property EquipSlot As EquipSlot
        Get
            Return EquipSlot.Head
        End Get
    End Property
End Class
