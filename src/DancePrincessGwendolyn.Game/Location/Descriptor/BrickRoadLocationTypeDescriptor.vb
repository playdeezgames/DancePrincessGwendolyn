﻿Friend Class BrickRoadLocationTypeDescriptor
    Inherits LocationTypeDescriptor

    Public Overrides ReadOnly Property Name As String
        Get
            Return "Brick Road"
        End Get
    End Property

    Friend Overrides Sub OnRefresh(location As Location)
    End Sub
End Class