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

namespace ProLinkDesktop
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
            txtUsuario.Select();

            txtUsuario.Multiline = false;
            txtSenha.Multiline = false;
            btnEntrar.Click += new EventHandler(btnEntrar_Click);
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

            bool isValid = false;

            // Conexão com o banco
            using (var conexao = new Conexao())
            {
                string query = "SELECT COUNT(1) FROM Administrador WHERE email = @Email AND senha = @Senha";
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Senha", senha)
                };

                DataTable result = conexao.ExecuteQuery(query, parameters);

                if (result.Rows.Count > 0 && Convert.ToInt32(result.Rows[0][0]) > 0)
                {
                    isValid = true;
                }
            }

            if (isValid)
            {
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool ValidarEmail(string email)
        {
            string padraoEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return new System.Text.RegularExpressions.Regex(padraoEmail).IsMatch(email);
        }

        private void lblCadastro_Click_1(object sender, EventArgs e)
        {
            Cadastro cadastroForm = new Cadastro();
            cadastroForm.Show();
            this.Hide();
        }
    }
}

