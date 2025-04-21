using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ProLinkDesktop
{
    public partial class FrmCadastrarFuncionario : Form
    {
        private ClasseConexao conexao;

        public FrmCadastrarFuncionario()
        {
            InitializeComponent();
            conexao = new ClasseConexao();
            ConfigurarDesign();
        }

        private void ConfigurarDesign()
        {
            // Configuração do formulário
            this.BackColor = Color.FromArgb(32, 36, 55);
            this.ForeColor = Color.White;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Configuração dos controles
            foreach (TextBox txt in new[] { txtNome, txtEmail, txtSenha, txtConfirmarSenha })
            {
                txt.BackColor = Color.FromArgb(46, 51, 73);
                txt.ForeColor = Color.White;
                txt.BorderStyle = BorderStyle.FixedSingle;
            }

            cmbNivelAcesso.BackColor = Color.FromArgb(46, 51, 73);
            cmbNivelAcesso.ForeColor = Color.White;
            cmbNivelAcesso.FlatStyle = FlatStyle.Flat;

            // Configuração dos botões
            btnCadastrar.BackColor = Color.FromArgb(67, 74, 105);
            btnCancelar.BackColor = Color.FromArgb(100, 30, 30);
            foreach (Button btn in new[] { btnCadastrar, btnCancelar })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
            }

            // Preencher combobox de nível de acesso
            cmbNivelAcesso.Items.Add(new { Text = "Supervisor", Value = 2 });
            cmbNivelAcesso.Items.Add(new { Text = "Gerente", Value = 1 });
            cmbNivelAcesso.DisplayMember = "Text";
            cmbNivelAcesso.ValueMember = "Value";
            cmbNivelAcesso.SelectedIndex = 0;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    string query = @"INSERT INTO Funcionario 
                                   (nome_completo, email, senha, nivel_acesso, criado_por, data_cadastro, ativo)
                                   VALUES (@nome, @email, @senha, @nivel, @criadoPor, GETDATE(), 1)";

                    SqlCommand cmd = new SqlCommand(query);
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
                    cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@senha", txtSenha.Text); // Em produção, usar hash!
                    cmd.Parameters.AddWithValue("@nivel", ((dynamic)cmbNivelAcesso.SelectedItem).Value);
                    cmd.Parameters.AddWithValue("@criadoPor", 1); // ID do admin master que está cadastrando

                    if (conexao.manutencaoDB_Parametros(cmd) > 0)
                    {
                        MessageBox.Show("Funcionário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao cadastrar funcionário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Informe o nome completo do funcionário", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                MessageBox.Show("Informe um e-mail válido", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSenha.Text) || txtSenha.Text.Length < 6)
            {
                MessageBox.Show("A senha deve ter pelo menos 6 caracteres", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSenha.Focus();
                return false;
            }

            if (txtSenha.Text != txtConfirmarSenha.Text)
            {
                MessageBox.Show("As senhas não coincidem", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarSenha.Focus();
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
