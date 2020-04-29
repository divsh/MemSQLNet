Imports AutoMapper
Imports SQLite
Public Class clsSample
    Implements IBO
    Public Class Sample
        Implements IDBObject
        <PrimaryKey, AutoIncrement>
        Property ID As Integer Implements IDBObject.ID
        <NotNull>
        Property Mainttime As String Implements IDBObject.MaintTime
        '>> Model table columns
        '###Replace with attrbiutes lists###
        '<< Model table columns

    End Class

#Region "Attributes enum types"

#End Region

#Region "Model attributes and associations"
    '>> Model attribues and association for each table column
    '### Replace with properties for each model attributes and associations###
    '>> Model attribues and association for each table column
#End Region

#Region "Business Object Setup and Creation"
    Private Shared nextAvailableID As Integer = 0
    Private mDbContext As DBContext
    Private mMapperToDB As Mapper
    Private mDBObject As Sample
    Private Shared mMapperFromDB As Mapper
    Public Sub New(dbContext As DBContext)
        mDbContext = dbContext
        SetUp()
    End Sub

    Private Sub SetUp()
        Dim mapConfigFromDB As MapperConfiguration = New MapperConfiguration(Function(x) x.CreateMap(Of Sample, Sample)())
        Dim mapConfigToDB As MapperConfiguration = New MapperConfiguration(Function(x) x.CreateMap(Of clsSample, Sample)())
        mMapperFromDB = mapConfigFromDB.CreateMapper()
        mMapperToDB = mapConfigToDB.CreateMapper()

        mDBObject = New Sample()
        mDBObject.ID = nextAvailableID
        nextAvailableID -= 1

        mIsDirty = True
        mIsStored = False
        Initialize()
    End Sub

    Shared Function FetchBusinessObjects(dbContext As DBContext, x As Func(Of Sample, Boolean)) As List(Of clsSample)
        Dim dbobjects As List(Of Sample)
        Dim modelObjects As List(Of clsSample) = New List(Of clsSample)
        dbobjects = dbContext.Table(Of Sample).Where(x).ToList()
        For Each item As Sample In dbobjects
            modelObjects.Add(clsSample.CreateBusinessObject(dbContext, item))
        Next
        Return modelObjects
    End Function

    Public Shared Function CreateBusinessObject(dbcontext As DBContext, ByVal DBObject As Sample) As clsSample
        Dim businessObject As New clsSample(dbcontext)
        mMapperFromDB.Map(DBObject, businessObject.mDBObject, GetType(Sample), GetType(Sample))
        businessObject.mIsStored = True
        businessObject.mIsDirty = False
        Return businessObject
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
            ex.Source = "clsSample.Save"
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
            ex.Source = "clsSample.Delete"
            Throw ex
        End Try
    End Function

    Public Function LoadFromStorage() As Boolean Implements IBO.LoadFromStorage
        Throw New NotImplementedException()
    End Function

    Public Function IsValid() As Boolean Implements IBO.IsValid
        Return True
    End Function

    ReadOnly Property DBObject As Sample
        Get
            Return mDBObject
        End Get
    End Property


#End Region

#Region "Custom Types, members and methods"

#End Region
End Class
