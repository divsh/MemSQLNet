Public Class MessageBoxEx
    Public Shared Sub Show(ex As Exception, methodName As String)
        MessageBox.Show("Exception:" & ex.Message & Environment.NewLine & ex.StackTrace, methodName)
    End Sub
End Class
