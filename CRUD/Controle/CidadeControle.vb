Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class CidadeControle
    Dim estadoControle As EstadoControle
    Dim cidade As Cidade

    Public Sub New()
        estadoControle = New EstadoControle
    End Sub

    Public Function Carregar() As DataSet
        Dim ds As DataSet
        ds = CidadeDAO.GetCidadeEstado()
        Dim linha = ds.Tables(0).NewRow()
        linha("NOME") = ""
        linha("ID") = 0
        ds.Tables(0).Rows.InsertAt(linha, 0)
        Return ds
    End Function

    'não tem try
    Public Sub AbrirFormulario(Optional id As Integer = 0)
        Dim form_cidade As FormularioCidade
        If id = 0 Then
            form_cidade = New FormularioCidade()
        Else
            Dim cidade As Cidade = CidadeDAO.GetById(id)
            form_cidade = New FormularioCidade(cidade)
        End If
        form_cidade.ShowDialog()
    End Sub

    Public Function Inserir(nome As String, id_estado As Integer)
        Me.cidade = New Cidade()
        Me.cidade.Nome = nome
        Me.cidade.Estado = id_estado
        Try
            Return CidadeDAO.ExecuteQuery(cidade, CidadeDAO.PROCEDURE.InserirCidade)
        Catch ex As Exception
            Throw ex
            Return False
        Finally
            Me.cidade = Nothing
        End Try
    End Function

    Public Function Atualizar(nome As String, id_estado As Integer, id As Integer)
        Me.cidade = New Cidade()
        Me.cidade.Id = id
        Me.cidade.Nome = nome
        Me.cidade.Estado = id_estado
        Try
            Return CidadeDAO.ExecuteQuery(cidade, CidadeDAO.PROCEDURE.AtualizarCidade)
        Catch ex As Exception
            Throw ex
            Return False
        Finally
            Me.cidade = Nothing
        End Try
    End Function

    Public Function Remover(id As Integer)
        Me.cidade = New Cidade()
        Me.cidade.Id = id
        Try
            Return CidadeDAO.ExecuteQuery(cidade, CidadeDAO.PROCEDURE.RemoverCidade)
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Public Function GetByNomeEstado(nome As String, estado As Integer)
        Return CidadeDAO.GetByNomeEstado(nome, estado)
    End Function

    Public Function Filtro(tipo_filtro As Integer, id_estado As Integer, valorTxt As String)
        Dim ds As DataSet
        If Not id_estado = 0 Then
            ds = CidadeDAO.Filtro("iId_estado", id_estado) 'coluna, valor
        ElseIf Not valorTxt.Trim() = "" And tipo_filtro = 0 Then
            ds = CidadeDAO.Filtro("vNome", "'%" + Regex.Replace(valorTxt, "[^a-zA-Zà-úÀ-Ú]", "") + "%'") 'coluna, valor
        ElseIf Not valorTxt.Trim() = "" And tipo_filtro = 2 Then
            ds = CidadeDAO.Filtro("iId", Regex.Replace(valorTxt, "\D", "")) 'coluna, valor
        Else
            ds = CidadeDAO.GetCidades()
        End If

        If ds.Tables(0).Rows.Count > 0 Then
            Return (True, ds)
        Else
            Return (False, Nothing)
        End If
    End Function

End Class
