Imports WindowsApp1

Public Class QuestionGridView
    Implements IQuestionGridView

    Public Event RequestToOpenQuestionView(questionID As Integer) Implements IQuestionGridView.RequestToOpenQuestionView

    Public Sub New(questionGridControl As Windows.Forms.Control)

    End Sub

    Public Sub PopulateQuestions(questions As List(Of Object)) Implements IQuestionGridView.PopulateQuestions
        Throw New NotImplementedException()
    End Sub

    Public Sub SelectQuestions(questions() As Integer) Implements IQuestionGridView.SelectQuestions
        Throw New NotImplementedException()
    End Sub
End Class
