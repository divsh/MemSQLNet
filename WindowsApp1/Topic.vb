Imports SQLite
Public Class Topic
    <PrimaryKey, AutoIncrement>
    Property ID As Integer
    <NotNull>
    Property Name As String
    <Indexed>
    Property ParentTopicID As Integer

    'getQuestions
    'addQuestion()

End Class
