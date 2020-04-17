Public Class Form1
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dbContext As DBContext = New DBContext("C:\A1\work\MemSQLNet\foofoo.db")
        Dim a As clsQuestion = New clsQuestion(dbContext)
        a.Answer = RichTextBox1.Rtf
        a.Name = "richtext example"
        a.Save()
        Dim abc As clsQuestion = New clsQuestion(dbContext)
        RichTextBox1.Clear()
        Dim t As New clsTopic(dbContext)

        Dim b As clsQuestion
        b = clsQuestion.FetchBusinessObjects(dbContext, Function(x) x.Id = a.Id).FirstOrDefault()
        'Dim richText As String = New TextRange(RichTextBox1.Document.ContentStart, RichTextBox1.Document.ContentEnd).Text
        RichTextBox1.Rtf = b.Answer
        Dim rtfControl As New RichTextBox
        rtfControl.Rtf = b.Answer
        MessageBox.Show(rtfControl.Text)

    End Sub
End Class
