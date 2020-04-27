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
    Private mQuestionView As IQuestionView
    Public Sub OnQuestionDoubleClicked(questionID As Integer) Implements ITopicQuestionPresenter.OnQuestionDoubleClicked
        If mQuestionView Is Nothing OrElse DirectCast(mQuestionView, Form).IsDisposed Then
            mQuestionView = New frmQuestionView(mdbContext, MyView)
        End If
        mQuestionView.Display(questionID)
        DirectCast(mQuestionView, Form).Focus()
    End Sub

    Public Function GetAllTopics() As List(Of clsTopic) Implements ITopicQuestionPresenter.GetAllTopics
        Dim allTopics = clsTopic.FetchBusinessObjects(mdbContext, Function(x) x.ID > 0)
        Return allTopics
    End Function

    Public Sub OnMenuAddQuestion(topicID As Integer, question As String) Implements ITopicQuestionPresenter.OnMenuAddQuestion
        Dim newQ As clsQuestion
        newQ = New clsQuestion(mdbContext)
        newQ.Name = question
        newQ.Answer = clsQuestion.TextToRTF("Edit to provide an answer to this question.")
        newQ.TopicID = topicID
        newQ.Save()
        MyView.RefeshQuestionsGrid(topicID)
    End Sub

    Public Sub OnMenuDeleteQuestion(question As clsQuestion) Implements ITopicQuestionPresenter.OnMenuDeleteQuestion
        Dim selectedTopic As clsTopic = question.Topic
        question.Delete()
        MyView.RefeshQuestionsGrid(selectedTopic.ID)
    End Sub

    Public Sub OnMenuAddTopic(ParentTopicID As Integer, topic As String) Implements ITopicQuestionPresenter.OnMenuAddTopic
        Dim newTopic As clsTopic
        newTopic = New clsTopic(mdbContext)
        newTopic.Name = topic
        newTopic.ParentTopicID = ParentTopicID
        newTopic.Save()
        MyView.populateTopicTree(clsTopic.FetchBusinessObjects(mdbContext, Function(x) True))
        MyView.RefeshQuestionsGrid(ParentTopicID)
    End Sub
#End Region

End Class
