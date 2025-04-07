using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Drawing.Drawing2D;

namespace ProLinkDesktop
{
    public partial class FormLogin : Form
    {
        ClasseConexao con;
        private bool isMouseOverButton = false; // Variável para rastrear o estado do mouse no botão

        public FormLogin()
        {
            InitializeComponent();
            txtUsuario.Select();

            txtUsuario.Multiline = false;
            txtSenha.Multiline = false;
            btnEntrar.Click += new EventHandler(btnEntrar_Click);
            btnEntrar.Paint += new PaintEventHandler(btnEntrar_Paint);
            btnEntrar.MouseEnter += new EventHandler(btnEntrar_MouseEnter);
            btnEntrar.MouseLeave += new EventHandler(btnEntrar_MouseLeave);
            btnSair.Click += new EventHandler(btnSair_Click);
            txtSenha.KeyDown += new KeyEventHandler(txtSenha_KeyDown);
            txtUsuario.KeyDown += new KeyEventHandler(txtUsuario_KeyDown);
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValidarEmail(txtUsuario.Text))
                {
                    txtSenha.Focus();
                }
                else
                {
                    MessageBox.Show("Por favor, insira um e-mail válido.");
                    txtUsuario.Select();
                }
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar.PerformClick();
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string email = txtUsuario.Text.Trim();
            string senha = txtSenha.Text.Trim();

            if (email == "" || senha == "")
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            con = new ClasseConexao();
            string sql = "SELECT * FROM Funcionario WHERE email = @Email AND senha = @Senha";

            using (SqlCommand comando = new SqlCommand(sql))
            {
                comando.Parameters.AddWithValue("@Email", email);
                comando.Parameters.AddWithValue("@Senha", senha);

                SqlConnection conexao = con.conectar();

                if (conexao == null)
                {
                    MessageBox.Show("Não foi possível conectar ao banco de dados.");
                    return;
                }

                comando.Connection = conexao;
                SqlDataAdapter adaptador = new SqlDataAdapter(comando);
                DataTable dt = new DataTable();

                try
                {
                    adaptador.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        string nomeUsuario = dt.Rows[0]["nome_completo"].ToString();

                        MessageBox.Show("Bem-vindo(a), " + nomeUsuario + "!", "Login realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuário ou senha incorretos.");
                        txtSenha.Clear();
                        txtSenha.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao acessar o banco de dados: " + ex.Message);
                }
                finally
                {
                    con.desconectar();
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool ValidarEmail(string email)
        {
            string padraoEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return new Regex(padraoEmail).IsMatch(email);
        }

        private void lblCadastro_Click_1(object sender, EventArgs e)
        {
            Cadastro cadastroForm = new Cadastro();
            cadastroForm.Show();
            this.Hide();
        }

        private void btnEntrar_Paint(object sender, PaintEventArgs e)
        {
            // Definir gradiente de azul
            Rectangle botaoRetangulo = btnEntrar.ClientRectangle;
            Color corInicio = isMouseOverButton ? Color.MediumSlateBlue : Color.DarkBlue;
            Color corFim = isMouseOverButton ? Color.CornflowerBlue : Color.SteelBlue;

            using (LinearGradientBrush brushGradiente = new LinearGradientBrush(botaoRetangulo, corInicio, corFim, 45f))
            {
                e.Graphics.FillRectangle(brushGradiente, botaoRetangulo);
            }

            // Definir bordas arredondadas
            using (GraphicsPath caminhoArredondado = new GraphicsPath())
            {
                int raio = 30;
                caminhoArredondado.AddArc(botaoRetangulo.X, botaoRetangulo.Y, raio, raio, 180, 90);
                caminhoArredondado.AddArc(botaoRetangulo.Right - raio, botaoRetangulo.Y, raio, raio, 270, 90);
                caminhoArredondado.AddArc(botaoRetangulo.Right - raio, botaoRetangulo.Bottom - raio, raio, raio, 0, 90);
                caminhoArredondado.AddArc(botaoRetangulo.X, botaoRetangulo.Bottom - raio, raio, raio, 90, 90);
                caminhoArredondado.CloseFigure();

                btnEntrar.Region = new Region(caminhoArredondado);
            }

            // Centralizar texto "ACESSAR"
            StringFormat formatacaoTexto = new StringFormat
            {
                Alignment = StringAlignment.Center, // Centralizar horizontalmente
                LineAlignment = StringAlignment.Center // Centralizar verticalmente
            };

            e.Graphics.DrawString("ACESSAR", new Font(btnEntrar.Font.FontFamily, 10, FontStyle.Bold), Brushes.White, botaoRetangulo, formatacaoTexto);
        }

        private void btnEntrar_MouseEnter(object sender, EventArgs e)
        {
            isMouseOverButton = true;
            btnEntrar.Invalidate(); 
        }

        private void btnEntrar_MouseLeave(object sender, EventArgs e)
        {
            isMouseOverButton = false;
            btnEntrar.Invalidate();
        }
    }
}