﻿Public Class frmTopicQuestionView
    Implements ITopicQuestionView

    Private myPresenter As ITopicQuestionPresenter
    Private mDBContext As DBContext
    Public Sub New(dbContext As DBContext)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        initGrid(grdQuestion)
        mDBContext = dbContext
        myPresenter = New TopicQuestionPresenter(dbContext, Me)
    End Sub

    Private Sub initGrid(ByVal grd As DataGridView)
        grd.AutoGenerateColumns = True
        grd.AutoSize = True
    End Sub

#Region "View Interface Implementation"
    Public Sub RefeshQuestionsGrid(questions As List(Of clsQuestion)) Implements ITopicQuestionView.RefeshQuestionsGrid
        Dim bs As BindingSource = New BindingSource()
        questions.ForEach(Sub(x) bs.Add(x))
        grdQuestion.DataSource = bs
    End Sub

    Public Sub populateTopicTree(topics As List(Of clsTopic)) Implements ITopicQuestionView.populateTopicTree
        Dim addedID As List(Of Integer) = New List(Of Integer)
        trvTopic.Nodes.Clear()
        Dim rootNode As TreeNode = New TreeNode("Root")
        trvTopic.Nodes.Add(rootNode)

        For Each t As clsTopic In topics
            If addedID.Contains(t.ID) Then Continue For
            Dim node As TreeNode = New TreeNode(t.Name)
            node.Tag = t.ID
            addNodeToParent(rootNode, node, t.ParentTopicID, topics, addedID)
        Next
    End Sub

    Public Sub selectTopicNode(topicID As Integer)
        Dim e As IEnumerable
        Dim tn As TreeNode
        e = trvTopic.Nodes
        tn = e.OfType(Of TreeNode)().ToList().Where(Function(x)
                                                        If x.Tag IsNot Nothing Then
                                                            Return DirectCast(x.Tag, Integer) = topicID
                                                        End If
                                                        Return False
                                                    End Function).FirstOrDefault()
        trvTopic.SelectedNode = tn
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
        Dim allTopics = myPresenter.GetAllTopics()
        populateTopicTree(allTopics)
        Try
            Application.Run(Me)
        Catch ex As Exception
            MessageBox.Show("Err:", ex.Message & Environment.NewLine & ex.StackTrace)
        End Try
    End Sub
#End Region

    Private Sub trvTopic_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles trvTopic.AfterSelect
        Try
            myPresenter.OnTopicSelectionChanged(e.Node.Tag)
        Catch ex As Exception
            MessageBoxEx.Show(ex, "trvTopic_AfterSelect")
        End Try
    End Sub

    Private Sub trvTopic_AfterLabelEdit(sender As Object, e As NodeLabelEditEventArgs) Handles trvTopic.AfterLabelEdit
        If e.Label Is Nothing OrElse e.Label.Length = 0 Then Return
        myPresenter.OnTopicRenamed(e.Node.Tag, e.Label)
    End Sub

    Private Sub grdQuestion_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles grdQuestion.MouseDoubleClick
        Try
            myPresenter.OnQuestionDoubleClicked(DirectCast(grdQuestion.SelectedRows(0).DataBoundItem, clsQuestion).ID)
        Catch
        End Try
    End Sub

    ''' <summary>
    ''' used to select question from list  
    ''' </summary>
    Public Function SelectNthRowFromCurrent(positionFromCurrent As Integer) As clsQuestion Implements ITopicQuestionView.SelectNthRowFromCurrent

        Dim newIndex As Integer = grdQuestion.SelectedRows().Item(0).Index + positionFromCurrent
        If newIndex < 0 Then
            grdQuestion.ClearSelection()
            grdQuestion.Rows().Item(0).Selected = True
            Return DirectCast(grdQuestion.Rows().Item(0).DataBoundItem, clsQuestion)
        ElseIf newIndex > grdQuestion.Rows().Count - 1 Then
            grdQuestion.ClearSelection()
            grdQuestion.Rows().Item(grdQuestion.Rows().Count - 1).Selected = True
            Return DirectCast(grdQuestion.Rows().Item(grdQuestion.Rows().Count - 1).DataBoundItem, clsQuestion)
        Else
            grdQuestion.ClearSelection()
            grdQuestion.Rows().Item(newIndex).Selected = True
            Return DirectCast(grdQuestion.Rows().Item(newIndex).DataBoundItem, clsQuestion)
        End If

    End Function

    Private Sub mnuItemAddQuestion_Click(sender As Object, e As EventArgs) Handles mnuItemAddQuestion.Click
        Try
            Dim q As String
            q = InputBox("Enter the question:", "New Question", String.Empty)
            If String.IsNullOrEmpty(q) Then Return
            myPresenter.OnMenuAddQuestion(trvTopic.SelectedNode.Tag, q)
        Catch ex As Exception
            MessageBoxEx.Show(ex, "mnuItemAddQuestion_Click")
        End Try
    End Sub

    Public Sub RefeshQuestionsGrid(TopicID As Integer) Implements ITopicQuestionView.RefeshQuestionsGrid
        RefeshQuestionsGrid(clsQuestion.FetchBusinessObjects(mDBContext, Function(x) x.TopicID = TopicID))
    End Sub

    Private Sub mnuItemAddTopic_Click(sender As Object, e As EventArgs) Handles mnuItemAddTopic.Click
        Try
            Dim topic As String
            Dim selectedTopicID As Integer
            selectedTopicID = If(trvTopic.SelectedNode.Tag, 0)

            topic = InputBox("Enter the topic Name:", "New Topic", String.Empty)

            If String.IsNullOrEmpty(topic) Then Return
            myPresenter.OnMenuAddTopic(selectedTopicID, topic)
            selectTopicNode(selectedTopicID)
        Catch ex As Exception
            MessageBoxEx.Show(ex, "mnuItemAddQuestion_Click")
        End Try
    End Sub
End Class