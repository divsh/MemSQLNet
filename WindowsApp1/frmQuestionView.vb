Imports WindowsApp1

Public Class frmQuestionView
    Implements IQuestionView

    Private MyPresenter As IQuestionPresenter
    Public Sub New(dbContext)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        MyPresenter = New QuestionPresenter(dbContext, Me)

    End Sub



    Public ReadOnly Property DisplayedBusinessObject As clsQuestion Implements IQuestionView.DisplayedBusinessObject
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public ReadOnly Property DisplayedBusinessObjectTopic As clsTopic Implements IQuestionView.DisplayedBusinessObjectTopic
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Sub DisplayBusinessObject(question As clsQuestion) Implements IQuestionView.DisplayBusinessObject
        Throw New NotImplementedException()
    End Sub

    Public Sub ChangeState(state As Object) Implements IQuestionView.ChangeState
        Throw New NotImplementedException()
    End Sub

    Public Sub SetMode(mode As QuestionViewMode) Implements IQuestionView.SetMode
        Throw New NotImplementedException()
    End Sub

    Private Sub frmQuestionView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Sub Display(questionID As Integer) Implements IQuestionView.Display
        DisplayedBusinessObject = questionID
        Application.Run(Me)
    End Sub
End Class