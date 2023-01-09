Namespace Model
    Public Class Users
        Private _userId As Integer
        Private _userFullName As String
        Private _userType As String
        Private _userCompanyName As String
        Private _userEmail As String
        Private _userPhoneNumber As String
        Private _userModifiedDate As Date

        Public Sub New()
        End Sub

        Public Sub New(userId As Integer, userFullName As String, userType As String, userCompanyName As String, userEmail As String, userPhoneNumber As String, userModifiedDate As Date)
            _userId = userId
            _userFullName = userFullName
            _userType = userType
            _userCompanyName = userCompanyName
            _userEmail = userEmail
            _userPhoneNumber = userPhoneNumber
            _userModifiedDate = userModifiedDate
        End Sub

        Public Property UserId As Integer
            Get
                Return _userId
            End Get
            Set(value As Integer)
                _userId = value
            End Set
        End Property

        Public Property UserFullName As String
            Get
                Return _userFullName
            End Get
            Set(value As String)
                _userFullName = value
            End Set
        End Property

        Public Property UserType As String
            Get
                Return _userType
            End Get
            Set(value As String)
                _userType = value
            End Set
        End Property

        Public Property UserCompanyName As String
            Get
                Return _userCompanyName
            End Get
            Set(value As String)
                _userCompanyName = value
            End Set
        End Property

        Public Property UserEmail As String
            Get
                Return _userEmail
            End Get
            Set(value As String)
                _userEmail = value
            End Set
        End Property

        Public Property UserPhoneNumber As String
            Get
                Return _userPhoneNumber
            End Get
            Set(value As String)
                _userPhoneNumber = value
            End Set
        End Property

        Public Property UserModifiedDate As Date
            Get
                Return _userModifiedDate
            End Get
            Set(value As Date)
                _userModifiedDate = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"UserId : {UserId} | UserFullName : {UserFullName} | UserType : {UserType} | UserCompanyName : {UserCompanyName} | UserEmail : {UserEmail} | UserPhoneNumber : {UserPhoneNumber} | UserModifiedDate : {UserModifiedDate}"
        End Function
    End Class
End Namespace
