Friend Class HoodieDescriptor
    Inherits ItemTypeDescriptor
    Sub New()
        MyBase.New(New Dictionary(Of CharacterStatisticType, Long) From
                   {
                        {CharacterStatisticType.BalletSkill, -6},
                        {CharacterStatisticType.BollywoodSkill, 0},
                        {CharacterStatisticType.CheerleadingSkill, 0},
                        {CharacterStatisticType.HipHopSkill, 6},
                        {CharacterStatisticType.LineDancingSkill, -12},
                        {CharacterStatisticType.TapDancingSkill, -6}
                   })
    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Hoodie"
        End Get
    End Property

    Public Overrides ReadOnly Property Price As Long
        Get
            Return 100
        End Get
    End Property

    Public Overrides ReadOnly Property EquipSlot As EquipSlot
        Get
            Return EquipSlot.Outfit
        End Get
    End Property
End Class
