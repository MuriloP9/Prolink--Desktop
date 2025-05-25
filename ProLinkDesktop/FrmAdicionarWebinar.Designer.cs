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
            this.lblTitulo = new System.Windows.Forms.Label();
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

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(159, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Novo Webinar";

            // lblTema
            this.lblTema.AutoSize = true;
            this.lblTema.Location = new System.Drawing.Point(20, 60);
            this.lblTema.Name = "lblTema";
            this.lblTema.Size = new System.Drawing.Size(37, 13);
            this.lblTema.TabIndex = 1;
            this.lblTema.Text = "Tema:";

            // txtTema
            this.txtTema.Location = new System.Drawing.Point(20, 80);
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(360, 20);
            this.txtTema.TabIndex = 2;

            // lblDataHora
            this.lblDataHora.AutoSize = true;
            this.lblDataHora.Location = new System.Drawing.Point(20, 110);
            this.lblDataHora.Name = "lblDataHora";
            this.lblDataHora.Size = new System.Drawing.Size(79, 13);
            this.lblDataHora.TabIndex = 3;
            this.lblDataHora.Text = "Data e Hora:";

            // dtpDataHora
            this.dtpDataHora.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDataHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataHora.Location = new System.Drawing.Point(20, 130);
            this.dtpDataHora.Name = "dtpDataHora";
            this.dtpDataHora.Size = new System.Drawing.Size(360, 20);
            this.dtpDataHora.TabIndex = 4;

            // lblPalestrante
            this.lblPalestrante.AutoSize = true;
            this.lblPalestrante.Location = new System.Drawing.Point(20, 160);
            this.lblPalestrante.Name = "lblPalestrante";
            this.lblPalestrante.Size = new System.Drawing.Size(64, 13);
            this.lblPalestrante.TabIndex = 5;
            this.lblPalestrante.Text = "Palestrante:";

            // txtPalestrante
            this.txtPalestrante.Location = new System.Drawing.Point(20, 180);
            this.txtPalestrante.Name = "txtPalestrante";
            this.txtPalestrante.Size = new System.Drawing.Size(360, 20);
            this.txtPalestrante.TabIndex = 6;

            // lblLink
            this.lblLink.AutoSize = true;
            this.lblLink.Location = new System.Drawing.Point(20, 210);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(30, 13);
            this.lblLink.TabIndex = 7;
            this.lblLink.Text = "Link:";

            // txtLink
            this.txtLink.Location = new System.Drawing.Point(20, 230);
            this.txtLink.Name = "txtLink";
            this.txtLink.Size = new System.Drawing.Size(360, 20);
            this.txtLink.TabIndex = 8;

            // lblDescricao
            this.lblDescricao.AutoSize = true;
            this.lblDescricao.Location = new System.Drawing.Point(20, 260);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(58, 13);
            this.lblDescricao.TabIndex = 9;
            this.lblDescricao.Text = "Descrição:";

            // txtDescricao
            this.txtDescricao.Location = new System.Drawing.Point(20, 280);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(360, 100);
            this.txtDescricao.TabIndex = 10;

            // btnSalvar
            this.btnSalvar.Location = new System.Drawing.Point(220, 400);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 30);
            this.btnSalvar.TabIndex = 11;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(305, 400);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 30);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // FrmAdicionarWebinar
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 450);
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
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdicionarWebinar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Adicionar Webinar";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
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