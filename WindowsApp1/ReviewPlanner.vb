
''' <summary>
''' This class contains implementation for space repeatation algorithm.
''' provides the right sequence the questions should be studied for effective memorization.
''' it adjust/update the review interval based on user recall pattern of questions
''' </summary>
Public Class ReviewPlanner
    Private mDBContext As DBContext
    Private mReviewQuestionEnumarator As IEnumerator
    Private mLastOverDueQuestionID As Integer
    Private Const RECALL_PERCENTAGE_DESIRED As Integer = 80

    ReadOnly Property QuestionsToReviewCount As Integer
    ReadOnly Property QuestionsFetchedCount As Integer
    ReadOnly Property ReviewQuestions As List(Of clsQuestion)

    ReadOnly Property LastOverDuedQuetionFetched As Boolean
    Sub New(dbContext As DBContext, appendNonOverdueQuestions As Boolean)
        mDBContext = dbContext
        buildQuestionsOverdueForReview(appendNonOverdueQuestions)
    End Sub
    Private Sub buildQuestionsOverdueForReview(appendNonOverdueQuestions As Boolean)
        'review question are arranged in order
        ' all never reviewed questions then,
        ' all overdue question arranged with highest nextReviewIntervalSNo on top then,
        ' all underdue question in with lowest recall response on top.
        Dim result As List(Of clsQuestion)
        Dim arrangedResult As List(Of clsQuestion) = New List(Of clsQuestion)
        'fetch overdue to review questions 
        result = clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.NextReviewIntervalSNo = 0 OrElse Convert.ToDateTime(x.LastReviewDate).AddDays(clsReviewInterval.FetchBusinessObjects(mDBContext, Function(y) y.SNo = x.NextReviewIntervalSNo).FirstOrDefault().Interval) >= Today)
        arrangedResult = Utility.Shuffle(Of clsQuestion)(clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.NextReviewIntervalSNo = 0))
        result = clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewDate IsNot Nothing AndAlso Convert.ToDateTime(x.LastReviewDate).AddDays(clsReviewInterval.FetchBusinessObjects(mDBContext, Function(y) y.SNo = x.NextReviewIntervalSNo).FirstOrDefault().Interval) >= Today)
        'result = Utility.Shuffle(Of clsQuestion)(result)
        arrangedResult.AddRange(result.OrderBy(Of Integer)(Function(x) x.NextReviewIntervalSNo))
        _LastOverDuedQuetionFetched = False
        mLastOverDueQuestionID = result.FirstOrDefault().ID
        result = Nothing
        If appendNonOverdueQuestions Then
            clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.Recall.Null).ForEach(Sub(y) If Not arrangedResult.Exists(Function(x) x.ID = y.ID) Then arrangedResult.Add(y))
            clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.Recall.Poor).ForEach(Sub(y) If Not arrangedResult.Exists(Function(x) x.ID = y.ID) Then arrangedResult.Add(y))
            clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.Recall.Average).ForEach(Sub(y) If Not arrangedResult.Exists(Function(x) x.ID = y.ID) Then arrangedResult.Add(y))
            clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.Recall.Good).ForEach(Sub(y) If Not arrangedResult.Exists(Function(x) x.ID = y.ID) Then arrangedResult.Add(y))
        End If

        _ReviewQuestions = arrangedResult
        arrangedResult.ForEach(Sub(x) Logger.Log(Logger.LoggingLevel.Info, x.Name & ", "))
        _QuestionsToReviewCount = arrangedResult.Count
        mReviewQuestionEnumarator = _ReviewQuestions.GetEnumerator
    End Sub

    Public Function fetchNextQuestionForReview() As clsQuestion
        If mReviewQuestionEnumarator.MoveNext Then
            _QuestionsFetchedCount += 1
            If mLastOverDueQuestionID = mReviewQuestionEnumarator.Current.id Then
                _LastOverDuedQuetionFetched = True
            End If
            Return DirectCast(mReviewQuestionEnumarator.Current, clsQuestion)
            Else
                Return Nothing
        End If
    End Function

    Public Sub updateUserResponse(question As clsQuestion, response As clsQuestion.Recall)
        'Save Review Response To Review table
        saveReviewInstance(question, response)
        ' Adjust the slope and review interval and schedule next review interval on the question
        UpdateAdjustReviewScheduleAndInterval(question, response)
    End Sub

    ''' <summary>
    ''' Save this instance of review to Review table
    ''' </summary>
    Private Sub saveReviewInstance(question As clsQuestion, response As clsQuestion.Recall)
        Dim rr As clsReview = New clsReview(mDBContext)
        rr.QuestionID = question.Id
        rr.Response = response
        rr.ReviewDateTime = Date.Now
        rr.Save()
    End Sub

    ''' <summary>
    ''' Adjust the slope and review interval and schedule next review interval on the question
    ''' </summary>
    Private Sub UpdateAdjustReviewScheduleAndInterval(question As clsQuestion, response As clsQuestion.Recall)

        Logger.Log(Logger.LoggingLevel.Info, String.Format("Begin:Recording review for question {0} with response {1}", question.ID, response.ToString))

        'first study; its not a review, so return
        If question.NextReviewIntervalSNo = 0 Then
            question.NextReviewIntervalSNo += 1
            question.LastReviewDate = Now
            question.LastReviewResponse = response
            question.ReviewCount = 0
            question.AverageReviewResponse = 0
            question.NextReviewDate = DateAdd(DateInterval.Day, 1, Now)
            question.Save()
            Logger.LogObjectSaved(Logger.LoggingLevel.Info, question, question.Description)
            Logger.Log(Logger.LoggingLevel.Info, String.Format("End:Recording review for question {0} with response {1}", question.ID, response.ToString))
            Return
        End If

        If response >= clsQuestion.Recall.Good Then
            question.LastReviewDate = Now
            question.LastReviewResponse = response
            question.ReviewCount += 1
            question.AverageReviewResponse = (question.AverageReviewResponse * (question.ReviewCount - 1) + response) / question.ReviewCount
            question.Save()
            Logger.LogObjectSaved(Logger.LoggingLevel.Info, question, question.Description)
            Logger.Log(Logger.LoggingLevel.Info, String.Format("End:Recording review for question {0} with response {1}", question.ID, response.ToString))
            Return
        End If

        If DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today) > 0 Then 'atleast 1 day gap since last review

            'Calculate Slope(M)a and review interval(Ri)
            Dim m As Double
            Dim ri As Integer
            m = (100 - (Convert.ToInt32(response) * 100) / 4) / DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today)
            ri = (100 - RECALL_PERCENTAGE_DESIRED) / m

            Dim revInt As clsReviewInterval
            revInt = clsReviewInterval.FetchBusinessObjects(mDBContext, Function(x) x.SNo = question.NextReviewIntervalSNo).FirstOrDefault()
            Dim NewRi As Integer
            NewRi = (revInt.Interval * revInt.SampleCount + ri) / (revInt.SampleCount + 1)
            revInt.Interval = NewRi
            revInt.Slope = m
            revInt.SampleCount += 1
            revInt.ForRecallStrengthPercentage = RECALL_PERCENTAGE_DESIRED
            revInt.Save()
            Logger.LogObjectSaved(Logger.LoggingLevel.Info, revInt, revInt.Description)
            Logger.Log(Logger.LoggingLevel.Info, String.Format("New {0}th Interval calculated = {1}", revInt.SNo.ToString, ri.ToString))

            'Schedule next review on the question.
            If DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today) > revInt.Interval Then
                'Post-term review
                postTerm(question)
            Else 'Pre-term review
                preTerm(question)
                '>>Seems wrong implementation
                ''This review must be after previous interval for question to progress to next review interval
                'revInt = clsReviewInterval.FetchBusinessObjects(mDBContext, Function(x) x.SNo = question.NextReviewIntervalSNo).FirstOrDefault()
                'If DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today) >= revInt.Interval Then
                '    question.NextReviewIntervalSNo += 1
                '    Logger.Log(Logger.LoggingLevel.Info, String.Format("questionID {0} being reviewed after {1} days. Review interval was though {2}",
                '            question.ID.ToString, DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today).ToString, revInt.Interval.ToString))
                '    Logger.Log(Logger.LoggingLevel.Info, String.Format("This pre-term of questionID {0} is past the previous review interval. The Next review interval SLo set to {1}",
                '         question.ID.ToString,
                '         question.NextReviewIntervalSNo.ToString))
                'End If
                '<<Seems wrong implementation
            End If
        End If

        'update the question
        question.LastReviewDate = Now
        question.LastReviewResponse = response
        question.ReviewCount += 1
        question.AverageReviewResponse = (question.AverageReviewResponse * (question.ReviewCount - 1) + response) / question.ReviewCount
        question.Save()
        Logger.LogObjectSaved(Logger.LoggingLevel.Info, question, question.Description)
        Logger.Log(Logger.LoggingLevel.Info, String.Format("End:Recording review for question {0} with response {1}", question.ID, response.ToString))
    End Sub

    ''' <summary>
    ''' sets the next review inteval SNo on the quesion.
    ''' </summary>
    Private Sub postTerm(question As clsQuestion)
        Dim revInt As clsReviewInterval
        revInt = clsReviewInterval.FetchBusinessObjects(mDBContext, Function(x) x.SNo = question.NextReviewIntervalSNo).FirstOrDefault()
        Logger.Log(Logger.LoggingLevel.Info,
                           String.Format("This is post-term. Question {0} is reviewed after {1} days. Review Interval for this was {2}",
                                         question.ID.ToString, DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today).ToString,
                                         revInt.ToString))

        Dim daysGap As Integer = DateDiff(DateInterval.Day, question.LastReviewDate, Today)
        Dim rTmp As List(Of clsReviewInterval)
        rTmp = clsReviewInterval.FetchBusinessObjects(mDBContext, Function(x) x.SNo >= question.NextReviewIntervalSNo)

        Dim totalJumpedInterval As Integer
        Dim sumOfDays As Integer = 0
        For Each ri As clsReviewInterval In rTmp
            sumOfDays += ri.Interval
            If daysGap > sumOfDays Then
                totalJumpedInterval += 1
            Else
                Exit For
            End If
        Next

        Logger.Log(Logger.LoggingLevel.Info,
                   String.Format("Question ID {0} with current review interval Sno {1} jumped interval count:{2}",
                                 question.ID.ToString,
                                 question.NextReviewIntervalSNo.ToString,
                                 totalJumpedInterval.ToString))

        'A questions recall is affected if noto reviewed on its review intervals; 
        'so as many intervals are jumped Is penalized by demoting the review interval slno of question to same number of jumps 
        If question.NextReviewIntervalSNo - totalJumpedInterval <= 0 Then
            question.NextReviewIntervalSNo = 1
        Else
            question.NextReviewIntervalSNo -= totalJumpedInterval
        End If
        question.NextReviewDate = DateAdd(DateInterval.Day, clsReviewInterval.FetchBusinessObjects(mDBContext, Function(x) x.SNo = question.NextReviewIntervalSNo).FirstOrDefault().Interval, Now)
        Logger.Log(Logger.LoggingLevel.Info, String.Format("On QuestionID {0}, Next Review interval Sno. Set:{1}",
                                                           question.ID.ToString, question.NextReviewIntervalSNo.ToString))
    End Sub

    ''' <summary>
    ''' set the next review interval Sno. on the question
    ''' </summary>
    Private Sub preTerm(q As clsQuestion)
        Dim prevRevIntervals As List(Of clsReviewInterval)
        prevRevIntervals = clsReviewInterval.FetchBusinessObjects(mDBContext, Function(x) x.SNo <= q.NextReviewIntervalSNo)
        Dim intervalsSum As Long = 0
        Dim lastIntervalGap As Integer = 0
        prevRevIntervals.ForEach(Sub(x) intervalsSum += x.Interval)

        Dim nextRevIntCondition1 As Boolean
        Dim nextRevIntCondition2 As Boolean
        Dim nextIntervalGapFromPrev As Integer = prevRevIntervals.OrderByDescending(Of Integer)(Function(x) x.SNo).ElementAt(0).Interval - prevRevIntervals.OrderByDescending(Of Integer)(Function(x) x.Interval).ElementAt(1).Interval
        If DateDiff(DateInterval.Day,
                    clsReview.FetchBusinessObjects(mDBContext, Function(x) x.QuestionID = q.ID).OrderBy(Of Integer)(Function(x) x.ID).First().MaintTime,
                    Now) >= intervalsSum Then
            nextRevIntCondition1 = True
        End If

        If DateDiff(DateInterval.Day, q.LastReviewDate, Now) <= nextIntervalGapFromPrev Then
            nextRevIntCondition2 = True
        End If

        If nextRevIntCondition1 AndAlso nextRevIntCondition2 Then
            q.NextReviewIntervalSNo += 1
        End If
    End Sub

End Class


