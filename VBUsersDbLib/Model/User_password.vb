Namespace Model
    Public Class User_password
        Private _uspaUserId As Integer
        Private _uspaPasswordHash As String
        Private _uspaPasswordSalt As String

        Public Sub New()
        End Sub

        Public Sub New(uspaUserId As Integer, uspaPasswordHash As String, uspaPasswordSalt As String)
            _uspaUserId = uspaUserId
            _uspaPasswordHash = uspaPasswordHash
            _uspaPasswordSalt = uspaPasswordSalt
        End Sub

        Public Property UspaUserId As Integer
            Get
                Return _uspaUserId
            End Get
            Set(value As Integer)
                _uspaUserId = value
            End Set
        End Property

        Public Property UspaPasswordHash As String
            Get
                Return _uspaPasswordHash
            End Get
            Set(value As String)
                _uspaPasswordHash = value
            End Set
        End Property

        Public Property UspaPasswordSalt As String
            Get
                Return _uspaPasswordSalt
            End Get
            Set(value As String)
                _uspaPasswordSalt = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"UspaUserId : {UspaUserId} | UspaPasswordHash : {UspaPasswordHash} | UspaPasswordSalt : {UspaPasswordSalt}"
        End Function
    End Class
End Namespace
