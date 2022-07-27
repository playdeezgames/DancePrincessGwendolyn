﻿Friend Class ConfidenceDescriptor
    Inherits CharacterStatisticTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Confidence"
        End Get
    End Property

    Public Overrides Function Minimum(character As Character) As Long
        Return 0
    End Function

    Public Overrides Function Maximum(character As Character) As Long
        Return Long.MaxValue
    End Function
End Class
