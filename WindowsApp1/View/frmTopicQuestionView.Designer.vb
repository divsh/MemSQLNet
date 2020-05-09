<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTopicQuestionView
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTopicQuestionView))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.trvTopic = New System.Windows.Forms.TreeView()
        Me.mnuTreeView = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuItemAddTopic = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemDeleteTopic = New System.Windows.Forms.ToolStripMenuItem()
        Me.grdQuestion = New System.Windows.Forms.DataGridView()
        Me.mnuQuestionGrid = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuItemAddQuestion = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuItemDeleteQuestion = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.sbTotalQuestions = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sbMemorize = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.mnuTreeView.SuspendLayout()
        CType(Me.grdQuestion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.mnuQuestionGrid.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.trvTopic)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grdQuestion)
        Me.SplitContainer1.Size = New System.Drawing.Size(970, 526)
        Me.SplitContainer1.SplitterDistance = 359
        Me.SplitContainer1.TabIndex = 6
        '
        'trvTopic
        '
        Me.trvTopic.ContextMenuStrip = Me.mnuTreeView
        Me.trvTopic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvTopic.Font = New System.Drawing.Font("Verdana", 10.02532!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trvTopic.ImageIndex = 0
        Me.trvTopic.ImageList = Me.ImageList1
        Me.trvTopic.LabelEdit = True
        Me.trvTopic.Location = New System.Drawing.Point(0, 0)
        Me.trvTopic.Name = "trvTopic"
        Me.trvTopic.SelectedImageIndex = 0
        Me.trvTopic.Size = New System.Drawing.Size(359, 526)
        Me.trvTopic.TabIndex = 5
        '
        'mnuTreeView
        '
        Me.mnuTreeView.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.mnuTreeView.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuItemAddTopic, Me.mnuItemDeleteTopic})
        Me.mnuTreeView.Name = "mnuTreeView"
        Me.mnuTreeView.Size = New System.Drawing.Size(181, 68)
        '
        'mnuItemAddTopic
        '
        Me.mnuItemAddTopic.Name = "mnuItemAddTopic"
        Me.mnuItemAddTopic.Size = New System.Drawing.Size(180, 32)
        Me.mnuItemAddTopic.Text = "&Add Topic"
        '
        'mnuItemDeleteTopic
        '
        Me.mnuItemDeleteTopic.Name = "mnuItemDeleteTopic"
        Me.mnuItemDeleteTopic.Size = New System.Drawing.Size(180, 32)
        Me.mnuItemDeleteTopic.Text = "&Delete Topic"
        '
        'grdQuestion
        '
        Me.grdQuestion.AllowUserToAddRows = False
        Me.grdQuestion.AllowUserToOrderColumns = True
        Me.grdQuestion.BackgroundColor = System.Drawing.Color.White
        Me.grdQuestion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdQuestion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.grdQuestion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.grdQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdQuestion.ContextMenuStrip = Me.mnuQuestionGrid
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 10.02532!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Desktop
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdQuestion.DefaultCellStyle = DataGridViewCellStyle1
        Me.grdQuestion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdQuestion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdQuestion.GridColor = System.Drawing.SystemColors.ScrollBar
        Me.grdQuestion.Location = New System.Drawing.Point(0, 0)
        Me.grdQuestion.Name = "grdQuestion"
        Me.grdQuestion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.grdQuestion.RowHeadersVisible = False
        Me.grdQuestion.RowHeadersWidth = 62
        Me.grdQuestion.RowTemplate.Height = 30
        Me.grdQuestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdQuestion.Size = New System.Drawing.Size(607, 526)
        Me.grdQuestion.TabIndex = 8
        '
        'mnuQuestionGrid
        '
        Me.mnuQuestionGrid.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.mnuQuestionGrid.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuItemAddQuestion, Me.mnuItemDeleteQuestion})
        Me.mnuQuestionGrid.Name = "mnuQuestionGrid"
        Me.mnuQuestionGrid.Size = New System.Drawing.Size(212, 68)
        '
        'mnuItemAddQuestion
        '
        Me.mnuItemAddQuestion.Name = "mnuItemAddQuestion"
        Me.mnuItemAddQuestion.Size = New System.Drawing.Size(211, 32)
        Me.mnuItemAddQuestion.Text = "&Add Question"
        '
        'mnuItemDeleteQuestion
        '
        Me.mnuItemDeleteQuestion.Name = "mnuItemDeleteQuestion"
        Me.mnuItemDeleteQuestion.Size = New System.Drawing.Size(211, 32)
        Me.mnuItemDeleteQuestion.Text = "&Delete Question"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sbTotalQuestions, Me.sbMemorize})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 494)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(970, 32)
        Me.StatusStrip1.TabIndex = 7
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'sbTotalQuestions
        '
        Me.sbTotalQuestions.Name = "sbTotalQuestions"
        Me.sbTotalQuestions.Size = New System.Drawing.Size(134, 25)
        Me.sbTotalQuestions.Text = "Total Questions"
        '
        'sbMemorize
        '
        Me.sbMemorize.Name = "sbMemorize"
        Me.sbMemorize.Size = New System.Drawing.Size(91, 25)
        Me.sbMemorize.Text = "Memorize"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "folderClose")
        Me.ImageList1.Images.SetKeyName(1, "folderOpen")
        Me.ImageList1.Images.SetKeyName(2, "folderClose2")
        '
        'frmTopicQuestionView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(970, 526)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmTopicQuestionView"
        Me.Text = "frmTopicQuestionView"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.mnuTreeView.ResumeLayout(False)
        CType(Me.grdQuestion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.mnuQuestionGrid.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents trvTopic As TreeView
    Friend WithEvents grdQuestion As DataGridView
    Friend WithEvents mnuTreeView As ContextMenuStrip
    Friend WithEvents mnuItemAddTopic As ToolStripMenuItem
    Friend WithEvents mnuItemDeleteTopic As ToolStripMenuItem
    Friend WithEvents mnuQuestionGrid As ContextMenuStrip
    Friend WithEvents mnuItemAddQuestion As ToolStripMenuItem
    Friend WithEvents mnuItemDeleteQuestion As ToolStripMenuItem
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents sbTotalQuestions As ToolStripStatusLabel
    Friend WithEvents sbMemorize As ToolStripStatusLabel
    Friend WithEvents ImageList1 As ImageList
End Class
