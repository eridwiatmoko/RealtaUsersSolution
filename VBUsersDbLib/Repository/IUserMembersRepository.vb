Imports VBUsersDbLib.Model

Namespace Repository
    Public Interface IUserMembersRepository
        Function CreateUserMember(ByVal usme As User_members) As User_members
        Function DeleteUserMember(ByVal id As Int32) As Int32
        Function FindAllUserMember() As List(Of User_members)
        Function FindAllUserMembersAsync() As Task(Of List(Of User_members))
        Function FindUserMemberById(ByVal id As Int32) As User_members
        Function UpdateUserMemberById(id As Integer, memb_name As String, promote_date As Date, points As Integer, type As String, Optional showCommand As Boolean = False) As Boolean
        Function UpdateUserMemberBySp(id As Integer, memb_name As String, promote_date As Date, points As Integer, type As String, Optional showCommand As Boolean = False) As Boolean
    End Interface
End Namespace
