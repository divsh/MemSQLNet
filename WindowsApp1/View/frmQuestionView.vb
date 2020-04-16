﻿Imports WindowsApp1

Public Class frmQuestionView
    Implements IQuestionView

    Private mTopicQuestionView As ITopicQuestionView
    Private MyPresenter As IQuestionPresenter
    Public Sub New(dbContext As DBContext, topicQuestionView As ITopicQuestionView)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        initButtonPanels()
        mTopicQuestionView = topicQuestionView
        MyPresenter = New QuestionPresenter(dbContext, Me)

    End Sub
    Private Sub initButtonPanels()
        Dim top, left As Integer
        top = plnBrowseMode.Top
        left = plnBrowseMode.Left

        plnEditMode.Top = top
        plnEditMode.Left = left

        plnReviewMode.Top = top
        plnReviewMode.Left = left
    End Sub


    Dim mDisplayedQuestion As clsQuestion
    Public ReadOnly Property DisplayedQuestion As clsQuestion Implements IQuestionView.DisplayedQuestion
        Get
            Return mDisplayedQuestion
        End Get
    End Property

    Public ReadOnly Property DisplayedTopic As clsTopic Implements IQuestionView.DisplayedTopic
        Get
            If mDisplayedQuestion.Id <= 0 Then Return Nothing
            Return MyPresenter.GetTopic(mDisplayedQuestion.Id)
        End Get
    End Property

    Private mCurrentMode As QuestionViewMode
    Public ReadOnly Property CurrentMode As QuestionViewMode Implements IQuestionView.CurrentMode
        Get
            Return mCurrentMode
        End Get
    End Property

    Public Sub DisplayBusinessObject(question As clsQuestion) Implements IQuestionView.DisplayBusinessObject
        Dim currQuestion As clsQuestion
        currQuestion = DisplayedQuestion
        mDisplayedQuestion = question
        txtTopic.Text = If(mDisplayedQuestion.TopicID > 0, MyPresenter.GetTopicFromTopicID(mDisplayedQuestion.TopicID).Name, "")
        txtQuestion.Text = DisplayedQuestion.Name
        txtTimeSinceLastReview.Text = DateDiff(DateInterval.Day, DisplayedQuestion.LastReviewDate, Now).ToString
        txtPrevRecall.Text = Convert.ToInt32(DisplayedQuestion.LastReviewResponse).ToString
        Try
            rtbAnswer.Rtf = DisplayedQuestion.Answer
        Catch ex As Exception
            rtbAnswer.Rtf = FormatAsRTF(DisplayedQuestion.Answer)
        End Try
        MyPresenter.OnDisplayedQuestionChange(currQuestion)

    End Sub

    Private Function FormatAsRTF(dirtyText As String) As String
        Dim rtf As System.Windows.Forms.RichTextBox = New RichTextBox()
        rtf.Text = dirtyText
        Return rtf.Rtf
    End Function


    Public Sub SetBusinessObjectOnView(question As clsQuestion) Implements IQuestionView.SetBusinessObjectOnView
        mDisplayedQuestion = question
        txtTopic.Text = DisplayedTopic.Name
        txtQuestion.Text = question.Name
        rtbAnswer.Rtf = question.Answer
    End Sub
    Public Sub ChangeState(state As Object) Implements IQuestionView.ChangeState
        Throw New NotImplementedException()
    End Sub

    Public Sub SetMode(mode As QuestionViewMode) Implements IQuestionView.SetMode
        plnEditMode.Visible = False
        plnReviewMode.Visible = False
        plnBrowseMode.Visible = False

        plnEditMode.Enabled = False
        plnReviewMode.Enabled = False
        plnBrowseMode.Enabled = False

        Select Case mode
            Case QuestionViewMode.Create
                plnEditMode.Visible = True
                plnEditMode.Enabled = True

                txtQuestion.ReadOnly = False
                rtbAnswer.ReadOnly = False
                rtbAnswer.Show()
            Case QuestionViewMode.Detail
                plnBrowseMode.Visible = True
                plnBrowseMode.Enabled = True

                txtQuestion.ReadOnly = True
                rtbAnswer.ReadOnly = True
            Case QuestionViewMode.Edit
                plnEditMode.Visible = True
                plnEditMode.Enabled = True

                txtQuestion.ReadOnly = False
                rtbAnswer.ReadOnly = False
            Case QuestionViewMode.Review
                plnReviewMode.Visible = True
                plnReviewMode.Enabled = True

                txtQuestion.ReadOnly = True
                rtbAnswer.ReadOnly = True
        End Select
        mCurrentMode = mode
    End Sub

    Public Sub Display(questionID As Integer) Implements IQuestionView.Display
        Dim q As clsQuestion
        Try
            q = MyPresenter.getQuestion(questionID)
            DisplayBusinessObject(q)
            Me.SetMode(QuestionViewMode.Detail)
            Me.Show()
        Catch ex As Exception
            MessageBox.Show("Err:", ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            MyPresenter.OnNewSelected()
        Catch ex As Exception
            MessageBox.Show("Err:", ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        DisplayedQuestion.Name = txtQuestion.Text
        DisplayedQuestion.Answer = rtbAnswer.Rtf
        MyPresenter.OnSaveClicked(DisplayedQuestion)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            MyPresenter.OnCancelSelected(DisplayedQuestion.Id, CurrentMode)
        Catch ex As Exception
            MessageBox.Show("Err:", ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        DisplayBusinessObject(mTopicQuestionView.SelectNthRowFromCurrent(-1))
        ' MyPresenter.OnPrevNextSelected()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        DisplayBusinessObject(mTopicQuestionView.SelectNthRowFromCurrent(1))
        'MyPresenter.OnPrevNextSelected()
    End Sub

    Private Sub btnReview_Click(sender As Object, e As EventArgs) Handles btnReview.Click
        Try
            If DisplayedTopic Is Nothing OrElse DisplayedTopic.Id <= 0 Then Return
            MyPresenter.OnReviewSelected(DisplayedTopic.Id)
        Catch ex As Exception
            MessageBox.Show("Err:" & ex.Message)
        End Try
    End Sub

    Public Sub HideAnswer() Implements IQuestionView.HideAnswer
        rtbAnswer.Hide()
        btnShowAnswer.Show()
        btnShowAnswer.Focus()
        grbResponse.Hide()
    End Sub

    Public Sub ShowAnswer() Implements IQuestionView.ShowAnswer
        rtbAnswer.Show()
        btnShowAnswer.Hide()
        grbResponse.Show()
        grbResponse.Focus()
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        MyPresenter.OnStopReviewSelected()
    End Sub

    Public Sub ResetResponse() Implements IQuestionView.ResetResponse
        optAverage.Checked = False
        optExcellent.Checked = False
        optGood.Checked = False
        optNull.Checked = False
        optPoor.Checked = False
    End Sub

    Private Sub btnShowAnswer_Click(sender As Object, e As EventArgs) Handles btnShowAnswer.Click
        ShowAnswer()
    End Sub

    Private Sub optAverage_Click(sender As Object, e As EventArgs) Handles optAverage.Click, optPoor.Click, optNull.Click, optExcellent.Click, optGood.Click
        Dim responseSelected As clsQuestion.Recall
        Select Case DirectCast(sender, Control).Name
            Case "optAverage"
                responseSelected = clsQuestion.Recall.Average
            Case "optPoor"
                responseSelected = clsQuestion.Recall.Poor
            Case "optNull"
                responseSelected = clsQuestion.Recall.Null
            Case "optExcellent"
                responseSelected = clsQuestion.Recall.Best
            Case "optGood"
                responseSelected = clsQuestion.Recall.Good
        End Select
        MyPresenter.OnResponseSelected(DisplayedQuestion, responseSelected)
    End Sub

    Private Sub grbResponse_KeyDown(sender As Object, e As KeyEventArgs) Handles grbResponse.KeyDown
        Select Case e.KeyCode
            Case Keys.D5 : optAverage_Click(optExcellent, Nothing)
            Case Keys.D4 : optAverage_Click(optGood, Nothing)
            Case Keys.D3 : optAverage_Click(optAverage, Nothing)
            Case Keys.D2 : optAverage_Click(optPoor, Nothing)
            Case Keys.D1 : optAverage_Click(optNull, Nothing)
        End Select
    End Sub

    Private Sub grbResponse_GotFocus(sender As Object, e As EventArgs) Handles grbResponse.GotFocus
        grbResponse.BackColor = Color.Yellow
    End Sub

    Private Sub grbResponse_LostFocus(sender As Object, e As EventArgs) Handles grbResponse.LostFocus
        grbResponse.BackColor = Color.BurlyWood
    End Sub
End Class