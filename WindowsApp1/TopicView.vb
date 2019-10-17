Imports WindowsApp1

Public Class TopicView
    Implements ITopicView

    Public Event SelectedTopicChanged(changedToTopicID As Integer) Implements ITopicView.SelectedTopicChanged
    Public Event DroppedOnTopic(droppedOnTopicID As Integer, typeOFItemDropped As DroppedItemType, droppedObjects As List(Of Object)) Implements ITopicView.DroppedOnTopic

    Public Sub New(TopicControl As Windows.Forms.Control)

    End Sub

    Public Sub RenameTopic(topicID As Integer, newName As String) Implements ITopicView.RenameTopic
        Throw New NotImplementedException()
    End Sub

    Public Sub ChangeParentTopic(childTopicID As Integer, parentTopicID As Integer) Implements ITopicView.ChangeParentTopic
        Throw New NotImplementedException()
    End Sub

    Public Sub PopulateTopics(alltopics As List(Of Tuple(Of Integer, String))) Implements ITopicView.PopulateTopics
        Throw New NotImplementedException()
    End Sub
End Class
