
namespace ProLinkDesktop
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnWebinar = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnConfiguracoes = new System.Windows.Forms.Button();
            this.btnGerenciarFuncionarios = new System.Windows.Forms.Button();
            this.btnGerenciarUsuarios = new System.Windows.Forms.Button();
            this.btnOportunidades = new System.Windows.Forms.Button();
            this.btnMenu = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFormLoader = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.btnWebinar);
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.pnlNav);
            this.panel1.Controls.Add(this.btnConfiguracoes);
            this.panel1.Controls.Add(this.btnGerenciarFuncionarios);
            this.panel1.Controls.Add(this.btnGerenciarUsuarios);
            this.panel1.Controls.Add(this.btnOportunidades);
            this.panel1.Controls.Add(this.btnMenu);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 577);
            this.panel1.TabIndex = 0;
            // 
            // btnWebinar
            // 
            this.btnWebinar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWebinar.FlatAppearance.BorderSize = 0;
            this.btnWebinar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWebinar.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWebinar.ForeColor = System.Drawing.Color.White;
            this.btnWebinar.Image = global::ProLinkDesktop.Properties.Resources.config;
            this.btnWebinar.Location = new System.Drawing.Point(0, 322);
            this.btnWebinar.Name = "btnWebinar";
            this.btnWebinar.Size = new System.Drawing.Size(186, 42);
            this.btnWebinar.TabIndex = 7;
            this.btnWebinar.Text = "Webinar";
            this.btnWebinar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnWebinar.UseVisualStyleBackColor = true;
            this.btnWebinar.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSair
            // 
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Image = global::ProLinkDesktop.Properties.Resources.Sair;
            this.btnSair.Location = new System.Drawing.Point(0, 532);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(186, 42);
            this.btnSair.TabIndex = 6;
            this.btnSair.Text = " Sair                          ";
            this.btnSair.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSair.UseVisualStyleBackColor = true;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // pnlNav
            // 
            this.pnlNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.pnlNav.Location = new System.Drawing.Point(0, 193);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(3, 100);
            this.pnlNav.TabIndex = 3;
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.FlatAppearance.BorderSize = 0;
            this.btnConfiguracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracoes.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracoes.ForeColor = System.Drawing.Color.White;
            this.btnConfiguracoes.Image = global::ProLinkDesktop.Properties.Resources.config;
            this.btnConfiguracoes.Location = new System.Drawing.Point(3, 494);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Size = new System.Drawing.Size(186, 42);
            this.btnConfiguracoes.TabIndex = 5;
            this.btnConfiguracoes.Text = "Configurações";
            this.btnConfiguracoes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConfiguracoes.UseVisualStyleBackColor = true;
            this.btnConfiguracoes.Click += new System.EventHandler(this.btnConfiguracoes_Click);
            // 
            // btnGerenciarFuncionarios
            // 
            this.btnGerenciarFuncionarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGerenciarFuncionarios.FlatAppearance.BorderSize = 0;
            this.btnGerenciarFuncionarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerenciarFuncionarios.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerenciarFuncionarios.ForeColor = System.Drawing.Color.White;
            this.btnGerenciarFuncionarios.Image = global::ProLinkDesktop.Properties.Resources.EmpresaseSubdivisoes;
            this.btnGerenciarFuncionarios.Location = new System.Drawing.Point(0, 280);
            this.btnGerenciarFuncionarios.Name = "btnGerenciarFuncionarios";
            this.btnGerenciarFuncionarios.Size = new System.Drawing.Size(186, 42);
            this.btnGerenciarFuncionarios.TabIndex = 4;
            this.btnGerenciarFuncionarios.Text = "Gerenciar Funcionários";
            this.btnGerenciarFuncionarios.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGerenciarFuncionarios.UseVisualStyleBackColor = true;
            this.btnGerenciarFuncionarios.Click += new System.EventHandler(this.btnGerenciarFuncionarios_Click);
            // 
            // btnGerenciarUsuarios
            // 
            this.btnGerenciarUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGerenciarUsuarios.FlatAppearance.BorderSize = 0;
            this.btnGerenciarUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGerenciarUsuarios.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerenciarUsuarios.ForeColor = System.Drawing.Color.White;
            this.btnGerenciarUsuarios.Image = global::ProLinkDesktop.Properties.Resources.Exportar;
            this.btnGerenciarUsuarios.Location = new System.Drawing.Point(0, 238);
            this.btnGerenciarUsuarios.Name = "btnGerenciarUsuarios";
            this.btnGerenciarUsuarios.Size = new System.Drawing.Size(186, 42);
            this.btnGerenciarUsuarios.TabIndex = 3;
            this.btnGerenciarUsuarios.Text = "Gerenciar Usuários";
            this.btnGerenciarUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnGerenciarUsuarios.UseVisualStyleBackColor = true;
            this.btnGerenciarUsuarios.Click += new System.EventHandler(this.btnGerenciarUsuarios_Click);
            // 
            // btnOportunidades
            // 
            this.btnOportunidades.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOportunidades.FlatAppearance.BorderSize = 0;
            this.btnOportunidades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOportunidades.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOportunidades.ForeColor = System.Drawing.Color.White;
            this.btnOportunidades.Image = global::ProLinkDesktop.Properties.Resources.Oportunidades;
            this.btnOportunidades.Location = new System.Drawing.Point(0, 196);
            this.btnOportunidades.Name = "btnOportunidades";
            this.btnOportunidades.Size = new System.Drawing.Size(186, 42);
            this.btnOportunidades.TabIndex = 2;
            this.btnOportunidades.Text = "Oportunidades";
            this.btnOportunidades.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnOportunidades.UseVisualStyleBackColor = true;
            this.btnOportunidades.Click += new System.EventHandler(this.btnOportunidades_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.ForeColor = System.Drawing.Color.White;
            this.btnMenu.Image = global::ProLinkDesktop.Properties.Resources.Menu__1_;
            this.btnMenu.Location = new System.Drawing.Point(0, 154);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(186, 42);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "Menu               ";
            this.btnMenu.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblUsuario);
            this.panel2.Controls.Add(this.PicBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 154);
            this.panel2.TabIndex = 0;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(42, 114);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(62, 16);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuário";
            // 
            // PicBox
            // 
            this.PicBox.Image = global::ProLinkDesktop.Properties.Resources.Usuario;
            this.PicBox.Location = new System.Drawing.Point(45, 22);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(94, 75);
            this.PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PicBox.TabIndex = 0;
            this.PicBox.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lblTitle.Location = new System.Drawing.Point(204, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(90, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Menu";
            // 
            // pnlFormLoader
            // 
            this.pnlFormLoader.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFormLoader.Location = new System.Drawing.Point(186, 100);
            this.pnlFormLoader.Name = "pnlFormLoader";
            this.pnlFormLoader.Size = new System.Drawing.Size(765, 477);
            this.pnlFormLoader.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(951, 577);
            this.Controls.Add(this.pnlFormLoader);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.PictureBox PicBox;
        private System.Windows.Forms.Button btnConfiguracoes;
        private System.Windows.Forms.Button btnGerenciarFuncionarios;
        private System.Windows.Forms.Button btnGerenciarUsuarios;
        private System.Windows.Forms.Button btnOportunidades;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel pnlFormLoader;
        private System.Windows.Forms.Button btnWebinar;
    }
}

