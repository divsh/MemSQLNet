Imports WindowsApp1
Imports AutoMapper
Imports SQLite

Public Class clsReviewInterval
    Implements IBO
    Public Class ReviewInterval
        Implements IDBObject
        Public Property MaintTime As String Implements IDBObject.MaintTime
        <primarykey, autoincrement>
        Public Property ID As Integer Implements IDBObject.ID

        Property Sno As Integer
        <notnull>
        Property Interval As Integer
        Property Slope As Double
        Property MemoryPercentage As Double

    End Class


#Region "Model variables"
    Private Shared nextAvailableID As Integer = 0
    Private mDbContext As DBContext
    Private mMapperToDB As Mapper
    Private mDBObject As ReviewInterval
    Shared mMapperFromDB As Mapper
#End Region

    Private mIsStored As Boolean
    Private mIsDirty As Boolean

    Dim mID As Integer
    ReadOnly Property Id As Integer
        Get
            Return mDBObject.ID
        End Get
    End Property

    Property SNo As Integer
        Get
            Return mDBObject.Sno
        End Get
        Set(value As Integer)
            mDBObject.Sno = value
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
    Property MemoryPercentage As Double

    Public ReadOnly Property IBO_isStored As Boolean Implements IBO.IBO_isStored
        Get
            Return mIsStored
        End Get
    End Property

    Public ReadOnly Property IBO_dirty As Boolean Implements IBO.IBO_dirty
        Get
            Return mIsDirty
        End Get
    End Property

    Public ReadOnly Property IBO_Id As Integer Implements IBO.IBO_Id
        Get
            Return mDBObject.ID
        End Get
    End Property

    Public Event IBO_Changed() Implements IBO.IBO_Changed

    Public Sub IBO_Initialize() Implements IBO.IBO_Initialize
        Throw New NotImplementedException()
    End Sub

    Public Function IBO_Save() As Boolean Implements IBO.IBO_Save
        Throw New NotImplementedException()
    End Function

    Public Function IBO_Delete() As Boolean Implements IBO.IBO_Delete
        Throw New NotImplementedException()
    End Function

    Public Function IBO_loadFromStorage() As Boolean Implements IBO.IBO_loadFromStorage
        Dim dbObject As ReviewInterval
        dbObject = FetchBusinessObjects(mDbContext, Function(x) x.Id = IBO_Id).FirstOrDefault().mDBObject
        mMapperFromDB.Map(dbObject, mDBObject)
        If (dbObject IsNot Nothing) Then
            mIsStored = True
            Return True
        End If
        Return False
    End Function

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

        mIsStored = False
    End Sub


    Shared Function FetchBusinessObjects(dbContext As DBContext, x As Func(Of ReviewInterval, Boolean)) As List(Of clsReviewInterval)
        'Dim mapConfigFromDB As MapperConfiguration = New MapperConfiguration(Function(ax) ax.CreateMap(Of Question, Question)())
        'Dim mapperFromDB As Mapper = mapConfigFromDB.CreateMapper()
        Dim dbobjects As List(Of ReviewInterval)
        Dim modelObjects As List(Of clsReviewInterval) = New List(Of clsReviewInterval)
        dbobjects = dbContext.Table(Of ReviewInterval).Where(x).ToList()
        For Each item As ReviewInterval In dbobjects
            Dim modelObj As New clsReviewInterval(dbContext)
            mMapperFromDB.Map(item, modelObj.mDBObject, GetType(ReviewInterval), GetType(ReviewInterval))
            modelObj.mIsStored = True
            modelObjects.Add(modelObj)
        Next
        Return modelObjects
    End Function
    Public Function IBO_isValid() As Boolean Implements IBO.IBO_isValid
        Throw New NotImplementedException()
    End Function
End Class
