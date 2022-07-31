Friend Class DiamondTiaraDescriptor
    Inherits ItemTypeDescriptor

    Sub New()
        MyBase.New(New Dictionary(Of CharacterStatisticType, Long) From
                   {
                        {CharacterStatisticType.BalletSkill, 10},
                        {CharacterStatisticType.BollywoodSkill, 10},
                        {CharacterStatisticType.CheerleadingSkill, 10},
                        {CharacterStatisticType.HipHopSkill, 10},
                        {CharacterStatisticType.LineDancingSkill, 10},
                        {CharacterStatisticType.TapDancingSkill, 10}
                   })
    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Diamond Tiara"
        End Get
    End Property

    Public Overrides ReadOnly Property Price As Long
        Get
            Return 0
        End Get
    End Property

    Public Overrides ReadOnly Property EquipSlot As EquipSlot
        Get
            Return EquipSlot.Bling
        End Get
    End Property
End Class
