Imports WindowsApp1

Public Class QuestionPresenter
    Implements IQuestionPresenter
    Private mDBContext As DBContext
    Private MyView As IQuestionView

    Public Sub New(dbcontext As DBContext, view As IQuestionView)
        mDBContext = dbcontext
        MyView = view
    End Sub

    Public Sub OnSaveClicked(questionID As Integer) Implements IQuestionPresenter.OnSaveClicked
        Throw New NotImplementedException()
    End Sub

    Public Sub OnResponseSelected(questionID As Integer, response As clsQuestion.RecallStrength) Implements IQuestionPresenter.OnResponseSelected
        Throw New NotImplementedException()
    End Sub

    Public Sub OnCancelSelected(questionID As Integer, mode As QuestionViewMode) Implements IQuestionPresenter.OnCancelSelected
        Throw New NotImplementedException()
    End Sub

    Public Sub OnPrevNextSelected(nextQuestionID As Integer) Implements IQuestionPresenter.OnPrevNextSelected
        Throw New NotImplementedException()
    End Sub

    Public Sub OnReviewSelected() Implements IQuestionPresenter.OnReviewSelected
        Throw New NotImplementedException()
    End Sub

    Public Sub OnNewSelected() Implements IQuestionPresenter.OnNewSelected
        Throw New NotImplementedException()
    End Sub

    Public Function getQuestion(questionID As Integer) As clsQuestion Implements IQuestionPresenter.getQuestion
        Throw New NotImplementedException()
    End Function
End Class
