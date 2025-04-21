
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ProLinkDesktop
{
    partial class FrmAdicionarVaga
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitulo;
        private TextBox txtTitulo;
        private Label lblLocalizacao;
        private TextBox txtLocalizacao;
        private Label lblTipoEmprego;
        private ComboBox cmbTipoEmprego;
        private Label lblArea;
        private ComboBox cmbArea;
        private Label lblEmpresa;
        private TextBox txtEmpresa;
        private Button btnSalvar;
        private Button btnCancelar;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new Label();
            this.txtTitulo = new TextBox();
            this.lblLocalizacao = new Label();
            this.txtLocalizacao = new TextBox();
            this.lblTipoEmprego = new Label();
            this.cmbTipoEmprego = new ComboBox();
            this.lblArea = new Label();
            this.cmbArea = new ComboBox();
            this.lblEmpresa = new Label();
            this.txtEmpresa = new TextBox();
            this.btnSalvar = new Button();
            this.btnCancelar = new Button();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(80, 15);
            this.lblTitulo.Text = "Título da Vaga:";

            // txtTitulo
            this.txtTitulo.Location = new Point(120, 17);
            this.txtTitulo.Name = "txtTitulo";
            this.txtTitulo.Size = new Size(300, 23);

            // lblLocalizacao
            this.lblLocalizacao.AutoSize = true;
            this.lblLocalizacao.Location = new Point(20, 60);
            this.lblLocalizacao.Name = "lblLocalizacao";
            this.lblLocalizacao.Size = new Size(70, 15);
            this.lblLocalizacao.Text = "Localização:";

            // txtLocalizacao
            this.txtLocalizacao.Location = new Point(120, 57);
            this.txtLocalizacao.Name = "txtLocalizacao";
            this.txtLocalizacao.Size = new Size(300, 23);

            // lblTipoEmprego
            this.lblTipoEmprego.AutoSize = true;
            this.lblTipoEmprego.Location = new Point(20, 100);
            this.lblTipoEmprego.Name = "lblTipoEmprego";
            this.lblTipoEmprego.Size = new Size(90, 15);
            this.lblTipoEmprego.Text = "Tipo de Emprego:";

            // cmbTipoEmprego
            this.cmbTipoEmprego.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTipoEmprego.FormattingEnabled = true;
            this.cmbTipoEmprego.Items.AddRange(new object[] {
            "full-time",
            "part-time",
            "internship"
        });
            this.cmbTipoEmprego.Location = new Point(120, 97);
            this.cmbTipoEmprego.Name = "cmbTipoEmprego";
            this.cmbTipoEmprego.Size = new Size(150, 23);

            // lblArea
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new Point(20, 140);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new Size(90, 15);
            this.lblArea.Text = "Área de Atuação:";

            // cmbArea
            this.cmbArea.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbArea.FormattingEnabled = true;
            this.cmbArea.Location = new Point(120, 137);
            this.cmbArea.Name = "cmbArea";
            this.cmbArea.Size = new Size(300, 23);

            // lblEmpresa
            this.lblEmpresa.AutoSize = true;
            this.lblEmpresa.Location = new Point(20, 180);
            this.lblEmpresa.Name = "lblEmpresa";
            this.lblEmpresa.Size = new Size(50, 15);
            this.lblEmpresa.Text = "Empresa:";

            // txtEmpresa
            this.txtEmpresa.Location = new Point(120, 177);
            this.txtEmpresa.Name = "txtEmpresa";
            this.txtEmpresa.Size = new Size(300, 23);

            // btnSalvar
            this.btnSalvar.BackColor = Color.FromArgb(46, 51, 73);
            this.btnSalvar.FlatStyle = FlatStyle.Flat;
            this.btnSalvar.ForeColor = Color.White;
            this.btnSalvar.Location = new Point(240, 220);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new Size(85, 30);
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new EventHandler(this.btnSalvar_Click);

            // btnCancelar
            this.btnCancelar.BackColor = Color.FromArgb(204, 0, 0);
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.ForeColor = Color.White;
            this.btnCancelar.Location = new Point(335, 220);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(85, 30);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            // FrmAdicionarVaga
            this.ClientSize = new Size(440, 270);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
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
            this.Name = "FrmAdicionarVaga";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}