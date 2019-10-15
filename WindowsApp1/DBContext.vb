Imports SQLite

Public Class DBContext
    Private mdbPath As String
    Private mDBConnection As SQLiteConnection
    Public Sub New(ByVal dbPath As String)
        CreateDB(dbPath)
    End Sub

    ''' <summary>
    ''' Creates a new entry every time regardless of existing ID.
    ''' </summary>
    Public Function Save(ByVal obj As IDBObject) As Boolean
        obj.MaintTime = Now.ToString
        Return mDBConnection.Insert(obj) > 0
    End Function

    ''' <summary>
    ''' Updates the entry with match id
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    Public Function Update(ByVal obj As Object) As Boolean
        Return mDBConnection.Update(obj) > 0
    End Function

    Public Function Delete(ByVal obj As Object) As Boolean
        Return mDBConnection.Delete(obj) > 0
    End Function

    Public Function Table(Of T As New)() As TableQuery(Of T)
        Return mDBConnection.Table(Of T)()
    End Function
    Private Sub CreateDB(ByVal dbName As String)
        mDBConnection = New SQLiteConnection(dbName)
        mDBConnection.CreateTable(Of clsTopic)()
        mDBConnection.CreateTable(Of WindowsApp1.clsQuestion.Question)()
    End Sub
End Class
