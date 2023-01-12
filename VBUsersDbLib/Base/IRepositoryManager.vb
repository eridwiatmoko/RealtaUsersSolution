Imports VBUsersDbLib.Repository

Namespace Base
    Public Interface IRepositoryManager
        ReadOnly Property Users As IUsersRepository
        ReadOnly Property UserRoles As IUserRolesRepository
    End Interface
End Namespace