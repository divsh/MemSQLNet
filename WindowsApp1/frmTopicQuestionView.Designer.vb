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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grdQuestion = New System.Windows.Forms.DataGridView()
        Me.trvTopic = New System.Windows.Forms.TreeView()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.grdQuestion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 717.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grdQuestion, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.trvTopic, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1078, 579)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'grdQuestion
        '
        Me.grdQuestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdQuestion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdQuestion.Location = New System.Drawing.Point(364, 3)
        Me.grdQuestion.Name = "grdQuestion"
        Me.grdQuestion.RowTemplate.Height = 30
        Me.grdQuestion.Size = New System.Drawing.Size(711, 573)
        Me.grdQuestion.TabIndex = 2
        '
        'trvTopic
        '
        Me.trvTopic.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvTopic.LabelEdit = True
        Me.trvTopic.Location = New System.Drawing.Point(3, 3)
        Me.trvTopic.Name = "trvTopic"
        Me.trvTopic.Size = New System.Drawing.Size(355, 573)
        Me.trvTopic.TabIndex = 1
        '
        'frmTopicQuestionView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1078, 579)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmTopicQuestionView"
        Me.Text = "frmTopicQuestionView"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.grdQuestion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents grdQuestion As DataGridView
    Friend WithEvents trvTopic As TreeView
End Class
