Imports System.Diagnostics.Eventing.Reader

Public Class Principal
    Dim geren_cid As GerenciarCidade
    Dim geren_fun As GerenciarFuncionario

    Public Sub New()
        InitializeComponent()
        Me.StartPosition = FormStartPosition.CenterScreen
    End Sub

    Private Sub Gerenciar_Cidade_Click(sender As Object, e As EventArgs) Handles Gerenciar_Cidade.Click
        If Not IsNothing(geren_cid) AndAlso geren_cid.Visible = True Then
            geren_cid.Focus()
        Else
            geren_cid = New GerenciarCidade()
            geren_cid.Show()
        End If
    End Sub

    Private Sub Gerenciar_Funcionario_Click(sender As Object, e As EventArgs) Handles Gerenciar_Funcionario.Click
        If Not IsNothing(geren_fun) AndAlso geren_fun.Visible = True Then
            geren_fun.Focus()
        Else
            geren_fun = New GerenciarFuncionario()
            geren_fun.Show()
        End If
    End Sub
End Class
