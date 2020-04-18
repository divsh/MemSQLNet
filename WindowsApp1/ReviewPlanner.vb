
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
        Dim result As List(Of clsQuestion)
        'fetch overdue to review questions 
        result = clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.NextReviewIntervalSNo = 0 OrElse Convert.ToDateTime(x.LastReviewDate).AddDays(clsReviewInterval.FetchBusinessObjects(mDBContext, Function(y) y.Sno = x.NextReviewIntervalSNo).FirstOrDefault().Interval) >= Today)
        _LastOverDuedQuetionFetched = False
        mLastOverDueQuestionID = result.FirstOrDefault().Id
        If appendNonOverdueQuestions Then
            clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.Recall.Null).ForEach(Sub(y) If Not result.Exists(Function(x) x.ID = y.ID) Then result.Add(y))
            clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.Recall.Poor).ForEach(Sub(y) If Not result.Exists(Function(x) x.Id = y.Id) Then result.Add(y))
            clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.Recall.Average).ForEach(Sub(y) If Not result.Exists(Function(x) x.Id = y.Id) Then result.Add(y))
            clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.LastReviewResponse = clsQuestion.Recall.Good).ForEach(Sub(y) If Not result.Exists(Function(x) x.Id = y.Id) Then result.Add(y))
        End If
        _ReviewQuestions = result
        _QuestionsToReviewCount = result.Count
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
            question.Save()
            Logger.LogObjectSaved(Logger.LoggingLevel.Info, question, question.Description)
            Logger.Log(Logger.LoggingLevel.Info, String.Format("End:Recording review for question {0} with response {1}", question.ID, response.ToString))
            Return
        End If

        If response = 5 Then
            question.LastReviewDate = Now
            question.LastReviewResponse = response
            question.ReviewCount += 1
            question.AverageReviewResponse = (question.AverageReviewResponse * question.ReviewCount + response) / question.ReviewCount
            question.Save()
            Logger.LogObjectSaved(Logger.LoggingLevel.Info, question, question.Description)
            Logger.Log(Logger.LoggingLevel.Info, String.Format("End:Recording review for question {0} with response {1}", question.ID, response.ToString))
            Return
        End If

        If DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today) > 0 Then

            'Calculate Slope(M)a and review interval(Ri)
            Dim m As Double
            Dim ri As Integer
            m = (100 - (Convert.ToInt32(response) * 100) / 5) / DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today)
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
                Logger.Log(Logger.LoggingLevel.Info,
                           String.Format("This is post-term. Question {0} is reviewed after {1} days. Review Interval for this was {2}",
                                         question.ID.ToString, DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today).ToString,
                                         revInt.ToString))

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

                Logger.Log(Logger.LoggingLevel.Info,
                           String.Format("Question ID {0} with current review interval Sno {1} jumped interval count:{2}",
                                         question.ID.ToString,
                                         question.NextReviewIntervalSNo.ToString,
                                         totalJumpedInterval.ToString))
                If question.NextReviewIntervalSNo - totalJumpedInterval <= 0 Then
                    question.NextReviewIntervalSNo = 1
                Else
                    question.NextReviewIntervalSNo -= totalJumpedInterval
                End If
                Logger.Log(Logger.LoggingLevel.Info, String.Format("On QuestionID {0}, Next Review interval Sno. Set:{1}",
                                                                   question.ID.ToString, question.NextReviewIntervalSNo.ToString))
            Else 'Pre-term review

                Logger.Log(Logger.LoggingLevel.Info,
                           String.Format("This is pre-term. Question {0} is reviewed after {1} days. Review Interval for this was {2}",
                                         question.ID.ToString, DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today).ToString,
                                         revInt.ToString))

                'This review must be after previous interval for question to progress to next review interval
                revInt = clsReviewInterval.FetchBusinessObjects(mDBContext, Function(x) x.SNo = question.NextReviewIntervalSNo).FirstOrDefault()
                If DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today) >= revInt.Interval Then
                    question.NextReviewIntervalSNo += 1
                    Logger.Log(Logger.LoggingLevel.Info, String.Format("questionID {0} being reviewed after {1} days. Review interval was though {2}",
                            question.ID.ToString, DateDiff(DateInterval.Day, question.LastReviewDate, Date.Today).ToString, revInt.Interval.ToString))
                    Logger.Log(Logger.LoggingLevel.Info, String.Format("This pre-term of questionID {0} is past the previous review interval. The Next review interval SLo set to {1}",
                         question.ID.ToString,
                         question.NextReviewIntervalSNo.ToString))
                End If
            End If
        End If

        'update the question
        question.LastReviewDate = Now
        question.LastReviewResponse = response
        question.ReviewCount += 1
        question.AverageReviewResponse = (question.AverageReviewResponse * question.ReviewCount + response) / question.ReviewCount
        question.Save()
        Logger.LogObjectSaved(Logger.LoggingLevel.Info, question, question.Description)
        Logger.Log(Logger.LoggingLevel.Info, String.Format("End:Recording review for question {0} with response {1}", question.ID, response.ToString))
    End Sub

End Class
