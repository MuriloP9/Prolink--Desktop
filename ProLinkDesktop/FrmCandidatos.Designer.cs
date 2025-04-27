namespace ProLinkDesktop
{
    partial class FrmCandidatos
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView gridCandidatos;
        private System.Windows.Forms.Button btnFechar;

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
            this.gridCandidatos = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridCandidatos)).BeginInit();
            this.SuspendLayout();

            // gridCandidatos
            this.gridCandidatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCandidatos.BackgroundColor = System.Drawing.Color.White;
            this.gridCandidatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.gridCandidatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCandidatos.Location = new System.Drawing.Point(12, 12);
            this.gridCandidatos.Name = "gridCandidatos";
            this.gridCandidatos.Size = new System.Drawing.Size(760, 400);
            this.gridCandidatos.TabIndex = 0;

            // btnFechar
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
            this.btnFechar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFechar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(672, 418);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(100, 30);
            this.btnFechar.TabIndex = 1;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);

            // FrmCandidatos
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.gridCandidatos);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FrmCandidatos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Candidatos da Vaga";
            ((System.ComponentModel.ISupportInitialize)(this.gridCandidatos)).EndInit();
            this.ResumeLayout(false);
        }
    }
}