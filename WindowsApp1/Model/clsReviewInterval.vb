Imports AutoMapper
Imports SQLite
Public Class clsReviewInterval
    Implements IBO
    Public Class ReviewInterval
        Implements IDBObject
        <PrimaryKey, AutoIncrement, Indexed>
        Property ID As Integer Implements IDBObject.ID
        <NotNull>
        Property MaintTime As String Implements IDBObject.MaintTime
        <NotNull>
        Property SNo As Integer
        <NotNull>
        Property Interval As Integer
        Property Slope As Double
        <NotNull>
        Property SampleCount As Integer
        Property ForRecallStrengthPercentage As Double
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

    Property SNo As Integer
        Get
            Return mDBObject.SNo
        End Get
        Set(value As Integer)
            mDBObject.SNo = value
        End Set
    End Property
    Property Interval As Integer
        Get
            Return mDBObject.Interval
        End Get
        Set(value As Integer)
            mDBObject.Interval = value
        End Set
    End Property
    Property Slope As Double
        Get
            Return mDBObject.Slope
        End Get
        Set(value As Double)
            mDBObject.Slope = value
        End Set
    End Property
    Property SampleCount As Integer
        Get
            Return mDBObject.SampleCount
        End Get
        Set(value As Integer)
            mDBObject.SampleCount = value
        End Set
    End Property
    Property ForRecallStrengthPercentage As Double
        Get
            Return mDBObject.ForRecallStrengthPercentage
        End Get
        Set(value As Double)
            mDBObject.ForRecallStrengthPercentage = value
        End Set
    End Property
#End Region

#Region "Business Object Setup and Creation"
    Private Shared nextAvailableID As Integer = 0
    Private mDbContext As DBContext
    Private mMapperToDB As Mapper
    Private mDBObject As ReviewInterval
    Private Shared mMapperFromDB As Mapper
    Public Sub New(dbContext As DBContext)
        mDbContext = dbContext
        SetUp()
    End Sub

    Private Sub SetUp()
        Dim mapConfigFromDB As MapperConfiguration = New MapperConfiguration(Function(x) x.CreateMap(Of ReviewInterval, ReviewInterval)())
        Dim mapConfigToDB As MapperConfiguration = New MapperConfiguration(Function(x) x.CreateMap(Of clsReviewInterval, ReviewInterval)())
        mMapperFromDB = mapConfigFromDB.CreateMapper()
        mMapperToDB = mapConfigToDB.CreateMapper()

        mDBObject = New ReviewInterval()
        mDBObject.ID = nextAvailableID
        nextAvailableID -= 1

        mIsDirty = True
        mIsStored = False
        Initialize()
    End Sub

    Shared Function FetchBusinessObjects(dbContext As DBContext, x As Func(Of ReviewInterval, Boolean)) As List(Of clsReviewInterval)
        Dim dbobjects As List(Of ReviewInterval)
        Dim modelObjects As List(Of clsReviewInterval) = New List(Of clsReviewInterval)
        dbobjects = dbContext.Table(Of ReviewInterval).Where(x).ToList()
        For Each item As ReviewInterval In dbobjects
            Dim businessObject As New clsReviewInterval(dbContext)
            mMapperFromDB.Map(item, businessObject.mDBObject, GetType(ReviewInterval), GetType(ReviewInterval))
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
            ex.Source = "clsReviewInterval.Save"
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
            ex.Source = "clsReviewInterval.Delete"
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
    ReadOnly Property DBObject As Object
        Get
            Return mDBObject
        End Get
    End Property
    ReadOnly Property Description As String
        Get
            Return "(ID:" & Me.ID.ToString &
               " SNo:" & Me.SNo.ToString &
               " Slope:" & Me.Slope.ToString &
               " Interval:" & Me.Interval.ToString &
               " SampleCount:" & Me.SampleCount &
               ")"
        End Get
    End Property
#End Region
End Class
