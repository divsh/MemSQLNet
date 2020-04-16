Public Interface IBO
    Event IBO_Changed()
    Sub Initialize()
    ReadOnly Property IsStored As Boolean
    ReadOnly Property IsDirty As Boolean
    Function Save() As Boolean
    Function Delete() As Boolean
    ReadOnly Property IBO_ID As Integer
    Function LoadFromStorage() As Boolean
    Function IsValid() As Boolean
End Interface
