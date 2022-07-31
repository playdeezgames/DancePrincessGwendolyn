Friend Class SilverBeltBuckleDescriptor
    Inherits ItemTypeDescriptor

    Sub New()
        MyBase.New(New Dictionary(Of CharacterStatisticType, Long) From
                   {
                        {CharacterStatisticType.BalletSkill, 0},
                        {CharacterStatisticType.BollywoodSkill, 0},
                        {CharacterStatisticType.CheerleadingSkill, 0},
                        {CharacterStatisticType.HipHopSkill, 0},
                        {CharacterStatisticType.LineDancingSkill, 10},
                        {CharacterStatisticType.TapDancingSkill, 0}
                   })
    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Silver Belt Buckle"
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
