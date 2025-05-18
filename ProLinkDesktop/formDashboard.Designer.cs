
namespace ProLinkDesktop
{
    partial class formDashboard
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
            this.pnlUser = new System.Windows.Forms.Panel();
            this.lblAtividade = new System.Windows.Forms.Label();
            this.CpbInatividade = new CircularProgressBar.CircularProgressBar();
            this.label12 = new System.Windows.Forms.Label();
            this.lblAcessoHorario = new System.Windows.Forms.Label();
            this.lblAcessoEmail = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblNUsuario = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblNEmpresas = new System.Windows.Forms.Label();
            this.lblEmpresas = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblVagas = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pnlUser.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.pnlUser.Controls.Add(this.lblAtividade);
            this.pnlUser.Controls.Add(this.CpbInatividade);
            this.pnlUser.Controls.Add(this.label12);
            this.pnlUser.Location = new System.Drawing.Point(307, 170);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Size = new System.Drawing.Size(404, 295);
            this.pnlUser.TabIndex = 12;
            this.pnlUser.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlUser_Paint);
            // 
            // lblAtividade
            // 
            this.lblAtividade.AutoSize = true;
            this.lblAtividade.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAtividade.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lblAtividade.Location = new System.Drawing.Point(19, 253);
            this.lblAtividade.Name = "lblAtividade";
            this.lblAtividade.Size = new System.Drawing.Size(165, 17);
            this.lblAtividade.TabIndex = 4;
            this.lblAtividade.Text = "8 de 12 vagas preenchidas";
            // 
            // CpbInatividade
            // 
            this.CpbInatividade.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.CpbInatividade.AnimationSpeed = 500;
            this.CpbInatividade.BackColor = System.Drawing.Color.Transparent;
            this.CpbInatividade.Font = new System.Drawing.Font("Agency FB", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CpbInatividade.ForeColor = System.Drawing.Color.White;
            this.CpbInatividade.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.CpbInatividade.InnerMargin = 2;
            this.CpbInatividade.InnerWidth = -1;
            this.CpbInatividade.Location = new System.Drawing.Point(131, 73);
            this.CpbInatividade.MarqueeAnimationSpeed = 2000;
            this.CpbInatividade.Name = "CpbInatividade";
            this.CpbInatividade.OuterColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.CpbInatividade.OuterMargin = -25;
            this.CpbInatividade.OuterWidth = 26;
            this.CpbInatividade.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.CpbInatividade.ProgressWidth = 7;
            this.CpbInatividade.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 36F);
            this.CpbInatividade.Size = new System.Drawing.Size(150, 150);
            this.CpbInatividade.StartAngle = 270;
            this.CpbInatividade.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.CpbInatividade.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.CpbInatividade.SubscriptText = "";
            this.CpbInatividade.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.CpbInatividade.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.CpbInatividade.SuperscriptText = "";
            this.CpbInatividade.TabIndex = 1;
            this.CpbInatividade.Text = "67%";
            this.CpbInatividade.TextMargin = new System.Windows.Forms.Padding(5, 8, 0, 0);
            this.CpbInatividade.Value = 68;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(4, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(204, 25);
            this.label12.TabIndex = 0;
            this.label12.Text = "Atividade dos Usuarios";
            // 
            // lblAcessoHorario
            // 
            this.lblAcessoHorario.AutoSize = true;
            this.lblAcessoHorario.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcessoHorario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lblAcessoHorario.Location = new System.Drawing.Point(74, 94);
            this.lblAcessoHorario.Name = "lblAcessoHorario";
            this.lblAcessoHorario.Size = new System.Drawing.Size(118, 17);
            this.lblAcessoHorario.TabIndex = 6;
            this.lblAcessoHorario.Text = "06/04/2025 - 14:32";
            // 
            // lblAcessoEmail
            // 
            this.lblAcessoEmail.AutoSize = true;
            this.lblAcessoEmail.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAcessoEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(161)))), ((int)(((byte)(176)))));
            this.lblAcessoEmail.Location = new System.Drawing.Point(13, 58);
            this.lblAcessoEmail.Name = "lblAcessoEmail";
            this.lblAcessoEmail.Size = new System.Drawing.Size(135, 17);
            this.lblAcessoEmail.TabIndex = 5;
            this.lblAcessoEmail.Text = "admin@empresa.com";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(11, 14);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(131, 25);
            this.label13.TabIndex = 0;
            this.label13.Text = "Último Acesso";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel5.Controls.Add(this.pictureBox1);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.lblAcessoHorario);
            this.panel5.Controls.Add(this.lblAcessoEmail);
            this.panel5.Location = new System.Drawing.Point(21, 318);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(258, 147);
            this.panel5.TabIndex = 13;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel4.Controls.Add(this.pictureBox3);
            this.panel4.Controls.Add(this.lblNUsuario);
            this.panel4.Controls.Add(this.lblUsuario);
            this.panel4.Location = new System.Drawing.Point(307, 10);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(404, 130);
            this.panel4.TabIndex = 10;
            // 
            // lblNUsuario
            // 
            this.lblNUsuario.AutoSize = true;
            this.lblNUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblNUsuario.Location = new System.Drawing.Point(18, 55);
            this.lblNUsuario.Name = "lblNUsuario";
            this.lblNUsuario.Size = new System.Drawing.Size(32, 32);
            this.lblNUsuario.TabIndex = 1;
            this.lblNUsuario.Text = "8";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.ForeColor = System.Drawing.Color.White;
            this.lblUsuario.Location = new System.Drawing.Point(19, 17);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(194, 25);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuarios Cadastrados";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.lblNEmpresas);
            this.panel3.Controls.Add(this.lblEmpresas);
            this.panel3.Location = new System.Drawing.Point(21, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(258, 130);
            this.panel3.TabIndex = 9;
            // 
            // lblNEmpresas
            // 
            this.lblNEmpresas.AutoSize = true;
            this.lblNEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNEmpresas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblNEmpresas.Location = new System.Drawing.Point(25, 69);
            this.lblNEmpresas.Name = "lblNEmpresas";
            this.lblNEmpresas.Size = new System.Drawing.Size(49, 32);
            this.lblNEmpresas.TabIndex = 1;
            this.lblNEmpresas.Text = "58";
            // 
            // lblEmpresas
            // 
            this.lblEmpresas.AutoSize = true;
            this.lblEmpresas.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmpresas.ForeColor = System.Drawing.Color.White;
            this.lblEmpresas.Location = new System.Drawing.Point(10, 17);
            this.lblEmpresas.Name = "lblEmpresas";
            this.lblEmpresas.Size = new System.Drawing.Size(173, 25);
            this.lblEmpresas.TabIndex = 0;
            this.lblEmpresas.Text = "Empresas Parceiras";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(42)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.lblVagas);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(21, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(255, 127);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Vagas Cadastradas";
            // 
            // lblVagas
            // 
            this.lblVagas.AutoSize = true;
            this.lblVagas.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVagas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.lblVagas.Location = new System.Drawing.Point(19, 61);
            this.lblVagas.Name = "lblVagas";
            this.lblVagas.Size = new System.Drawing.Size(49, 32);
            this.lblVagas.TabIndex = 4;
            this.lblVagas.Text = "45";
            this.lblVagas.Click += new System.EventHandler(this.lblVagas_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::ProLinkDesktop.Properties.Resources.Documento;
            this.pictureBox4.Location = new System.Drawing.Point(163, 49);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(80, 59);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 4;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ProLinkDesktop.Properties.Resources.UltimoAcesso;
            this.pictureBox1.Location = new System.Drawing.Point(16, 83);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 47);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::ProLinkDesktop.Properties.Resources.Oportunidades;
            this.pictureBox3.Location = new System.Drawing.Point(283, 45);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 70);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ProLinkDesktop.Properties.Resources.Empresas;
            this.pictureBox2.Location = new System.Drawing.Point(152, 45);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(103, 72);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // formDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(733, 477);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlUser);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formDashboard";
            this.Text = "Oportunidades";
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel5;
        private CircularProgressBar.CircularProgressBar CpbInatividade;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label lblNUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblNEmpresas;
        private System.Windows.Forms.Label lblEmpresas;
        private System.Windows.Forms.Label lblAtividade;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblAcessoHorario;
        private System.Windows.Forms.Label lblAcessoEmail;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblVagas;
        private System.Windows.Forms.Label label1;
    }
}