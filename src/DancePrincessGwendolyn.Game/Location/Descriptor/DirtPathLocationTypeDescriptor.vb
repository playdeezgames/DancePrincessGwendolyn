﻿Friend Class DirtPathLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Dirt Path"
        End Get
    End Property

    Friend Overrides Sub OnRefresh(location As Location)

    End Sub
End Class