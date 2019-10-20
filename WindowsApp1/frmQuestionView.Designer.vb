<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuestionView
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
        Me.lblTopic = New System.Windows.Forms.Label()
        Me.lblQuestion = New System.Windows.Forms.Label()
        Me.lblAnswer = New System.Windows.Forms.Label()
        Me.txtTopic = New System.Windows.Forms.TextBox()
        Me.txtQuestion = New System.Windows.Forms.TextBox()
        Me.rtbAnswer = New System.Windows.Forms.RichTextBox()
        Me.plnBrowseMode = New System.Windows.Forms.Panel()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnReview = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.plnEditMode = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.plnReviewMode = New System.Windows.Forms.Panel()
        Me.grbResponse = New System.Windows.Forms.GroupBox()
        Me.optExcellent = New System.Windows.Forms.RadioButton()
        Me.optGood = New System.Windows.Forms.RadioButton()
        Me.optAverage = New System.Windows.Forms.RadioButton()
        Me.optPoor = New System.Windows.Forms.RadioButton()
        Me.optNull = New System.Windows.Forms.RadioButton()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnShowAnswer = New System.Windows.Forms.Button()
        Me.plnBrowseMode.SuspendLayout()
        Me.plnEditMode.SuspendLayout()
        Me.plnReviewMode.SuspendLayout()
        Me.grbResponse.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTopic
        '
        Me.lblTopic.AutoSize = True
        Me.lblTopic.Location = New System.Drawing.Point(8, 3)
        Me.lblTopic.Name = "lblTopic"
        Me.lblTopic.Size = New System.Drawing.Size(58, 24)
        Me.lblTopic.TabIndex = 0
        Me.lblTopic.Text = "Topic"
        '
        'lblQuestion
        '
        Me.lblQuestion.AutoSize = True
        Me.lblQuestion.Location = New System.Drawing.Point(8, 44)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(86, 24)
        Me.lblQuestion.TabIndex = 1
        Me.lblQuestion.Text = "Question"
        '
        'lblAnswer
        '
        Me.lblAnswer.AutoSize = True
        Me.lblAnswer.Location = New System.Drawing.Point(8, 102)
        Me.lblAnswer.Name = "lblAnswer"
        Me.lblAnswer.Size = New System.Drawing.Size(74, 24)
        Me.lblAnswer.TabIndex = 2
        Me.lblAnswer.Text = "Answer"
        '
        'txtTopic
        '
        Me.txtTopic.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTopic.Location = New System.Drawing.Point(72, 3)
        Me.txtTopic.Multiline = True
        Me.txtTopic.Name = "txtTopic"
        Me.txtTopic.ReadOnly = True
        Me.txtTopic.Size = New System.Drawing.Size(1203, 38)
        Me.txtTopic.TabIndex = 3
        '
        'txtQuestion
        '
        Me.txtQuestion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuestion.Location = New System.Drawing.Point(12, 71)
        Me.txtQuestion.Multiline = True
        Me.txtQuestion.Name = "txtQuestion"
        Me.txtQuestion.ReadOnly = True
        Me.txtQuestion.Size = New System.Drawing.Size(1266, 28)
        Me.txtQuestion.TabIndex = 4
        '
        'rtbAnswer
        '
        Me.rtbAnswer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbAnswer.Location = New System.Drawing.Point(12, 129)
        Me.rtbAnswer.Name = "rtbAnswer"
        Me.rtbAnswer.ReadOnly = True
        Me.rtbAnswer.Size = New System.Drawing.Size(1266, 459)
        Me.rtbAnswer.TabIndex = 5
        Me.rtbAnswer.Text = ""
        '
        'plnBrowseMode
        '
        Me.plnBrowseMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.plnBrowseMode.Controls.Add(Me.btnNew)
        Me.plnBrowseMode.Controls.Add(Me.btnReview)
        Me.plnBrowseMode.Controls.Add(Me.btnPrev)
        Me.plnBrowseMode.Controls.Add(Me.btnNext)
        Me.plnBrowseMode.Location = New System.Drawing.Point(9, 594)
        Me.plnBrowseMode.Name = "plnBrowseMode"
        Me.plnBrowseMode.Size = New System.Drawing.Size(1266, 100)
        Me.plnBrowseMode.TabIndex = 15
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(3, 27)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(157, 47)
        Me.btnNew.TabIndex = 17
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnReview
        '
        Me.btnReview.Location = New System.Drawing.Point(166, 27)
        Me.btnReview.Name = "btnReview"
        Me.btnReview.Size = New System.Drawing.Size(157, 47)
        Me.btnReview.TabIndex = 18
        Me.btnReview.Text = "Review"
        Me.btnReview.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrev.Location = New System.Drawing.Point(943, 27)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(157, 47)
        Me.btnPrev.TabIndex = 15
        Me.btnPrev.Text = "Prev"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(1106, 27)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(157, 47)
        Me.btnNext.TabIndex = 16
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'plnEditMode
        '
        Me.plnEditMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.plnEditMode.Controls.Add(Me.btnSave)
        Me.plnEditMode.Controls.Add(Me.btnCancel)
        Me.plnEditMode.Location = New System.Drawing.Point(12, 347)
        Me.plnEditMode.Name = "plnEditMode"
        Me.plnEditMode.Size = New System.Drawing.Size(1266, 100)
        Me.plnEditMode.TabIndex = 16
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(943, 27)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(157, 47)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(1106, 27)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(157, 47)
        Me.btnCancel.TabIndex = 16
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'plnReviewMode
        '
        Me.plnReviewMode.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.plnReviewMode.Controls.Add(Me.btnShowAnswer)
        Me.plnReviewMode.Controls.Add(Me.grbResponse)
        Me.plnReviewMode.Controls.Add(Me.btnStop)
        Me.plnReviewMode.Location = New System.Drawing.Point(18, 169)
        Me.plnReviewMode.Name = "plnReviewMode"
        Me.plnReviewMode.Size = New System.Drawing.Size(1266, 100)
        Me.plnReviewMode.TabIndex = 17
        '
        'grbResponse
        '
        Me.grbResponse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbResponse.Controls.Add(Me.optExcellent)
        Me.grbResponse.Controls.Add(Me.optGood)
        Me.grbResponse.Controls.Add(Me.optAverage)
        Me.grbResponse.Controls.Add(Me.optPoor)
        Me.grbResponse.Controls.Add(Me.optNull)
        Me.grbResponse.Location = New System.Drawing.Point(464, 0)
        Me.grbResponse.Name = "grbResponse"
        Me.grbResponse.Size = New System.Drawing.Size(632, 100)
        Me.grbResponse.TabIndex = 21
        Me.grbResponse.TabStop = False
        '
        'optExcellent
        '
        Me.optExcellent.AutoSize = True
        Me.optExcellent.Location = New System.Drawing.Point(494, 37)
        Me.optExcellent.Name = "optExcellent"
        Me.optExcellent.Size = New System.Drawing.Size(113, 28)
        Me.optExcellent.TabIndex = 5
        Me.optExcellent.TabStop = True
        Me.optExcellent.Text = "Excellent"
        Me.optExcellent.UseVisualStyleBackColor = True
        '
        'optGood
        '
        Me.optGood.AutoSize = True
        Me.optGood.Location = New System.Drawing.Point(377, 37)
        Me.optGood.Name = "optGood"
        Me.optGood.Size = New System.Drawing.Size(82, 28)
        Me.optGood.TabIndex = 4
        Me.optGood.TabStop = True
        Me.optGood.Text = "Good"
        Me.optGood.UseVisualStyleBackColor = True
        '
        'optAverage
        '
        Me.optAverage.AutoSize = True
        Me.optAverage.Location = New System.Drawing.Point(236, 37)
        Me.optAverage.Name = "optAverage"
        Me.optAverage.Size = New System.Drawing.Size(106, 28)
        Me.optAverage.TabIndex = 3
        Me.optAverage.TabStop = True
        Me.optAverage.Text = "Average"
        Me.optAverage.UseVisualStyleBackColor = True
        '
        'optPoor
        '
        Me.optPoor.AutoSize = True
        Me.optPoor.Location = New System.Drawing.Point(126, 37)
        Me.optPoor.Name = "optPoor"
        Me.optPoor.Size = New System.Drawing.Size(75, 28)
        Me.optPoor.TabIndex = 2
        Me.optPoor.TabStop = True
        Me.optPoor.Text = "Poor"
        Me.optPoor.UseVisualStyleBackColor = True
        '
        'optNull
        '
        Me.optNull.AutoSize = True
        Me.optNull.Location = New System.Drawing.Point(23, 37)
        Me.optNull.Name = "optNull"
        Me.optNull.Size = New System.Drawing.Size(68, 28)
        Me.optNull.TabIndex = 1
        Me.optNull.TabStop = True
        Me.optNull.Text = "Null"
        Me.optNull.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStop.Location = New System.Drawing.Point(1103, 28)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(157, 47)
        Me.btnStop.TabIndex = 16
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnShowAnswer
        '
        Me.btnShowAnswer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowAnswer.Location = New System.Drawing.Point(12, 28)
        Me.btnShowAnswer.Name = "btnShowAnswer"
        Me.btnShowAnswer.Size = New System.Drawing.Size(1078, 47)
        Me.btnShowAnswer.TabIndex = 22
        Me.btnShowAnswer.Text = "Show Answer"
        Me.btnShowAnswer.UseVisualStyleBackColor = True
        '
        'frmQuestionView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1290, 706)
        Me.Controls.Add(Me.plnReviewMode)
        Me.Controls.Add(Me.plnEditMode)
        Me.Controls.Add(Me.plnBrowseMode)
        Me.Controls.Add(Me.rtbAnswer)
        Me.Controls.Add(Me.txtQuestion)
        Me.Controls.Add(Me.txtTopic)
        Me.Controls.Add(Me.lblAnswer)
        Me.Controls.Add(Me.lblQuestion)
        Me.Controls.Add(Me.lblTopic)
        Me.Name = "frmQuestionView"
        Me.Text = "frmQuestionView"
        Me.plnBrowseMode.ResumeLayout(False)
        Me.plnEditMode.ResumeLayout(False)
        Me.plnReviewMode.ResumeLayout(False)
        Me.grbResponse.ResumeLayout(False)
        Me.grbResponse.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblTopic As Label
    Friend WithEvents lblQuestion As Label
    Friend WithEvents lblAnswer As Label
    Friend WithEvents txtTopic As TextBox
    Friend WithEvents txtQuestion As TextBox
    Friend WithEvents rtbAnswer As RichTextBox
    Friend WithEvents plnBrowseMode As Panel
    Friend WithEvents btnNew As Button
    Friend WithEvents btnReview As Button
    Friend WithEvents btnPrev As Button
    Friend WithEvents btnNext As Button
    Friend WithEvents plnEditMode As Panel
    Friend WithEvents btnSave As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents plnReviewMode As Panel
    Friend WithEvents btnStop As Button
    Friend WithEvents grbResponse As GroupBox
    Friend WithEvents optExcellent As RadioButton
    Friend WithEvents optGood As RadioButton
    Friend WithEvents optAverage As RadioButton
    Friend WithEvents optPoor As RadioButton
    Friend WithEvents optNull As RadioButton
    Friend WithEvents btnShowAnswer As Button
End Class
