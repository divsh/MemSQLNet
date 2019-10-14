Imports AutoMapper
Imports SQLite

Public Class Question
    Implements IBO
    Public Class Question
        Implements IDBObject
        Property MaintTime As String Implements IDBObject.MaintTime
        <PrimaryKey, AutoIncrement>
        Property Id As Integer Implements IDBObject.ID
        <NotNull>
        Property Name As String
        <NotNull>
        Property Ans As String
        Property NextReviewDate As String
        Property RememberQuality As Double
        <Indexed>
        Property TopicID As Integer
    End Class

    ReadOnly Property Id As Integer
    Property Name As String
    Property Ans As String

    Property NextReviewDate As Date
        Get
            Return Convert.ToDateTime(mDBValue.NextReviewDate)
        End Get
        Set(value As Date)
            mDBValue.NextReviewDate = value.ToString
        End Set
    End Property
    Property RememberQuality As Double
    Property TopicID As Integer
    Property MaintTime As Date



    Private mDb As DBContext
    Private mIsSTored As Boolean


    Private mMapperToDB As Mapper
    Private mDBValue As Question
    Shared mMapperFromDB As Mapper

    Public Sub New(dbContext As DBContext)
        'Dim mDBValue As Question = New Question()
        Dim mapConfigToDB As MapperConfiguration = New MapperConfiguration(Function(x) x.CreateMap(Of WindowsApp1.Question, WindowsApp1.Question.Question)())
        Dim mapConfigFromDB As MapperConfiguration = New MapperConfiguration(Function(x) x.CreateMap(Of WindowsApp1.Question.Question, WindowsApp1.Question)())
        mMapperToDB = mapConfigToDB.CreateMapper()
        mMapperFromDB = mapConfigFromDB.CreateMapper()
        mDBValue = New Question

        Me.Id = mDBValue.Id
        mDb = dbContext
        mIsSTored = False

    End Sub



    Private Function DBObject() As WindowsApp1.Question.Question
        Dim a As WindowsApp1.Question.Question
        a = mMapperToDB.Map(Of WindowsApp1.Question.Question)(Me)
        Return a
    End Function



    Function Save() As Boolean
        If mIsSTored Then
            mDb.Update(DBObject)
            Return True
        Else
            mDb.Save(DBObject)
            Return True
            mIsSTored = True
        End If
    End Function

    Function Delete() As Boolean
        mDb.Delete(DBObject)
        Return True
    End Function

    Private Shared Function ModelObject(ByVal dbObject As WindowsApp1.Question.Question) As WindowsApp1.Question
        Return mMapperFromDB.Map(Of WindowsApp1.Question)(dbObject)
    End Function

    Shared Function FetchBusinessObjects(dbContext As DBContext, x As Func(Of WindowsApp1.Question.Question, Boolean)) As List(Of WindowsApp1.Question)
        Dim mapConfigFromDB As MapperConfiguration = New MapperConfiguration(Function(ax) ax.CreateMap(Of Question, Question)())
        Dim mapperFromDB As Mapper = mapConfigFromDB.CreateMapper()
        Dim dbobjects As List(Of Question)
        Dim modelObjects As List(Of WindowsApp1.Question) = New List(Of WindowsApp1.Question)
        dbobjects = dbContext.Table(Of WindowsApp1.Question.Question).Where(x).ToList()
        For Each item As Question In dbobjects
            Dim modelObj As New WindowsApp1.Question(dbContext)
            modelObj.mDBValue = mapperFromDB.Map(Of Question)(item)
            modelObjects.Add(modelObj)
        Next
        Return modelObjects
    End Function

End Class
