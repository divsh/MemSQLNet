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

Public Interface ITopicQuestionView
    Sub QuestionsDroppedOnTopic(quesions As Integer(), droppedOnTopicID As Integer)
    Sub Show()
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

