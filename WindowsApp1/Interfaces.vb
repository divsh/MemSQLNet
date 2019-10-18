#Region "MVP"
Public Interface ITopicQuestionView
    Sub Display()
    Sub RefeshQuestionsGrid(questions As List(Of clsQuestion))
    Function getSelectedTopicID() As Integer
    Sub populateTopicTree(topics As List(Of clsTopic))
End Interface

Public Interface ITopicQuestionPresenter
    Function GetAllTopics() As List(Of clsTopic)
    Sub OnTopicSelectionChanged(selectedTopicID As Integer)
    Sub OnQuestionsDroppedOnTopic(questionIDs As List(Of Integer))
    Sub OnTopicRenamed(topicIDRenamed As Integer, newName As String)
    Sub OnTopicParentTopicChanged(topicIDChanged As Integer, newParentTopicID As Integer)
    Sub OnQuestionsDroppedOnTopic(quesions As Integer(), droppedOnTopicID As Integer)
    Sub OnQuestionDelete(questionID As Integer)
End Interface

#End Region

Public Interface ITopicView
    Event SelectedTopicChanged(changedToTopicID As Integer)
    Event DroppedOnTopic(droppedOnTopicID As Integer, typeOFItemDropped As DroppedItemType, droppedObjects As List(Of Object))
    Sub RenameTopic(topicID As Integer, newName As String)
    Sub ChangeParentTopic(childTopicID As Integer, parentTopicID As Integer)
    Sub PopulateTopics()
End Interface
Public Interface IQuestionGridView
    Event RequestToOpenQuestionView(questionID As Integer)
    Sub PopulateQuestions(questions As List(Of Object))
    Sub SelectQuestions(questions() As Integer)
End Interface



Public Interface ITopicViewController
    Sub getAllTopics()
End Interface

Public Interface IQuestionGridViewController

End Interface
Public Interface ITopicQuestionViewController

End Interface

Public Interface IQuestionView

End Interface

Public Interface IQuestionViewController

End Interface

Public Enum DroppedItemType
    Topic
    Question
End Enum

Module Interfaces

End Module

