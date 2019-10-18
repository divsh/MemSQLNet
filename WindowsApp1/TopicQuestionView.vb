Imports WindowsApp1

Public Class TopicQuestionView
    Implements ITopicQuestionView
    Private mquestionGridView As IQuestionGridView
    Private mTopicView As ITopicView

    Public Sub New(ByVal questionGridView As IQuestionGridView, ByVal topicView As ITopicView)
        mquestionGridView = questionGridView
        mTopicView = topicView
        mTopicView.PopulateTopics()
    End Sub

    Public Sub QuestionsDroppedOnTopic(quesions() As Integer, droppedOnTopicID As Integer) Implements ITopicQuestionView.QuestionsDroppedOnTopic
        Throw New NotImplementedException()
    End Sub

    Public Sub Show() Implements ITopicQuestionView.Show
        Throw New NotImplementedException()
    End Sub
End Class
