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
        'createQuestions(dbContext)
        Dim topicQuestionView As ITopicQuestionView = New frmTopicQuestionView(dbContext)
        topicQuestionView.Display()
    End Sub

    Sub createQuestions(DBContext As DBContext)
        Dim espq As clsQuestion = New clsQuestion(DBContext)
        Dim vbnetq As clsQuestion = New clsQuestion(DBContext)

        espq.Name = "ESP full form?"
        espq.Answer = "Enterprise Sales Processing"
        espq.TopicID = 7
        espq.Save()

        vbnetq.Name = "test question"
        vbnetq.Answer = "test answer"
        vbnetq.TopicID = 9
        vbnetq.Save()
    End Sub
    Sub CreateTopicsAndQuestions(DBContext As DBContext)
        Dim ESP As clsTopic = New clsTopic(DBContext)
        Dim Net As clsTopic = New clsTopic(DBContext)
        Dim VBNet As clsTopic = New clsTopic(DBContext)
        Dim CSharp As clsTopic = New clsTopic(DBContext)

        ESP.Name = "ESP"
        ESP.Save()

        Net.Name = "NET"
        Net.Save()

        VBNet.ParentTopicID = Net.ID
        VBNet.Name = "VB.Net"
        VBNet.Save()

        CSharp.Name = "C#"
        CSharp.ParentTopicID = Net.ID
        CSharp.Save()
    End Sub

    Sub createSampleTopics(DBContext As DBContext)
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
        inorganic.Name = "Inorganic Chemistry"
        inorganic.ParentTopicID = chem.ID
        inorganic.Save()

        Dim maths As New clsTopic(DBContext)
        maths.Name = "Mathematics"
        maths.Save()

        Dim algebra As New clsTopic(DBContext)
        algebra.Name = "Algebra"
        algebra.ParentTopicID = maths.ID
        algebra.Save()
    End Sub


End Class
