﻿Friend Class BindiDescriptor
    Inherits ItemTypeDescriptor
    Sub New()
        MyBase.New(New Dictionary(Of CharacterStatisticType, Long) From
                   {
                        {CharacterStatisticType.BalletSkill, 0},
                        {CharacterStatisticType.BollywoodSkill, 2},
                        {CharacterStatisticType.CheerleadingSkill, -2},
                        {CharacterStatisticType.HipHopSkill, 0},
                        {CharacterStatisticType.LineDancingSkill, -2},
                        {CharacterStatisticType.TapDancingSkill, -4}
                   })
    End Sub

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Bindi"
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
