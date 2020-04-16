Imports SQLite
Public Class StartUp
    Public Shared Function Main() As Int32
        Dim app As StartUp = New StartUp
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        app.Run()
        Return 0
    End Function

    Private Sub Run1()
        Dim dbContext As DBContext = New DBContext("C:\A1\work\MemSQLNet\foofoo.db")
        Dim aQuestion As clsQuestion = New clsQuestion(dbContext)
        'Dim aTopic As Topic = New Topic(dbContext)

        aQuestion = clsQuestion.FetchBusinessObjects(dbContext, Function(x) x.Id <> 5).FirstOrDefault()
        'MessageBox.Show(dbContext.Table(Of WindowsApp1.Question.Question).Where(Function(x) x.Id = 5).ToList().Count)


        aQuestion.Name = "capital of new zeland"
        aQuestion.Answer = "wellington"
        'aQuestion.nextreviewdate = Convert.ToDateTime("3/4/2020")
        aQuestion.Save()

        'aQuestion = dbContext.Table(Of Question)().Where(Function(x) x.Id = 2).ToList().Item(0)
        'Debug.WriteLine(aQuestion.GetAll().Count.ToString)
        'Console.WriteLine(aQuestion.GetAll().Count.ToString)
        'Console.ReadKey()


    End Sub

    Private Sub Run()
        Dim dbContext As DBContext = New DBContext("C:\A1\Work\MemSQLNet\WindowsApp1\foofoo.db")
        'createsomeTopics(dbContext)
        Dim topicQuestionView As ITopicQuestionView = New frmTopicQuestionView(dbContext)
        topicQuestionView.Display()

        'Dim aTopicQuestionView As ITopicQuestionView
        'aTopicQuestionView = New TopicQuestionView(dbContext)
        'aTopicQuestionView.Show()
    End Sub

    Sub createsomeTopics(DBContext As DBContext)
        Dim science As clsTopic = New clsTopic(DBContext)
        science.Name = "science"
        science.Save()

        Dim phy As clsTopic = New clsTopic(DBContext)
        phy.Name = "physics"
        phy.ParentTopicID = science.ID
        phy.Save()

        Dim chem As clsTopic = New clsTopic(DBContext)
        chem.Name = "chemistry"
        chem.ParentTopicID = science.ID
        chem.Save()

        Dim organicchem As New clsTopic(DBContext)
        organicchem.Name = "organic chemistry"
        organicchem.ParentTopicID = chem.ID

        Dim inorganic As New clsTopic(DBContext)
        inorganic.Name = "Inorganic CHemistry"
        inorganic.ParentTopicID = chem.ID
        inorganic.Save()

        Dim maths As New clsTopic(DBContext)
        maths.name = "Mathematics"
        maths.Save

        Dim algebra As New clsTopic(DBContext)
        algebra.Name = "Algebra"
        algebra.ParentTopicID = maths.ID
        algebra.Save()
    End Sub


End Class
