Public Class GerenciarFuncionario
    Dim funcionarioControle As FuncionarioControle
    Dim cidadeControle As CidadeControle
    Dim form_cidade As FormularioCidade
    Dim filtro As Object

    Public Sub New()
        InitializeComponent()
        funcionarioControle = New FuncionarioControle
        cidadeControle = New CidadeControle
    End Sub

    Private Sub GerenciarFuncionario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'carrega a lista
        Me.Recarregar()
        'carrega os estados no cmbCidade
        Dim cidades = cidadeControle.Carregar()
        Me.cmbEstado.DataSource = cidades.Tables(0)
        Me.cmbEstado.DisplayMember = "NOME"
        Me.cmbEstado.ValueMember = "ID"
        Me.gbUf.Location = New Point(392, 10)
    End Sub

    Private Sub Recarregar()
        Me.Lista.DataSource = Nothing
        filtro = funcionarioControle.Filtro(cmbFiltro.SelectedIndex, Me.cmbEstado.SelectedValue, Me.txtPesquisa.Text)
        If filtro.Item1 Then
            Me.Lista.DataSource = filtro.Item2.tables(0)
        End If
    End Sub

    Private Sub cmbFiltro_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbFiltro.SelectedIndexChanged
        If Me.cmbFiltro.SelectedIndex = 0 Or Me.cmbFiltro.SelectedIndex = 2 Then
            Me.cmbEstado.SelectedIndex = 0
            Me.txtPesquisa.Text = ""
            Me.gbUf.Visible = False
            Me.txtPesquisa.Visible = True
            Me.btnPesquisar.Location = New Point(236, 14)
        ElseIf Me.cmbFiltro.SelectedIndex = 1 Then
            Me.txtPesquisa.Text = ""
            Me.txtPesquisa.Visible = False
            Me.gbUf.Visible = True
            Me.btnPesquisar.Location = New Point(132, 15)
        End If
    End Sub

    Private Sub btnPesquisar_Click(sender As Object, e As EventArgs) Handles btnPesquisar.Click
        Me.Recarregar()
    End Sub

    Private Sub Cadastrar_Click(sender As Object, e As EventArgs) Handles Cadastrar.Click
        funcionarioControle.AbrirFormulario()
        Me.Recarregar()
    End Sub

    Private Sub Editar_Click(sender As Object, e As EventArgs) Handles Editar.Click
        If Me.ValidarLinha("editar") Then
            Dim linha As DataGridViewRow = Lista.SelectedRows(0)
            Dim id As Integer = Integer.Parse(linha.Cells("ID").Value)
            funcionarioControle.AbrirFormulario(id)
            Me.Recarregar()
        End If
    End Sub

    Private Sub Remover_Click(sender As Object, e As EventArgs) Handles Remover.Click
        If Me.ValidarLinha("remover") Then
            Dim linha As DataGridViewRow = Lista.SelectedRows(0)
            If funcionarioControle.Remover(linha.Cells("ID").Value) Then
                MessageBox.Show("Cidade removida com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.Recarregar()
            Else
                MessageBox.Show("Falha ao remover cidade!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Function ValidarLinha(msg As String)
        If Me.Lista.SelectedRows.Count = 1 Then
            Return True
        Else
            MessageBox.Show("Selecione uma linha para " + msg + "!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
    End Function

End Class