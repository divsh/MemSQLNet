Imports Mem
Public Class QuestionPresenter
    Implements IQuestionPresenter
    Private mDBContext As DBContext
    Private MyView As IQuestionView
    Private mLastDisplayedQuestion As clsQuestion


    Public Sub New(dbcontext As DBContext, view As IQuestionView)
        mDBContext = dbcontext
        MyView = view
    End Sub

    Public Sub OnCancelSelected(questionID As Integer, mode As QuestionViewMode) Implements IQuestionPresenter.OnCancelSelected
        If MyView.CurrentMode = QuestionViewMode.Create OrElse MyView.CurrentMode = QuestionViewMode.Edit Then
            MyView.DisplayBusinessObject(MyView.LastDisplayedStoredBusinessObject)
        ElseIf MyView.CurrentMode = QuestionViewMode.Edit Then
            MyView.DisplayBusinessObject(clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.ID = questionID).FirstOrDefault)
        End If
        MyView.SetMode(QuestionViewMode.Detail)
    End Sub

    Public Sub OnPrevNextSelected(nextQuestionID As Integer) Implements IQuestionPresenter.OnPrevNextSelected
        Throw New NotImplementedException()
    End Sub

    Private mReviewPlan As IQuestionReviewPlan
    Private mFakeReviewPlan As List(Of clsQuestion)
    Private mCurrentQuestionOnReviewPlan As Integer = -1
    Private mQuestionReviewList As List(Of clsQuestion)
    Private mQuestionReviewListEnumerator As IEnumerator
    Private mLastOverDueQuestionID As Integer
    Private mLastOverDueQuestionPlayed As Boolean = False
    Private mUserSelectedToKeepReviewing As Boolean = False

    Private mReviewPlanner As ReviewPlanner

    Public Sub OnReviewSelected(topicID As Integer) Implements IQuestionPresenter.OnReviewSelected
        mReviewPlanner = New ReviewPlanner(mDBContext, appendNonOverdueQuestions:=True)
        mUserConfirmedExtraQuestions = False
        displayNextReviewQuestion()
    End Sub

    Private Function getQuestionsOverdueForReview() As List(Of clsQuestion)
        Dim result As List(Of clsQuestion)
        'fetch overdue to review questions 
        result = clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.NextReviewIntervalSNo = 0 OrElse Convert.ToDateTime(x.LastReviewDate).AddDays(clsReviewInterval.FetchBusinessObjects(mDBContext, Function(y) y.SNo = x.NextReviewIntervalSNo).FirstOrDefault().Interval) >= Today)
        mLastOverDueQuestionID = result.LastOrDefault().ID

        clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.Recall.Null).ForEach(Sub(y) If Not result.Exists(Function(x) x.ID = y.ID) Then result.Add(y))
        clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.Recall.Poor).ForEach(Sub(y) If Not result.Exists(Function(x) x.ID = y.ID) Then result.Add(y))
        clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.Recall.Average).ForEach(Sub(y) If Not result.Exists(Function(x) x.ID = y.ID) Then result.Add(y))
        clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.Recall.Good).ForEach(Sub(y) If Not result.Exists(Function(x) x.ID = y.ID) Then result.Add(y))
        Return result
    End Function

    Private mUserConfirmedExtraQuestions As Boolean
    Public Sub OnResponseSelected(question As IBO, response As clsQuestion.Recall) Implements IQuestionPresenter.OnResponseSelected
        mReviewPlanner.updateUserResponse(DirectCast(question, clsQuestion), response)
        displayNextReviewQuestion()
    End Sub
    Private Sub displayNextReviewQuestion()
        Dim nextQ As clsQuestion = mReviewPlanner.fetchNextQuestionForReview
        If nextQ Is Nothing Then
            MessageBox.Show("Review Completes! The Review will stop now.", "Information!")
            OnStopReviewSelected()
        ElseIf mReviewPlanner.LastOverDuedQuetionFetched Then
            If mUserConfirmedExtraQuestions Then
                displayQuestionForReview(nextQ)
            Else
                Dim user As DialogResult
                user = MessageBox.Show("All overdued question reviewed. Do you still want to keep om reviewing?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                If user = DialogResult.No Then
                    OnStopReviewSelected()
                Else
                    mUserConfirmedExtraQuestions = True
                    displayQuestionForReview(nextQ)
                End If
            End If
        Else
            displayQuestionForReview(nextQ)
        End If
    End Sub

    Public Sub OnSkipReviewQuestion() Implements IQuestionPresenter.OnSkipReviewQuestion
        displayNextReviewQuestion()
    End Sub

    Private Sub displayQuestionForReview(ByVal question As clsQuestion)
        MyView.SetMode(QuestionViewMode.Review)
        MyView.DisplayBusinessObject(question)
    End Sub

    Private Sub displayNextQuestion()
        Dim nextQ As clsQuestion = mReviewPlanner.fetchNextQuestionForReview
        If nextQ Is Nothing Then
            MessageBox.Show("Review Completes! The Review will stop now.", "Information!")
            OnStopReviewSelected()
        Else
            displayQuestionForReview(nextQ)
        End If
    End Sub
    Private muserResponse As Boolean = False
    Private malreadyPrompted As Boolean = False

    Function askUserContinueReviewingPastOverDue() As Boolean

        If Not mLastOverDueQuestionPlayed Then Return True
        If malreadyPrompted Then Return muserResponse
        If mLastOverDueQuestionPlayed Then
            mLastOverDueQuestionPlayed = True

            Dim user As DialogResult
            user = MessageBox.Show("All overdued question reviewed. Do you still want to keep om reviewing?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
            If user = DialogResult.No Then
                muserResponse = False
            Else
                muserResponse = True
            End If

            malreadyPrompted = True
            Return muserResponse
        End If

    End Function


    ''' <summary>
    ''' Save this instance of review to Review table
    ''' </summary>
    Private Sub saveReviewInstance(question As clsQuestion, response As clsQuestion.Recall)
        Dim rr As clsReview = New clsReview(mDBContext)
        rr.QuestionID = question.ID
        rr.Response = response
        rr.ReviewDateTime = Date.Now
        rr.Save()
    End Sub

    ''' <summary>
    ''' Adjust the slope and review interval and schedule next review interval on the question
    ''' </summary>
    Private Sub UpdateAdjustReviewScheduleAndInterval(question As clsQuestion, response As clsQuestion.Recall)
        If response >= 4 Then
            question.LastReviewDate = Now
            question.LastReviewResponse = response
            If question.NextReviewIntervalSNo = 0 Then question.NextReviewIntervalSNo += 1
            question.Save()
            Return
        End If
        If question.NextReviewIntervalSNo = 0 Then
            question.NextReviewIntervalSNo += 1
        ElseIf DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today) > 0 Then

            'Calculate Slope(M)a and review interval(Ri)
            Dim m As Double
            Dim ri As Integer
            m = (100 - (Convert.ToInt32(response) * 100) / 5) / DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today)
            ri = 20 / m

            Dim revInt As clsReviewInterval
            revInt = clsReviewInterval.FetchBusinessObjects(mDBContext, Function(x) x.SNo = question.NextReviewIntervalSNo).FirstOrDefault()
            Dim NewRi As Integer
            NewRi = (revInt.Interval * revInt.SampleCount + ri) / (revInt.SampleCount + 1)
            revInt.Interval = NewRi
            revInt.Slope = m
            revInt.SampleCount += 1
            revInt.Save()

            'Schedule next review on the question.
            If DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today) > revInt.Interval Then
                'Post-term review
                Dim daysGap As Integer = DateDiff(DateInterval.Day, question.LastReviewDate, Today)
                Dim rTmp As List(Of clsReviewInterval)
                rTmp = clsReviewInterval.FetchBusinessObjects(mDBContext, Function(x) x.SNo >= question.NextReviewIntervalSNo)

                Dim totalJumpedInterval As Integer
                Dim sumOfDays As Integer = 0
                For Each r As clsReviewInterval In rTmp
                    sumOfDays += r.Interval
                    If daysGap > sumOfDays Then
                        totalJumpedInterval += 1
                    Else
                        Exit For
                    End If
                Next
                If question.NextReviewIntervalSNo - totalJumpedInterval <= 0 Then
                    question.NextReviewIntervalSNo = 1
                Else
                    question.NextReviewIntervalSNo -= totalJumpedInterval
                End If
            Else 'Pre-term review

                'This review must be after previous interval for question to progress to next review interval
                revInt = clsReviewInterval.FetchBusinessObjects(mDBContext, Function(x) x.SNo = question.NextReviewIntervalSNo).FirstOrDefault()
                If DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today) >= revInt.Interval Then
                    question.NextReviewIntervalSNo += 1
                End If
            End If
        End If

        'update the question
        question.LastReviewDate = Now
        question.LastReviewResponse = response
        question.Save()
    End Sub

    Public Sub OnResponseSelected_old(questionID As Integer, response As clsQuestion.Recall)
        mCurrentQuestionOnReviewPlan += 1
        If mCurrentQuestionOnReviewPlan > mFakeReviewPlan.Count - 1 Then Return

        'Save Review Response To Review table
        Dim rr As clsReview = New clsReview(mDBContext)
        rr.QuestionID = questionID
        rr.Response = response
        rr.ReviewDateTime = Date.Now
        rr.Save()
        MyView.ResetResponse()
        MyView.HideAnswer()

        MyView.DisplayBusinessObject(mFakeReviewPlan.Item(mCurrentQuestionOnReviewPlan))
        Return
        mReviewPlan.ReviewPlan.GetEnumerator.MoveNext()
        MyView.ResetResponse()
        mReviewPlan.ReviewPlan.GetEnumerator.MoveNext()
        MyView.HideAnswer()
        MyView.DisplayBusinessObject(mReviewPlan.ReviewPlan.GetEnumerator.Current)
    End Sub

    Public Sub OnNewSelected() Implements IQuestionPresenter.OnNewSelected
        Dim newQuestion As clsQuestion = New clsQuestion(mDBContext)
        newQuestion.TopicID = MyView.DisplayedTopic.ID
        MyView.SetMode(QuestionViewMode.Create)
        MyView.DisplayBusinessObject(newQuestion)
    End Sub


    Public Sub OnSaveClicked(displayedBusinessObject As clsQuestion) Implements IQuestionPresenter.OnSaveClicked
        displayedBusinessObject.Save()
        MyView.SetMode(QuestionViewMode.Detail)
        MyView.CallQuestionTopicGridRefresh()

    End Sub

    Public Function getQuestion(questionID As Integer) As clsQuestion Implements IQuestionPresenter.getQuestion
        Return clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.ID = questionID).FirstOrDefault
    End Function

    Public Function GetTopic(questionID As Integer) As clsTopic Implements IQuestionPresenter.GetTopic
        Dim t As clsTopic
        Try
            t = clsTopic.FetchBusinessObjects(mDBContext, Function(x) x.ID = clsQuestion.FetchBusinessObjects(mDBContext, Function(y) y.ID = questionID).FirstOrDefault.TopicID).FirstOrDefault
        Catch ex As Exception

        End Try
        Return t
    End Function
    Public Function GetTopicFromTopicID(topicID As Integer) As clsTopic Implements IQuestionPresenter.GetTopicFromTopicID
        Return clsTopic.FetchBusinessObjects(mDBContext, Function(x) x.ID = topicID).FirstOrDefault
    End Function

    Public Sub OnStopReviewSelected() Implements IQuestionPresenter.OnStopReviewSelected
        MyView.SetMode(QuestionViewMode.Detail)
    End Sub

    Public Sub onQuestionEditRequest() Implements IQuestionPresenter.onQuestionEditRequest
        MyView.SetMode(QuestionViewMode.Edit)
    End Sub

End Class
