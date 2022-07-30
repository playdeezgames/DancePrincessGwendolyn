Friend Class MicrophoneDescriptor
    Inherits ItemTypeDescriptor
    Sub New()
        MyBase.New(New Dictionary(Of CharacterStatisticType, Long) From
                   {
                        {CharacterStatisticType.BalletSkill, -4},
                        {CharacterStatisticType.BollywoodSkill, 0},
                        {CharacterStatisticType.CheerleadingSkill, 0},
                        {CharacterStatisticType.HipHopSkill, 4},
                        {CharacterStatisticType.LineDancingSkill, -8},
                        {CharacterStatisticType.TapDancingSkill, -4}
                   })
    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Microphone"
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
