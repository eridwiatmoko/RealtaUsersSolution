Namespace Model
    Public Class User_profiles
        Private _usproId As Integer
        Private _usproNationalId As String
        Private _usproBirthDate As Date
        Private _usproJobTitle As String
        Private _usproMaritalStatus As String
        Private _usproGender As String
        Private _usproAddrId As Integer
        Private _usproUserId As Integer

        Public Sub New()
        End Sub

        Public Sub New(usproId As Integer, usproNationalId As String, usproBirthDate As Date, usproJobTitle As String, usproMaritalStatus As String, usproGender As String, usproAddrId As Integer, usproUserId As Integer)
            _usproId = usproId
            _usproNationalId = usproNationalId
            _usproBirthDate = usproBirthDate
            _usproJobTitle = usproJobTitle
            _usproMaritalStatus = usproMaritalStatus
            _usproGender = usproGender
            _usproAddrId = usproAddrId
            _usproUserId = usproUserId
        End Sub

        Public Property UsproId As Integer
            Get
                Return _usproId
            End Get
            Set(value As Integer)
                _usproId = value
            End Set
        End Property

        Public Property UsproNationalId As String
            Get
                Return _usproNationalId
            End Get
            Set(value As String)
                _usproNationalId = value
            End Set
        End Property

        Public Property UsproBirthDate As Date
            Get
                Return _usproBirthDate
            End Get
            Set(value As Date)
                _usproBirthDate = value
            End Set
        End Property

        Public Property UsproJobTitle As String
            Get
                Return _usproJobTitle
            End Get
            Set(value As String)
                _usproJobTitle = value
            End Set
        End Property

        Public Property UsproMaritalStatus As String
            Get
                Return _usproMaritalStatus
            End Get
            Set(value As String)
                _usproMaritalStatus = value
            End Set
        End Property

        Public Property UsproGender As String
            Get
                Return _usproGender
            End Get
            Set(value As String)
                _usproGender = value
            End Set
        End Property

        Public Property UsproAddrId As Integer
            Get
                Return _usproAddrId
            End Get
            Set(value As Integer)
                _usproAddrId = value
            End Set
        End Property

        Public Property UsproUserId As Integer
            Get
                Return _usproUserId
            End Get
            Set(value As Integer)
                _usproUserId = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"UsproId : {UsproId} | UsproNationalId : {UsproNationalId} | UsproBirthDate : {UsproBirthDate} | UsproJobTitle : {UsproJobTitle} | UsproMaritalStatus : {UsproMaritalStatus} | UsproGender : {UsproGender} | UsproAddrId : {UsproAddrId} | UsproUserId : {UsproUserId}"
        End Function
    End Class
End Namespace
