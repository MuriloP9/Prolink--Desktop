
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
            this.btnSair = new System.Windows.Forms.Button();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.btnConfiguracoes = new System.Windows.Forms.Button();
            this.btnContato = new System.Windows.Forms.Button();
            this.btnCalendario = new System.Windows.Forms.Button();
            this.btnAnalystics = new System.Windows.Forms.Button();
            this.btnDashBoard = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlFormLoader = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.btnSair);
            this.panel1.Controls.Add(this.pnlNav);
            this.panel1.Controls.Add(this.btnConfiguracoes);
            this.panel1.Controls.Add(this.btnContato);
            this.panel1.Controls.Add(this.btnCalendario);
            this.panel1.Controls.Add(this.btnAnalystics);
            this.panel1.Controls.Add(this.btnDashBoard);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(186, 577);
            this.panel1.TabIndex = 0;
            // 
            // btnSair
            // 
            this.btnSair.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSair.FlatAppearance.BorderSize = 0;
            this.btnSair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSair.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnSair.Image = global::ProLinkDesktop.Properties.Resources.Sair;
            this.btnSair.Location = new System.Drawing.Point(0, 535);
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
            this.btnConfiguracoes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfiguracoes.FlatAppearance.BorderSize = 0;
            this.btnConfiguracoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracoes.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfiguracoes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnConfiguracoes.Image = global::ProLinkDesktop.Properties.Resources.config;
            this.btnConfiguracoes.Location = new System.Drawing.Point(0, 322);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Size = new System.Drawing.Size(186, 42);
            this.btnConfiguracoes.TabIndex = 5;
            this.btnConfiguracoes.Text = "Configurações";
            this.btnConfiguracoes.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnConfiguracoes.UseVisualStyleBackColor = true;
            this.btnConfiguracoes.Click += new System.EventHandler(this.btnConfiguracoes_Click);
            this.btnConfiguracoes.Leave += new System.EventHandler(this.btnConfiguracoes_Leave);
            // 
            // btnContato
            // 
            this.btnContato.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnContato.FlatAppearance.BorderSize = 0;
            this.btnContato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnContato.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContato.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnContato.Image = global::ProLinkDesktop.Properties.Resources.Contato__1_;
            this.btnContato.Location = new System.Drawing.Point(0, 280);
            this.btnContato.Name = "btnContato";
            this.btnContato.Size = new System.Drawing.Size(186, 42);
            this.btnContato.TabIndex = 4;
            this.btnContato.Text = "Contato        ";
            this.btnContato.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnContato.UseVisualStyleBackColor = true;
            this.btnContato.Click += new System.EventHandler(this.btnContato_Click);
            this.btnContato.Leave += new System.EventHandler(this.btnContato_Leave);
            // 
            // btnCalendario
            // 
            this.btnCalendario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCalendario.FlatAppearance.BorderSize = 0;
            this.btnCalendario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalendario.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalendario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnCalendario.Image = global::ProLinkDesktop.Properties.Resources.Exportar;
            this.btnCalendario.Location = new System.Drawing.Point(0, 238);
            this.btnCalendario.Name = "btnCalendario";
            this.btnCalendario.Size = new System.Drawing.Size(186, 42);
            this.btnCalendario.TabIndex = 3;
            this.btnCalendario.Text = "Exportar Relatorios";
            this.btnCalendario.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnCalendario.UseVisualStyleBackColor = true;
            this.btnCalendario.Click += new System.EventHandler(this.btnCalendario_Click);
            this.btnCalendario.Leave += new System.EventHandler(this.btnCalendario_Leave);
            // 
            // btnAnalystics
            // 
            this.btnAnalystics.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnalystics.FlatAppearance.BorderSize = 0;
            this.btnAnalystics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalystics.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnalystics.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnAnalystics.Image = global::ProLinkDesktop.Properties.Resources.Oportunidades;
            this.btnAnalystics.Location = new System.Drawing.Point(0, 196);
            this.btnAnalystics.Name = "btnAnalystics";
            this.btnAnalystics.Size = new System.Drawing.Size(186, 42);
            this.btnAnalystics.TabIndex = 2;
            this.btnAnalystics.Text = "Oportunidades";
            this.btnAnalystics.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnAnalystics.UseVisualStyleBackColor = true;
            this.btnAnalystics.Click += new System.EventHandler(this.btnAnalystics_Click);
            this.btnAnalystics.Leave += new System.EventHandler(this.btnAnalystics_Leave);
            // 
            // btnDashBoard
            // 
            this.btnDashBoard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashBoard.FlatAppearance.BorderSize = 0;
            this.btnDashBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashBoard.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashBoard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnDashBoard.Image = global::ProLinkDesktop.Properties.Resources.Menu__1_;
            this.btnDashBoard.Location = new System.Drawing.Point(0, 154);
            this.btnDashBoard.Name = "btnDashBoard";
            this.btnDashBoard.Size = new System.Drawing.Size(186, 42);
            this.btnDashBoard.TabIndex = 1;
            this.btnDashBoard.Text = "Menu               ";
            this.btnDashBoard.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnDashBoard.UseVisualStyleBackColor = true;
            this.btnDashBoard.Click += new System.EventHandler(this.btnDashBoard_Click);
            this.btnDashBoard.Leave += new System.EventHandler(this.btnDashBoard_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(186, 154);
            this.panel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.label1.Location = new System.Drawing.Point(61, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuário";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProLinkDesktop.Properties.Resources.Usuario;
            this.pictureBox1.Location = new System.Drawing.Point(45, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lblTitle.Location = new System.Drawing.Point(204, 22);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(166, 32);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "DashBoard";
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
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDashBoard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnConfiguracoes;
        private System.Windows.Forms.Button btnContato;
        private System.Windows.Forms.Button btnCalendario;
        private System.Windows.Forms.Button btnAnalystics;
        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Panel pnlFormLoader;
    }
}

