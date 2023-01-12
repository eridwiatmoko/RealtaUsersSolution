Namespace Model
    Public Class User_members
        Private _usmeUserId As Integer
        Private _usmeMembName As String
        Private _usmePromoteDate As Date
        Private _usmePoints As Integer
        Private _usmeType As String

        Public Sub New()
        End Sub

        Public Sub New(usmeUserId As Integer, usmeMembName As String, usmePromoteDate As Date, usmePoints As Integer, usmeType As String)
            _usmeUserId = usmeUserId
            _usmeMembName = usmeMembName
            _usmePromoteDate = usmePromoteDate
            _usmePoints = usmePoints
            _usmeType = usmeType
        End Sub

        Public Property UsmeUserId As Integer
            Get
                Return _usmeUserId
            End Get
            Set(value As Integer)
                _usmeUserId = value
            End Set
        End Property

        Public Property UsmeMembName As String
            Get
                Return _usmeMembName
            End Get
            Set(value As String)
                _usmeMembName = value
            End Set
        End Property

        Public Property UsmePromoteDate As Date
            Get
                Return _usmePromoteDate
            End Get
            Set(value As Date)
                _usmePromoteDate = value
            End Set
        End Property

        Public Property UsmePoints As Integer
            Get
                Return _usmePoints
            End Get
            Set(value As Integer)
                _usmePoints = value
            End Set
        End Property

        Public Property UsmeType As String
            Get
                Return _usmeType
            End Get
            Set(value As String)
                _usmeType = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"UsmeUserId : {UsmeUserId} | UsmeMembName : {UsmeMembName} | UsmePromoteDate : {UsmePromoteDate} | UsmePoints : {UsmePoints} | UsmeType : {UsmeType}"
        End Function
    End Class
End Namespace
