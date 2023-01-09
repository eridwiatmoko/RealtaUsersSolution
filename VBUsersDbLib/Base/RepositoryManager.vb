Imports VBUsersDbLib.Context
Imports VBUsersDbLib.Repository

Namespace Base
    Public Class RepositoryManager
        Implements IRepositoryManager

        Private _usersRepository As IUsersRepository
        Private ReadOnly _repositoryContext As IRepositoryContext

        Public Sub New(repositoryContext As IRepositoryContext)
            _repositoryContext = repositoryContext
        End Sub

        Public ReadOnly Property Users As IUsersRepository Implements IRepositoryManager.Users
            Get
                'up iregionrepository & implementation
                If _usersRepository Is Nothing Then
                    _usersRepository = New UsersRepository(_repositoryContext)
                End If
                Return _usersRepository
            End Get
        End Property


    End Class
End Namespace