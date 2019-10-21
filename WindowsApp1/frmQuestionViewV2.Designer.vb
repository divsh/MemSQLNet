<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmQuestionViewV2
    Inherits MetroFramework.Forms.MetroForm

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
        Me.rtbAnswer = New System.Windows.Forms.RichTextBox()
        Me.lblQuestion = New MetroFramework.Controls.MetroLabel()
        Me.lblTopic = New MetroFramework.Controls.MetroLabel()
        Me.lblAnswer = New MetroFramework.Controls.MetroLabel()
        Me.txtTopic = New MetroFramework.Controls.MetroTextBox()
        Me.txtQuestion = New MetroFramework.Controls.MetroTextBox()
        Me.plnEditMode = New MetroFramework.Controls.MetroPanel()
        Me.btnCancel = New MetroFramework.Controls.MetroButton()
        Me.btnSave = New MetroFramework.Controls.MetroButton()
        Me.plnBrowse = New MetroFramework.Controls.MetroPanel()
        Me.btnPrev = New MetroFramework.Controls.MetroButton()
        Me.btnNext = New MetroFramework.Controls.MetroButton()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.btnNew = New MetroFramework.Controls.MetroButton()
        Me.btnReview = New MetroFramework.Controls.MetroButton()
        Me.MetroPanel1 = New MetroFramework.Controls.MetroPanel()
        Me.btnShowAnswer = New MetroFramework.Controls.MetroButton()
        Me.btnStop = New MetroFramework.Controls.MetroButton()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.MetroPanel2 = New MetroFramework.Controls.MetroPanel()
        Me.optNull = New MetroFramework.Controls.MetroRadioButton()
        Me.optPoor = New MetroFramework.Controls.MetroRadioButton()
        Me.optAverage = New MetroFramework.Controls.MetroRadioButton()
        Me.optGood = New MetroFramework.Controls.MetroRadioButton()
        Me.optBetter = New MetroFramework.Controls.MetroRadioButton()
        Me.optExcellent = New MetroFramework.Controls.MetroRadioButton()
        Me.plnEditMode.SuspendLayout()
        Me.plnBrowse.SuspendLayout()
        Me.MetroPanel1.SuspendLayout()
        Me.MetroPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'rtbAnswer
        '
        Me.rtbAnswer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.rtbAnswer.Location = New System.Drawing.Point(100, 162)
        Me.rtbAnswer.Margin = New System.Windows.Forms.Padding(2)
        Me.rtbAnswer.Name = "rtbAnswer"
        Me.rtbAnswer.ReadOnly = True
        Me.rtbAnswer.Size = New System.Drawing.Size(682, 365)
        Me.rtbAnswer.TabIndex = 23
        Me.rtbAnswer.Text = ""
        '
        'lblQuestion
        '
        Me.lblQuestion.AutoSize = True
        Me.lblQuestion.Location = New System.Drawing.Point(32, 98)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(61, 19)
        Me.lblQuestion.TabIndex = 27
        Me.lblQuestion.Text = "Question"
        '
        'lblTopic
        '
        Me.lblTopic.AutoSize = True
        Me.lblTopic.Location = New System.Drawing.Point(54, 60)
        Me.lblTopic.Name = "lblTopic"
        Me.lblTopic.Size = New System.Drawing.Size(39, 19)
        Me.lblTopic.TabIndex = 28
        Me.lblTopic.Text = "Topic"
        '
        'lblAnswer
        '
        Me.lblAnswer.AutoSize = True
        Me.lblAnswer.Location = New System.Drawing.Point(42, 162)
        Me.lblAnswer.Name = "lblAnswer"
        Me.lblAnswer.Size = New System.Drawing.Size(51, 19)
        Me.lblAnswer.TabIndex = 29
        Me.lblAnswer.Text = "Answer"
        '
        'txtTopic
        '
        '
        '
        '
        Me.txtTopic.CustomButton.Image = Nothing
        Me.txtTopic.CustomButton.Location = New System.Drawing.Point(661, 1)
        Me.txtTopic.CustomButton.Name = ""
        Me.txtTopic.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.txtTopic.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtTopic.CustomButton.TabIndex = 1
        Me.txtTopic.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtTopic.CustomButton.UseSelectable = True
        Me.txtTopic.CustomButton.Visible = False
        Me.txtTopic.Lines = New String(-1) {}
        Me.txtTopic.Location = New System.Drawing.Point(99, 60)
        Me.txtTopic.MaxLength = 32767
        Me.txtTopic.Name = "txtTopic"
        Me.txtTopic.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtTopic.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtTopic.SelectedText = ""
        Me.txtTopic.SelectionLength = 0
        Me.txtTopic.SelectionStart = 0
        Me.txtTopic.ShortcutsEnabled = True
        Me.txtTopic.Size = New System.Drawing.Size(683, 23)
        Me.txtTopic.TabIndex = 30
        Me.txtTopic.UseSelectable = True
        Me.txtTopic.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtTopic.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'txtQuestion
        '
        '
        '
        '
        Me.txtQuestion.CustomButton.Image = Nothing
        Me.txtQuestion.CustomButton.Location = New System.Drawing.Point(631, 1)
        Me.txtQuestion.CustomButton.Name = ""
        Me.txtQuestion.CustomButton.Size = New System.Drawing.Size(51, 51)
        Me.txtQuestion.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.txtQuestion.CustomButton.TabIndex = 1
        Me.txtQuestion.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.txtQuestion.CustomButton.UseSelectable = True
        Me.txtQuestion.CustomButton.Visible = False
        Me.txtQuestion.Lines = New String(-1) {}
        Me.txtQuestion.Location = New System.Drawing.Point(99, 98)
        Me.txtQuestion.MaxLength = 32767
        Me.txtQuestion.Multiline = True
        Me.txtQuestion.Name = "txtQuestion"
        Me.txtQuestion.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtQuestion.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.txtQuestion.SelectedText = ""
        Me.txtQuestion.SelectionLength = 0
        Me.txtQuestion.SelectionStart = 0
        Me.txtQuestion.ShortcutsEnabled = True
        Me.txtQuestion.Size = New System.Drawing.Size(683, 53)
        Me.txtQuestion.TabIndex = 31
        Me.txtQuestion.UseSelectable = True
        Me.txtQuestion.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.txtQuestion.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'plnEditMode
        '
        Me.plnEditMode.Controls.Add(Me.btnSave)
        Me.plnEditMode.Controls.Add(Me.btnCancel)
        Me.plnEditMode.HorizontalScrollbarBarColor = True
        Me.plnEditMode.HorizontalScrollbarHighlightOnWheel = False
        Me.plnEditMode.HorizontalScrollbarSize = 10
        Me.plnEditMode.Location = New System.Drawing.Point(139, 289)
        Me.plnEditMode.Name = "plnEditMode"
        Me.plnEditMode.Size = New System.Drawing.Size(683, 53)
        Me.plnEditMode.TabIndex = 34
        Me.plnEditMode.VerticalScrollbarBarColor = True
        Me.plnEditMode.VerticalScrollbarHighlightOnWheel = False
        Me.plnEditMode.VerticalScrollbarSize = 10
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(605, 15)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 34
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseSelectable = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(524, 15)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 35
        Me.btnSave.Text = "Save"
        Me.btnSave.UseSelectable = True
        '
        'plnBrowse
        '
        Me.plnBrowse.Controls.Add(Me.btnNew)
        Me.plnBrowse.Controls.Add(Me.btnReview)
        Me.plnBrowse.Controls.Add(Me.btnPrev)
        Me.plnBrowse.Controls.Add(Me.btnNext)
        Me.plnBrowse.Controls.Add(Me.RichTextBox1)
        Me.plnBrowse.HorizontalScrollbarBarColor = True
        Me.plnBrowse.HorizontalScrollbarHighlightOnWheel = False
        Me.plnBrowse.HorizontalScrollbarSize = 10
        Me.plnBrowse.Location = New System.Drawing.Point(99, 532)
        Me.plnBrowse.Name = "plnBrowse"
        Me.plnBrowse.Size = New System.Drawing.Size(683, 53)
        Me.plnBrowse.TabIndex = 35
        Me.plnBrowse.VerticalScrollbarBarColor = True
        Me.plnBrowse.VerticalScrollbarHighlightOnWheel = False
        Me.plnBrowse.VerticalScrollbarSize = 10
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(524, 15)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(75, 23)
        Me.btnPrev.TabIndex = 35
        Me.btnPrev.Text = "Prev."
        Me.btnPrev.UseSelectable = True
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(605, 15)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(75, 23)
        Me.btnNext.TabIndex = 34
        Me.btnNext.Text = "Next"
        Me.btnNext.UseSelectable = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox1.Location = New System.Drawing.Point(-7, -36)
        Me.RichTextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(682, 31)
        Me.RichTextBox1.TabIndex = 23
        Me.RichTextBox1.Text = ""
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(3, 15)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 23)
        Me.btnNew.TabIndex = 37
        Me.btnNew.Text = "New"
        Me.btnNew.UseSelectable = True
        '
        'btnReview
        '
        Me.btnReview.Location = New System.Drawing.Point(84, 15)
        Me.btnReview.Name = "btnReview"
        Me.btnReview.Size = New System.Drawing.Size(75, 23)
        Me.btnReview.TabIndex = 36
        Me.btnReview.Text = "Review"
        Me.btnReview.UseSelectable = True
        '
        'MetroPanel1
        '
        Me.MetroPanel1.Controls.Add(Me.MetroPanel2)
        Me.MetroPanel1.Controls.Add(Me.btnShowAnswer)
        Me.MetroPanel1.Controls.Add(Me.btnStop)
        Me.MetroPanel1.Controls.Add(Me.RichTextBox2)
        Me.MetroPanel1.HorizontalScrollbarBarColor = True
        Me.MetroPanel1.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.HorizontalScrollbarSize = 10
        Me.MetroPanel1.Location = New System.Drawing.Point(139, 348)
        Me.MetroPanel1.Name = "MetroPanel1"
        Me.MetroPanel1.Size = New System.Drawing.Size(683, 53)
        Me.MetroPanel1.TabIndex = 36
        Me.MetroPanel1.VerticalScrollbarBarColor = True
        Me.MetroPanel1.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel1.VerticalScrollbarSize = 10
        '
        'btnShowAnswer
        '
        Me.btnShowAnswer.Location = New System.Drawing.Point(3, 15)
        Me.btnShowAnswer.Name = "btnShowAnswer"
        Me.btnShowAnswer.Size = New System.Drawing.Size(596, 23)
        Me.btnShowAnswer.TabIndex = 35
        Me.btnShowAnswer.Text = "Show Answer"
        Me.btnShowAnswer.UseSelectable = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(605, 15)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(75, 23)
        Me.btnStop.TabIndex = 34
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseSelectable = True
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RichTextBox2.Location = New System.Drawing.Point(-7, -36)
        Me.RichTextBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.ReadOnly = True
        Me.RichTextBox2.Size = New System.Drawing.Size(682, 31)
        Me.RichTextBox2.TabIndex = 23
        Me.RichTextBox2.Text = ""
        '
        'MetroPanel2
        '
        Me.MetroPanel2.Controls.Add(Me.optExcellent)
        Me.MetroPanel2.Controls.Add(Me.optBetter)
        Me.MetroPanel2.Controls.Add(Me.optGood)
        Me.MetroPanel2.Controls.Add(Me.optAverage)
        Me.MetroPanel2.Controls.Add(Me.optPoor)
        Me.MetroPanel2.Controls.Add(Me.optNull)
        Me.MetroPanel2.HorizontalScrollbarBarColor = True
        Me.MetroPanel2.HorizontalScrollbarHighlightOnWheel = False
        Me.MetroPanel2.HorizontalScrollbarSize = 10
        Me.MetroPanel2.Location = New System.Drawing.Point(3, 6)
        Me.MetroPanel2.Name = "MetroPanel2"
        Me.MetroPanel2.Size = New System.Drawing.Size(444, 40)
        Me.MetroPanel2.TabIndex = 38
        Me.MetroPanel2.VerticalScrollbarBarColor = True
        Me.MetroPanel2.VerticalScrollbarHighlightOnWheel = False
        Me.MetroPanel2.VerticalScrollbarSize = 10
        '
        'optNull
        '
        Me.optNull.AutoSize = True
        Me.optNull.Location = New System.Drawing.Point(3, 13)
        Me.optNull.Name = "optNull"
        Me.optNull.Size = New System.Drawing.Size(45, 15)
        Me.optNull.TabIndex = 2
        Me.optNull.Text = "Null"
        Me.optNull.UseSelectable = True
        '
        'optPoor
        '
        Me.optPoor.AutoSize = True
        Me.optPoor.Location = New System.Drawing.Point(69, 13)
        Me.optPoor.Name = "optPoor"
        Me.optPoor.Size = New System.Drawing.Size(48, 15)
        Me.optPoor.TabIndex = 3
        Me.optPoor.Text = "Poor"
        Me.optPoor.UseSelectable = True
        '
        'optAverage
        '
        Me.optAverage.AutoSize = True
        Me.optAverage.Location = New System.Drawing.Point(138, 13)
        Me.optAverage.Name = "optAverage"
        Me.optAverage.Size = New System.Drawing.Size(66, 15)
        Me.optAverage.TabIndex = 4
        Me.optAverage.Text = "Average"
        Me.optAverage.UseSelectable = True
        '
        'optGood
        '
        Me.optGood.AutoSize = True
        Me.optGood.Location = New System.Drawing.Point(225, 13)
        Me.optGood.Name = "optGood"
        Me.optGood.Size = New System.Drawing.Size(52, 15)
        Me.optGood.TabIndex = 5
        Me.optGood.Text = "Good"
        Me.optGood.UseSelectable = True
        '
        'optBetter
        '
        Me.optBetter.AutoSize = True
        Me.optBetter.Location = New System.Drawing.Point(298, 13)
        Me.optBetter.Name = "optBetter"
        Me.optBetter.Size = New System.Drawing.Size(54, 15)
        Me.optBetter.TabIndex = 6
        Me.optBetter.Text = "Better"
        Me.optBetter.UseSelectable = True
        '
        'optExcellent
        '
        Me.optExcellent.AutoSize = True
        Me.optExcellent.Location = New System.Drawing.Point(373, 13)
        Me.optExcellent.Name = "optExcellent"
        Me.optExcellent.Size = New System.Drawing.Size(69, 15)
        Me.optExcellent.TabIndex = 7
        Me.optExcellent.Text = "Excellent"
        Me.optExcellent.UseSelectable = True
        '
        'frmQuestionViewV2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(805, 608)
        Me.Controls.Add(Me.MetroPanel1)
        Me.Controls.Add(Me.plnBrowse)
        Me.Controls.Add(Me.plnEditMode)
        Me.Controls.Add(Me.rtbAnswer)
        Me.Controls.Add(Me.txtQuestion)
        Me.Controls.Add(Me.txtTopic)
        Me.Controls.Add(Me.lblAnswer)
        Me.Controls.Add(Me.lblTopic)
        Me.Controls.Add(Me.lblQuestion)
        Me.Name = "frmQuestionViewV2"
        Me.Text = "frmQuestionViewV2"
        Me.plnEditMode.ResumeLayout(False)
        Me.plnBrowse.ResumeLayout(False)
        Me.MetroPanel1.ResumeLayout(False)
        Me.MetroPanel2.ResumeLayout(False)
        Me.MetroPanel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rtbAnswer As RichTextBox
    Friend WithEvents lblQuestion As MetroFramework.Controls.MetroLabel
    Friend WithEvents lblTopic As MetroFramework.Controls.MetroLabel
    Friend WithEvents lblAnswer As MetroFramework.Controls.MetroLabel
    Friend WithEvents txtTopic As MetroFramework.Controls.MetroTextBox
    Friend WithEvents txtQuestion As MetroFramework.Controls.MetroTextBox
    Friend WithEvents plnEditMode As MetroFramework.Controls.MetroPanel
    Friend WithEvents btnSave As MetroFramework.Controls.MetroButton
    Friend WithEvents btnCancel As MetroFramework.Controls.MetroButton
    Friend WithEvents plnBrowse As MetroFramework.Controls.MetroPanel
    Friend WithEvents btnPrev As MetroFramework.Controls.MetroButton
    Friend WithEvents btnNext As MetroFramework.Controls.MetroButton
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents btnNew As MetroFramework.Controls.MetroButton
    Friend WithEvents btnReview As MetroFramework.Controls.MetroButton
    Friend WithEvents MetroPanel1 As MetroFramework.Controls.MetroPanel
    Friend WithEvents btnShowAnswer As MetroFramework.Controls.MetroButton
    Friend WithEvents btnStop As MetroFramework.Controls.MetroButton
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents MetroPanel2 As MetroFramework.Controls.MetroPanel
    Friend WithEvents optExcellent As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents optBetter As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents optGood As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents optAverage As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents optPoor As MetroFramework.Controls.MetroRadioButton
    Friend WithEvents optNull As MetroFramework.Controls.MetroRadioButton
End Class
