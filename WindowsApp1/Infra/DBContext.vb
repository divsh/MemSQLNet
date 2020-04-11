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
    Public Function Save(ByVal obj As IDBObject, ByRef IDCreated As Integer) As Boolean
        obj.MaintTime = Now.ToString
        Dim noOfRecords As Integer
        noOfRecords = mDBConnection.Insert(obj)
        IDCreated = obj.ID
        Return noOfRecords > 0
    End Function

    ''' <summary>
    ''' Updates the entry with match id
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <returns></returns>
    Public Function Update(ByVal obj As Object) As Boolean
        Try
            Return mDBConnection.Update(obj) > 0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Delete(ByVal obj As Object) As Boolean
        Return mDBConnection.Delete(obj) > 0
    End Function

    Public Function Table(Of T As New)() As TableQuery(Of T)
        Return mDBConnection.Table(Of T)()
    End Function
    Private Sub CreateDB(ByVal dbName As String)
        mDBConnection = New SQLiteConnection(dbName)
        mDBConnection.CreateTable(Of clsTopic.Topic)()
        mDBConnection.CreateTable(Of clsQuestion.Question)()
        mDBConnection.CreateTable(Of clsReview.Review)()
    End Sub
End Class
