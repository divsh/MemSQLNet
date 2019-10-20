﻿Imports WindowsApp1

Public Class QuestionPresenter
    Implements IQuestionPresenter
    Private mDBContext As DBContext
    Private MyView As IQuestionView
    Private mLastDisplayedQuestion As clsQuestion


    Public Sub New(dbcontext As DBContext, view As IQuestionView)
        mDBContext = dbcontext
        MyView = view
    End Sub

    Public Sub OnResponseSelected(questionID As Integer, response As clsQuestion.RecallStrength) Implements IQuestionPresenter.OnResponseSelected
        Throw New NotImplementedException()
    End Sub

    Public Sub OnCancelSelected(questionID As Integer, mode As QuestionViewMode) Implements IQuestionPresenter.OnCancelSelected
        MyView.SetMode(QuestionViewMode.Detail)
        If MyView.CurrentMode = QuestionViewMode.Create Then
            MyView.DisplayBusinessObject(mLastDisplayedQuestion)
        ElseIf MyView.CurrentMode = QuestionViewMode.Edit Then
            MyView.DisplayBusinessObject(clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.Id = questionID).FirstOrDefault)
        End If
    End Sub

    Public Sub OnPrevNextSelected(nextQuestionID As Integer) Implements IQuestionPresenter.OnPrevNextSelected
        Throw New NotImplementedException()
    End Sub

    Private mReviewPlan As IQuestionReviewPlan
    Public Sub OnReviewSelected(topicID As Integer) Implements IQuestionPresenter.OnReviewSelected
        'Create Question review plan
        MyView.SetMode(QuestionViewMode.Review)
        'mReviewPlan.ReviewPlan.GetEnumerator.MoveNext()
        'MyView.DisplayBusinessObject(mReviewPlan.ReviewPlan.GetEnumerator.Current)
    End Sub


    Public Sub OnNewSelected() Implements IQuestionPresenter.OnNewSelected
        Dim newQuestion As clsQuestion = New clsQuestion(mDBContext)
        newQuestion.TopicID = MyView.DisplayedTopic.Id
        MyView.SetMode(QuestionViewMode.Create)
        MyView.DisplayBusinessObject(newQuestion)
    End Sub

    Public Sub OnSaveClicked(displayedBusinessObject As clsQuestion) Implements IQuestionPresenter.OnSaveClicked
        displayedBusinessObject.Save()
        MyView.SetMode(QuestionViewMode.Detail)
    End Sub

    Public Sub OnDisplayedQuestionChange(lastquestion As clsQuestion) Implements IQuestionPresenter.OnDisplayedQuestionChange
        mLastDisplayedQuestion = lastquestion
    End Sub

    Public Function getQuestion(questionID As Integer) As clsQuestion Implements IQuestionPresenter.getQuestion
        Return clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.Id = questionID).FirstOrDefault
    End Function

    Public Function GetTopic(questionID As Integer) As clsTopic Implements IQuestionPresenter.GetTopic
        Dim t As clsTopic
        Try
            t = clsTopic.FetchBusinessObjects(mDBContext, Function(x) x.ID = clsQuestion.FetchBusinessObjects(mDBContext, Function(y) y.Id = questionID).FirstOrDefault.TopicID).FirstOrDefault
        Catch ex As Exception

        End Try
        Return t
    End Function

    Public Function GetTopicFromTopicID(topicID As Integer) As clsTopic Implements IQuestionPresenter.GetTopicFromTopicID
        Return clsTopic.FetchBusinessObjects(mDBContext, Function(x) x.ID = topicID).FirstOrDefault
    End Function
End Class
