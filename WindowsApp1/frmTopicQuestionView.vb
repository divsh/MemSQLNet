﻿Imports WindowsApp1

Public Class frmTopicQuestionView
    Implements ITopicQuestionView

    Private mTopicQuestionPresenter As ITopicQuestionPresenter

    Public Sub New(dbContext As DBContext)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        mTopicQuestionPresenter = New TopicQuestionPresenter(dbContext, Me)
    End Sub

#Region "View Interface Implementation"
    Public Sub RefeshQuestionsGrid(questions As List(Of clsQuestion)) Implements ITopicQuestionView.RefeshQuestionsGrid
        Throw New NotImplementedException()
    End Sub

    Public Sub populateTopicTree(topics As List(Of clsTopic)) Implements ITopicQuestionView.populateTopicTree
        Dim addedID As List(Of Integer) = New List(Of Integer)
        trvTopic.Nodes.Clear()
        Dim rootNode As TreeNode = New TreeNode("Root")
        trvTopic.Nodes.Add(rootNode)

        For Each t As clsTopic In topics
            If addedID.Contains(t.Id) Then Continue For
            Dim node As TreeNode = New TreeNode(t.Name)
            node.Tag = t.ID
            addNodeToParent(rootNode, node, t.ParentTopicID, topics, addedID)
        Next
    End Sub

    Private Sub addNodeToParent(rootnode As TreeNode, node As TreeNode, parentNodeID As Integer, topics As List(Of clsTopic), addedID As List(Of Integer))
        If parentNodeID = 0 Then
            rootnode.Nodes.Add(node)
            Return
        End If

        Dim parentFound As Boolean = False
        Dim allnodes As List(Of TreeNode) = getAllNodes(trvTopic)
        parentFound = allnodes.Exists(Function(x) x.Tag = parentNodeID)
        If parentFound Then
            Dim parentNode As TreeNode
            parentNode = allnodes.Where(Function(x) x.Tag = parentNodeID).FirstOrDefault()
            parentNode.Nodes.Add(node)
            addedID.Add(node.Tag)
        Else
            'create parent node and add it first.
            Dim parentTopic As clsTopic
            parentTopic = topics.Where(Function(x) x.ID = parentNodeID).FirstOrDefault()
            Dim parentNode As TreeNode = New TreeNode(parentTopic.Name)
            node.Tag = parentTopic.ID
            addNodeToParent(rootnode, parentNode, parentTopic.ParentTopicID, topics, addedID)
        End If
    End Sub

    Private Function getAllNodes(ByVal tv As TreeView) As List(Of TreeNode)
        Dim allNOdes As List(Of TreeNode) = New List(Of TreeNode)
        addChilds(allNOdes, tv.Nodes.Item(0))
        Return allNOdes
    End Function

    Private Sub addChilds(ByVal allNOdes As List(Of TreeNode), ByVal node As TreeNode)
        allNOdes.Add(node)
        If node.Nodes.Count = 0 Then Return
        allNOdes.AddRange(node.Nodes.Cast(Of TreeNode))
        For Each childNOde As TreeNode In node.Nodes
            addChilds(allNOdes, childNOde)
        Next
    End Sub

    Private Sub frmTopicQuestionView_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub


    Public Function getSelectedTopicID() As Integer Implements ITopicQuestionView.getSelectedTopicID
        Throw New NotImplementedException()
    End Function

    Public Sub Display() Implements ITopicQuestionView.Display
        Dim allTopics = mTopicQuestionPresenter.GetAllTopics()
        populateTopicTree(allTopics)
        Application.Run(Me)
    End Sub
#End Region
End Class