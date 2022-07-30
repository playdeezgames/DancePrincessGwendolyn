Friend Class SandalsDescriptor
    Inherits ItemTypeDescriptor
    Sub New()
        MyBase.New(New Dictionary(Of CharacterStatisticType, Long) From
                   {
                        {CharacterStatisticType.BalletSkill, 0},
                        {CharacterStatisticType.BollywoodSkill, 1},
                        {CharacterStatisticType.CheerleadingSkill, -1},
                        {CharacterStatisticType.HipHopSkill, 0},
                        {CharacterStatisticType.LineDancingSkill, -1},
                        {CharacterStatisticType.TapDancingSkill, -2}
                   })
    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Sandals"
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
