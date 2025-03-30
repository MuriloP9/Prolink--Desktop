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
            txtCnpj.KeyDown += ValidarCnpj;
            txtUsuario.KeyDown += ProximoCampo;
            txtRazaoSocial.KeyDown += IrParaSenha;
            txtSenha.KeyDown += ValidarSenha;  // Evento para o campo senha
            btnSair.Click += (s, e) => VoltarParaLogin();
            btnCadastrar.Click += BtnCadastrar_Click; // Evento para o botão Cadastrar
        }

        private void ValidarEmail(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string email = txtEmail.Text.Trim();
                if (EmailValido(email))
                {
                    txtCnpj.Focus();
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
            return System.Text.RegularExpressions.Regex.IsMatch(email, padraoEmail);
        }

        private void ValidarCnpj(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string cnpj = txtCnpj.Text.Trim();

                // Limpeza para remover qualquer caractere não numérico
                cnpj = Regex.Replace(cnpj, @"\D", ""); // Remove tudo que não for número

                if (CnpjValido(cnpj))
                {
                    txtUsuario.Focus();
                }
                else
                {
                    MessageBox.Show("Por favor, insira um CNPJ válido (ex: 12.345.678/0001-90).", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                e.SuppressKeyPress = true;
            }
        }

        private bool CnpjValido(string cnpj)
        {
            // Remove todos os caracteres não numéricos
            cnpj = Regex.Replace(cnpj, "[^0-9]", "");

            if (cnpj.Length != 14) return false;

            int[] multiplicador1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCnpj = cnpj.Substring(0, 12);
            int soma = 0;

            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

            int resto = (soma % 11);
            int digito1 = (resto < 2) ? 0 : 11 - resto;

            tempCnpj += digito1;
            soma = 0;

            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

            resto = (soma % 11);
            int digito2 = (resto < 2) ? 0 : 11 - resto;

            return cnpj.EndsWith(digito1.ToString() + digito2.ToString());
        }

        private void ProximoCampo(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
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
                    btnCadastrar.PerformClick();  // Clica no botão "Cadastrar"
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
            string cnpj = txtCnpj.Text.Trim();
            string nomeFantasia = txtUsuario.Text.Trim();
            string razaoSocial = txtRazaoSocial.Text.Trim();

            using (var conexao = new Conexao())
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha) ||
                    string.IsNullOrWhiteSpace(cnpj) || string.IsNullOrWhiteSpace(razaoSocial))
                {
                    MessageBox.Show("Todos os campos devem ser preenchidos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string query = "INSERT INTO Administrador (email, senha, cnpj, razao_social, nome_fantasia) " +
                               "VALUES (@Email, @Senha, @Cnpj, @RazaoSocial, @nomeFantasia)";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@Email", email),
                    new SqlParameter("@Senha", senha),
                    new SqlParameter("@Cnpj", cnpj),
                    new SqlParameter("@RazaoSocial", razaoSocial),
                    new SqlParameter("@nomeFantasia", nomeFantasia)
                };

                int rowsAffected = conexao.ExecuteNonQuery(query, parameters);

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Cadastro realizado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VoltarParaLogin();  // Volta para a tela de login após o cadastro
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
