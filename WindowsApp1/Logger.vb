Public Class Logger
    Public Shared Property LogFilePath As String

    Public Shared Sub Log(ByVal level As LoggingLevel, ByVal logStatement As String)

        If String.IsNullOrEmpty(_LogFilePath) Then
            IO.Directory.CreateDirectory(IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "MemLog"))
            _LogFilePath = IO.Path.Combine(IO.Path.GetDirectoryName(Application.ExecutablePath), "MemLog\MemLog.txt")
        End If

        Dim statement As String
        statement = Date.Now.ToString() & ":" & level.ToString & ":" & logStatement
        IO.File.AppendAllText(_LogFilePath, Environment.NewLine & statement)
    End Sub

    Public Shared Sub LogObjectSaved(ByVal level As LoggingLevel, obj As Object, objectDesc As String)
        Log(level, obj.GetType().ToString & " Saved:" & objectDesc)
    End Sub
    Public Shared Sub LogObjectSaved_old(ByVal level As LoggingLevel, obj As Object)
        Log(level, obj.GetType.ToString & " saved:" & Serialize(obj))
    End Sub
    Public Enum LoggingLevel
        Info = 0
        Warning = 1
        Debug = 3
        Err = 2
    End Enum
    Private Shared Function Serialize(ByVal obj As Object) As String
        Dim xmlS As Xml.Serialization.XmlSerializer = New Xml.Serialization.XmlSerializer(obj.GetType)
        Dim stringWriter As IO.StringWriter = New IO.StringWriter()
        xmlS.Serialize(stringWriter, obj)
        Return stringWriter.ToString()
    End Function

End Class


