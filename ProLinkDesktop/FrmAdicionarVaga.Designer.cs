namespace ProLinkDesktop
{
    partial class FrmAdicionarVaga
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblLocalizacao = new System.Windows.Forms.Label();
            this.txtLocalizacao = new System.Windows.Forms.TextBox();
            this.lblTipoEmprego = new System.Windows.Forms.Label();
            this.cmbTipoEmprego = new System.Windows.Forms.ComboBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.cmbArea = new System.Windows.Forms.ComboBox();
            this.lblEmpresa = new System.Windows.Forms.Label();
            this.txtEmpresa = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblSalario = new System.Windows.Forms.Label();
            this.txtSalario = new System.Windows.Forms.TextBox();
            this.lblRequisitos = new System.Windows.Forms.Label();
            this.txtRequisitos = new System.Windows.Forms.TextBox();
            this.lblBeneficios = new System.Windows.Forms.Label();
            this.txtBeneficios = new System.Windows.Forms.TextBox();
            this.chkAtiva = new System.Windows.Forms.CheckBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(81, 13);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Título da Vaga:";
            // 
            // txtTitulo
            // 
            this.txtTitulo.Location = new System.Drawing.Point(120, 17);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new System.Drawing.Size(300, 20);
            this.txtTitulo.TabIndex = 1;
            // 
            // lblLocalizacao
            // 
            this.lblLocalizacao.AutoSize = true;
            this.lblLocalizacao.ForeColor = System.Drawing.Color.White;
            this.lblLocalizacao.Location = new System.Drawing.Point(20, 60);
            this.lblLocalizacao.Name = "lblLocalizacao";
            this.lblLocalizacao.Size = new System.Drawing.Size(67, 13);
            this.lblLocalizacao.TabIndex = 2;
            this.lblLocalizacao.Text = "Localização:";
            // 
            // txtLocalizacao
            // 
            this.txtLocalizacao.Location = new System.Drawing.Point(120, 57);
            this.txtLocalizacao.Name = "txtLocalizacao";
            this.txtLocalizacao.Size = new System.Drawing.Size(300, 20);
            this.txtLocalizacao.TabIndex = 3;
            // 
            // lblTipoEmprego
            // 
            this.lblTipoEmprego.AutoSize = true;
            this.lblTipoEmprego.ForeColor = System.Drawing.Color.White;
            this.lblTipoEmprego.Location = new System.Drawing.Point(20, 100);
            this.lblTipoEmprego.Name = "lblTipoEmprego";
            this.lblTipoEmprego.Size = new System.Drawing.Size(91, 13);
            this.lblTipoEmprego.TabIndex = 4;
            this.lblTipoEmprego.Text = "Tipo de Emprego:";
            // 
            // cmbTipoEmprego
            // 
            this.cmbTipoEmprego.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoEmprego.FormattingEnabled = true;
            this.cmbTipoEmprego.Items.AddRange(new object[] {
            "full-time",
            "part-time",
            "internship"});
            this.cmbTipoEmprego.Location = new System.Drawing.Point(120, 97);
            this.cmbTipoEmprego.Name = "cmbTipoEmprego";
            this.cmbTipoEmprego.Size = new System.Drawing.Size(150, 21);
            this.cmbTipoEmprego.TabIndex = 5;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.ForeColor = System.Drawing.Color.White;
            this.lblArea.Location = new System.Drawing.Point(20, 140);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(90, 13);
            this.lblArea.TabIndex = 6;
            this.lblArea.Text = "Área de Atuação:";
            // 
            // cmbArea
            // 
            this.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new System.Drawing.Point(120, 137);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new System.Drawing.Size(300, 21);
            this.cmbArea.TabIndex = 7;
            // 
            // lblEmpresa
            // 
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.ForeColor = System.Drawing.Color.White;
            this.lblEmpresa.Location = new System.Drawing.Point(20, 180);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new System.Drawing.Size(51, 13);
            this.lblEmpresa.TabIndex = 8;
            this.lblEmpresa.Text = "Empresa:";
            // 
            // txtEmpresa
            // 
            this.txtEmpresa.Location = new System.Drawing.Point(120, 177);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new System.Drawing.Size(300, 20);
            this.txtEmpresa.TabIndex = 9;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(240, 530);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(85, 30);
            this.btnSalvar.TabIndex = 19;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(335, 530);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 30);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblSalario
            // 
            this.lblSalario.AutoSize = true;
            this.lblSalario.ForeColor = System.Drawing.Color.White;
            this.lblSalario.Location = new System.Drawing.Point(20, 220);
            this.lblSalario.Name = "lblSalario";
            this.lblSalario.Size = new System.Drawing.Size(42, 13);
            this.lblSalario.TabIndex = 10;
            this.lblSalario.Text = "Salário:";
            // 
            // txtSalario
            // 
            this.txtSalario.Location = new System.Drawing.Point(120, 217);
            this.txtSalario.Name = "txtSalario";
            this.txtSalario.Size = new System.Drawing.Size(100, 20);
            this.txtSalario.TabIndex = 11;
            // 
            // lblRequisitos
            // 
            this.lblRequisitos.AutoSize = true;
            this.lblRequisitos.ForeColor = System.Drawing.Color.White;
            this.lblRequisitos.Location = new System.Drawing.Point(20, 340);
            this.lblRequisitos.Name = "lblRequisitos";
            this.lblRequisitos.Size = new System.Drawing.Size(57, 13);
            this.lblRequisitos.TabIndex = 14;
            this.lblRequisitos.Text = "Requisitos:";
            // 
            // txtRequisitos
            // 
            this.txtRequisitos.Location = new System.Drawing.Point(120, 337);
            this.txtRequisitos.Multiline = true;
            this.txtRequisitos.Name = "txtRequisitos";
            this.txtRequisitos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtRequisitos.Size = new System.Drawing.Size(300, 60);
            this.txtRequisitos.TabIndex = 17;
            // 
            // lblBeneficios
            // 
            this.lblBeneficios.AutoSize = true;
            this.lblBeneficios.ForeColor = System.Drawing.Color.White;
            this.lblBeneficios.Location = new System.Drawing.Point(20, 410);
            this.lblBeneficios.Name = "lblBeneficios";
            this.lblBeneficios.Size = new System.Drawing.Size(56, 13);
            this.lblBeneficios.TabIndex = 16;
            this.lblBeneficios.Text = "Benefícios:";
            // 
            // txtBeneficios
            // 
            this.txtBeneficios.Location = new System.Drawing.Point(120, 407);
            this.txtBeneficios.Multiline = true;
            this.txtBeneficios.Name = "txtBeneficios";
            this.txtBeneficios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBeneficios.Size = new System.Drawing.Size(300, 60);
            this.txtBeneficios.TabIndex = 18;
            // 
            // chkAtiva
            // 
            this.chkAtiva.AutoSize = true;
            this.chkAtiva.ForeColor = System.Drawing.Color.White;
            this.chkAtiva.Location = new System.Drawing.Point(120, 480);
            this.chkAtiva.Name = "chkAtiva";
            this.chkAtiva.Size = new System.Drawing.Size(50, 17);
            this.chkAtiva.TabIndex = 21;
            this.chkAtiva.Text = "Ativa";
            this.chkAtiva.UseVisualStyleBackColor = true;
            this.chkAtiva.Visible = false;
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.ForeColor = System.Drawing.Color.White;
            this.lblDescricao.Location = new System.Drawing.Point(20, 260);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 12;
            this.lblDescricao.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(120, 257);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricao.Size = new System.Drawing.Size(300, 60);
            this.txtDescricao.TabIndex = 13;
            // 
            // FrmAdicionarVaga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(450, 580);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.chkAtiva);
            this.Controls.Add(this.txtBeneficios);
            this.Controls.Add(this.lblBeneficios);
            this.Controls.Add(this.txtRequisitos);
            this.Controls.Add(this.lblRequisitos);
            this.Controls.Add(this.txtSalario);
            this.Controls.Add(this.lblSalario);
            this.Controls.Add(this.txtEmpresa);
            this.Controls.Add(this.lblEmpresa);
            this.Controls.Add(this.cmbArea);
            this.Controls.Add(this.lblArea);
            this.Controls.Add(this.cmbTipoEmprego);
            this.Controls.Add(this.lblTipoEmprego);
            this.Controls.Add(this.txtLocalizacao);
            this.Controls.Add(this.lblLocalizacao);
            this.Controls.Add(this.txtTitulo);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdicionarVaga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adicionar Vaga";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblLocalizacao;
        private System.Windows.Forms.TextBox txtLocalizacao;
        private System.Windows.Forms.Label lblTipoEmprego;
        private System.Windows.Forms.ComboBox cmbTipoEmprego;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.ComboBox cmbArea;
        private System.Windows.Forms.Label lblEmpresa;
        private System.Windows.Forms.TextBox txtEmpresa;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblSalario;
        private System.Windows.Forms.TextBox txtSalario;
        private System.Windows.Forms.Label lblRequisitos;
        private System.Windows.Forms.TextBox txtRequisitos;
        private System.Windows.Forms.Label lblBeneficios;
        private System.Windows.Forms.TextBox txtBeneficios;
        private System.Windows.Forms.CheckBox chkAtiva;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
    }
}