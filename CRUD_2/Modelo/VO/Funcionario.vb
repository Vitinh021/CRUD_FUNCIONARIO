Public Class Funcionario
    Private _id As Integer
    Private _nome As String
    Private _cpf As String
    Private _data As Date
    Private _cidade As Integer

    Public Property Id() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return _nome
        End Get
        Set(ByVal value As String)
            _nome = value
        End Set
    End Property

    Public Property Cpf() As String
        Get
            Return _cpf
        End Get
        Set(ByVal value As String)
            _cpf = value
        End Set
    End Property

    Public Property Data() As Date
        Get
            Return _data
        End Get
        Set(ByVal value As Date)
            _data = value
        End Set
    End Property

    Public Property Cidade() As Integer
        Get
            Return _cidade
        End Get
        Set(ByVal value As Integer)
            _cidade = value
        End Set
    End Property

End Class
