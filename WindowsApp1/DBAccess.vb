Imports SQLite
Public Class DBAccess
    Public Shared Sub CreateDB(ByVal dbName As String)
        Dim db = New SQLiteConnection("foofoo")
        db.CreateTable(Of clsTopic)()
        db.CreateTable(Of clsQuestion)()
    End Sub
End Class
