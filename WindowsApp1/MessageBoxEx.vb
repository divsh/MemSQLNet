Public Class MessageBoxEx
    Public Shared Sub Show(ex As Exception, methodName As String)
        Logger.Log(Logger.LoggingLevel.Err, "Exception:" & ex.Message & Environment.NewLine & ex.StackTrace)
        MessageBox.Show("Exception:" & ex.Message & Environment.NewLine & ex.StackTrace, methodName)
    End Sub
End Class
