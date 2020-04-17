Imports AutoMapper
Imports SQLite
Public Class clsReview
    Implements IBO
    Public Class Review
        Implements IDBObject
        <PrimaryKey, AutoIncrement, Indexed>
        Property ID As Integer Implements IDBObject.ID
        <NotNull>
        Property MaintTime As String Implements IDBObject.MaintTime
        <NotNull>
        Property ReviewDateTime As String
        <NotNull, Indexed>
        Property QuestionID As Integer
        <NotNull>
        Property Response As Integer

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

    Property ReviewDateTime As Date
        Get
            Return Convert.ToDateTime(mDBObject.ReviewDateTime)
        End Get
        Set(value As Date)
            mDBObject.ReviewDateTime = value.ToString
        End Set
    End Property
    Property QuestionID As Integer
        Get
            Return mDBObject.QuestionID
        End Get
        Set(value As Integer)
            mDBObject.QuestionID = value
        End Set
    End Property

    ReadOnly Property Question As clsQuestion
        Get
            Return clsQuestion.FetchBusinessObjects(mDbContext, Function(x) x.ID = Me.QuestionID).FirstOrDefault
        End Get
    End Property

    Property Response As clsQuestion.Recall
        Get
            Return mDBObject.Response
        End Get
        Set(value As clsQuestion.Recall)
            mDBObject.Response = value
        End Set
    End Property
#End Region

#Region "Business Object Setup and Creation"
    Private Shared nextAvailableID As Integer = 0
    Private mDbContext As DBContext
    Private mMapperToDB As Mapper
    Private mDBObject As Review
    Private Shared mMapperFromDB As Mapper
    Public Sub New(dbContext As DBContext)
        mDbContext = dbContext
        SetUp()
    End Sub

    Private Sub SetUp()
        Dim mapConfigFromDB As MapperConfiguration = New MapperConfiguration(Function(x) x.CreateMap(Of Review, Review)())
        Dim mapConfigToDB As MapperConfiguration = New MapperConfiguration(Function(x) x.CreateMap(Of clsReview, Review)())
        mMapperFromDB = mapConfigFromDB.CreateMapper()
        mMapperToDB = mapConfigToDB.CreateMapper()

        mDBObject = New Review()
        mDBObject.ID = nextAvailableID
        nextAvailableID -= 1

        mIsDirty = True
        mIsStored = False
        Initialize()
    End Sub

    Shared Function FetchBusinessObjects(dbContext As DBContext, x As Func(Of Review, Boolean)) As List(Of clsReview)
        Dim dbobjects As List(Of Review)
        Dim modelObjects As List(Of clsReview) = New List(Of clsReview)
        dbobjects = dbContext.Table(Of Review).Where(x).ToList()
        For Each item As Review In dbobjects
            Dim businessObject As New clsReview(dbContext)
            mMapperFromDB.Map(item, businessObject.mDBObject, GetType(Review), GetType(Review))
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
            ex.Source = "clsReview.Save"
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
            ex.Source = "clsReview.Delete"
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
