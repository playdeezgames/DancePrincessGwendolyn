Friend Class SariDescriptor
    Inherits ItemTypeDescriptor
    Sub New()
        MyBase.New(New Dictionary(Of CharacterStatisticType, Long) From
                   {
                        {CharacterStatisticType.BalletSkill, 0},
                        {CharacterStatisticType.BollywoodSkill, 6},
                        {CharacterStatisticType.CheerleadingSkill, -6},
                        {CharacterStatisticType.HipHopSkill, 0},
                        {CharacterStatisticType.LineDancingSkill, -6},
                        {CharacterStatisticType.TapDancingSkill, -12}
                   })
    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Sari"
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
