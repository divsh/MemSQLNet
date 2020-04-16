﻿Imports AutoMapper
Imports SQLite
Public Class clsReview
    Implements IBO

    Public Class Review
        Implements IDBObject
        Property MaintTime As String Implements IDBObject.MaintTime
        <PrimaryKey, AutoIncrement>
        Property Id As Integer Implements IDBObject.ID

        <NotNull>
        Property QuestionID As Integer
        <NotNull>
        Property ReviewDateTime As String

        Property Respose As clsQuestion.Recall
    End Class

#Region "Model variables"
    Private Shared nextAvailableID As Integer = 0
    Private mDbContext As DBContext
    Private mMapperToDB As Mapper
    Private mDBObject As Review
    Shared mMapperFromDB As Mapper
#End Region
#Region "Model Properties and associations"
    Dim mID As Integer
    ReadOnly Property Id As Integer
        Get
            Return mDBObject.Id
        End Get
    End Property

    ReadOnly Property MaintTime As Date

    Property Response As clsQuestion.Recall
        Get
            Return mDBObject.Respose
        End Get
        Set(value As clsQuestion.Recall)
            mDBObject.Respose = value
        End Set
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

#End Region

    ReadOnly Property Question As clsQuestion
        Get
            Return clsQuestion.FetchBusinessObjects(mDbContext, Function(x) x.Id = QuestionID).FirstOrDefault()
        End Get
    End Property


    Public ReadOnly Property IsStored As Boolean Implements IBO.IsStored
        Get
            Return mIsStored
        End Get
    End Property

    Public ReadOnly Property IsDirty As Boolean Implements IBO.IsDirty
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public ReadOnly Property IBO_ID As Integer Implements IBO.IBO_ID
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Event IBO_Changed() Implements IBO.IBO_Changed

    Public Sub Initialize() Implements IBO.Initialize
        Throw New NotImplementedException()
    End Sub

    Public Function Save() As Boolean Implements IBO.Save
        If mIsStored Then
            Return mDbContext.Update(mDBObject)
        Else
            Dim IDCreated As Integer
            mDbContext.Save(mDBObject, IDCreated)
            mID = IDCreated
            mIsStored = True
            Return True
        End If
    End Function

    Public Function Delete() As Boolean Implements IBO.Delete
        Return mDbContext.Delete(mDBObject)
    End Function

    Private mIsStored As Boolean
    Public Function LoadFromStorage() As Boolean Implements IBO.LoadFromStorage
        Dim dbObject As Review
        dbObject = FetchBusinessObjects(mDbContext, Function(x) x.Id = IBO_ID).FirstOrDefault().mDBObject
        mMapperFromDB.Map(dbObject, mDBObject)
        If (dbObject IsNot Nothing) Then
            mIsStored = True
            Return True
        End If
        Return False
    End Function

    Public Function IsValid() As Boolean Implements IBO.IsValid
        Throw New NotImplementedException()
    End Function


#Region "Model methods"
    'Private Function DBObject() As Question
    '    Return mMapperToDB.Map(Of Question)(Me)
    'End Function

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
        mDBObject.Id = nextAvailableID
        nextAvailableID -= 1

        mIsStored = False
    End Sub

    Shared Function FetchBusinessObjects(dbContext As DBContext, x As Func(Of Review, Boolean)) As List(Of clsReview)
        'Dim mapConfigFromDB As MapperConfiguration = New MapperConfiguration(Function(ax) ax.CreateMap(Of Question, Question)())
        'Dim mapperFromDB As Mapper = mapConfigFromDB.CreateMapper()
        Dim dbobjects As List(Of Review)
        Dim modelObjects As List(Of clsReview) = New List(Of clsReview)
        dbobjects = dbContext.Table(Of Review).Where(x).ToList()
        For Each item As Review In dbobjects
            Dim modelObj As New clsReview(dbContext)
            mMapperFromDB.Map(item, modelObj.mDBObject, GetType(Review), GetType(Review))
            modelObj.mIsStored = True
            modelObjects.Add(modelObj)
        Next
        Return modelObjects
    End Function

#End Region

#Region "Custom Members"

#End Region
End Class