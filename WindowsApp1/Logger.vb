Public Class Logger
    Public Shared Property LogFilePath As String

    Public Shared Sub Log(ByVal level As LoggingLevel, ByVal logStatement As String)
        If String.IsNullOrEmpty(_LogFilePath) Then _LogFilePath = IO.Path.Combine(Application.ExecutablePath, "MemLog\MemLog.txt")

        Dim statement As String
        statement = Date.Now.ToString() & ":" & level.ToString & ":" & logStatement
        IO.File.WriteAllText(_LogFilePath, statement)
    End Sub

    Public Enum LoggingLevel
        Info = 0
        Warning = 1
        Debug = 3
        Err = 2
    End Enum

End Class
