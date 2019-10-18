#Region "MVP"
Public Interface ITopicQuestionView
    Sub Display()
    Sub RefeshQuestionsGrid(questions As List(Of clsQuestion))
    Function getSelectedTopicID() As Integer
    Sub populateTopicTree(topics As List(Of clsTopic))
End Interface

Public Interface ITopicQuestionPresenter
    Function GetAllTopics() As List(Of clsTopic)
    Sub OnQuestionDoubleClicked(questionID As Integer)
    Sub OnTopicSelectionChanged(selectedTopicID As Integer)
    Sub OnQuestionsDroppedOnTopic(questionIDs As List(Of Integer))
    Sub OnTopicRenamed(topicIDRenamed As Integer, newName As String)
    Sub OnTopicParentTopicChanged(topicIDChanged As Integer, newParentTopicID As Integer)
    Sub OnQuestionsDroppedOnTopic(quesions As Integer(), droppedOnTopicID As Integer)
    Sub OnQuestionDelete(questionID As Integer)
End Interface

Public Interface IQuestionView
    Sub Display(questionID As Integer)
    ReadOnly Property DisplayedBusinessObject As clsQuestion
    ReadOnly Property DisplayedBusinessObjectTopic As clsTopic
    Sub DisplayBusinessObject(question As clsQuestion)
    Sub ChangeState(state As Object)
    Sub SetMode(mode As QuestionViewMode)
End Interface


Public Interface IQuestionPresenter
    Function getQuestion(questionID As Integer) As clsQuestion
    Sub OnSaveClicked(questionID As Integer)
    Sub OnResponseSelected(questionID As Integer, response As clsQuestion.RecallStrength)
    Sub OnCancelSelected(questionID As Integer, mode As QuestionViewMode)
    Sub OnPrevNextSelected(nextQuestionID As Integer)
    Sub OnReviewSelected()
    Sub OnNewSelected()
End Interface
#End Region

Public Enum QuestionViewMode
    Create
    Detail
    Edit
    Review
End Enum

Public Enum DroppedItemType
    Topic
    Question
End Enum

Module Interfaces

End Module

