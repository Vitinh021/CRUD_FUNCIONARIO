Imports System.Data.SqlClient

Public Class FuncionarioDAO
    Private Shared comando As SqlClient.SqlCommand
    Private Shared da As SqlClient.SqlDataAdapter
    Private Shared dr As SqlClient.SqlDataReader

    Public Shared Function GetFuncionarios() As DataSet
        Dim ds As New DataSet
        da = New SqlClient.SqlDataAdapter
        comando = New SqlClient.SqlCommand
        Try
            comando = Conexao.Conectar().CreateCommand
            comando.CommandText = "SELECT f.iId AS ID, f.vNome AS NOME, f.vCpf AS CPF, f.dData AS NASCIMENTO, CONCAT(c.vNome,' - ', e.vSigla) AS CIDADE
                                    FROM funcionario AS f 
                                    JOIN cidade AS c ON f.iId_cidade = c.iId 
                                    JOIN estado AS e ON c.iId_estado = e.iId 
                                    ORDER BY f.iId DESC"
            da = New SqlClient.SqlDataAdapter(comando)
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            Conexao.Fechar()
        End Try
    End Function

    Public Shared Function Inserir(func As Funcionario) As Boolean
        Try
            comando = Conexao.Conectar().CreateCommand
            comando.CommandText = "INSERT INTO funcionario (vNome, vCpf, dData, iId_cidade) VALUES (@nome, @cpf, @data, @cidade)"
            comando.Parameters.AddWithValue("nome", func.Nome)
            comando.Parameters.AddWithValue("cpf", func.Cpf)
            comando.Parameters.AddWithValue("data", func.Data)
            comando.Parameters.AddWithValue("cidade", func.Cidade)
            Dim linhasAfetadas As Integer = comando.ExecuteNonQuery()
            Return linhasAfetadas > 0
        Catch ex As Exception
            Throw ex
            Return False
        Finally
            Conexao.Fechar()
        End Try
    End Function

    Public Shared Function Atualizar(func As Funcionario) As Boolean
        Try
            comando = Conexao.Conectar().CreateCommand
            comando.CommandText = "UPDATE funcionario SET vNome = @nome, vCpf = @cpf, dData = @data, iId_cidade = @id_cidade WHERE iId = @id"
            comando.Parameters.AddWithValue("nome", func.Nome)
            comando.Parameters.AddWithValue("cpf", func.Cpf)
            comando.Parameters.AddWithValue("data", func.Data)
            comando.Parameters.AddWithValue("id_cidade", func.Cidade)
            comando.Parameters.AddWithValue("id", func.Id)
            Dim linhasAfetadas As Integer = comando.ExecuteNonQuery()
            Return linhasAfetadas > 0
        Catch ex As Exception
            Throw ex
            Return False
        Finally
            Conexao.Fechar()
        End Try
    End Function

    Public Shared Function Remover(id As Integer) As Boolean
        Try
            comando = Conexao.Conectar().CreateCommand
            comando.CommandText = "DELETE FROM funcionario WHERE iId = @id"
            comando.Parameters.AddWithValue("@id", id)
            Dim linhasAfetadas As Integer = comando.ExecuteNonQuery()
            Return linhasAfetadas > 0
        Catch ex As Exception
            Throw ex
            Return False
        Finally
            Conexao.Fechar()
        End Try
    End Function

    Public Shared Function GetByCpfId(cpf As String, id As Integer)
        Try
            comando = Conexao.Conectar.CreateCommand
            comando.CommandText = "SELECT * FROM funcionario WHERE vCpf = @cpf And iId != @id"
            comando.Parameters.AddWithValue("cpf", cpf)
            comando.Parameters.AddWithValue("id", id)
            Dim obj As IDataReader = comando.ExecuteReader()
            If obj.Read() Then
                Return True
            End If
            Return Nothing
        Catch ex As Exception
            Throw ex
        Finally
            Conexao.Fechar()
        End Try
    End Function

    Public Shared Function GetByCpf(cpf As String)
        Try
            comando = Conexao.Conectar.CreateCommand
            comando.CommandText = "SELECT * FROM funcionario WHERE vCpf = @cpf"
            comando.Parameters.AddWithValue("cpf", cpf)
            Dim obj As IDataReader = comando.ExecuteReader()
            If obj.Read() Then
                'Dim funcionario As New Funcionario()
                'funcionario.Cpf = obj("vCpf").ToString()
                'Return funcionario
                Return True
            End If
            Return Nothing
        Catch ex As Exception
            Throw ex
        Finally
            Conexao.Fechar()
        End Try
    End Function

    Public Shared Function GetById(id As Integer)
        Try
            comando = Conexao.Conectar.CreateCommand
            comando.CommandText = "SELECT * FROM funcionario WHERE iId = @id"
            comando.Parameters.AddWithValue("id", id)
            Dim obj As IDataReader = comando.ExecuteReader()
            If obj.Read() Then
                Dim func As New Funcionario()
                func.Id = Convert.ToInt32(obj("iId"))
                func.Nome = obj("vNome").ToString()
                func.Cpf = obj("vCpf").ToString()
                func.Data = obj("dData").ToString()
                func.Cidade = Convert.ToInt32(obj("iId_cidade"))
                Return func
            End If
            Return Nothing
        Catch ex As Exception
            Throw ex
        Finally
            Conexao.Fechar()
        End Try
    End Function

    Public Shared Function Filtro(coluna As String, valor As String) As DataSet
        Dim ds As New DataSet
        da = New SqlClient.SqlDataAdapter
        comando = New SqlClient.SqlCommand
        Try
            comando = Conexao.Conectar().CreateCommand
            comando.CommandText = "SELECT f.iId AS ID, f.vNome AS NOME, f.vCpf AS CPF, f.dData AS NASCIMENTO, CONCAT(c.vNome,' - ', e.vSigla) AS CIDADE
                                    FROM funcionario AS f 
                                    JOIN cidade AS c ON f.iId_cidade = c.iId 
                                    JOIN estado AS e ON c.iId_   = e.iId
                                    WHERE c." + coluna + " LIKE " + valor + "
                                    ORDER BY f.iId DESC"
            da = New SqlClient.SqlDataAdapter(comando)
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            Conexao.Fechar()
        End Try
    End Function

End Class
