Namespace Model
    Public Class User_roles
        Private _usroUserId As Integer
        Private _usroRoleId As Integer

        Public Sub New()
        End Sub

        Public Sub New(usroUserId As Integer, usroRoleId As Integer)
            _usroUserId = usroUserId
            _usroRoleId = usroRoleId
        End Sub

        Public Property UsroUserId As Integer
            Get
                Return _usroUserId
            End Get
            Set(value As Integer)
                _usroUserId = value
            End Set
        End Property

        Public Property UsroRoleId As Integer
            Get
                Return _usroRoleId
            End Get
            Set(value As Integer)
                _usroRoleId = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"UsroUserId : {UsroUserId} | UsroRoleId : {UsroRoleId}"
        End Function
    End Class
End Namespace
