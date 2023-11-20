Public Class EstadoControle
    Public Function Carregar()
        Dim ds As DataSet
        Try
            ds = EstadoDAO.GetEstados()
            Dim linha = ds.Tables(0).NewRow()
            linha("vSigla") = ""
            linha("iId") = 0
            ds.Tables(0).Rows.InsertAt(linha, 0)
            Return (True, ds)
        Catch ex As Exception
            Throw ex
            Return (False, Nothing)
        End Try
    End Function

End Class
