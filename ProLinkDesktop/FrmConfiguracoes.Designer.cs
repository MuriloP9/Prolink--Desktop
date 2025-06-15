namespace ProLinkDesktop
{
    partial class FrmConfiguracoes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUsuario = new System.Windows.Forms.TabPage();
            this.tabGeral = new System.Windows.Forms.TabPage();
            this.tabSobre = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCargo = new System.Windows.Forms.Label();
            this.lblDataCadastro = new System.Windows.Forms.Label();
            this.lblUltimoAcesso = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkNotificacoes = new System.Windows.Forms.CheckBox();
            this.chkIniciarWindows = new System.Windows.Forms.CheckBox();
            this.chkSonsAtivos = new System.Windows.Forms.CheckBox();
            this.btnLimparCache = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblVersao = new System.Windows.Forms.Label();
            this.lblDataCompilacao = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSobre = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabUsuario.SuspendLayout();
            this.tabGeral.SuspendLayout();
            this.tabSobre.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabUsuario);
            this.tabControl1.Controls.Add(this.tabGeral);
            this.tabControl1.Controls.Add(this.tabSobre);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(460, 340);
            this.tabControl1.TabIndex = 0;
            // 
            // tabUsuario
            // 
            this.tabUsuario.Controls.Add(this.groupBox1);
            this.tabUsuario.Location = new System.Drawing.Point(4, 22);
            this.tabUsuario.Name = "tabUsuario";
            this.tabUsuario.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsuario.Size = new System.Drawing.Size(452, 314);
            this.tabUsuario.TabIndex = 0;
            this.tabUsuario.Text = "Usuário";
            this.tabUsuario.UseVisualStyleBackColor = true;
            // 
            // tabGeral
            // 
            this.tabGeral.Controls.Add(this.btnLimparCache);
            this.tabGeral.Controls.Add(this.groupBox2);
            this.tabGeral.Location = new System.Drawing.Point(4, 22);
            this.tabGeral.Name = "tabGeral";
            this.tabGeral.Padding = new System.Windows.Forms.Padding(3);
            this.tabGeral.Size = new System.Drawing.Size(452, 314);
            this.tabGeral.TabIndex = 1;
            this.tabGeral.Text = "Geral";
            this.tabGeral.UseVisualStyleBackColor = true;
            // 
            // tabSobre
            // 
            this.tabSobre.Controls.Add(this.btnSobre);
            this.tabSobre.Controls.Add(this.groupBox3);
            this.tabSobre.Location = new System.Drawing.Point(4, 22);
            this.tabSobre.Name = "tabSobre";
            this.tabSobre.Size = new System.Drawing.Size(452, 314);
            this.tabSobre.TabIndex = 2;
            this.tabSobre.Text = "Sobre";
            this.tabSobre.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblUltimoAcesso);
            this.groupBox1.Controls.Add(this.lblDataCadastro);
            this.groupBox1.Controls.Add(this.lblCargo);
            this.groupBox1.Controls.Add(this.txtObservacoes);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtEmail);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtNomeUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 270);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Informações Pessoais";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do Usuário:";
            // 
            // txtNomeUsuario
            // 
            this.txtNomeUsuario.Location = new System.Drawing.Point(23, 51);
            this.txtNomeUsuario.Name = "txtNomeUsuario";
            this.txtNomeUsuario.Size = new System.Drawing.Size(370, 20);
            this.txtNomeUsuario.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(23, 101);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(370, 20);
            this.txtEmail.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Observações:";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Location = new System.Drawing.Point(23, 171);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtObservacoes.Size = new System.Drawing.Size(370, 60);
            this.txtObservacoes.TabIndex = 5;
            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargo.Location = new System.Drawing.Point(20, 240);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new System.Drawing.Size(45, 13);
            this.lblCargo.TabIndex = 6;
            this.lblCargo.Text = "Cargo:";
            // 
            // lblDataCadastro
            // 
            this.lblDataCadastro.AutoSize = true;
            this.lblDataCadastro.Location = new System.Drawing.Point(150, 240);
            this.lblDataCadastro.Name = "lblDataCadastro";
            this.lblDataCadastro.Size = new System.Drawing.Size(95, 13);
            this.lblDataCadastro.TabIndex = 7;
            this.lblDataCadastro.Text = "Cadastrado em: --";
            // 
            // lblUltimoAcesso
            // 
            this.lblUltimoAcesso.AutoSize = true;
            this.lblUltimoAcesso.Location = new System.Drawing.Point(270, 240);
            this.lblUltimoAcesso.Name = "lblUltimoAcesso";
            this.lblUltimoAcesso.Size = new System.Drawing.Size(85, 13);
            this.lblUltimoAcesso.TabIndex = 8;
            this.lblUltimoAcesso.Text = "Último acesso: --";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkSonsAtivos);
            this.groupBox2.Controls.Add(this.chkIniciarWindows);
            this.groupBox2.Controls.Add(this.chkNotificacoes);
            this.groupBox2.Location = new System.Drawing.Point(15, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(420, 130);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preferências";
            // 
            // chkNotificacoes
            // 
            this.chkNotificacoes.AutoSize = true;
            this.chkNotificacoes.Checked = true;
            this.chkNotificacoes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNotificacoes.Location = new System.Drawing.Point(23, 35);
            this.chkNotificacoes.Name = "chkNotificacoes";
            this.chkNotificacoes.Size = new System.Drawing.Size(129, 17);
            this.chkNotificacoes.TabIndex = 0;
            this.chkNotificacoes.Text = "Ativar notificações";
            this.chkNotificacoes.UseVisualStyleBackColor = true;
            this.chkNotificacoes.CheckedChanged += new System.EventHandler(this.chkNotificacoes_CheckedChanged);
            // 
            // chkIniciarWindows
            // 
            this.chkIniciarWindows.AutoSize = true;
            this.chkIniciarWindows.Location = new System.Drawing.Point(23, 65);
            this.chkIniciarWindows.Name = "chkIniciarWindows";
            this.chkIniciarWindows.Size = new System.Drawing.Size(158, 17);
            this.chkIniciarWindows.TabIndex = 1;
            this.chkIniciarWindows.Text = "Iniciar junto com o Windows";
            this.chkIniciarWindows.UseVisualStyleBackColor = true;
            // 
            // chkSonsAtivos
            // 
            this.chkSonsAtivos.AutoSize = true;
            this.chkSonsAtivos.Checked = true;
            this.chkSonsAtivos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSonsAtivos.Location = new System.Drawing.Point(23, 95);
            this.chkSonsAtivos.Name = "chkSonsAtivos";
            this.chkSonsAtivos.Size = new System.Drawing.Size(122, 17);
            this.chkSonsAtivos.TabIndex = 2;
            this.chkSonsAtivos.Text = "Sons de notificação";
            this.chkSonsAtivos.UseVisualStyleBackColor = true;
            // 
            // btnLimparCache
            // 
            this.btnLimparCache.Location = new System.Drawing.Point(15, 170);
            this.btnLimparCache.Name = "btnLimparCache";
            this.btnLimparCache.Size = new System.Drawing.Size(150, 35);
            this.btnLimparCache.TabIndex = 1;
            this.btnLimparCache.Text = "Limpar Cache";
            this.btnLimparCache.UseVisualStyleBackColor = true;
            this.btnLimparCache.Click += new System.EventHandler(this.btnLimparCache_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lblDataCompilacao);
            this.groupBox3.Controls.Add(this.lblVersao);
            this.groupBox3.Location = new System.Drawing.Point(15, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(420, 120);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informações do Sistema";
            // 
            // lblVersao
            // 
            this.lblVersao.AutoSize = true;
            this.lblVersao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersao.Location = new System.Drawing.Point(80, 35);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(75, 15);
            this.lblVersao.TabIndex = 0;
            this.lblVersao.Text = "Versão 1.0";
            // 
            // lblDataCompilacao
            // 
            this.lblDataCompilacao.AutoSize = true;
            this.lblDataCompilacao.Location = new System.Drawing.Point(80, 65);
            this.lblDataCompilacao.Name = "lblDataCompilacao";
            this.lblDataCompilacao.Size = new System.Drawing.Size(130, 13);
            this.lblDataCompilacao.TabIndex = 1;
            this.lblDataCompilacao.Text = "Compilado em: 01/01/2025";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Versão:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Compilado:";
            // 
            // btnSobre
            // 
            this.btnSobre.Location = new System.Drawing.Point(15, 160);
            this.btnSobre.Name = "btnSobre";
            this.btnSobre.Size = new System.Drawing.Size(150, 35);
            this.btnSobre.TabIndex = 1;
            this.btnSobre.Text = "Sobre o Sistema";
            this.btnSobre.UseVisualStyleBackColor = true;
            this.btnSobre.Click += new System.EventHandler(this.btnSobre_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(230, 370);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(80, 30);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Location = new System.Drawing.Point(320, 370);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(80, 30);
            this.btnRestaurar.TabIndex = 2;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(410, 370);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(80, 30);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FrmConfiguracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 415);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguracoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configurações - ProLink Desktop";
            this.tabControl1.ResumeLayout(false);
            this.tabUsuario.ResumeLayout(false);
            this.tabGeral.ResumeLayout(false);
            this.tabSobre.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUsuario;
        private System.Windows.Forms.TabPage tabGeral;
        private System.Windows.Forms.TabPage tabSobre;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkSonsAtivos;
        private System.Windows.Forms.CheckBox chkIniciarWindows;
        private System.Windows.Forms.CheckBox chkNotificacoes;
        private System.Windows.Forms.Button btnLimparCache;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDataCompilacao;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Label lblCargo;
        private System.Windows.Forms.Label lblDataCadastro;
        private System.Windows.Forms.Label lblUltimoAcesso;
        private System.Windows.Forms.Button btnSobre;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.Button btnFechar;
    }
}