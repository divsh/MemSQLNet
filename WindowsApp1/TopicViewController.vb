Public Class TopicViewController
    Private mTopicView As ITopicView
    Private mDBContext As DBContext
    Public Sub New(topicView As ITopicView, dbContext As DBContext)
        mTopicView = topicView
        mDBContext = dbContext
    End Sub

    Public Sub populateTopics()
        Dim allTopics As List(Of clsTopic)
        allTopics = clsTopic.FetchBusinessObjects(mDBContext, Function(x) x.ID > 0)
        mTopicView.PopulateTopics(alltopic)
    End Sub

    Public Function getAllTopics() As List(Of clsTopic)
        Dim allTopics As List(Of clsTopic)
        allTopics = clsTopic.FetchBusinessObjects(mDBContext, Function(x) x.ID > 0)
        Return allTopics

    End Function

End Class
