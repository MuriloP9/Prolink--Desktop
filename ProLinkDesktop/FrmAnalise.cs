using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace ProLinkDesktop
{
    public partial class FrmAnalise : Form
    {
        private int userId;
        private ClasseConexao conexao;

        public FrmAnalise(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            conexao = new ClasseConexao();
            ConfigurarDesign();
            CarregarFotoUsuario();
        }

        private void CarregarFotoUsuario()
        {
            try
            {
                byte[] fotoData = conexao.BuscarFotoUsuario(userId);

                if (fotoData != null && fotoData.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(fotoData))
                    {
                        picFotoPerfil.Image = Image.FromStream(ms);
                    }
                }
                else
                {
                    // Se não houver foto, usar ícone padrão
                    picFotoPerfil.Image = SystemIcons.WinLogo.ToBitmap();
                    picFotoPerfil.SizeMode = PictureBoxSizeMode.CenterImage;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar foto: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                picFotoPerfil.Image = SystemIcons.WinLogo.ToBitmap();
            }
        }

        private void ConfigurarDesign()
        {
            // Configurações do formulário - AUMENTEI MAIS AINDA PRA TER CERTEZA
            this.BackColor = Color.FromArgb(32, 36, 55);
            this.ForeColor = Color.White;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Text = "Análise de Foto de Perfil";
            this.Size = new Size(700, 600); // MAIOR AINDA

            // PictureBox para exibir a foto
            picFotoPerfil.SizeMode = PictureBoxSizeMode.Zoom;
            picFotoPerfil.BackColor = Color.FromArgb(46, 51, 73);
            picFotoPerfil.BorderStyle = BorderStyle.FixedSingle;
            picFotoPerfil.Size = new Size(400, 400);
            picFotoPerfil.Location = new Point((this.ClientSize.Width - picFotoPerfil.Width) / 2, 20);

            // Botões - POSICIONAMENTO MAIS SEGURO
            btnAprovar.BackColor = Color.FromArgb(76, 175, 80); // Verde
            btnNegar.BackColor = Color.FromArgb(244, 67, 54); // Vermelho

            foreach (Button btn in new[] { btnAprovar, btnNegar })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
                btn.Size = new Size(150, 50); // BOTÕES MAIORES
            }

            btnAprovar.Text = "Aprovar";
            btnNegar.Text = "Negar";

            // POSICIONAMENTO COM MAIS MARGEM DE SEGURANÇA
            int espacoEntreBotoes = 80;
            int yBotoes = picFotoPerfil.Bottom + 30;
            int larguraTotal = btnAprovar.Width + espacoEntreBotoes + btnNegar.Width;
            int xInicial = (this.ClientSize.Width - larguraTotal) / 2;

            btnAprovar.Location = new Point(xInicial, yBotoes);
            btnNegar.Location = new Point(xInicial + btnAprovar.Width + espacoEntreBotoes, yBotoes);
        }

        private void BtnAprovar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnNegar_Click(object sender, EventArgs e)
        {
            try
            {
                string updateQuery = "UPDATE Usuario SET ativo = 0 WHERE id_usuario = @id";
                SqlCommand updateCmd = new SqlCommand(updateQuery);
                updateCmd.Parameters.AddWithValue("@id", userId);

                if (conexao.manutencaoDB_Parametros(updateCmd) > 0)
                {
                    MessageBox.Show("Usuário inativado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inativar usuário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}