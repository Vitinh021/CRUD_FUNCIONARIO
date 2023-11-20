Public Class GerenciarCidade
    Dim cidadeControle As CidadeControle
    Dim estadoControle As EstadoControle
    Dim form_cidade As FormularioCidade
    Dim filtro As Object

    Public Sub New()
        InitializeComponent()
        cidadeControle = New CidadeControle
        estadoControle = New EstadoControle
    End Sub

    Private Sub GerenciarCidade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'carrega a lista
        Me.Recarregar()
        'carrega os estados no cmbEstado(uf)
        Dim estados = estadoControle.Carregar()
        If estados.Item1 Then
            Me.cmbEstado.DataSource = estados.Item2.Tables(0)
            Me.cmbEstado.DisplayMember = "vSigla"
            Me.cmbEstado.ValueMember = "iId"
            Me.gbUf.Location = New Point(392, 10)
        Else
            MessageBox.Show("Falha ao carregar os estados!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Recarregar()
        Try
            filtro = cidadeControle.Filtro(cmbFiltro.SelectedIndex, Me.cmbEstado.SelectedValue, Me.txtPesquisa.Text)
            If filtro.Item1 Then
                Me.Lista.DataSource = filtro.Item2.tables(0)
            Else
                MessageBox.Show("Registro não encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show("Falha ao carregar as cidades!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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
        cidadeControle.AbrirFormulario()
        Me.Recarregar()
    End Sub

    Private Sub Editar_Click(sender As Object, e As EventArgs) Handles Editar.Click
        If Me.ValidarLinha("editar") Then
            Dim linha As DataGridViewRow = Lista.SelectedRows(0)
            Dim id As Integer = Integer.Parse(linha.Cells("ID").Value)
            cidadeControle.AbrirFormulario(id)
            Me.Recarregar()
        End If
    End Sub

    Private Sub Remover_Click(sender As Object, e As EventArgs) Handles Remover.Click
        If Me.ValidarLinha("remover") Then
            If DialogResult.Yes = MessageBox.Show("Deseja realmente remover essa cidade?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                Dim linha As DataGridViewRow = Lista.SelectedRows(0)
                If cidadeControle.Remover(linha.Cells("ID").Value) Then
                    MessageBox.Show("Cidade removida com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Recarregar()
                Else
                    MessageBox.Show("Falha ao remover cidade!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
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