Imports AutoMapper
Imports SQLite

Public Class clsQuestion
    Implements IBO
    Public Class Question
        Implements IDBObject

        <PrimaryKey, AutoIncrement, Indexed>
        Property ID As Integer Implements IDBObject.ID
        <NotNull>
        Property MaintTime As String Implements IDBObject.MaintTime
        <NotNull>
        Property Name As String
        Property Answer As String
        Property AnswerText As String
        <NotNull, Indexed>
        Property TopicID As Integer
        Property LastReviewDate As String
        Property LastReviewResponse As Integer
        Property NextReviewIntervalSNo As Integer
        Property ReviewCount As Integer
        Property AverageReviewResponse As Double
    End Class

#Region "Attributes enum types"
    Public Enum Recall
        Null
        Poor
        Average
        Good
        Best
    End Enum
#End Region

#Region "Business Object Setup and Creation"
    Private Shared nextAvailableID As Integer = 0
    Private mDbContext As DBContext
    Private mMapperToDB As Mapper
    Private mDBObject As Question
    Private Shared mMapperFromDB As Mapper
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
        mDBObject.ID = nextAvailableID
        nextAvailableID -= 1

        mIsDirty = True
        mIsStored = False
        Initialize()
    End Sub

    Shared Function FetchBusinessObjects(dbContext As DBContext, x As Func(Of Question, Boolean)) As List(Of clsQuestion)
        Dim dbobjects As List(Of Question)
        Dim modelObjects As List(Of clsQuestion) = New List(Of clsQuestion)
        dbobjects = dbContext.Table(Of Question).Where(x).ToList()
        For Each item As Question In dbobjects
            Dim businessObject As New clsQuestion(dbContext)
            mMapperFromDB.Map(item, businessObject.mDBObject, GetType(Question), GetType(Question))
            businessObject.mIsStored = True
            businessObject.mIsDirty = False
            modelObjects.Add(businessObject)
        Next
        Return modelObjects
    End Function
#End Region

#Region "Model attributes and associations"
    ReadOnly Property ID As Integer
        Get
            Return mDBObject.ID
        End Get
    End Property

    ReadOnly Property MaintTime As String
        Get
            Return Convert.ToDateTime(mDBObject.MaintTime) 'todo: what to return if string is null/empty
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

    Property Answer As String
        Get
            Return mDBObject.Answer
        End Get
        Set(value As String)
            mDBObject.Answer = value
            mDBObject.AnswerText = RTFToText(value)
        End Set
    End Property
    ReadOnly Property AnswerText As String
        Get
            Return mDBObject.AnswerText
        End Get
    End Property
    Property TopicID As Integer
        Get
            Return mDBObject.TopicID
        End Get
        Set(value As Integer)
            mDBObject.TopicID = value
        End Set
    End Property

    ReadOnly Property Topic As clsTopic
        Get
            Return clsTopic.FetchBusinessObjects(mDbContext, Function(x) x.ID = TopicID).FirstOrDefault
        End Get
    End Property

    Property LastReviewDate As Date
        Get
            Return Convert.ToDateTime(mDBObject.LastReviewDate)
        End Get
        Set(value As Date)
            mDBObject.LastReviewDate = value.ToString()
        End Set
    End Property

    Property LastReviewResponse As Recall
        Get
            Return mDBObject.LastReviewResponse
        End Get
        Set(value As Recall)
            mDBObject.LastReviewResponse = value
        End Set
    End Property

    Property NextReviewIntervalSNo As Integer
        Get
            Return mDBObject.NextReviewIntervalSNo
        End Get
        Set(value As Integer)
            mDBObject.NextReviewIntervalSNo = value
        End Set
    End Property

    Property ReviewCount As Integer
        Get
            Return mDBObject.ReviewCount
        End Get
        Set(value As Integer)
            mDBObject.ReviewCount = value
        End Set
    End Property
    Property AverageReviewResponse As Double
        Get
            Return mDBObject.AverageReviewResponse
        End Get
        Set(value As Double)
            mDBObject.AverageReviewResponse = value
        End Set
    End Property
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
            ex.Source = "clsQuestion.Save"
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
            ex.Source = "clsQuestion.Delete"
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
    Public Shared Function RTFToText(RtfText As String) As String
        Dim rtf As System.Windows.Forms.RichTextBox = New RichTextBox()
        rtf.Rtf = RtfText
        Return rtf.Text
    End Function

    Public Shared Function TextToRTF(NormalText As String) As String
        Dim rtf As System.Windows.Forms.RichTextBox = New RichTextBox()
        rtf.Text = NormalText
        Return rtf.Rtf
    End Function

    ReadOnly Property DBObject As Object
        Get
            Return mDBObject
        End Get
    End Property

    ReadOnly Property Description As String
        Get
            Return "ID:" & Me.ID.ToString &
                " ReviewCount:" & Me.ReviewCount.ToString &
                " NextReviewIntervalSNo:" & Me.NextReviewIntervalSNo.ToString &
            " ReviewCount:" & Me.ReviewCount.ToString &
            " AverageReviewResponse:" & Me.AverageReviewResponse.ToString &
            " LastReviewDate:" & Me.LastReviewDate.ToString &
            " LastReviewResponse:" & Me.LastReviewResponse.ToString() &
            ")"
        End Get
    End Property

    ReadOnly Property DBContext As DBContext
        Get
            Return mDbContext
        End Get
    End Property
#End Region
End Class
