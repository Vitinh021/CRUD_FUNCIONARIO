Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class FuncionarioControle
    Dim cidadeControle As CidadeControle

    Public Sub New()
        cidadeControle = New CidadeControle
    End Sub

    Public Sub AbrirFormulario(Optional id As Integer = 0)
        Dim cidades = cidadeControle.Carregar()
        Dim form_func As FormularioFuncionario
        If Not id = 0 Then
            Dim func As Funcionario = FuncionarioDAO.GetById(id)
            form_func = New FormularioFuncionario(func)
            form_func.cmbCidade.DataSource = cidades.Tables(0)
            form_func.cmbCidade.DisplayMember = "NOME"
            form_func.cmbCidade.ValueMember = "ID"
            form_func.cmbCidade.SelectedValue = func.Cidade
            form_func.nome.Text = func.Nome
            form_func.cpf.Text = func.Cpf
            form_func.data.Text = func.Data
            form_func.ShowDialog()
        Else
            form_func = New FormularioFuncionario()
            form_func.cmbCidade.DataSource = cidades.Tables(0)
            form_func.cmbCidade.DisplayMember = "NOME"
            form_func.cmbCidade.ValueMember = "ID"
            form_func.ShowDialog()
        End If
    End Sub

    Public Function Inserir(nome As String, cpf As String, data As String, id_cidade As Integer)
        Dim obj = New Funcionario
        obj.Nome = nome
        obj.Cpf = cpf
        Dim dataFormatada As Date = Date.ParseExact(data, "ddMMyyyy", CultureInfo.InvariantCulture)
        obj.Data = dataFormatada.ToString("dd/MM/yyyy")
        obj.Cidade = id_cidade
        Return FuncionarioDAO.Inserir(obj)
    End Function

    Public Function Atualizar(nome As String, cpf As String, data As String, id_cidade As Integer, id As Integer)
        Dim obj = New Funcionario
        obj.Id = id
        obj.Nome = nome
        obj.Cpf = cpf
        Dim dataFormatada As Date = Date.ParseExact(data, "ddMMyyyy", CultureInfo.InvariantCulture)
        obj.Data = dataFormatada.ToString("dd/MM/yyyy")
        obj.Cidade = id_cidade
        Return FuncionarioDAO.Atualizar(obj)
    End Function

    Public Function Remover(id As Integer)
        Return FuncionarioDAO.Remover(id)
    End Function

    Public Function GetByCpf(cpf As String)
        If FuncionarioDAO.GetByCpf(cpf) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function GetByCpfId(cpf As String, id As Integer)
        If FuncionarioDAO.GetByCpfId(cpf, id) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Filtro(tipo_filtro As Integer, id_estado As Integer, valorTxt As String)
        Dim ds As DataSet
        'If Not id_estado = 0 Then
        '    ds = CidadeDAO.Filtro("iId_estado", id_estado) 'coluna, valor
        'ElseIf Not valorTxt.Trim() = "" And tipo_filtro = 0 Then
        '    ds = CidadeDAO.Filtro("vNome", "'" + Regex.Replace(valorTxt, "[^a-zA-Z]", "") + "'") 'coluna, valor
        'ElseIf Not valorTxt.Trim() = "" And tipo_filtro = 2 Then
        '    ds = CidadeDAO.Filtro("iId", Regex.Replace(valorTxt, "\D", "")) 'coluna, valor
        'Else
        'End If
        ds = FuncionarioDAO.GetFuncionarios()


        If ds.Tables(0).Rows.Count > 0 Then
            Return (True, ds)
        Else
            Return (False, Nothing)
        End If
    End Function

End Class
