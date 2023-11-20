Imports System.Text.RegularExpressions

Public Class FormularioCidade
    Dim cidade As Cidade
    Dim cidadeControle As CidadeControle
    Dim estadoControle As EstadoControle

    Public Sub New(Optional cidade As Cidade = Nothing)
        InitializeComponent()
        Me.cidade = cidade
        cidadeControle = New CidadeControle
        estadoControle = New EstadoControle
    End Sub

    Private Sub FormularioCidade_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim estados = estadoControle.Carregar()
        If estados.Item1 Then
            Me.cmbEstado.DataSource = estados.Item2.Tables(0)
            Me.cmbEstado.DisplayMember = "vSigla"
            Me.cmbEstado.ValueMember = "iId"
        Else
            MessageBox.Show("Falha ao carregar os estados!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End If

        If IsNothing(Me.cidade) Then
            Me.Acao.Text = "&Salvar"
        Else
            Me.Acao.Text = "&Atualizar"
            Me.cmbEstado.SelectedValue = Me.cidade.Estado
            Me.nome.Text = Me.cidade.Nome
        End If
    End Sub

    Private Sub Acao_Click(sender As Object, e As EventArgs) Handles Acao.Click
        If Validar_Campos() Then
            If IsNothing(Me.cidade) Then
                If cidadeControle.Inserir(Me.nome.Text.Trim(), Me.cmbEstado.SelectedValue) Then
                    MessageBox.Show("Cidade cadastrada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Limpar_Campos()
                Else
                    MessageBox.Show("Falha ao cadastrar cidade!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Limpar_Campos()
                End If
            Else
                If cidadeControle.Atualizar(Me.nome.Text.Trim(), Me.cmbEstado.SelectedValue, Me.cidade.Id) Then
                    MessageBox.Show("Cidade Atualizada com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Else
                    MessageBox.Show("Falha ao atualizar cidade!", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Public Function Validar_Campos() As Boolean
        Dim nome = Regex.Replace(Me.nome.Text, "[^a-zA-Zà-úÀ-Ú]+", " ").Trim()
        Dim estado = Me.cmbEstado.SelectedIndex

        If nome = String.Empty Then
            MessageBox.Show("Preencha o nome!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.nome.Focus()
            Return False
        ElseIf estado = 0 Then
            MessageBox.Show("Preencha a UF!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.cmbEstado.Focus()
            Return False
        ElseIf Me.nome.Text.Trim().Length > Regex.Replace(Me.nome.Text.Trim(), "[^a-zA-Zà-úÀ-Ú/\s+/]", "").Length Then
            MessageBox.Show("Só é permitido letras e espaços!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.nome.Focus()
            Return False
        Else
            Dim cidade = cidadeControle.GetByNomeEstado(Me.nome.Text, Me.cmbEstado.SelectedValue)
            If Not IsNothing(cidade) Then
                MessageBox.Show("Essa cidade já consta no sistema!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Limpar_Campos()
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Private Sub Limpar_Campos()
        If DialogResult.Yes = DialogResult = MessageBox.Show("Limpar todos os campos?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then
            Me.nome.Text = ""
            Me.cmbEstado.SelectedIndex = 0
        Else
            Me.nome.Focus()
        End If
    End Sub

End Class