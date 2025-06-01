namespace ProLinkDesktop
{
    partial class FrmWebinar
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
            this.dgvWebinars = new System.Windows.Forms.DataGridView();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnInativar = new System.Windows.Forms.Button();
            this.txtBusca = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWebinars)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvWebinars
            // 
            this.dgvWebinars.AllowUserToAddRows = false;
            this.dgvWebinars.AllowUserToDeleteRows = false;
            this.dgvWebinars.AllowUserToResizeColumns = false;
            this.dgvWebinars.AllowUserToResizeRows = false;
            this.dgvWebinars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWebinars.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWebinars.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(55)))));
            this.dgvWebinars.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvWebinars.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWebinars.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.dgvWebinars.Location = new System.Drawing.Point(20, 50);
            this.dgvWebinars.MultiSelect = false;
            this.dgvWebinars.Name = "dgvWebinars";
            this.dgvWebinars.ReadOnly = true;
            this.dgvWebinars.RowHeadersVisible = false;
            this.dgvWebinars.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWebinars.Size = new System.Drawing.Size(760, 300);
            this.dgvWebinars.TabIndex = 1;
            this.dgvWebinars.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvWebinars_CellClick);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdicionar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.btnAdicionar.FlatAppearance.BorderSize = 0;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(520, 370);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(100, 30);
            this.btnAdicionar.TabIndex = 2;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.btnEditar.FlatAppearance.BorderSize = 0;
            this.btnEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditar.ForeColor = System.Drawing.Color.White;
            this.btnEditar.Location = new System.Drawing.Point(620, 370);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 30);
            this.btnEditar.TabIndex = 3;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnInativar
            // 
            this.btnInativar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInativar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.btnInativar.FlatAppearance.BorderSize = 0;
            this.btnInativar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInativar.ForeColor = System.Drawing.Color.White;
            this.btnInativar.Location = new System.Drawing.Point(720, 370);
            this.btnInativar.Name = "btnInativar";
            this.btnInativar.Size = new System.Drawing.Size(100, 30);
            this.btnInativar.TabIndex = 4;
            this.btnInativar.Text = "Inativar";
            this.btnInativar.UseVisualStyleBackColor = false;
            this.btnInativar.Click += new System.EventHandler(this.btnInativar_Click);
            // 
            // txtBusca
            // 
            this.txtBusca.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBusca.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.txtBusca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBusca.ForeColor = System.Drawing.Color.White;
            this.txtBusca.Location = new System.Drawing.Point(20, 20);
            this.txtBusca.Name = "txtBusca";
            this.txtBusca.Size = new System.Drawing.Size(760, 20);
            this.txtBusca.TabIndex = 0;
            this.txtBusca.TextChanged += new System.EventHandler(this.txtBusca_TextChanged);
            // 
            // FrmWebinar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(800, 420);
            this.Controls.Add(this.txtBusca);
            this.Controls.Add(this.btnInativar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.dgvWebinars);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "FrmWebinar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Webinars";
            ((System.ComponentModel.ISupportInitialize)(this.dgvWebinars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvWebinars;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnInativar;
        private System.Windows.Forms.TextBox txtBusca;
    }
}