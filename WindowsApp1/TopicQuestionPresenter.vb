Imports WindowsApp1

Public Class TopicQuestionPresenter
    Implements ITopicQuestionPresenter
    Private mdbContext As DBContext
    Private MyView As ITopicQuestionView
    Public Sub New(dbcontext As DBContext, view As ITopicQuestionView)
        mdbContext = dbcontext
        MyView = view
    End Sub


#Region "Presenter Interface Implementation"
    Public Sub OnTopicSelectionChanged(selectedTopicID As Integer) Implements ITopicQuestionPresenter.OnTopicSelectionChanged
        Dim questions As List(Of clsQuestion)
        questions = clsQuestion.FetchBusinessObjects(mdbContext, Function(x) x.TopicID = selectedTopicID)
        MyView.RefeshQuestionsGrid(questions)
    End Sub

    Public Sub OnQuestionsDroppedOnTopic(questionIDs As List(Of Integer)) Implements ITopicQuestionPresenter.OnQuestionsDroppedOnTopic
        Throw New NotImplementedException()
    End Sub

    Public Sub OnQuestionsDroppedOnTopic(quesions() As Integer, droppedOnTopicID As Integer) Implements ITopicQuestionPresenter.OnQuestionsDroppedOnTopic
        Throw New NotImplementedException()
    End Sub

    Public Sub OnTopicRenamed(topicIDRenamed As Integer, newName As String) Implements ITopicQuestionPresenter.OnTopicRenamed
        Dim topic As clsTopic
        topic = clsTopic.FetchBusinessObjects(mdbContext, Function(x) x.ID = topicIDRenamed).FirstOrDefault()
        topic.Name = newName
        topic.Save()
    End Sub

    Public Sub OnTopicParentTopicChanged(topicIDChanged As Integer, newParentTopicID As Integer) Implements ITopicQuestionPresenter.OnTopicParentTopicChanged
        Throw New NotImplementedException()
    End Sub

    Public Sub OnQuestionDelete(questionID As Integer) Implements ITopicQuestionPresenter.OnQuestionDelete
        Throw New NotImplementedException()
    End Sub

    Public Function GetAllTopics() As List(Of clsTopic) Implements ITopicQuestionPresenter.GetAllTopics
        Dim allTopics = clsTopic.FetchBusinessObjects(mdbContext, Function(x) x.ID > 0)
        Return allTopics
    End Function
#End Region

End Class
