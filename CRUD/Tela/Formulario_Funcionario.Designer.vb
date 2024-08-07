<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormularioFuncionario
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Acao = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cmbCidade = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nome = New System.Windows.Forms.TextBox()
        Me.GbDt = New System.Windows.Forms.GroupBox()
        Me.data = New System.Windows.Forms.MaskedTextBox()
        Me.cpf = New System.Windows.Forms.MaskedTextBox()
        Me.gbCpf = New System.Windows.Forms.GroupBox()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GbDt.SuspendLayout()
        Me.gbCpf.SuspendLayout()
        Me.SuspendLayout()
        '
        'Acao
        '
        Me.Acao.Location = New System.Drawing.Point(176, 151)
        Me.Acao.Name = "Acao"
        Me.Acao.Size = New System.Drawing.Size(90, 33)
        Me.Acao.TabIndex = 6
        Me.Acao.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbCidade)
        Me.GroupBox2.Location = New System.Drawing.Point(249, 72)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(155, 62)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cidade"
        '
        'cmbCidade
        '
        Me.cmbCidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCidade.FormattingEnabled = True
        Me.cmbCidade.Location = New System.Drawing.Point(7, 24)
        Me.cmbCidade.MaxLength = 2
        Me.cmbCidade.Name = "cmbCidade"
        Me.cmbCidade.Size = New System.Drawing.Size(142, 24)
        Me.cmbCidade.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nome)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(392, 54)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Nome"
        '
        'nome
        '
        Me.nome.Location = New System.Drawing.Point(4, 21)
        Me.nome.Name = "nome"
        Me.nome.Size = New System.Drawing.Size(382, 22)
        Me.nome.TabIndex = 0
        '
        'GbDt
        '
        Me.GbDt.Controls.Add(Me.data)
        Me.GbDt.Location = New System.Drawing.Point(12, 72)
        Me.GbDt.Name = "GbDt"
        Me.GbDt.Size = New System.Drawing.Size(110, 62)
        Me.GbDt.TabIndex = 5
        Me.GbDt.TabStop = False
        Me.GbDt.Text = "Nascimento"
        '
        'data
        '
        Me.data.Location = New System.Drawing.Point(6, 26)
        Me.data.Mask = "00/00/0000"
        Me.data.Name = "data"
        Me.data.Size = New System.Drawing.Size(97, 22)
        Me.data.TabIndex = 8
        Me.data.ValidatingType = GetType(Date)
        '
        'cpf
        '
        Me.cpf.Location = New System.Drawing.Point(6, 26)
        Me.cpf.Mask = "000.000.000-00"
        Me.cpf.Name = "cpf"
        Me.cpf.Size = New System.Drawing.Size(114, 22)
        Me.cpf.TabIndex = 7
        '
        'gbCpf
        '
        Me.gbCpf.Controls.Add(Me.cpf)
        Me.gbCpf.Location = New System.Drawing.Point(123, 72)
        Me.gbCpf.Name = "gbCpf"
        Me.gbCpf.Size = New System.Drawing.Size(125, 62)
        Me.gbCpf.TabIndex = 6
        Me.gbCpf.TabStop = False
        Me.gbCpf.Text = "CPF"
        '
        'FormularioFuncionario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 196)
        Me.Controls.Add(Me.gbCpf)
        Me.Controls.Add(Me.GbDt)
        Me.Controls.Add(Me.Acao)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormularioFuncionario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Funcionario"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GbDt.ResumeLayout(False)
        Me.GbDt.PerformLayout()
        Me.gbCpf.ResumeLayout(False)
        Me.gbCpf.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Acao As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbCidade As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents nome As TextBox
    Friend WithEvents GbDt As GroupBox
    Friend WithEvents cpf As MaskedTextBox
    Friend WithEvents gbCpf As GroupBox
    Friend WithEvents data As MaskedTextBox
End Class
