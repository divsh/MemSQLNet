Public Class Utility
    Shared Function Shuffle(Of T)(collection As List(Of T)) As List(Of T)
        If collection Is Nothing Then Return Nothing
        Dim r As Random = New Random()
        Shuffle = collection.OrderBy(Function(a) r.Next()).ToList()
        Return Shuffle
    End Function

End Class
