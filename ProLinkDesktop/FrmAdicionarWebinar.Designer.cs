namespace ProLinkDesktop
{
    partial class FrmAdicionarWebinar
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
            this.lblTema = new System.Windows.Forms.Label();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.lblDataHora = new System.Windows.Forms.Label();
            this.dtpDataHora = new System.Windows.Forms.DateTimePicker();
            this.lblPalestrante = new System.Windows.Forms.Label();
            this.txtPalestrante = new System.Windows.Forms.TextBox();
            this.lblLink = new System.Windows.Forms.Label();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTema
            // 
            this.lblTema.AutoSize = true;
            this.lblTema.ForeColor = System.Drawing.Color.White;
            this.lblTema.Location = new System.Drawing.Point(20, 20);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(37, 13);
            this.lblTema.TabIndex = 0;
            this.lblTema.Text = "Tema:";
            // 
            // txtTema
            // 
            this.txtTema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtTema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTema.ForeColor = System.Drawing.Color.White;
            this.txtTema.Location = new System.Drawing.Point(20, 40);
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(360, 20);
            this.txtTema.TabIndex = 1;
            this.txtTema.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTema_KeyDown);
            // 
            // lblDataHora
            // 
            this.lblDataHora.AutoSize = true;
            this.lblDataHora.ForeColor = System.Drawing.Color.White;
            this.lblDataHora.Location = new System.Drawing.Point(20, 70);
            this.lblDataHora.Name = "lblDataHora";
            this.lblDataHora.Size = new System.Drawing.Size(79, 13);
            this.lblDataHora.TabIndex = 2;
            this.lblDataHora.Text = "Data e Hora:";
            // 
            // dtpDataHora
            // 
            this.dtpDataHora.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dtpDataHora.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.dtpDataHora.CalendarTitleForeColor = System.Drawing.Color.White;
            this.dtpDataHora.CalendarTrailingForeColor = System.Drawing.Color.Gray;
            this.dtpDataHora.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDataHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataHora.Location = new System.Drawing.Point(20, 90);
            this.dtpDataHora.Name = "dtpDataHora";
            this.dtpDataHora.Size = new System.Drawing.Size(360, 20);
            this.dtpDataHora.TabIndex = 2;
            this.dtpDataHora.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtpDataHora_KeyDown);
            // 
            // lblPalestrante
            // 
            this.lblPalestrante.AutoSize = true;
            this.lblPalestrante.ForeColor = System.Drawing.Color.White;
            this.lblPalestrante.Location = new System.Drawing.Point(20, 120);
            this.lblPalestrante.Name = "lblPalestrante";
            this.lblPalestrante.Size = new System.Drawing.Size(64, 13);
            this.lblPalestrante.TabIndex = 4;
            this.lblPalestrante.Text = "Palestrante:";
            // 
            // txtPalestrante
            // 
            this.txtPalestrante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtPalestrante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPalestrante.ForeColor = System.Drawing.Color.White;
            this.txtPalestrante.Location = new System.Drawing.Point(20, 140);
            this.txtPalestrante.Name = "txtPalestrante";
            this.txtPalestrante.Size = new System.Drawing.Size(360, 20);
            this.txtPalestrante.TabIndex = 3;
            this.txtPalestrante.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPalestrante_KeyDown);
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.ForeColor = System.Drawing.Color.White;
            this.lblLink.Location = new System.Drawing.Point(20, 170);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(30, 13);
            this.lblLink.TabIndex = 6;
            this.lblLink.Text = "Link:";
            // 
            // txtLink
            // 
            this.txtLink.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtLink.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLink.ForeColor = System.Drawing.Color.White;
            this.txtLink.Location = new System.Drawing.Point(20, 190);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(360, 20);
            this.txtLink.TabIndex = 4;
            this.txtLink.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLink_KeyDown);
            // 
            // lblDescricao
            // 
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.ForeColor = System.Drawing.Color.White;
            this.lblDescricao.Location = new System.Drawing.Point(20, 220);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 8;
            this.lblDescricao.Text = "Descrição:";
            // 
            // txtDescricao
            // 
            this.txtDescricao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.ForeColor = System.Drawing.Color.White;
            this.txtDescricao.Location = new System.Drawing.Point(20, 240);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricao.Size = new System.Drawing.Size(360, 100);
            this.txtDescricao.TabIndex = 5;
            this.txtDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescricao_KeyDown);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.btnSalvar.FlatAppearance.BorderSize = 0;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.ForeColor = System.Drawing.Color.White;
            this.btnSalvar.Location = new System.Drawing.Point(220, 360);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 30);
            this.btnSalvar.TabIndex = 6;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(305, 360);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FrmAdicionarWebinar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(400, 400);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtLink);
            this.Controls.Add(this.lblLink);
            this.Controls.Add(this.txtPalestrante);
            this.Controls.Add(this.lblPalestrante);
            this.Controls.Add(this.dtpDataHora);
            this.Controls.Add(this.lblDataHora);
            this.Controls.Add(this.txtTema);
            this.Controls.Add(this.lblTema);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdicionarWebinar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Webinar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTema;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.Label lblDataHora;
        private System.Windows.Forms.DateTimePicker dtpDataHora;
        private System.Windows.Forms.Label lblPalestrante;
        private System.Windows.Forms.TextBox txtPalestrante;
        private System.Windows.Forms.Label lblLink;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
    }
}