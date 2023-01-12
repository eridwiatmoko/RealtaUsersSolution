Imports VBUsersDbLib.Model

Namespace Repository
    Public Interface IUserRolesRepository
        Function CreateUserRole(ByVal usro As User_roles) As User_roles
        Function DeleteUserRole(ByVal id As Int32) As Int32
        Function FindAllUserRole() As List(Of User_roles)
        Function FindAllUserRoleAsync() As Task(Of List(Of User_roles))
        Function FindUserRoleById(ByVal id As Int32) As User_roles
        Function UpdateUserRoleById(id As Integer, value As Integer, Optional showCommand As Boolean = False) As Boolean
        Function UpdateUserRoleBySp(id As Integer, value As Integer, Optional showCommand As Boolean = False) As Boolean
    End Interface
End Namespace
