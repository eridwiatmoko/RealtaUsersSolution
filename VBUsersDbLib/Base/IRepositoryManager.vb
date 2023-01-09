Imports VBUsersDbLib.Repository

Namespace Base
    Public Interface IRepositoryManager
        ReadOnly Property Users As IUsersRepository
    End Interface
End Namespace