Friend MustInherit Class CharacterTypeDescriptor
    Friend MustOverride ReadOnly Property Name As String
    Protected Sub InitializeStatistics(character As Character, table As IReadOnlyDictionary(Of CharacterStatisticType, Long))
        For Each entry In table
            CharacterStatisticData.Write(character.Id, entry.Key, entry.Value)
        Next
    End Sub
    Friend MustOverride Sub OnCreate(character As Character)
    Friend MustOverride Function RollDefeatBux(character As Character) As Long
End Class
Friend Module CharacterTypeDescriptorUtility
    Friend ReadOnly CharacterTypeDescriptors As IReadOnlyDictionary(Of CharacterType, CharacterTypeDescriptor) =
        New Dictionary(Of CharacterType, CharacterTypeDescriptor) From
        {
            {CharacterType.BalletChamp, New BalletChampDescriptor},
            {CharacterType.BalletDiva, New BalletDivaDescriptor},
            {CharacterType.BalletN00b, New BalletN00bDescriptor},
            {CharacterType.BollywoodChamp, New BollywoodChampDescriptor},
            {CharacterType.BollywoodDiva, New BollywoodDivaDescriptor},
            {CharacterType.BalletStudent, New BalletStudentDescriptor},
            {CharacterType.BollywoodN00b, New BollywoodN00bDescriptor},
            {CharacterType.BollywoodStudent, New BollywoodStudentDescriptor},
            {CharacterType.CheerleadingChamp, New CheerleadingChampDescriptor},
            {CharacterType.CheerleadingDiva, New CheerleadingDivaDescriptor},
            {CharacterType.CheerleadingN00b, New CheerleadingN00bDescriptor},
            {CharacterType.CheerleadingStudent, New CheerleadingStudentDescriptor},
            {CharacterType.DanceQueen, New DanceQueenDescriptor},
            {CharacterType.Gwendolyn, New GwendolynDescriptor},
            {CharacterType.HipHopChamp, New HipHopChampDescriptor},
            {CharacterType.HipHopN00b, New HipHopN00bDescriptor},
            {CharacterType.HipHopPlaya, New HipHopPlayaDescriptor},
            {CharacterType.HipHopStudent, New HipHopStudentDescriptor},
            {CharacterType.LineDancingChamp, New LineDancingChampDescriptor},
            {CharacterType.LineDancingDiva, New LineDancingDivaDescriptor},
            {CharacterType.LineDancingN00b, New LineDancingN00bDescriptor},
            {CharacterType.LineDancingStudent, New LineDancingStudentDescriptor},
            {CharacterType.TapDanceChamp, New TapDanceChampDescriptor},
            {CharacterType.TapDancingDiva, New TapDancingDivaDescriptor},
            {CharacterType.TapDancingN00b, New TapDancingN00bDescriptor},
            {CharacterType.TapDancingStudent, New TapDancingStudentDescriptor}
        }
End Module