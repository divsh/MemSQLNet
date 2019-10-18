Imports System.ComponentModel
Imports WindowsApp1

Public Class ucTreeView
    Implements ITopicView

    Private mTopicViewPresenter As ITopicViewController
    Public Event SelectedTopicChanged(changedToTopicID As Integer) Implements ITopicView.SelectedTopicChanged
    Public Event DroppedOnTopic(droppedOnTopicID As Integer, typeOFItemDropped As DroppedItemType, droppedObjects As List(Of Object)) Implements ITopicView.DroppedOnTopic

    Public Sub New(dbContext As DBContext)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        mTopicViewPresenter = New TopicViewController(Me, dbContext)

    End Sub

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub

    Private Sub TreeView1_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles TreeView1.AfterLabelEdit
        If String.IsNullOrEmpty(e.Label) Then e.CancelEdit = True

    End Sub

    Public Sub PopulateNodes(alltopics As List(Of Tuple(Of Integer, String, Integer)))

    End Sub


    Private Sub TreeView1_DragDrop(sender As Object, e As DragEventArgs) Handles TreeView1.DragDrop

    End Sub

    Public Sub RenameTopic(topicID As Integer, newName As String) Implements ITopicView.RenameTopic
        Throw New NotImplementedException()
    End Sub

    Public Sub ChangeParentTopic(childTopicID As Integer, parentTopicID As Integer) Implements ITopicView.ChangeParentTopic
        Throw New NotImplementedException()
    End Sub

    Public Sub PopulateTopics() Implements ITopicView.PopulateTopics
        mTopicViewPresenter.getAllTopics()

    End Sub


End Class
