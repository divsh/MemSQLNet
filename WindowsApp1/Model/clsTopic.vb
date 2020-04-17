Imports AutoMapper
Imports SQLite
Public Class clsTopic
    Implements IBO
    Public Class Topic
        Implements IDBObject
        <PrimaryKey, AutoIncrement, Indexed>
        Property ID As Integer Implements IDBObject.ID
        <NotNull>
        Property MaintTime As String Implements IDBObject.MaintTime
        <NotNull>
        Property Name As String
        Property Description As String
        <Indexed>
        Property ParentTopicID As Integer
    End Class

#Region "Attributes enum types"

#End Region

#Region "Model attributes and associations"
    ReadOnly Property ID As Integer
        Get
            Return mDBObject.ID
        End Get
    End Property

    ReadOnly Property MaintTime As Date
        Get
            Return Convert.ToDateTime(mDBObject.MaintTime)
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

    Property Description As String
        Get
            Return mDBObject.Description
        End Get
        Set(value As String)
            mDBObject.Description = value
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

    ReadOnly Property ParentTopic As clsTopic
        Get
            Return clsTopic.FetchBusinessObjects(mDbContext, Function(x) x.ID = Me.ParentTopicID).FirstOrDefault
        End Get
    End Property

    ReadOnly Property ChildrenTopics As List(Of clsTopic)
        Get
            Return clsTopic.FetchBusinessObjects(mDbContext, Function(x) x.ParentTopicID = Me.ID)
        End Get
    End Property
#End Region

#Region "Business Object Setup and Creation"
    Private Shared nextAvailableID As Integer = 0
    Private mDbContext As DBContext
    Private mMapperToDB As Mapper
    Private mDBObject As Topic
    Private Shared mMapperFromDB As Mapper
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
        mDBObject.ID = nextAvailableID
        nextAvailableID -= 1

        mIsDirty = True
        mIsStored = False
        Initialize()
    End Sub

    Shared Function FetchBusinessObjects(dbContext As DBContext, x As Func(Of Topic, Boolean)) As List(Of clsTopic)
        Dim dbobjects As List(Of Topic)
        Dim modelObjects As List(Of clsTopic) = New List(Of clsTopic)
        dbobjects = dbContext.Table(Of Topic).Where(x).ToList()
        For Each item As Topic In dbobjects
            Dim businessObject As New clsTopic(dbContext)
            mMapperFromDB.Map(item, businessObject.mDBObject, GetType(Topic), GetType(Topic))
            businessObject.mIsStored = True
            businessObject.mIsDirty = False
            modelObjects.Add(businessObject)
        Next
        Return modelObjects
    End Function
#End Region

#Region "IBO implementation"
    Private mIsStored As Boolean
    Public ReadOnly Property IsStored As Boolean Implements IBO.IsStored
        Get
            Return mIsStored
        End Get
    End Property

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


    Public Event IBO_Changed() Implements IBO.IBO_Changed

    Public Sub Initialize() Implements IBO.Initialize
        'Add any initialization code here
    End Sub

    Public Function Save() As Boolean Implements IBO.Save
        If Not IsValid() Then
            Throw New Exception("Object cannot be saved as not valid.")
        End If
        'Pre_save custom code begin
        'Pre_save custom code end
        Dim result As Boolean
        Try
            If mIsStored Then
                result = mDbContext.Update(mDBObject)
            Else
                Dim IDCreated As Integer
                result = mDbContext.Save(mDBObject, IDCreated)
                mIsStored = result
            End If
        Catch ex As Exception
            ex.Source = "clsTopic.Save"
            Throw ex
        End Try
        If result Then
            mIsDirty = True
        End If
        'Post_save custom code begin
        'Post_save custom code end
        Return result
    End Function

    Public Function Delete() As Boolean Implements IBO.Delete
        Try
            Return mDbContext.Delete(mDBObject)
        Catch ex As Exception
            ex.Source = "clsTopic.Delete"
            Throw ex
        End Try
    End Function

    Public Function LoadFromStorage() As Boolean Implements IBO.LoadFromStorage
        Throw New NotImplementedException()
    End Function

    Public Function IsValid() As Boolean Implements IBO.IsValid
        Return True
    End Function
#End Region

#Region "Custom Types, members and methods"

#End Region
End Class
