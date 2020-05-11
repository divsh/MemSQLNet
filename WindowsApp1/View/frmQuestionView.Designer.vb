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
        Me.btnShowAnswer = New System.Windows.Forms.Button()
        Me.grbResponse = New System.Windows.Forms.GroupBox()
        Me.optExcellent = New System.Windows.Forms.RadioButton()
        Me.optGood = New System.Windows.Forms.RadioButton()
        Me.optAverage = New System.Windows.Forms.RadioButton()
        Me.optPoor = New System.Windows.Forms.RadioButton()
        Me.optNull = New System.Windows.Forms.RadioButton()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.lblTimeSinceLastReview = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTimeSinceLastReview = New System.Windows.Forms.TextBox()
        Me.txtPrevRecall = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtTotalReview = New System.Windows.Forms.TextBox()
        Me.txtAverageRecall = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.plnBrowseMode.SuspendLayout()
        Me.plnEditMode.SuspendLayout()
        Me.plnReviewMode.SuspendLayout()
        Me.grbResponse.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblTopic
        '
        Me.lblTopic.AutoSize = True
        Me.lblTopic.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTopic.Location = New System.Drawing.Point(8, 3)
        Me.lblTopic.Name = "lblTopic"
        Me.lblTopic.Size = New System.Drawing.Size(62, 25)
        Me.lblTopic.TabIndex = 0
        Me.lblTopic.Text = "Topic"
        '
        'lblQuestion
        '
        Me.lblQuestion.AutoSize = True
        Me.lblQuestion.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuestion.Location = New System.Drawing.Point(8, 53)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(102, 25)
        Me.lblQuestion.TabIndex = 1
        Me.lblQuestion.Text = "Question"
        '
        'lblAnswer
        '
        Me.lblAnswer.AutoSize = True
        Me.lblAnswer.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAnswer.Location = New System.Drawing.Point(8, 166)
        Me.lblAnswer.Name = "lblAnswer"
        Me.lblAnswer.Size = New System.Drawing.Size(86, 25)
        Me.lblAnswer.TabIndex = 2
        Me.lblAnswer.Text = "Answer"
        '
        'txtTopic
        '
        Me.txtTopic.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTopic.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTopic.Location = New System.Drawing.Point(72, 3)
        Me.txtTopic.Multiline = True
        Me.txtTopic.Name = "txtTopic"
        Me.txtTopic.ReadOnly = True
        Me.txtTopic.Size = New System.Drawing.Size(1353, 47)
        Me.txtTopic.TabIndex = 3
        '
        'txtQuestion
        '
        Me.txtQuestion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtQuestion.BackColor = System.Drawing.Color.White
        Me.txtQuestion.Font = New System.Drawing.Font("Verdana", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuestion.Location = New System.Drawing.Point(10, 81)
        Me.txtQuestion.Multiline = True
        Me.txtQuestion.Name = "txtQuestion"
        Me.txtQuestion.ReadOnly = True
        Me.txtQuestion.Size = New System.Drawing.Size(1413, 46)
        Me.txtQuestion.TabIndex = 4
        '
        'rtbAnswer
        '
        Me.rtbAnswer.AcceptsTab = True
        Me.rtbAnswer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbAnswer.AutoWordSelection = True
        Me.rtbAnswer.BackColor = System.Drawing.Color.White
        Me.rtbAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.rtbAnswer.EnableAutoDragDrop = True
        Me.rtbAnswer.Font = New System.Drawing.Font("Verdana", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbAnswer.Location = New System.Drawing.Point(10, 194)
        Me.rtbAnswer.Name = "rtbAnswer"
        Me.rtbAnswer.ReadOnly = True
        Me.rtbAnswer.ShowSelectionMargin = True
        Me.rtbAnswer.Size = New System.Drawing.Size(1411, 341)
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
        Me.plnBrowseMode.Location = New System.Drawing.Point(8, 540)
        Me.plnBrowseMode.Name = "plnBrowseMode"
        Me.plnBrowseMode.Size = New System.Drawing.Size(1411, 91)
        Me.plnBrowseMode.TabIndex = 15
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(3, 25)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(141, 43)
        Me.btnNew.TabIndex = 17
        Me.btnNew.Text = "New"
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnReview
        '
        Me.btnReview.Location = New System.Drawing.Point(150, 25)
        Me.btnReview.Name = "btnReview"
        Me.btnReview.Size = New System.Drawing.Size(141, 43)
        Me.btnReview.TabIndex = 18
        Me.btnReview.Text = "Review"
        Me.btnReview.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrev.Location = New System.Drawing.Point(1120, 25)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(141, 43)
        Me.btnPrev.TabIndex = 15
        Me.btnPrev.Text = "Prev"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNext.Location = New System.Drawing.Point(1267, 25)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(141, 43)
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
        Me.plnEditMode.Location = New System.Drawing.Point(12, 411)
        Me.plnEditMode.Name = "plnEditMode"
        Me.plnEditMode.Size = New System.Drawing.Size(1411, 91)
        Me.plnEditMode.TabIndex = 16
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(1120, 25)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(141, 43)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(1267, 25)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(141, 43)
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
        Me.plnReviewMode.Location = New System.Drawing.Point(16, 303)
        Me.plnReviewMode.Name = "plnReviewMode"
        Me.plnReviewMode.Size = New System.Drawing.Size(1411, 91)
        Me.plnReviewMode.TabIndex = 17
        '
        'btnShowAnswer
        '
        Me.btnShowAnswer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnShowAnswer.Location = New System.Drawing.Point(281, 26)
        Me.btnShowAnswer.Name = "btnShowAnswer"
        Me.btnShowAnswer.Size = New System.Drawing.Size(970, 43)
        Me.btnShowAnswer.TabIndex = 22
        Me.btnShowAnswer.Text = "Show Answer"
        Me.btnShowAnswer.UseVisualStyleBackColor = True
        '
        'grbResponse
        '
        Me.grbResponse.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grbResponse.Controls.Add(Me.optExcellent)
        Me.grbResponse.Controls.Add(Me.optGood)
        Me.grbResponse.Controls.Add(Me.optAverage)
        Me.grbResponse.Controls.Add(Me.optPoor)
        Me.grbResponse.Controls.Add(Me.optNull)
        Me.grbResponse.Location = New System.Drawing.Point(688, 0)
        Me.grbResponse.Name = "grbResponse"
        Me.grbResponse.Size = New System.Drawing.Size(568, 91)
        Me.grbResponse.TabIndex = 21
        Me.grbResponse.TabStop = False
        '
        'optExcellent
        '
        Me.optExcellent.AutoSize = True
        Me.optExcellent.Location = New System.Drawing.Point(444, 34)
        Me.optExcellent.Name = "optExcellent"
        Me.optExcellent.Size = New System.Drawing.Size(98, 24)
        Me.optExcellent.TabIndex = 5
        Me.optExcellent.TabStop = True
        Me.optExcellent.Text = "Excellent"
        Me.optExcellent.UseVisualStyleBackColor = True
        '
        'optGood
        '
        Me.optGood.AutoSize = True
        Me.optGood.Location = New System.Drawing.Point(339, 34)
        Me.optGood.Name = "optGood"
        Me.optGood.Size = New System.Drawing.Size(74, 24)
        Me.optGood.TabIndex = 4
        Me.optGood.TabStop = True
        Me.optGood.Text = "Good"
        Me.optGood.UseVisualStyleBackColor = True
        '
        'optAverage
        '
        Me.optAverage.AutoSize = True
        Me.optAverage.Location = New System.Drawing.Point(213, 34)
        Me.optAverage.Name = "optAverage"
        Me.optAverage.Size = New System.Drawing.Size(93, 24)
        Me.optAverage.TabIndex = 3
        Me.optAverage.TabStop = True
        Me.optAverage.Text = "Average"
        Me.optAverage.UseVisualStyleBackColor = True
        '
        'optPoor
        '
        Me.optPoor.AutoSize = True
        Me.optPoor.Location = New System.Drawing.Point(114, 34)
        Me.optPoor.Name = "optPoor"
        Me.optPoor.Size = New System.Drawing.Size(67, 24)
        Me.optPoor.TabIndex = 2
        Me.optPoor.TabStop = True
        Me.optPoor.Text = "Poor"
        Me.optPoor.UseVisualStyleBackColor = True
        '
        'optNull
        '
        Me.optNull.AutoSize = True
        Me.optNull.Location = New System.Drawing.Point(21, 34)
        Me.optNull.Name = "optNull"
        Me.optNull.Size = New System.Drawing.Size(60, 24)
        Me.optNull.TabIndex = 1
        Me.optNull.TabStop = True
        Me.optNull.Text = "Null"
        Me.optNull.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStop.Location = New System.Drawing.Point(1264, 26)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(141, 43)
        Me.btnStop.TabIndex = 16
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'lblTimeSinceLastReview
        '
        Me.lblTimeSinceLastReview.AutoSize = True
        Me.lblTimeSinceLastReview.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimeSinceLastReview.Location = New System.Drawing.Point(8, 130)
        Me.lblTimeSinceLastReview.Name = "lblTimeSinceLastReview"
        Me.lblTimeSinceLastReview.Size = New System.Drawing.Size(245, 25)
        Me.lblTimeSinceLastReview.TabIndex = 18
        Me.lblTimeSinceLastReview.Text = "Time since last review:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(352, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(138, 25)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Prev. Recall:"
        '
        'txtTimeSinceLastReview
        '
        Me.txtTimeSinceLastReview.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTimeSinceLastReview.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTimeSinceLastReview.Location = New System.Drawing.Point(247, 133)
        Me.txtTimeSinceLastReview.Multiline = True
        Me.txtTimeSinceLastReview.Name = "txtTimeSinceLastReview"
        Me.txtTimeSinceLastReview.ReadOnly = True
        Me.txtTimeSinceLastReview.Size = New System.Drawing.Size(111, 37)
        Me.txtTimeSinceLastReview.TabIndex = 20
        Me.txtTimeSinceLastReview.Text = "tt"
        '
        'txtPrevRecall
        '
        Me.txtPrevRecall.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPrevRecall.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrevRecall.Location = New System.Drawing.Point(481, 133)
        Me.txtPrevRecall.Multiline = True
        Me.txtPrevRecall.Name = "txtPrevRecall"
        Me.txtPrevRecall.ReadOnly = True
        Me.txtPrevRecall.Size = New System.Drawing.Size(153, 37)
        Me.txtPrevRecall.TabIndex = 21
        Me.txtPrevRecall.Text = "tt"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(630, 130)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 25)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Total reviews:"
        '
        'txtTotalReview
        '
        Me.txtTotalReview.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalReview.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalReview.Location = New System.Drawing.Point(777, 130)
        Me.txtTotalReview.Multiline = True
        Me.txtTotalReview.Name = "txtTotalReview"
        Me.txtTotalReview.ReadOnly = True
        Me.txtTotalReview.Size = New System.Drawing.Size(153, 37)
        Me.txtTotalReview.TabIndex = 23
        Me.txtTotalReview.Text = "tt"
        '
        'txtAverageRecall
        '
        Me.txtAverageRecall.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtAverageRecall.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAverageRecall.Location = New System.Drawing.Point(1057, 130)
        Me.txtAverageRecall.Multiline = True
        Me.txtAverageRecall.Name = "txtAverageRecall"
        Me.txtAverageRecall.ReadOnly = True
        Me.txtAverageRecall.Size = New System.Drawing.Size(153, 37)
        Me.txtAverageRecall.TabIndex = 25
        Me.txtAverageRecall.Text = "tt"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(896, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(166, 25)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Average recall:"
        '
        'frmQuestionView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1432, 642)
        Me.Controls.Add(Me.txtAverageRecall)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtTotalReview)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPrevRecall)
        Me.Controls.Add(Me.txtTimeSinceLastReview)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblTimeSinceLastReview)
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
    Friend WithEvents lblTimeSinceLastReview As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTimeSinceLastReview As TextBox
    Friend WithEvents txtPrevRecall As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTotalReview As TextBox
    Friend WithEvents txtAverageRecall As TextBox
    Friend WithEvents Label3 As Label
End Class
