Imports System.Data.SqlClient

Public Class EstadoDAO
    Private Shared comando As SqlClient.SqlCommand
    Private Shared da As SqlClient.SqlDataAdapter
    Private Shared dr As SqlClient.SqlDataReader

    Public Shared Function GetEstados() As DataSet
        Dim ds As New DataSet
        da = New SqlClient.SqlDataAdapter
        comando = New SqlClient.SqlCommand
        Try
            comando = Conexao.Conectar().CreateCommand
            comando.CommandText = "SELECT * FROM estado"
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
