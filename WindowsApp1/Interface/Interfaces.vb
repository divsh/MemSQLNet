﻿#Region "MVP"
Public Interface ITopicQuestionView
    Sub Display()
    Sub RefeshQuestionsGrid(questions As List(Of clsQuestion))
    Function getSelectedTopicID() As Integer
    Sub populateTopicTree(topics As List(Of clsTopic))
    Function SelectNthRowFromCurrent(positionFromCurrent As Integer) As clsQuestion
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
    ReadOnly Property CurrentMode As QuestionViewMode
    ReadOnly Property DisplayedQuestion As clsQuestion
    ReadOnly Property DisplayedTopic As clsTopic
    Sub SetBusinessObjectOnView(question As clsQuestion)
    Sub DisplayBusinessObject(question As clsQuestion)
    Sub ChangeState(state As Object)
    Sub SetMode(mode As QuestionViewMode)
    Sub HideAnswer()
    Sub ShowAnswer()
    Sub ResetResponse()
End Interface


Public Interface IQuestionPresenter
    Function getQuestion(questionID As Integer) As clsQuestion
    Function GetTopic(questionID As Integer) As clsTopic
    Function GetTopicFromTopicID(topicID As Integer) As clsTopic
    Sub OnSaveClicked(displayedBusinessObject As clsQuestion)
    Sub OnResponseSelected(question As IBO, response As clsQuestion.Recall)
    Sub OnCancelSelected(questionID As Integer, mode As QuestionViewMode)
    Sub OnPrevNextSelected(nextQuestionID As Integer)
    Sub OnReviewSelected(topicID As Integer)
    Sub OnNewSelected()
    Sub OnStopReviewSelected()
    Sub OnDisplayedQuestionChange(lastquestion As clsQuestion)
    Sub onQuestionEditRequest()
End Interface
#End Region

Interface IQuestionReviewPlan
    ReadOnly Property ReviewPlan As IEnumerable(Of clsQuestion)
End Interface
Public Interface IQuestionPlannable
    ReadOnly Property LastRecallGrade As Integer
    ReadOnly Property AverageRecallScaled100K As Integer
    ReadOnly Property ReviewCount As Integer
    ReadOnly Property LastReviewDateTime As Date
End Interface

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

