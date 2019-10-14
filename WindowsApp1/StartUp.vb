Imports SQLite
Public Class StartUp
    Public Shared Function Main() As Int32
        Dim app As StartUp = New StartUp
        app.Run()
        Return 0
    End Function

    Private Sub Run()
        Dim dbContext As DBContext = New DBContext("C:\A1\work\MemSQLNet\foofoo.db")
        Dim aQuestion As Question = New Question(dbContext)
        'Dim aTopic As Topic = New Topic(dbContext)

        aQuestion = Question.FetchBusinessObjects(dbContext, Function(x) x.Id <> 5).FirstOrDefault()
        'MessageBox.Show(dbContext.Table(Of WindowsApp1.Question.Question).Where(Function(x) x.Id = 5).ToList().Count)


        aQuestion.Name = "capital of new zeland"
        aQuestion.Ans = "wellington"
        aQuestion.NextReviewDate = Convert.ToDateTime("3/4/2020")
        aQuestion.Save()

        'aQuestion = dbContext.Table(Of Question)().Where(Function(x) x.Id = 2).ToList().Item(0)
        'Debug.WriteLine(aQuestion.GetAll().Count.ToString)
        'Console.WriteLine(aQuestion.GetAll().Count.ToString)
        'Console.ReadKey()


    End Sub

End Class
