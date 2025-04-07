using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace ProLinkDesktop
{
    public partial class Cadastro : Form
    {
        public Cadastro()
        {
            InitializeComponent();
            ConfigurarEventos();
        }

        private void ConfigurarEventos()
        {
            txtEmail.KeyDown += ValidarEmail;
            txtNomeCompleto.KeyDown += IrParaSenha;
            txtSenha.KeyDown += ValidarSenha;
            btnSair.Click += (s, e) => VoltarParaLogin();
            btnCadastrar.Click += BtnCadastrar_Click;
        }

        private void ValidarEmail(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string email = txtEmail.Text.Trim();
                if (EmailValido(email))
                {
                    txtNomeCompleto.Focus();
                }
                else
                {
                    MessageBox.Show("Por favor, insira um e-mail válido.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.SuppressKeyPress = true;
            }
        }

        private bool EmailValido(string email)
        {
            string padraoEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, padraoEmail);
        }

        private void IrParaSenha(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSenha.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void ValidarSenha(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtSenha.Text.Length >= 6)
                {
                    btnCadastrar.PerformClick();
                }
                else
                {
                    MessageBox.Show("A senha deve ter no mínimo 6 caracteres.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.SuppressKeyPress = true;
            }
        }

        private void VoltarParaLogin()
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();
            this.Close();
        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string senha = txtSenha.Text.Trim();
            string nomeCompleto = txtNomeCompleto.Text.Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(nomeCompleto))
            {
                MessageBox.Show("Todos os campos devem ser preenchidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ClasseConexao conexao = new ClasseConexao();
            SqlCommand comando = new SqlCommand();

            comando.CommandText = "INSERT INTO Funcionario (email, senha, nome_completo) VALUES (@Email, @Senha, @NomeCompleto)";
            comando.Parameters.AddWithValue("@Email", email);
            comando.Parameters.AddWithValue("@Senha", senha);
            comando.Parameters.AddWithValue("@NomeCompleto", nomeCompleto);

            try
            {
                int resultado = conexao.manutencaoDB_Parametros(comando);

                if (resultado > 0)
                {
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VoltarParaLogin();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar. Nenhuma linha foi afetada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cadastrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}