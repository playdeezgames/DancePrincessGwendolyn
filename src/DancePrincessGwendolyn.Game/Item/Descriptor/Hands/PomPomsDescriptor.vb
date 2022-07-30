Friend Class PomPomsDescriptor
    Inherits ItemTypeDescriptor
    Sub New()
        MyBase.New(New Dictionary(Of CharacterStatisticType, Long) From
                   {
                        {CharacterStatisticType.BalletSkill, -8},
                        {CharacterStatisticType.BollywoodSkill, -4},
                        {CharacterStatisticType.CheerleadingSkill, 4},
                        {CharacterStatisticType.HipHopSkill, 0},
                        {CharacterStatisticType.LineDancingSkill, -4},
                        {CharacterStatisticType.TapDancingSkill, 0}
                   })
    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Pom Poms"
        End Get
    End Property

    Public Overrides ReadOnly Property Price As Long
        Get
            Return 25
        End Get
    End Property

    Public Overrides ReadOnly Property EquipSlot As EquipSlot
        Get
            Return EquipSlot.Hands
        End Get
    End Property
End Class
