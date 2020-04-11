Imports WindowsApp1


''' <summary>
''' Returns questions overdued and ontime to be review followed by not dued question in order of <>,<>,<>...
''' at the same time update the 'interval table for 80% retention'
''' The class will directly access the question table and ReviewInterval table.
''' </summary>
Public Class QuestionReviewPlan
    Implements IEnumerable, IQuestionReviewPlan

    Dim mReviewPlan As List(Of IQuestionPlannable)
    Dim mDbContext As DBContext

    Public Sub New(questions As List(Of IQuestionPlannable), dbCOntext As DBContext)
        mDbContext = dbCOntext
        mReviewPlan = questions
    End Sub
    Public ReadOnly Property ReviewPlan As IEnumerable(Of clsQuestion) Implements IQuestionReviewPlan.ReviewPlan
        Get
            If mReviewPlan Is Nothing Then

            End If
            Return mReviewPlan
        End Get
    End Property

    Private Function retriveQuestionsForReviewFromDB() As List(Of IQuestionPlannable)
        'clsQuestion.FetchBusinessObjects(mDbContext, Function(x) x.re)
    End Function


    Public Function AdjustCurrentInterval(i As Integer, Ra As Integer, recallPercentage As Integer) As Integer
        Return Nothing
    End Function

    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return mReviewPlan.GetEnumerator()
    End Function
End Class

Public Class ReviwPlan
    Implements IEnumerable, IEnumerator

    Public ReadOnly Property Current As Object Implements IEnumerator.Current
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Sub Reset() Implements IEnumerator.Reset
        Throw New NotImplementedException()
    End Sub

    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Throw New NotImplementedException()
    End Function

    Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
        Throw New NotImplementedException()
    End Function
End Class


