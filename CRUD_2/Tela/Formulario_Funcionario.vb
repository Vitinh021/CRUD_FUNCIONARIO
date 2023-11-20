Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class FormularioFuncionario
    Dim funcionario As Funcionario
    Dim funcionarioControle As FuncionarioControle

    Private Sub FormularioFuncionario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsNothing(funcionario) Then
            Me.Acao.Text = "&Atualizar"
        Else
            Me.Acao.Text = "&Salvar"
        End If
    End Sub

    Public Sub New(Optional func As Funcionario = Nothing)
        InitializeComponent()
        Me.funcionario = func
        funcionarioControle = New FuncionarioControle
    End Sub

    Private Sub Acao_Click(sender As Object, e As EventArgs) Handles Acao.Click
        If Validar_Campos() Then
            Dim nome = Regex.Replace(Me.nome.Text.Trim(), "[^a-zA-Zà-úÀ-Ú]", "")
            Dim cpf = Regex.Replace(Me.cpf.Text.Trim(), "[\D]", "")
            Dim data = Regex.Replace(Me.data.Text.Trim(), "[\D]", "")
            Dim cidade = Me.cmbCidade.SelectedValue
            If IsNothing(Me.funcionario) Then
                Try
                    If funcionarioControle.Inserir(nome, cpf, data, cidade) Then
                        MessageBox.Show("Funcionario cadastrado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Limpar_Campos()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Falha ao cadastrar funcionario!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Limpar_Campos()
                    Throw ex
                End Try
            Else
                Try
                    If funcionarioControle.Atualizar(nome, cpf, data, cidade, funcionario.Id) Then
                        MessageBox.Show("Funcionario Atualizado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                    End If
                Catch ex As Exception
                    MessageBox.Show("Falha ao Atualizar funcionario!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Me.Close()
                    Throw ex
                End Try
            End If
        End If
    End Sub

    Public Function Validar_Campos() As Boolean

        If Me.nome.Text.Trim() = String.Empty Then
            MessageBox.Show("Preencha o nome!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.nome.Focus()
            Return False
        ElseIf Me.nome.Text.Trim().Length > Regex.Replace(Me.nome.Text.Trim(), "[^a-zA-Zà-úÀ-Ú]", "").Length Then
            MessageBox.Show("Não é permitido caracteres especiais! [@#$%&]", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.nome.Focus()
            Return False
        ElseIf Regex.Replace(Me.data.Text.Trim(), "[\D]", "").Length < 8 Then
            MessageBox.Show("Preencha a data de nascimento corretamente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.data.Focus()
            Return False
        ElseIf Regex.Replace(Me.cpf.Text.Trim(), "[\D]", "").Length < 11 Then
            MessageBox.Show("Preencha o CPF corretamente!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.cpf.Focus()
            Return False
        ElseIf Me.cmbCidade.SelectedIndex = 0 Then
            MessageBox.Show("Preencha a cidade!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.cmbCidade.Focus()
            Return False
        Else
            If Not IsNothing(funcionario) Then
                If funcionarioControle.GetByCpfId(Regex.Replace(Me.cpf.Text.Trim(), "[\D]", ""), funcionario.Id) Then
                    MessageBox.Show("Esse CPF já consta no sistema!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                Else
                    Return True
                End If
            ElseIf funcionarioControle.GetByCpf(Regex.Replace(Me.cpf.Text.Trim(), "[\D]", "")) Then
                MessageBox.Show("Esse funcionario já consta no sistema!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Private Sub Limpar_Campos()
        If DialogResult.Yes = MessageBox.Show("Limpar todos os campos?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Information) Then
            Me.nome.Text = ""
            Me.data.Text = ""
            Me.cpf.Text = ""
            Me.cmbCidade.SelectedIndex = 0
        Else
            Me.nome.Focus()
        End If
    End Sub

End Class