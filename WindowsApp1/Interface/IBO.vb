Public Interface IBO
    Class DBObjectTYpe

    End Class
    Sub IBO_Initialize()
    ReadOnly Property IBO_isStored As Boolean
    ReadOnly Property IBO_dirty As Boolean
    Function IBO_Save() As Boolean
    Function IBO_Delete() As Boolean
    ReadOnly Property IBO_Id As Integer
    Function IBO_loadFromStorage() As Boolean
    Event IBO_Changed()
    Function IBO_isValid() As Boolean

End Interface
