
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
        Me.Icon = My.Resources.sync
        Me.Text = "Question"
        'setupBulletingOnRichTextControl()
    End Sub

    Private Sub setupBulletingOnRichTextControl()
        rtbAnswer.SelectionBullet = True
        rtbAnswer.SelectionIndent = 8
        rtbAnswer.SelectionRightIndent = 12
        rtbAnswer.SelectionHangingIndent = 3
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
            If mDisplayedQuestion.ID <= 0 Then Return Nothing
            Return mDisplayedQuestion.Topic
            'Return MyPresenter.GetTopic(mDisplayedQuestion.Id)
        End Get
    End Property

    Private mCurrentMode As QuestionViewMode
    Public ReadOnly Property CurrentMode As QuestionViewMode Implements IQuestionView.CurrentMode
        Get
            Return mCurrentMode
        End Get
    End Property

    Public ReadOnly Property LastDisplayedStoredBusinessObject As clsQuestion Implements IQuestionView.LastDisplayedStoredBusinessObject

    Public Sub DisplayBusinessObject(question As clsQuestion) Implements IQuestionView.DisplayBusinessObject
        If question Is Nothing Then Return
        If DisplayedQuestion IsNot Nothing AndAlso DisplayedQuestion.IsStored Then _LastDisplayedStoredBusinessObject = DisplayedQuestion
        Dim currQuestion As clsQuestion
        currQuestion = DisplayedQuestion
        mDisplayedQuestion = question
        txtTopic.Text = DisplayedQuestion.Topic.TopicFullPath
        'txtTopic.Text = If(mDisplayedQuestion.TopicID > 0, MyPresenter.GetTopicFromTopicID(mDisplayedQuestion.TopicID).Name, "")
        txtQuestion.Text = DisplayedQuestion.Name
        txtTimeSinceLastReview.Text = DateDiff(DateInterval.Day, DisplayedQuestion.LastReviewDate, Now).ToString
        txtPrevRecall.Text = Convert.ToInt32(DisplayedQuestion.LastReviewResponse + 1).ToString
        txtTotalReview.Text = DisplayedQuestion.ReviewCount.ToString
        txtAverageRecall.Text = String.Format("{0:F1}", DisplayedQuestion.AverageReviewResponse + 1)
        Try
            rtbAnswer.Rtf = DisplayedQuestion.Answer
        Catch ex As Exception
            rtbAnswer.Rtf = clsQuestion.TextToRTF(DisplayedQuestion.Answer)
        End Try
    End Sub

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

        rtbAnswer.BackColor = Color.White
        txtQuestion.BackColor = Color.White


        Select Case mode
            Case QuestionViewMode.Create
                plnEditMode.Visible = True
                plnEditMode.Enabled = True

                txtQuestion.ReadOnly = False
                rtbAnswer.ReadOnly = False
                txtQuestion.BackColor = Color.LightYellow
                rtbAnswer.BackColor = Color.LightYellow

                rtbAnswer.Show()
                txtQuestion.Focus()
            Case QuestionViewMode.Detail
                plnBrowseMode.Visible = True
                plnBrowseMode.Enabled = True

                txtQuestion.ReadOnly = True
                rtbAnswer.ReadOnly = True
                rtbAnswer.Visible = True
            Case QuestionViewMode.Edit
                plnEditMode.Visible = True
                plnEditMode.Enabled = True

                txtQuestion.ReadOnly = False
                rtbAnswer.ReadOnly = False
                txtQuestion.BackColor = Color.LightYellow
                rtbAnswer.BackColor = Color.LightYellow
            Case QuestionViewMode.Review
                plnReviewMode.Visible = True
                plnReviewMode.Enabled = True

                txtQuestion.ReadOnly = True
                rtbAnswer.ReadOnly = True
                ResetResponse()
                HideAnswer()
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
            MessageBoxEx.Show(ex, "frmQuestionView.Display")
        End Try
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            Logger.Log(Logger.LoggingLevel.Info, "Begin:btnNew_Click")
            MyPresenter.OnNewSelected()
        Catch ex As Exception
            MessageBoxEx.Show(ex, "frmQuestionView.btnNew_Click")
        Finally
            Logger.Log(Logger.LoggingLevel.Info, "End:btnNew_Click")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            DisplayedQuestion.Name = txtQuestion.Text
            DisplayedQuestion.Answer = rtbAnswer.Rtf
            MyPresenter.OnSaveClicked(DisplayedQuestion)
        Catch ex As Exception
            MessageBoxEx.Show(ex, "btnSave_Click")
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            MyPresenter.OnCancelSelected(DisplayedQuestion.Id, CurrentMode)
        Catch ex As Exception
            MessageBoxEx.Show(ex, "frmQuestionView.btnCancel_Click")
        End Try
    End Sub

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Try
            DisplayBusinessObject(mTopicQuestionView.SelectNthRowFromCurrent(-1))
        Catch ex As Exception
            MessageBoxEx.Show(ex, "btnPrev_Click")
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            DisplayBusinessObject(mTopicQuestionView.SelectNthRowFromCurrent(1))
        Catch ex As Exception
            MessageBoxEx.Show(ex, "btnNext_Click")
        End Try
    End Sub

    Private Sub btnReview_Click(sender As Object, e As EventArgs) Handles btnReview.Click
        Logger.Log(Logger.LoggingLevel.Debug, "Begin:btnReview_Click")
        Dim cur As Object = DirectCast(Me, Form).Cursor
        Try
            DirectCast(Me, Form).Cursor = Cursors.WaitCursor
            If DisplayedTopic Is Nothing OrElse DisplayedTopic.ID <= 0 Then Return
            MyPresenter.OnReviewSelected(DisplayedTopic.ID)
            DirectCast(Me, Form).Cursor = DirectCast(cur, Cursor)
        Catch ex As Exception
            MessageBoxEx.Show(ex, "btnReview_Click")
        Finally
            DirectCast(Me, Form).Cursor = DirectCast(cur, Cursor)
            Logger.Log(Logger.LoggingLevel.Debug, "End:btnReview_Click")
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
        Try
            MyPresenter.OnStopReviewSelected()
        Catch ex As Exception
            MessageBoxEx.Show(ex, "btnStop_Click")
        End Try
    End Sub

    Public Sub ResetResponse() Implements IQuestionView.ResetResponse
        optAverage.Checked = False
        optExcellent.Checked = False
        optGood.Checked = False
        optNull.Checked = False
        optPoor.Checked = False
    End Sub

    Private Sub btnShowAnswer_Click(sender As Object, e As EventArgs) Handles btnShowAnswer.Click
        Try
            ShowAnswer()
        Catch ex As Exception
            MessageBoxEx.Show(ex, "btnShowAnswer_Click")
        End Try
    End Sub

    Private Sub optAverage_Click(sender As Object, e As EventArgs) Handles optAverage.Click, optPoor.Click, optNull.Click, optExcellent.Click, optGood.Click
        Dim responseSelected As clsQuestion.Recall
        Try
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
        Catch ex As Exception
            MessageBoxEx.Show(ex, "optAverage_Click")
        End Try
    End Sub

    Private Sub grbResponse_KeyDown(sender As Object, e As KeyEventArgs) Handles grbResponse.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.D5 : optAverage_Click(optExcellent, Nothing)
                Case Keys.D4 : optAverage_Click(optGood, Nothing)
                Case Keys.D3 : optAverage_Click(optAverage, Nothing)
                Case Keys.D2 : optAverage_Click(optPoor, Nothing)
                Case Keys.D1 : optAverage_Click(optNull, Nothing)
                Case Keys.Escape : MyPresenter.OnSkipReviewQuestion()
            End Select
        Catch ex As Exception
            MessageBoxEx.Show(ex, "grbResponse_KeyDown")
        End Try
    End Sub
    Private Sub btnShowAnswer_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles btnShowAnswer.PreviewKeyDown
        If e.KeyCode = Keys.Escape Then
            MyPresenter.OnSkipReviewQuestion()
        End If
    End Sub
    Private Sub grbResponse_GotFocus(sender As Object, e As EventArgs) Handles grbResponse.GotFocus
        Try
            grbResponse.BackColor = Color.Yellow
        Catch ex As Exception
            MessageBoxEx.Show(ex, "grbResponse_GotFocus")
        End Try
    End Sub

    Private Sub grbResponse_LostFocus(sender As Object, e As EventArgs) Handles grbResponse.LostFocus
        Try
            grbResponse.BackColor = Color.BurlyWood
        Catch ex As Exception
            MessageBoxEx.Show(ex, "grbResponse_LostFocus")
        End Try
    End Sub

    Private Sub rtbAnswer_DoubleClick(sender As Object, e As EventArgs) Handles rtbAnswer.DoubleClick
        Try
            If Me.CurrentMode = QuestionViewMode.Review OrElse
                Me.CurrentMode = QuestionViewMode.Edit OrElse
                Me.CurrentMode = QuestionViewMode.Create Then Return

            Dim result As DialogResult
            result = MessageBox.Show("Do you want to edit the question?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If result = DialogResult.Yes Then MyPresenter.onQuestionEditRequest()
        Catch ex As Exception
            MessageBoxEx.Show(ex, "rtbAnswer_DoubleClick")
        End Try
    End Sub

    Public Sub CallQuestionTopicGridRefresh() Implements IQuestionView.CallQuestionTopicGridRefresh
        mTopicQuestionView.RefeshQuestionsGrid(DisplayedQuestion.TopicID)
    End Sub


End Class