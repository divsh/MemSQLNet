Imports AutoMapper
Imports SQLite

Public Class clsTopic
    Implements IBO
    Public Class Topic
        Implements IDBObject
        Public Property MaintTime As String Implements IDBObject.MaintTime
        <PrimaryKey, AutoIncrement>
        Property ID As Integer Implements IDBObject.ID
        <NotNull>
        Property Name As String
        <Indexed>
        Property ParentTopicID As Integer
    End Class

#Region "Model variables"
    Private Shared nextID As Integer = 0
    Private mDbContext As DBContext
    Private mMapperToDB As Mapper
    Private mDBObject As Topic
    Shared mMapperFromDB As Mapper
#End Region

#Region "Model Properties and associations"
    Dim mID As Integer
    ReadOnly Property Id As Integer
        Get
            Return mDBObject.ID
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

    Property ParentTopicID As Integer
        Get
            Return mDBObject.ParentTopicID
        End Get
        Set(value As Integer)
            mDBObject.ParentTopicID = value
        End Set
    End Property

    Public Function Questions() As List(Of clsQuestion)
        Return clsQuestion.FetchBusinessObjects(mDbContext, Function(x) x.TopicID = mDBObject.ID)
    End Function

    Public Function ParentTopic() As clsTopic
        If ParentTopicID = 0 Then Return Nothing
        Return clsTopic.FetchBusinessObjects(mDbContext, Function(x) x.ID = ParentTopicID).FirstOrDefault()
    End Function
#End Region

#Region "IBO implementations"
    Public Event IBO_Changed() Implements IBO.IBO_Changed


    Public Sub Initialize() Implements IBO.Initialize

    End Sub

    Private mIsDirty As Boolean
    Public ReadOnly Property IsDirty As Boolean Implements IBO.IsDirty
        Get
            Return mIsDirty
        End Get
    End Property

    Public ReadOnly Property IBO_ID As Integer Implements IBO.IBO_ID
        Get
            Return mDBObject.ID
        End Get
    End Property

    Private mIsStored As Boolean
    Public ReadOnly Property IsStored As Boolean Implements IBO.IsStored
        Get
            Return mIsStored
        End Get
    End Property

    Public Function LoadFromStorage() As Boolean Implements IBO.LoadFromStorage
        Dim dbObject As Topic
        dbObject = FetchBusinessObjects(mDbContext, Function(x) x.ID = IBO_ID).FirstOrDefault().DBObject
        mMapperFromDB.Map(dbObject, mDBObject)
        If (dbObject IsNot Nothing) Then
            mIsStored = True
            Return True
        End If
        Return False
    End Function

    Public Function Save() As Boolean Implements IBO.Save
        If mIsStored Then
            Return mDbContext.Update(mDBObject)
        Else
            Dim IDCreated As Integer
            mDbContext.Save(mDBObject, IDCreated)
            'Mid = IDCreated
            mIsStored = True
            Return True
        End If
    End Function

    Public Function Delete() As Boolean Implements IBO.Delete
        Return mDbContext.Delete(DBObject)
    End Function


    Public Function IsValid() As Boolean Implements IBO.IsValid
        Throw New NotImplementedException()
    End Function
#End Region

#Region "Model methods"
    Private Function DBObject() As Topic
        Return mMapperToDB.Map(Of Topic)(Me)
    End Function

    Public Sub New(dbContext As DBContext)
        mDbContext = dbContext
        SetUp()
    End Sub

    Private Sub SetUp()
        Dim mapConfigFromDB As MapperConfiguration = New MapperConfiguration(Function(x) x.CreateMap(Of Topic, Topic)())
        Dim mapConfigToDB As MapperConfiguration = New MapperConfiguration(Function(x) x.CreateMap(Of clsTopic, Topic)())
        mMapperFromDB = mapConfigFromDB.CreateMapper()
        mMapperToDB = mapConfigToDB.CreateMapper()

        mDBObject = New Topic()
        mDBObject.ID = nextID
        nextID -= 1

        mIsStored = False
    End Sub

    Shared Function FetchBusinessObjects(dbContext As DBContext, x As Func(Of Topic, Boolean)) As List(Of clsTopic)
        'Dim mapConfigFromDB As MapperConfiguration = New MapperConfiguration(Function(ax) ax.CreateMap(Of Topic, Topic)())
        'Dim mapperFromDB As Mapper = mapConfigFromDB.CreateMapper()
        Dim dbobjects As List(Of Topic)
        Dim modelObjects As List(Of clsTopic) = New List(Of clsTopic)
        dbobjects = dbContext.Table(Of Topic).Where(x).ToList()
        For Each item As Topic In dbobjects
            Dim modelObj As New clsTopic(dbContext)
            mMapperFromDB.Map(item, modelObj.mDBObject, GetType(Topic), GetType(Topic))
            modelObj.mIsStored = True
            modelObjects.Add(modelObj)
        Next
        Return modelObjects
    End Function

#End Region

    'getQuestions
    'addQuestion()

End Class
