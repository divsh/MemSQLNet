Imports WindowsApp1

Public Class QuestionReviewPlan
    Implements IQuestionReviewPlan

    Dim mReviewPlan As List(Of IQuestionPlannable)
    Public Sub New(questions As List(Of IQuestionPlannable))
        mReviewPlan = questions
    End Sub
    Public ReadOnly Property ReviewPlan As IEnumerable(Of clsQuestion) Implements IQuestionReviewPlan.ReviewPlan
        Get
            Return mReviewPlan
        End Get
    End Property
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


