Namespace Model
    Public Class User_bonus_points
        Private _ubpoId As Integer
        Private _ubpoUserId As Integer
        Private _ubpoTotalPoints As Integer
        Private _ubpoBonusType As String
        Private _ubpoCreatedOn As Date

        Public Sub New()
        End Sub

        Public Sub New(ubpoId As Integer, ubpoUserId As Integer, ubpoTotalPoints As Integer, ubpoBonusType As String, ubpoCreatedOn As Date)
            _ubpoId = ubpoId
            _ubpoUserId = ubpoUserId
            _ubpoTotalPoints = ubpoTotalPoints
            _ubpoBonusType = ubpoBonusType
            _ubpoCreatedOn = ubpoCreatedOn
        End Sub

        Public Property UbpoId As Integer
            Get
                Return _ubpoId
            End Get
            Set(value As Integer)
                _ubpoId = value
            End Set
        End Property

        Public Property UbpoUserId As Integer
            Get
                Return _ubpoUserId
            End Get
            Set(value As Integer)
                _ubpoUserId = value
            End Set
        End Property

        Public Property UbpoTotalPoints As Integer
            Get
                Return _ubpoTotalPoints
            End Get
            Set(value As Integer)
                _ubpoTotalPoints = value
            End Set
        End Property

        Public Property UbpoBonusType As String
            Get
                Return _ubpoBonusType
            End Get
            Set(value As String)
                _ubpoBonusType = value
            End Set
        End Property

        Public Property UbpoCreatedOn As Date
            Get
                Return _ubpoCreatedOn
            End Get
            Set(value As Date)
                _ubpoCreatedOn = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return $"UbpoId : {UbpoId} | UbpoUserId : {UbpoUserId} | UbpoTotalPoints : {UbpoTotalPoints} | UbpoBonusType : {UbpoBonusType} | UbpoCreatedOn : {UbpoCreatedOn}"
        End Function
    End Class
End Namespace
