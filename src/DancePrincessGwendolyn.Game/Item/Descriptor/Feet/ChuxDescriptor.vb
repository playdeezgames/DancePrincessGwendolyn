Friend Class ChuxDescriptor
    Inherits ItemTypeDescriptor
    Sub New()
        MyBase.New(New Dictionary(Of CharacterStatisticType, Long) From
                   {
                        {CharacterStatisticType.BalletSkill, -1},
                        {CharacterStatisticType.BollywoodSkill, 0},
                        {CharacterStatisticType.CheerleadingSkill, 0},
                        {CharacterStatisticType.HipHopSkill, 1},
                        {CharacterStatisticType.LineDancingSkill, -2},
                        {CharacterStatisticType.TapDancingSkill, -1}
                   })
    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Chux"
        End Get
    End Property

    Public Overrides ReadOnly Property Price As Long
        Get
            Return 50
        End Get
    End Property

    Public Overrides ReadOnly Property EquipSlot As EquipSlot
        Get
            Return EquipSlot.Feet
        End Get
    End Property
End Class
