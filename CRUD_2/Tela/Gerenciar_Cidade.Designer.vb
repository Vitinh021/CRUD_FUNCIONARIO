<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GerenciarCidade
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
        Me.Lista = New System.Windows.Forms.DataGridView()
        Me.Editar = New System.Windows.Forms.Button()
        Me.Remover = New System.Windows.Forms.Button()
        Me.Cadastrar = New System.Windows.Forms.Button()
        Me.cmbFiltro = New System.Windows.Forms.ComboBox()
        Me.txtPesquisa = New System.Windows.Forms.TextBox()
        Me.gbProcurar = New System.Windows.Forms.GroupBox()
        Me.btnPesquisar = New System.Windows.Forms.Button()
        Me.gbUf = New System.Windows.Forms.GroupBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbProcurar.SuspendLayout()
        Me.gbUf.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Lista
        '
        Me.Lista.AllowUserToAddRows = False
        Me.Lista.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Lista.Location = New System.Drawing.Point(12, 87)
        Me.Lista.MultiSelect = False
        Me.Lista.Name = "Lista"
        Me.Lista.ReadOnly = True
        Me.Lista.RowHeadersWidth = 51
        Me.Lista.RowTemplate.Height = 24
        Me.Lista.Size = New System.Drawing.Size(776, 351)
        Me.Lista.TabIndex = 0
        '
        'Editar
        '
        Me.Editar.Location = New System.Drawing.Point(102, 17)
        Me.Editar.Name = "Editar"
        Me.Editar.Size = New System.Drawing.Size(90, 33)
        Me.Editar.TabIndex = 4
        Me.Editar.Text = "&Editar"
        Me.Editar.UseVisualStyleBackColor = True
        '
        'Remover
        '
        Me.Remover.Location = New System.Drawing.Point(198, 16)
        Me.Remover.Name = "Remover"
        Me.Remover.Size = New System.Drawing.Size(90, 33)
        Me.Remover.TabIndex = 5
        Me.Remover.Text = "&Remover"
        Me.Remover.UseVisualStyleBackColor = True
        '
        'Cadastrar
        '
        Me.Cadastrar.Location = New System.Drawing.Point(6, 17)
        Me.Cadastrar.Name = "Cadastrar"
        Me.Cadastrar.Size = New System.Drawing.Size(90, 33)
        Me.Cadastrar.TabIndex = 9
        Me.Cadastrar.Text = "&Cadastrar"
        Me.Cadastrar.UseVisualStyleBackColor = True
        '
        'cmbFiltro
        '
        Me.cmbFiltro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFiltro.FormattingEnabled = True
        Me.cmbFiltro.Items.AddRange(New Object() {"NOME", "ESTADO", "ID"})
        Me.cmbFiltro.Location = New System.Drawing.Point(6, 21)
        Me.cmbFiltro.Name = "cmbFiltro"
        Me.cmbFiltro.Size = New System.Drawing.Size(88, 24)
        Me.cmbFiltro.TabIndex = 10
        '
        'txtPesquisa
        '
        Me.txtPesquisa.Location = New System.Drawing.Point(99, 21)
        Me.txtPesquisa.Name = "txtPesquisa"
        Me.txtPesquisa.Size = New System.Drawing.Size(209, 22)
        Me.txtPesquisa.TabIndex = 8
        '
        'gbProcurar
        '
        Me.gbProcurar.Controls.Add(Me.btnPesquisar)
        Me.gbProcurar.Controls.Add(Me.cmbFiltro)
        Me.gbProcurar.Controls.Add(Me.txtPesquisa)
        Me.gbProcurar.Location = New System.Drawing.Point(420, 12)
        Me.gbProcurar.Name = "gbProcurar"
        Me.gbProcurar.Size = New System.Drawing.Size(368, 56)
        Me.gbProcurar.TabIndex = 11
        Me.gbProcurar.TabStop = False
        Me.gbProcurar.Text = "Procurar por:"
        '
        'btnPesquisar
        '
        Me.btnPesquisar.Image = Global.CRUD_2.My.Resources.Resources.lupa
        Me.btnPesquisar.Location = New System.Drawing.Point(314, 17)
        Me.btnPesquisar.Name = "btnPesquisar"
        Me.btnPesquisar.Size = New System.Drawing.Size(36, 29)
        Me.btnPesquisar.TabIndex = 11
        Me.btnPesquisar.UseVisualStyleBackColor = True
        '
        'gbUf
        '
        Me.gbUf.Controls.Add(Me.cmbEstado)
        Me.gbUf.Location = New System.Drawing.Point(350, 12)
        Me.gbUf.Name = "gbUf"
        Me.gbUf.Size = New System.Drawing.Size(70, 56)
        Me.gbUf.TabIndex = 13
        Me.gbUf.TabStop = False
        Me.gbUf.Text = "UF"
        Me.gbUf.Visible = False
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(6, 21)
        Me.cmbEstado.MaxLength = 2
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(57, 24)
        Me.cmbEstado.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Cadastrar)
        Me.GroupBox1.Controls.Add(Me.Editar)
        Me.GroupBox1.Controls.Add(Me.Remover)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(304, 56)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Ações"
        '
        'GerenciarCidade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.gbUf)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gbProcurar)
        Me.Controls.Add(Me.Lista)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "GerenciarCidade"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Gerenciador de Cidades"
        CType(Me.Lista, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbProcurar.ResumeLayout(False)
        Me.gbProcurar.PerformLayout()
        Me.gbUf.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Lista As DataGridView
    Friend WithEvents Editar As Button
    Friend WithEvents Remover As Button
    Friend WithEvents Cadastrar As Button
    Friend WithEvents cmbFiltro As ComboBox
    Friend WithEvents txtPesquisa As TextBox
    Friend WithEvents gbProcurar As GroupBox
    Friend WithEvents btnPesquisar As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents gbUf As GroupBox
    Friend WithEvents cmbEstado As ComboBox
End Class
