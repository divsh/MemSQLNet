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
    Private mFakeReviewPlan As List(Of clsQuestion)
    Private mCurrentQuestionOnReviewPlan As Integer = -1
    Private mQuestionReviewList As List(Of clsQuestion)
    Private mQuestionReviewListEnumerator As IEnumerator

    Public Sub OnReviewSelected_Old(topicID As Integer)
        If mFakeReviewPlan Is Nothing Then
            mFakeReviewPlan = clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.TopicID = topicID)
        End If
        mCurrentQuestionOnReviewPlan += 1

        'todo: index out of bound exception may happen
        MyView.DisplayBusinessObject(mFakeReviewPlan.Item(mCurrentQuestionOnReviewPlan))
        MyView.HideAnswer()
        MyView.SetMode(QuestionViewMode.Review)
        Return
        'Create Question review plan
        MyView.SetMode(QuestionViewMode.Review)
        mReviewPlan.ReviewPlan.GetEnumerator.MoveNext()
        MyView.HideAnswer()
        MyView.DisplayBusinessObject(mReviewPlan.ReviewPlan.GetEnumerator.Current)

    End Sub

    Public Sub OnReviewSelected(topicID As Integer) Implements IQuestionPresenter.OnReviewSelected
        mQuestionReviewList = getQuestionsOverdueForReview()
        mQuestionReviewListEnumerator = mQuestionReviewList.GetEnumerator()
        If mQuestionReviewListEnumerator.MoveNext() Then
            MyView.DisplayBusinessObject(mQuestionReviewListEnumerator.Current)
        End If

        'todo: index out of bound exception may happen
        ' MyView.DisplayBusinessObject(mFakeReviewPlan.Item(mCurrentQuestionOnReviewPlan))
        MyView.HideAnswer()
        MyView.SetMode(QuestionViewMode.Review)
        Return
    End Sub

    Private Function getQuestionsOverdueForReview() As List(Of clsQuestion)
        Dim result As List(Of clsQuestion)
        'fetch overdue to review questions 
        result = clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.NextReviewIntervalSNo = 0 OrElse Convert.ToDateTime(x.LastReviewDate).AddDays(clsReviewInterval.FetchBusinessObjects(mDBContext, Function(y) y.Sno = x.NextReviewIntervalSNo).FirstOrDefault().Interval) >= Today)
        clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.RecallStrength.Null).ForEach(Sub(y) If Not result.Exists(Function(x) x.Id = y.Id) Then result.Add(y))
        clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.RecallStrength.Poor).ForEach(Sub(y) If Not result.Exists(Function(x) x.Id = y.Id) Then result.Add(y))
        clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.RecallStrength.Average).ForEach(Sub(y) If Not result.Exists(Function(x) x.Id = y.Id) Then result.Add(y))
        clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.RecallStrength.Good).ForEach(Sub(y) If Not result.Exists(Function(x) x.Id = y.Id) Then result.Add(y))
        Return result
    End Function

    Public Sub OnResponseSelected(question As IBO, response As clsQuestion.RecallStrength) Implements IQuestionPresenter.OnResponseSelected
        If mQuestionReviewListEnumerator Is Nothing Then Return
        Dim q As clsQuestion = DirectCast(question, clsQuestion)

        'Save Review Response To Review table
        Dim rr As clsReview = New clsReview(mDBContext)
        rr.QuestionID = q.Id
        rr.Response = response
        rr.ReviewDateTime = Date.Now
        rr.Save()
        MyView.ResetResponse()
        MyView.HideAnswer()


        UpdateAdjustReviewScheduleAndInterval(q, response)


        If mQuestionReviewListEnumerator.MoveNext() Then
            MyView.DisplayBusinessObject(mQuestionReviewListEnumerator.Current)
        Else
            MessageBox.Show("Alert", "Review Completes! The Review will stop now.")
            OnStopReviewSelected()
        End If
    End Sub

    Private Sub UpdateAdjustReviewScheduleAndInterval(question As clsQuestion, response As clsQuestion.RecallStrength)
        If response >= 4 Then
            question.LastReviewDate = Now
            question.LastReviewResponse = response
            question.Save()
            Return
        End If
        If question.NextReviewIntervalSNo = 0 Then
            question.NextReviewIntervalSNo += 1
        Else
            'Update Next Review schedules and adjust Review Inervals
            'Calculate Slope(M)
            Dim m As Double
            Dim ri As Integer
            m = (100 - (Convert.ToInt32(response) * 100) / 5) / DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today)
            ri = 20 / m

            Dim revInt As clsReviewInterval
            revInt = clsReviewInterval.FetchBusinessObjects(mDBContext, Function(x) x.Sno = question.NextReviewIntervalSNo).FirstOrDefault()
            Dim NewRi As Integer
            NewRi = (revInt.Interval * revInt.TotalSample + ri) / (revInt.TotalSample + 1)
            revInt.Interval = NewRi
            revInt.Slope = m

            Dim totalJumpedInterval As Integer
            If DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today) > revInt.Interval Then
                'post-Term
                Dim daysGap As Integer = DateDiff(DateInterval.Day, question.LastReviewDate, Today)
                Dim rTmp As List(Of clsReviewInterval)
                rTmp = clsReviewInterval.FetchBusinessObjects(mDBContext, Function(x) x.Sno >= question.NextReviewIntervalSNo)

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
            Else
                question.NextReviewIntervalSNo += 1
            End If
            revInt.TotalSample += 1
            revInt.Save()
        End If
        question.LastReviewDate = Now
        question.LastReviewResponse = response
        question.Save()
    End Sub

    Public Sub OnResponseSelected_old(questionID As Integer, response As clsQuestion.RecallStrength)
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

    Public Sub OnStopReviewSelected() Implements IQuestionPresenter.OnStopReviewSelected
        MyView.SetMode(QuestionViewMode.Detail)
    End Sub
End Class
