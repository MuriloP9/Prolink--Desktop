namespace ProLinkDesktop
{
    partial class FrmConfiguracoes
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
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toggleTema = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkNotificacoes = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkBackupAuto = new System.Windows.Forms.CheckBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.pnlContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();

            // pnlContainer
            this.pnlContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlContainer.BackColor = System.Drawing.Color.White;
            this.pnlContainer.Controls.Add(this.panel3);
            this.pnlContainer.Controls.Add(this.panel2);
            this.pnlContainer.Controls.Add(this.panel1);
            this.pnlContainer.Controls.Add(this.btnSalvar);
            this.pnlContainer.Location = new System.Drawing.Point(20, 20);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(500, 400);
            this.pnlContainer.TabIndex = 0;

            // panel1 (Tema)
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.toggleTema);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20);
            this.panel1.Size = new System.Drawing.Size(500, 80);
            this.panel1.TabIndex = 1;

            // label1
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tema Escuro";

            // toggleTema
            this.toggleTema.Appearance = System.Windows.Forms.Appearance.Button;
            this.toggleTema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleTema.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toggleTema.Location = new System.Drawing.Point(350, 15);
            this.toggleTema.Name = "toggleTema";
            this.toggleTema.Size = new System.Drawing.Size(100, 30);
            this.toggleTema.TabIndex = 1;
            this.toggleTema.Text = "OFF";
            this.toggleTema.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toggleTema.UseVisualStyleBackColor = true;
            this.toggleTema.CheckedChanged += new System.EventHandler(this.toggleTema_CheckedChanged);

            // panel2 (Notificações)
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.chkNotificacoes);
            this.panel2.Location = new System.Drawing.Point(0, 90);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(500, 80);
            this.panel2.TabIndex = 2;

            // chkNotificacoes
            this.chkNotificacoes.AutoSize = true;
            this.chkNotificacoes.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.chkNotificacoes.Location = new System.Drawing.Point(20, 20);
            this.chkNotificacoes.Name = "chkNotificacoes";
            this.chkNotificacoes.Size = new System.Drawing.Size(220, 24);
            this.chkNotificacoes.TabIndex = 0;
            this.chkNotificacoes.Text = "Receber Notificações";
            this.chkNotificacoes.UseVisualStyleBackColor = true;

            // panel3 (Backup)
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.chkBackupAuto);
            this.panel3.Location = new System.Drawing.Point(0, 180);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(20);
            this.panel3.Size = new System.Drawing.Size(500, 80);
            this.panel3.TabIndex = 3;

            // chkBackupAuto
            this.chkBackupAuto.AutoSize = true;
            this.chkBackupAuto.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.chkBackupAuto.Location = new System.Drawing.Point(20, 20);
            this.chkBackupAuto.Name = "chkBackupAuto";
            this.chkBackupAuto.Size = new System.Drawing.Size(210, 24);
            this.chkBackupAuto.TabIndex = 0;
            this.chkBackupAuto.Text = "Backup Automático";
            this.chkBackupAuto.UseVisualStyleBackColor = true;

            // btnSalvar
            this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI Semibold", 11F);
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(350, 340);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(120, 40);
            this.btnSalvar.TabIndex = 4;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // FrmConfiguracoes
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 440);
            this.Controls.Add(this.pnlContainer);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "FrmConfiguracoes";
            this.Text = "Configurações";
            this.pnlContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox toggleTema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox chkNotificacoes;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chkBackupAuto;
        private System.Windows.Forms.Button btnSalvar;
    }
}