Friend Class TopHatDescriptor
    Inherits ItemTypeDescriptor
    Sub New()
        MyBase.New(New Dictionary(Of CharacterStatisticType, Long) From
                   {
                        {CharacterStatisticType.BalletSkill, -2},
                        {CharacterStatisticType.BollywoodSkill, -4},
                        {CharacterStatisticType.CheerleadingSkill, 0},
                        {CharacterStatisticType.HipHopSkill, -2},
                        {CharacterStatisticType.LineDancingSkill, 0},
                        {CharacterStatisticType.TapDancingSkill, 2}
                   })
    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Top Hat"
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
