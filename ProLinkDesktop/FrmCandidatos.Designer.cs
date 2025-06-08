namespace ProLinkDesktop
{
    partial class FrmCandidatos
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
            this.gridCandidatos = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridCandidatos)).BeginInit();
            this.SuspendLayout();

            // gridCandidatos
            this.gridCandidatos.AllowUserToAddRows = false;
            this.gridCandidatos.AllowUserToDeleteRows = false;
            this.gridCandidatos.AllowUserToResizeColumns = false;
            this.gridCandidatos.AllowUserToResizeRows = false;
            this.gridCandidatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCandidatos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(55)))));
            this.gridCandidatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridCandidatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCandidatos.EnableHeadersVisualStyles = false;
            this.gridCandidatos.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.gridCandidatos.Location = new System.Drawing.Point(12, 12);
            this.gridCandidatos.MultiSelect = false;
            this.gridCandidatos.Name = "gridCandidatos";
            this.gridCandidatos.RowHeadersVisible = false;
            this.gridCandidatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCandidatos.Size = new System.Drawing.Size(960, 400);
            this.gridCandidatos.TabIndex = 0;

            // btnFechar
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(74)))), ((int)(((byte)(105)))));
            this.btnFechar.FlatAppearance.BorderSize = 0;
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(852, 418);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(120, 32);
            this.btnFechar.TabIndex = 1;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);

            // FrmCandidatos
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(36)))), ((int)(((byte)(55)))));
            this.ClientSize = new System.Drawing.Size(984, 462);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gridCandidatos);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "FrmCandidatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Candidatos";
            ((System.ComponentModel.ISupportInitialize)(this.gridCandidatos)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView gridCandidatos;
        private System.Windows.Forms.Button btnFechar;
    }
}