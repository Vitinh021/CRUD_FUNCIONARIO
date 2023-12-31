﻿Imports System.Data.SqlClient
Imports CRUD_2.CidadeDAO

Public Class CidadeDAO
    Private Shared comando As SqlClient.SqlCommand
    Private Shared da As SqlClient.SqlDataAdapter
    Private Shared dr As SqlClient.SqlDataReader

    Public Enum PROCEDURE
        InserirCidade
        AtualizarCidade
        RemoverCidade
    End Enum

    Public Shared Function GetCidades() As DataSet
        Dim ds As New DataSet
        da = New SqlClient.SqlDataAdapter
        comando = New SqlClient.SqlCommand
        Try
            comando = Conexao.Conectar().CreateCommand
            comando.CommandText = "SELECT c.iId AS ID, c.vNome AS NOME, CONCAT(e.vNome,'  (', e.vSigla,')') AS ESTADO
                                    FROM cidade AS c 
                                    JOIN estado AS e ON c.iId_estado = e.iId
                                    ORDER BY c.iId DESC"
            da = New SqlClient.SqlDataAdapter(comando)
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            Conexao.Fechar()
        End Try
    End Function

    Public Shared Function GetCidadeEstado() As DataSet
        Dim ds As New DataSet
        da = New SqlClient.SqlDataAdapter
        comando = New SqlClient.SqlCommand
        Try
            comando = Conexao.Conectar().CreateCommand
            comando.CommandText = "SELECT c.iId AS ID, CONCAT(c.vNome,'  (', e.vSigla,')') AS NOME
                                    FROM cidade AS c 
                                    JOIN estado AS e ON c.iId_estado = e.iId
                                    ORDER BY c.iId DESC"
            da = New SqlClient.SqlDataAdapter(comando)
            da.Fill(ds)
            Return ds
        Catch ex As Exception
            Throw ex
        Finally
            Conexao.Fechar()
        End Try
    End Function

    Public Shared Function ExecuteQuery(cidade As Cidade, query As String) As Boolean
        Try
            comando = Conexao.Conectar().CreateCommand
            comando.CommandType = CommandType.StoredProcedure

            If query = PROCEDURE.InserirCidade Then
                comando.CommandText = PROCEDURE.InserirCidade.ToString()
                comando.Parameters.AddWithValue("nome", cidade.Nome)
                comando.Parameters.AddWithValue("@id_estado", cidade.Estado)
            ElseIf query = PROCEDURE.AtualizarCidade Then
                comando.CommandText = PROCEDURE.AtualizarCidade.ToString()
                comando.Parameters.AddWithValue("id", cidade.Id)
                comando.Parameters.AddWithValue("id_estado", cidade.Estado)
                comando.Parameters.AddWithValue("nome", cidade.Nome)
            ElseIf query = PROCEDURE.RemoverCidade Then
                comando.CommandText = PROCEDURE.RemoverCidade.ToString()
                comando.Parameters.AddWithValue("id", cidade.Id)
            End If

            Dim linhasAfetadas As Integer = comando.ExecuteNonQuery()
            Return linhasAfetadas > 0 'retorna a qtd de linhas afetadas, se for maior que 0, então sucesso!
        Catch ex As Exception
            Throw ex
            Return False
        Finally
            Conexao.Fechar()
        End Try
    End Function

    'BUSCA 1 REGISTRO
    Public Shared Function GetByNomeEstado(nome As String, id_estado As Integer)
        Try
            comando = Conexao.Conectar.CreateCommand
            comando.CommandText = "SELECT * FROM cidade WHERE vNome = @nome and iId_estado = @id_estado"
            comando.Parameters.AddWithValue("nome", nome)
            comando.Parameters.AddWithValue("id_estado", id_estado)
            Dim obj As IDataReader = comando.ExecuteReader()
            If obj.Read() Then
                Dim cidade As New Cidade()
                cidade.Id = Convert.ToInt32(obj("iId"))
                cidade.Estado = Convert.ToInt32(obj("iId_estado"))
                cidade.Nome = obj("vNome").ToString()
                Return cidade
            End If
            Return Nothing
        Catch ex As Exception
            Throw ex
        Finally
            Conexao.Fechar()
        End Try
    End Function

    'BUSCA 1 REGISTRO
    Public Shared Function GetById(id As Integer)
        Try
            comando = Conexao.Conectar.CreateCommand
            comando.CommandText = "SELECT * FROM cidade WHERE iId = @id"
            comando.Parameters.AddWithValue("id", id)
            Dim obj As IDataReader = comando.ExecuteReader()
            If obj.Read() Then
                Dim cidade As New Cidade()
                cidade.Id = Convert.ToInt32(obj("iId"))
                cidade.Estado = Convert.ToInt32(obj("iId_estado"))
                cidade.Nome = obj("vNome").ToString()
                Return cidade
            End If
            Return Nothing
        Catch ex As Exception
            Throw ex
        Finally
            Conexao.Fechar()
        End Try
    End Function

    'BUASCA UMA LISTA
    Public Shared Function Filtro(coluna As String, valor As String)
        Dim ds As New DataSet
        da = New SqlClient.SqlDataAdapter
        comando = New SqlClient.SqlCommand
        Try
            comando = Conexao.Conectar().CreateCommand
            comando.CommandText = "SELECT c.iId AS ID, c.vNome AS NOME, CONCAT(e.vNome,'  (', e.vSigla,')') AS ESTADO
                                    FROM cidade AS c JOIN estado AS e ON c.iId_estado = e.iId
                                    WHERE c." + coluna + " LIKE " + valor + "
                                    ORDER BY c.iId DESC"
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
