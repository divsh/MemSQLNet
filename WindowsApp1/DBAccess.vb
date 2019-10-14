Imports SQLite
Public Class DBAccess
    Public Shared Sub CreateDB(ByVal dbName As String)
        Dim db = New SQLiteConnection("foofoo")
        db.CreateTable(Of Topic)()
        db.CreateTable(Of Question)()
    End Sub
End Class
