namespace ProLinkDesktop
{
    partial class FrmGerenciarFuncionarios
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvFuncionarios = new System.Windows.Forms.DataGridView();
            this.pnlDetalhes = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblStatusValor = new System.Windows.Forms.Label();
            this.lblUltimoAcessoValor = new System.Windows.Forms.Label();
            this.lblUltimoAcesso = new System.Windows.Forms.Label();
            this.lblDataCadastroValor = new System.Windows.Forms.Label();
            this.lblDataCadastro = new System.Windows.Forms.Label();
            this.lblCargoValor = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblEmailValor = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblNomeValor = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.lblDetalhes = new System.Windows.Forms.Label();
            this.btnAtivarInativar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.txtPesquisa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNovoFuncionario = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionarios)).BeginInit();
            this.pnlDetalhes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvFuncionarios
            // 
            this.dgvFuncionarios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFuncionarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(55)))));
            this.dgvFuncionarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFuncionarios.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFuncionarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFuncionarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(55)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFuncionarios.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFuncionarios.EnableHeadersVisualStyles = false;
            this.dgvFuncionarios.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.dgvFuncionarios.Location = new System.Drawing.Point(12, 80);
            this.dgvFuncionarios.Name = "dgvFuncionarios";
            this.dgvFuncionarios.ReadOnly = true;
            this.dgvFuncionarios.RowHeadersVisible = false;
            this.dgvFuncionarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFuncionarios.Size = new System.Drawing.Size(680, 350);
            this.dgvFuncionarios.TabIndex = 0;
            this.dgvFuncionarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFuncionarios_CellClick);
            // 
            // pnlDetalhes
            // 
            this.pnlDetalhes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDetalhes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.pnlDetalhes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDetalhes.Controls.Add(this.lblStatus);
            this.pnlDetalhes.Controls.Add(this.lblStatusValor);
            this.pnlDetalhes.Controls.Add(this.lblUltimoAcessoValor);
            this.pnlDetalhes.Controls.Add(this.lblUltimoAcesso);
            this.pnlDetalhes.Controls.Add(this.lblDataCadastroValor);
            this.pnlDetalhes.Controls.Add(this.lblDataCadastro);
            this.pnlDetalhes.Controls.Add(this.lblCargoValor);
            this.pnlDetalhes.Controls.Add(this.lblCargo);
            this.pnlDetalhes.Controls.Add(this.lblEmailValor);
            this.pnlDetalhes.Controls.Add(this.lblEmail);
            this.pnlDetalhes.Controls.Add(this.lblNomeValor);
            this.pnlDetalhes.Controls.Add(this.lblNome);
            this.pnlDetalhes.Controls.Add(this.lblDetalhes);
            this.pnlDetalhes.Location = new System.Drawing.Point(700, 80);
            this.pnlDetalhes.Name = "pnlDetalhes";
            this.pnlDetalhes.Size = new System.Drawing.Size(250, 350);
            this.pnlDetalhes.TabIndex = 1;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(15, 280);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(45, 15);
            this.lblStatus.TabIndex = 12;
            this.lblStatus.Text = "Status:";
            // 
            // lblStatusValor
            // 
            this.lblStatusValor.AutoSize = true;
            this.lblStatusValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStatusValor.ForeColor = System.Drawing.Color.White;
            this.lblStatusValor.Location = new System.Drawing.Point(15, 300);
            this.lblStatusValor.Name = "lblStatusValor";
            this.lblStatusValor.Size = new System.Drawing.Size(22, 15);
            this.lblStatusValor.TabIndex = 13;
            this.lblStatusValor.Text = "---";
            // 
            // lblUltimoAcessoValor
            // 
            this.lblUltimoAcessoValor.AutoSize = true;
            this.lblUltimoAcessoValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUltimoAcessoValor.ForeColor = System.Drawing.Color.White;
            this.lblUltimoAcessoValor.Location = new System.Drawing.Point(15, 250);
            this.lblUltimoAcessoValor.Name = "lblUltimoAcessoValor";
            this.lblUltimoAcessoValor.Size = new System.Drawing.Size(22, 15);
            this.lblUltimoAcessoValor.TabIndex = 11;
            this.lblUltimoAcessoValor.Text = "---";
            // 
            // lblUltimoAcesso
            // 
            this.lblUltimoAcesso.AutoSize = true;
            this.lblUltimoAcesso.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblUltimoAcesso.ForeColor = System.Drawing.Color.White;
            this.lblUltimoAcesso.Location = new System.Drawing.Point(15, 230);
            this.lblUltimoAcesso.Name = "lblUltimoAcesso";
            this.lblUltimoAcesso.Size = new System.Drawing.Size(89, 15);
            this.lblUltimoAcesso.TabIndex = 10;
            this.lblUltimoAcesso.Text = "Último Acesso:";
            // 
            // lblDataCadastroValor
            // 
            this.lblDataCadastroValor.AutoSize = true;
            this.lblDataCadastroValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDataCadastroValor.ForeColor = System.Drawing.Color.White;
            this.lblDataCadastroValor.Location = new System.Drawing.Point(15, 200);
            this.lblDataCadastroValor.Name = "lblDataCadastroValor";
            this.lblDataCadastroValor.Size = new System.Drawing.Size(22, 15);
            this.lblDataCadastroValor.TabIndex = 9;
            this.lblDataCadastroValor.Text = "---";
            // 
            // lblDataCadastro
            // 
            this.lblDataCadastro.AutoSize = true;
            this.lblDataCadastro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblDataCadastro.ForeColor = System.Drawing.Color.White;
            this.lblDataCadastro.Location = new System.Drawing.Point(15, 180);
            this.lblDataCadastro.Name = "lblDataCadastro";
            this.lblDataCadastro.Size = new System.Drawing.Size(87, 15);
            this.lblDataCadastro.TabIndex = 8;
            this.lblDataCadastro.Text = "Data Cadastro:";
            // 
            // lblCargoValor
            // 
            this.lblCargoValor.AutoSize = true;
            this.lblCargoValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCargoValor.ForeColor = System.Drawing.Color.White;
            this.lblCargoValor.Location = new System.Drawing.Point(15, 150);
            this.lblCargoValor.Name = "lblCargoValor";
            this.lblCargoValor.Size = new System.Drawing.Size(22, 15);
            this.lblCargoValor.TabIndex = 7;
            this.lblCargoValor.Text = "---";
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblCargo.ForeColor = System.Drawing.Color.White;
            this.lblCargo.Location = new System.Drawing.Point(15, 130);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(42, 15);
            this.lblCargo.TabIndex = 6;
            this.lblCargo.Text = "Cargo:";
            // 
            // lblEmailValor
            // 
            this.lblEmailValor.AutoSize = true;
            this.lblEmailValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmailValor.ForeColor = System.Drawing.Color.White;
            this.lblEmailValor.Location = new System.Drawing.Point(15, 100);
            this.lblEmailValor.Name = "lblEmailValor";
            this.lblEmailValor.Size = new System.Drawing.Size(22, 15);
            this.lblEmailValor.TabIndex = 5;
            this.lblEmailValor.Text = "---";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblEmail.ForeColor = System.Drawing.Color.White;
            this.lblEmail.Location = new System.Drawing.Point(15, 80);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // lblNomeValor
            // 
            this.lblNomeValor.AutoSize = true;
            this.lblNomeValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNomeValor.ForeColor = System.Drawing.Color.White;
            this.lblNomeValor.Location = new System.Drawing.Point(15, 50);
            this.lblNomeValor.Name = "lblNomeValor";
            this.lblNomeValor.Size = new System.Drawing.Size(22, 15);
            this.lblNomeValor.TabIndex = 3;
            this.lblNomeValor.Text = "---";
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblNome.ForeColor = System.Drawing.Color.White;
            this.lblNome.Location = new System.Drawing.Point(15, 30);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(44, 15);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome:";
            // 
            // lblDetalhes
            // 
            this.lblDetalhes.AutoSize = true;
            this.lblDetalhes.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDetalhes.ForeColor = System.Drawing.Color.White;
            this.lblDetalhes.Location = new System.Drawing.Point(15, 10);
            this.lblDetalhes.Name = "lblDetalhes";
            this.lblDetalhes.Size = new System.Drawing.Size(170, 19);
            this.lblDetalhes.TabIndex = 1;
            this.lblDetalhes.Text = "Detalhes do Funcionário";
            // 
            // btnAtivarInativar
            // 
            this.btnAtivarInativar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAtivarInativar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.btnAtivarInativar.FlatAppearance.BorderSize = 0;
            this.btnAtivarInativar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtivarInativar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAtivarInativar.ForeColor = System.Drawing.Color.White;
            this.btnAtivarInativar.Location = new System.Drawing.Point(700, 440);
            this.btnAtivarInativar.Name = "btnAtivarInativar";
            this.btnAtivarInativar.Size = new System.Drawing.Size(120, 35);
            this.btnAtivarInativar.TabIndex = 2;
            this.btnAtivarInativar.Text = "Inativar";
            this.btnAtivarInativar.UseVisualStyleBackColor = false;
            this.btnAtivarInativar.Click += new System.EventHandler(this.btnAtivarInativar_Click);
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAtualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.btnAtualizar.FlatAppearance.BorderSize = 0;
            this.btnAtualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(12, 440);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(120, 35);
            this.btnAtualizar.TabIndex = 3;
            this.btnAtualizar.Text = "Atualizar Lista";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            this.btnAtualizar.Click += new System.EventHandler(this.btnAtualizar_Click);
            // 
            // txtPesquisa
            // 
            this.txtPesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPesquisa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtPesquisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisa.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPesquisa.ForeColor = System.Drawing.Color.White;
            this.txtPesquisa.Location = new System.Drawing.Point(550, 50);
            this.txtPesquisa.Name = "txtPesquisa";
            this.txtPesquisa.Size = new System.Drawing.Size(400, 25);
            this.txtPesquisa.TabIndex = 5;
            this.txtPesquisa.TextChanged += new System.EventHandler(this.TxtPesquisa_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(455, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Pesquisar:";
            // 
            // btnNovoFuncionario
            // 
            this.btnNovoFuncionario.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNovoFuncionario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnNovoFuncionario.FlatAppearance.BorderSize = 0;
            this.btnNovoFuncionario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoFuncionario.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNovoFuncionario.ForeColor = System.Drawing.Color.White;
            this.btnNovoFuncionario.Location = new System.Drawing.Point(830, 440);
            this.btnNovoFuncionario.Name = "btnNovoFuncionario";
            this.btnNovoFuncionario.Size = new System.Drawing.Size(120, 35);
            this.btnNovoFuncionario.TabIndex = 7;
            this.btnNovoFuncionario.Text = "Novo Funcionário";
            this.btnNovoFuncionario.UseVisualStyleBackColor = false;
            this.btnNovoFuncionario.Click += new System.EventHandler(this.btnNovoFuncionario_Click);
            // 
            // FrmGerenciarFuncionarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(962, 487);
            this.Controls.Add(this.btnNovoFuncionario);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPesquisa);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnAtivarInativar);
            this.Controls.Add(this.pnlDetalhes);
            this.Controls.Add(this.dgvFuncionarios);
            this.Name = "FrmGerenciarFuncionarios";
            this.Text = "Gerenciamento de Funcionários";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFuncionarios)).EndInit();
            this.pnlDetalhes.ResumeLayout(false);
            this.pnlDetalhes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFuncionarios;
        private System.Windows.Forms.Panel pnlDetalhes;
        private System.Windows.Forms.Label lblDetalhes;
        private System.Windows.Forms.Button btnAtivarInativar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.TextBox txtPesquisa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblNomeValor;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblEmailValor;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblCargoValor;
        private System.Windows.Forms.Label lblDataCadastro;
        private System.Windows.Forms.Label lblDataCadastroValor;
        private System.Windows.Forms.Label lblUltimoAcesso;
        private System.Windows.Forms.Label lblUltimoAcessoValor;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblStatusValor;
        private System.Windows.Forms.Button btnNovoFuncionario;
    }
}