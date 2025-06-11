namespace ProLinkDesktop
{
    partial class FrmAnalise
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
            this.picFotoPerfil = new System.Windows.Forms.PictureBox();
            this.btnAprovar = new System.Windows.Forms.Button();
            this.btnNegar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picFotoPerfil)).BeginInit();
            this.SuspendLayout();
            // 
            // picFotoPerfil
            // 
            this.picFotoPerfil.Location = new System.Drawing.Point(100, 20);
            this.picFotoPerfil.Margin = new System.Windows.Forms.Padding(2);
            this.picFotoPerfil.Name = "picFotoPerfil";
            this.picFotoPerfil.Size = new System.Drawing.Size(400, 400);
            this.picFotoPerfil.TabIndex = 0;
            this.picFotoPerfil.TabStop = false;
            this.picFotoPerfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            // 
            // btnAprovar
            // 
            this.btnAprovar.Location = new System.Drawing.Point(120, 460);
            this.btnAprovar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAprovar.Name = "btnAprovar";
            this.btnAprovar.Size = new System.Drawing.Size(150, 50);
            this.btnAprovar.TabIndex = 1;
            this.btnAprovar.Text = "Aprovar";
            this.btnAprovar.UseVisualStyleBackColor = true;
            this.btnAprovar.Click += new System.EventHandler(this.BtnAprovar_Click);
            // 
            // btnNegar
            // 
            this.btnNegar.Location = new System.Drawing.Point(380, 460);
            this.btnNegar.Margin = new System.Windows.Forms.Padding(2);
            this.btnNegar.Name = "btnNegar";
            this.btnNegar.Size = new System.Drawing.Size(150, 50);
            this.btnNegar.TabIndex = 2;
            this.btnNegar.Text = "Negar";
            this.btnNegar.UseVisualStyleBackColor = true;
            this.btnNegar.Click += new System.EventHandler(this.BtnNegar_Click);
            // 
            // FrmAnalise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 550);
            this.Controls.Add(this.btnNegar);
            this.Controls.Add(this.btnAprovar);
            this.Controls.Add(this.picFotoPerfil);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmAnalise";
            this.Text = "Análise de Foto de Perfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.picFotoPerfil)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.PictureBox picFotoPerfil;
        private System.Windows.Forms.Button btnAprovar;
        private System.Windows.Forms.Button btnNegar;
    }
}