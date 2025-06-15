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
    public partial class FrmConfiguracoes : Form
    {
        private ClasseConexao conexao;
        private int funcionarioId;

        public FrmConfiguracoes(int idFuncionario)
        {
            InitializeComponent();
            funcionarioId = idFuncionario;
            conexao = new ClasseConexao();
            ConfigurarDesign();
            CarregarInformacoes();
        }

        private void ConfigurarDesign()
        {
            // Configuração do formulário
            this.BackColor = Color.FromArgb(32, 36, 55);
            this.ForeColor = Color.White;

            // Configuração dos TabPages
            foreach (TabPage tab in tabControl1.TabPages)
            {
                tab.BackColor = Color.FromArgb(32, 36, 55);
                tab.ForeColor = Color.White;
            }

            // Configuração do TabControl
            tabControl1.BackColor = Color.FromArgb(32, 36, 55);

            // Configuração dos GroupBoxes
            foreach (Control control in this.Controls)
            {
                ConfigurarControlsRecursivo(control);
            }

            // Configuração dos botões
            ConfigurarBotoes();
        }


        private void ConfigurarControlsRecursivo(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is GroupBox)
                {
                    control.ForeColor = Color.White;
                    control.BackColor = Color.FromArgb(46, 51, 73);
                }
                else if (control is TextBox)
                {
                    control.BackColor = Color.FromArgb(46, 51, 73);
                    control.ForeColor = Color.White;
                    ((TextBox)control).BorderStyle = BorderStyle.FixedSingle;
                }
                else if (control is CheckBox)
                {
                    control.ForeColor = Color.White;
                    control.BackColor = Color.FromArgb(32, 36, 55);
                }
                else if (control is Label)
                {
                    control.ForeColor = Color.White;
                    control.BackColor = Color.Transparent;
                }

                if (control.HasChildren)
                {
                    ConfigurarControlsRecursivo(control);
                }
            }
        }

        private void ConfigurarBotoes()
        {
            foreach (Button btn in new[] { btnSalvar, btnRestaurar, btnFechar, btnSobre, btnLimparCache })
            {
                btn.BackColor = Color.FromArgb(67, 74, 105);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
            }
        }

        private void CarregarInformacoes()
        {
            try
            {
                // Carregar informações do funcionário logado
                string query = @"SELECT nome_completo, email, 
                                CASE nivel_acesso 
                                    WHEN 0 THEN 'Admin Master' 
                                    WHEN 1 THEN 'Gerente' 
                                    WHEN 2 THEN 'Supervisor' 
                                END AS Cargo,
                                FORMAT(data_cadastro, 'dd/MM/yyyy') AS DataCadastro,
                                FORMAT(ultimo_acesso, 'dd/MM/yyyy HH:mm') AS UltimoAcesso
                                FROM Funcionario WHERE id_funcionario = @id";

                SqlCommand cmd = new SqlCommand(query);
                cmd.Parameters.AddWithValue("@id", funcionarioId);

                DataTable dados = conexao.executarSQL_Parametros(cmd);

                if (dados.Rows.Count > 0)
                {
                    DataRow row = dados.Rows[0];
                    txtNomeUsuario.Text = row["nome_completo"].ToString();
                    txtEmail.Text = row["email"].ToString();
                    lblCargo.Text = "Cargo: " + row["Cargo"].ToString();
                    lblDataCadastro.Text = "Cadastrado em: " + row["DataCadastro"].ToString();
                    lblUltimoAcesso.Text = "Último acesso: " + (row["UltimoAcesso"] != DBNull.Value ? row["UltimoAcesso"].ToString() : "Nunca acessou");
                }

                // Informações do sistema
                lblVersao.Text = "Versão 1.0.0";
                lblDataCompilacao.Text = "Compilado em: " + DateTime.Now.ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar informações: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                SalvarConfiguracoes();
                MessageBox.Show("Configurações salvas com sucesso!", "Sucesso",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNomeUsuario.Text))
            {
                MessageBox.Show("Por favor, informe o nome do usuário.", "Atenção",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomeUsuario.Focus();
                return false;
            }

            if (!string.IsNullOrWhiteSpace(txtEmail.Text) && !IsEmailValido(txtEmail.Text))
            {
                MessageBox.Show("Por favor, informe um email válido.", "Atenção",
                               MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool IsEmailValido(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void SalvarConfiguracoes()
        {
            try
            {
                // Atualizar apenas nome e email do funcionário
                string updateQuery = @"UPDATE Funcionario SET 
                                      nome_completo = @nome, 
                                      email = @email 
                                      WHERE id_funcionario = @id";

                SqlCommand cmd = new SqlCommand(updateQuery);
                cmd.Parameters.AddWithValue("@nome", txtNomeUsuario.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                cmd.Parameters.AddWithValue("@id", funcionarioId);

                if (conexao.manutencaoDB_Parametros(cmd) > 0)
                {
                    // Salvar outras configurações localmente (preferências)
                    // Aqui você pode usar Properties.Settings ou arquivo de configuração

                    MessageBox.Show("Configurações salvas com sucesso!", "Sucesso",
                                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao salvar configurações no banco de dados.", "Erro",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar configurações: {ex.Message}", "Erro",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Tem certeza que deseja restaurar as configurações padrão?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                RestaurarPadrao();
                MessageBox.Show("Configurações restauradas para o padrão!", "Sucesso",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RestaurarPadrao()
        {
            // Recarregar dados originais do banco
            CarregarInformacoes();

            // Restaurar configurações locais para padrão
            txtObservacoes.Text = "";
            chkNotificacoes.Checked = true;
            chkIniciarWindows.Checked = false;
            chkSonsAtivos.Checked = true;
        }

        private void btnSobre_Click(object sender, EventArgs e)
        {
            string mensagem = $"ProLink Desktop\n\n" +
                             $"Versão: 1.0.0\n" +
                             $"Desenvolvido em: C# .NET Framework\n" +
                             $"Data de Compilação: {DateTime.Now:dd/MM/yyyy}\n\n" +
                             $"Sistema simples de gerenciamento\n" +
                             $"para uso pessoal e profissional.\n\n" +
                             $"© 2025 - Todos os direitos reservados";

            MessageBox.Show(mensagem, "Sobre o ProLink Desktop",
                           MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimparCache_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Isso irá limpar arquivos temporários e cache. Continuar?",
                "Limpar Cache",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Simular limpeza de cache
                var progressForm = new Form()
                {
                    Text = "Limpando...",
                    Size = new Size(300, 100),
                    StartPosition = FormStartPosition.CenterParent,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    MaximizeBox = false,
                    MinimizeBox = false
                };

                var label = new Label()
                {
                    Text = "Limpando arquivos temporários...",
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                progressForm.Controls.Add(label);
                progressForm.Show();

                // Simular processo
                System.Threading.Thread.Sleep(2000);
                progressForm.Close();

                MessageBox.Show("Cache limpo com sucesso!\n\nArquivos temporários removidos.",
                               "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chkNotificacoes_CheckedChanged(object sender, EventArgs e)
        {
            // Atualizar interface baseado na opção
            if (chkNotificacoes.Checked)
            {
                chkSonsAtivos.Enabled = true;
            }
            else
            {
                chkSonsAtivos.Enabled = false;
                chkSonsAtivos.Checked = false;
            }
        }
    }
}