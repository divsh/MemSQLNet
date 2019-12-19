Imports WindowsApp1
Imports AutoMapper
Imports SQLite

Public Class clsReviewInterval
    Implements IBO
    Public Class ReviewInterval
        Implements IDBObject
        Property Sno As Integer
        Property Interval As Integer
        Property Slope As Double
        Property MemoryPercentage As Double
        Public Property MaintTime As String Implements IDBObject.MaintTime
        <PrimaryKey, AutoIncrement>
        Public Property ID As Integer Implements IDBObject.ID
    End Class

    Private mIsStored As Boolean
    Private mIsDirty As Boolean
    Private mDBObject As ReviewInterval

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

    Shared Function FetchBusinessObjects(dbContext As DBContext, x As Func(Of clsQuestion.Question, Boolean)) As List(Of clsQuestion)
        'Dim mapConfigFromDB As MapperConfiguration = New MapperConfiguration(Function(ax) ax.CreateMap(Of Question, Question)())
        'Dim mapperFromDB As Mapper = mapConfigFromDB.CreateMapper()
        Dim dbobjects As List(Of clsQuestion.Question)
        Dim modelObjects As List(Of clsQuestion) = New List(Of clsQuestion)
        dbobjects = dbContext.Table(Of clsQuestion.Question).Where(x).ToList()
        For Each item As clsQuestion.Question In dbobjects
            Dim modelObj As New clsQuestion(dbContext)
            mMapperFromDB.Map(item, modelObj.mDBObject, GetType(clsQuestion.Question), GetType(clsQuestion.Question))
            modelObj.mIsStored = True
            modelObjects.Add(modelObj)
        Next
        Return modelObjects
    End Function
    Public Function IBO_isValid() As Boolean Implements IBO.IBO_isValid
        Throw New NotImplementedException()
    End Function
End Class
