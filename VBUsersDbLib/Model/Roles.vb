Namespace Model
    Public Class Roles
        Private _roleId As Integer
        Private _roleName As String

        Public Sub New()
        End Sub

        Public Sub New(roleId As Integer, roleName As String)
            Me.RoleId = roleId
            Me.RoleName = roleName
        End Sub

        Public Property RoleId As Integer
            Get
                Return _roleId
            End Get
            Set(value As Integer)
                _roleId = value
            End Set
        End Property

        Public Property RoleName As String
            Get
                Return _roleName
            End Get
            Set(value As String)
                _roleName = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"RoleId : {RoleId} | RoleName : {RoleName}"
        End Function
    End Class
End Namespace
