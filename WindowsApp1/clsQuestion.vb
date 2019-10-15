Imports AutoMapper
Imports SQLite

Public Class clsQuestion
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
    '>>Custom declarations
    '<<Custom declarations

#Region "Model variables"
    Private Shared nextID As Integer = 0
    Private mDbContext As DBContext
    Private mMapperToDB As Mapper
    Private mDBObject As Question
    Shared mMapperFromDB As Mapper
#End Region

#Region "Model Properties and associations"
    Dim mID As Integer
    ReadOnly Property Id As Integer
        Get
            Return mID
        End Get
    End Property
    Property Name As String
        Get
            Return mDBObject.Name
        End Get
        Set(value As String)
            mDBObject.Name = value
        End Set
    End Property
    Property Ans As String
        Get
            Return mDBObject.Ans
        End Get
        Set(value As String)
            mDBObject.Ans = value
        End Set
    End Property
    Property NextReviewDate As Date
        Get
            Return Convert.ToDateTime(mDBObject.NextReviewDate)
        End Get
        Set(value As Date)
            If mDBObject.NextReviewDate <> Convert.ToDateTime(value) Then
                mDBObject.NextReviewDate = value.ToString
            End If
        End Set
    End Property
    Property RememberQuality As Double
    Property TopicID As Integer

    Public Function Topics() As List(Of clsTopic)
        Return clsTopic.FetchBusinessObjects(mDbContext, Function(x) x.ID = TopicID)
    End Function

    Property MaintTime As Date


#End Region

#Region "IBO implementations"
    Public Event IBO_Changed() Implements IBO.IBO_Changed


    Public Sub IBO_Initialize() Implements IBO.IBO_Initialize

    End Sub

    Private mIsDirty As Boolean
    Public ReadOnly Property IBO_dirty As Boolean Implements IBO.IBO_dirty
        Get
            Return mIsDirty
        End Get
    End Property

    Public ReadOnly Property IBO_Id As Integer Implements IBO.IBO_Id
        Get
            Return mDBObject.Id
        End Get
    End Property

    Private mIsStored As Boolean
    Public ReadOnly Property IBO_isStored As Boolean Implements IBO.IBO_isStored
        Get
            Return mIsStored
        End Get
    End Property

    Public Function IBO_loadFromStorage() As Boolean Implements IBO.IBO_loadFromStorage
        Dim dbObject As Question
        dbObject = FetchBusinessObjects(mDbContext, Function(x) x.Id = IBO_Id).FirstOrDefault().DBObject
        mMapperFromDB.Map(dbObject, mDBObject)
        If (dbObject IsNot Nothing) Then
            mIsSTored = True
            Return True
        End If
        Return False
    End Function

    Public Function Save() As Boolean Implements IBO.IBO_Save
        If mIsStored Then
            Return mDbContext.Update(DBObject)
        Else
            Dim IDCreated As Integer
            mDbContext.Save(DBObject, IDCreated)
            mID = IDCreated
            mIsStored = True
            Return True
        End If
    End Function

    Public Function Delete() As Boolean Implements IBO.IBO_Delete
        Return mDbContext.Delete(DBObject)
    End Function


    Public Function IBO_isValid() As Boolean Implements IBO.IBO_isValid
        Throw New NotImplementedException()
    End Function
#End Region

#Region "Model methods"
    Private Function DBObject() As Question
        Return mMapperToDB.Map(Of Question)(Me)
    End Function

    Public Sub New(dbContext As DBContext)
        mDbContext = dbContext
        SetUp()
    End Sub

    Private Sub SetUp()
        Dim mapConfigFromDB As MapperConfiguration = New MapperConfiguration(Function(x) x.CreateMap(Of Question, Question)())
        Dim mapConfigToDB As MapperConfiguration = New MapperConfiguration(Function(x) x.CreateMap(Of clsQuestion, Question)())
        mMapperFromDB = mapConfigFromDB.CreateMapper()
        mMapperToDB = mapConfigToDB.CreateMapper()

        mDBObject = New Question()
        mDBObject.Id = nextID
        nextID -= 1

        mIsStored = False
    End Sub

    Shared Function FetchBusinessObjects(dbContext As DBContext, x As Func(Of Question, Boolean)) As List(Of clsQuestion)
        'Dim mapConfigFromDB As MapperConfiguration = New MapperConfiguration(Function(ax) ax.CreateMap(Of Question, Question)())
        'Dim mapperFromDB As Mapper = mapConfigFromDB.CreateMapper()
        Dim dbobjects As List(Of Question)
        Dim modelObjects As List(Of clsQuestion) = New List(Of clsQuestion)
        dbobjects = dbContext.Table(Of Question).Where(x).ToList()
        For Each item As Question In dbobjects
            Dim modelObj As New clsQuestion(dbContext)
            mMapperFromDB.Map(item, modelObj.mDBObject, GetType(Question), GetType(Question))
            modelObj.mIsStored = True
            modelObjects.Add(modelObj)
        Next
        Return modelObjects
    End Function

#End Region

#Region "Custom Members"

#End Region
    'todo: work on associations
    'todo: db script for creating referencial constraint on the database tables
    'todo: test saving and retriving RTF from db.

End Class
