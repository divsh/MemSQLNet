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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.trvTopic = New System.Windows.Forms.TreeView()
        Me.grdQuestion = New System.Windows.Forms.DataGridView()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.grdQuestion, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Size = New System.Drawing.Size(1078, 579)
        Me.SplitContainer1.SplitterDistance = 400
        Me.SplitContainer1.TabIndex = 6
        '
        'trvTopic
        '
        Me.trvTopic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvTopic.Font = New System.Drawing.Font("Verdana", 10.02532!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.trvTopic.LabelEdit = True
        Me.trvTopic.Location = New System.Drawing.Point(0, 0)
        Me.trvTopic.Name = "trvTopic"
        Me.trvTopic.Size = New System.Drawing.Size(400, 579)
        Me.trvTopic.TabIndex = 5
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
        Me.grdQuestion.RowTemplate.Height = 30
        Me.grdQuestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdQuestion.Size = New System.Drawing.Size(674, 579)
        Me.grdQuestion.TabIndex = 8
        '
        'frmTopicQuestionView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 579)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "frmTopicQuestionView"
        Me.Text = "frmTopicQuestionView"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.grdQuestion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents trvTopic As TreeView
    Friend WithEvents grdQuestion As DataGridView
End Class
