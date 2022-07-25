Friend MustInherit Class DanceStyleDescriptor
    MustOverride ReadOnly Property Name As String

    MustOverride ReadOnly Property CharacterStatisticType As CharacterStatisticType

    MustOverride ReadOnly Property UsageStatisticType As CharacterStatisticType

    MustOverride ReadOnly Property MaximumUsageStatisticType As CharacterStatisticType
End Class
Public Module DanceStyleDescriptorUtility
    Friend ReadOnly DanceStyleDescriptors As IReadOnlyDictionary(Of DanceStyle, DanceStyleDescriptor) =
        New Dictionary(Of DanceStyle, DanceStyleDescriptor) From
        {
            {DanceStyle.Ballet, New BalletDescriptor},
            {DanceStyle.Bollywood, New BollywoodDescriptor},
            {DanceStyle.Cheerleading, New CheerleadingDescriptor},
            {DanceStyle.HipHop, New HipHopDescriptor},
            {DanceStyle.LineDancing, New LineDancingDescriptor},
            {DanceStyle.TapDancing, New TapDancingDescriptor}
        }
    Public ReadOnly Property AllDanceStyles As IEnumerable(Of DanceStyle)
        Get
            Return DanceStyleDescriptors.Keys
        End Get
    End Property
End Module
