Imports VBUsersDbLib.Model

Namespace Repository
    Public Interface IUsersRepository
        Function CreateUser(ByVal users As Users) As Users
        Function DeleteUser(ByVal id As Int32) As Int32
        Function FindAllUser() As List(Of Users)
        Function FindAllUserAsync() As Task(Of List(Of Users))
        Function FindUserById(ByVal id As Int32) As Users
        Function UpdateUserById(id As Integer, name As String, type As String, company As String, email As String, phone As String, Optional showCommand As Boolean = False) As Boolean
        Function UpdateUserBySp(id As Integer, name As String, type As String, company As String, email As String, phone As String, Optional showCommand As Boolean = False) As Boolean
    End Interface
End Namespace
