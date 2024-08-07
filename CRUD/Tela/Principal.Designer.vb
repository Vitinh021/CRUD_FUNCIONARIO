<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Principal
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.cidade = New System.Windows.Forms.ToolStripMenuItem()
        Me.Gerenciar_Cidade = New System.Windows.Forms.ToolStripMenuItem()
        Me.FuncionarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Gerenciar_Funcionario = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cidade, Me.FuncionarioToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 28)
        Me.MenuStrip1.TabIndex = 7
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'cidade
        '
        Me.cidade.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Gerenciar_Cidade})
        Me.cidade.Name = "cidade"
        Me.cidade.Size = New System.Drawing.Size(70, 24)
        Me.cidade.Text = "Cidade"
        '
        'Gerenciar_Cidade
        '
        Me.Gerenciar_Cidade.Name = "Gerenciar_Cidade"
        Me.Gerenciar_Cidade.Size = New System.Drawing.Size(224, 26)
        Me.Gerenciar_Cidade.Text = "&Gerenciar"
        '
        'FuncionarioToolStripMenuItem
        '
        Me.FuncionarioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Gerenciar_Funcionario})
        Me.FuncionarioToolStripMenuItem.Name = "FuncionarioToolStripMenuItem"
        Me.FuncionarioToolStripMenuItem.Size = New System.Drawing.Size(100, 24)
        Me.FuncionarioToolStripMenuItem.Text = "Funcionario"
        '
        'Gerenciar_Funcionario
        '
        Me.Gerenciar_Funcionario.Name = "Gerenciar_Funcionario"
        Me.Gerenciar_Funcionario.Size = New System.Drawing.Size(224, 26)
        Me.Gerenciar_Funcionario.Text = "&Gerenciar"
        '
        'Principal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "Principal"
        Me.Text = "SISTEMA"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents cidade As ToolStripMenuItem
    Friend WithEvents FuncionarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Gerenciar_Cidade As ToolStripMenuItem
    Friend WithEvents Gerenciar_Funcionario As ToolStripMenuItem
End Class
