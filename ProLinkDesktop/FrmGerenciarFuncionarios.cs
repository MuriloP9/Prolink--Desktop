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
    public partial class FrmGerenciarFuncionarios : Form
    {
        private ClasseConexao conexao;
        private DataTable funcionarios;
        private int funcionarioSelecionadoId = -1;
        private int nivelAcessoUsuarioAtual;

        public FrmGerenciarFuncionarios(int nivelAcesso)
        {
            InitializeComponent();
            nivelAcessoUsuarioAtual = nivelAcesso;
            conexao = new ClasseConexao();
            ConfigurarDesign();
            CarregarFuncionarios();
            LimparDetalhes();
            btnNovoFuncionario.Visible = (nivelAcessoUsuarioAtual == 0); // Mostrar apenas para admin master
        }

        private void ConfigurarDesign()
        {
            // Configuração do formulário
            this.BackColor = Color.FromArgb(32, 36, 55);
            this.ForeColor = Color.White;

            // Configuração do DataGridView (somente leitura)
            dgvFuncionarios.ReadOnly = true;
            dgvFuncionarios.AllowUserToAddRows = false;
            dgvFuncionarios.AllowUserToDeleteRows = false;
            dgvFuncionarios.AllowUserToResizeRows = false;
            dgvFuncionarios.RowHeadersVisible = false;
            dgvFuncionarios.MultiSelect = false;
            dgvFuncionarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFuncionarios.BackgroundColor = Color.FromArgb(32, 36, 55);
            dgvFuncionarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            dgvFuncionarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvFuncionarios.DefaultCellStyle.BackColor = Color.FromArgb(32, 36, 55);
            dgvFuncionarios.DefaultCellStyle.ForeColor = Color.White;
            dgvFuncionarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(67, 74, 105);
            dgvFuncionarios.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvFuncionarios.EnableHeadersVisualStyles = false;

            // Configuração dos botões
            btnAtivarInativar.BackColor = Color.FromArgb(67, 74, 105);
            btnAtualizar.BackColor = Color.FromArgb(67, 74, 105);
            btnNovoFuncionario.BackColor = Color.FromArgb(0, 123, 255); // Azul diferenciado
            foreach (Button btn in new[] { btnAtivarInativar, btnAtualizar, btnNovoFuncionario })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
            }
            btnAtivarInativar.Enabled = false;

            // Configuração do painel de detalhes
            pnlDetalhes.BackColor = Color.FromArgb(46, 51, 73);
            pnlDetalhes.BorderStyle = BorderStyle.FixedSingle;
        }

        private void CarregarFuncionarios()
        {
            try
            {
                string query = @"SELECT id_funcionario, nome_completo, email, 
                                CASE nivel_acesso 
                                    WHEN 0 THEN 'Admin Master' 
                                    WHEN 1 THEN 'Gerente' 
                                    WHEN 2 THEN 'Supervisor' 
                                END AS Cargo,
                                CASE ativo WHEN 1 THEN 'Ativo' ELSE 'Inativo' END AS Status,
                                FORMAT(data_cadastro, 'dd/MM/yyyy HH:mm') AS 'Data Cadastro',
                                FORMAT(ultimo_acesso, 'dd/MM/yyyy HH:mm') AS 'Último Acesso'
                                FROM Funcionario ORDER BY nome_completo";

                funcionarios = conexao.executarSQL(query);
                dgvFuncionarios.DataSource = funcionarios;

                if (dgvFuncionarios.Columns.Count > 0)
                {
                    dgvFuncionarios.Columns["id_funcionario"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar funcionários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvFuncionarios.Rows[e.RowIndex];
                funcionarioSelecionadoId = Convert.ToInt32(row.Cells["id_funcionario"].Value);

                // Preencher detalhes do funcionário
                lblNomeValor.Text = row.Cells["nome_completo"].Value.ToString();
                lblEmailValor.Text = row.Cells["email"].Value.ToString();
                lblCargoValor.Text = row.Cells["Cargo"].Value.ToString();
                lblStatusValor.Text = row.Cells["Status"].Value.ToString();
                lblDataCadastroValor.Text = row.Cells["Data Cadastro"].Value.ToString();
                lblUltimoAcessoValor.Text = row.Cells["Último Acesso"].Value?.ToString() ?? "Nunca acessou";

                // Configurar cores do status
                lblStatusValor.ForeColor = lblStatusValor.Text == "Ativo" ? Color.LightGreen : Color.OrangeRed;

                // Configurar botão de ativar/inativar
                btnAtivarInativar.Text = lblStatusValor.Text == "Ativo" ? "Inativar Funcionário" : "Ativar Funcionário";
                btnAtivarInativar.Enabled = (nivelAcessoUsuarioAtual <= 1); // Admin e Gerentes podem ativar/inativar
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarFuncionarios();
            LimparDetalhes();
        }

        private void btnAtivarInativar_Click(object sender, EventArgs e)
        {
            if (funcionarioSelecionadoId == -1) return;

            try
            {
                bool estaAtivo = lblStatusValor.Text == "Ativo";
                string mensagem = estaAtivo ?
                    "Tem certeza que deseja inativar este funcionário? Ele não poderá fazer login." :
                    "Tem certeza que deseja ativar este funcionário? Ele poderá fazer login novamente.";

                if (MessageBox.Show(mensagem, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string updateQuery = estaAtivo ?
                        "UPDATE Funcionario SET ativo = 0 WHERE id_funcionario = @id" :
                        "UPDATE Funcionario SET ativo = 1 WHERE id_funcionario = @id";

                    SqlCommand updateCmd = new SqlCommand(updateQuery);
                    updateCmd.Parameters.AddWithValue("@id", funcionarioSelecionadoId);

                    if (conexao.manutencaoDB_Parametros(updateCmd) > 0)
                    {
                        MessageBox.Show(estaAtivo ? "Funcionário inativado com sucesso!" : "Funcionário ativado com sucesso!",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarFuncionarios();
                        LimparDetalhes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao alterar status do funcionário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovoFuncionario_Click(object sender, EventArgs e)
        {
            FrmCadastrarFuncionario formCadastro = new FrmCadastrarFuncionario();
            this.Hide(); // Esconde o formulário atual
            if (formCadastro.ShowDialog() == DialogResult.OK)
            {
                CarregarFuncionarios(); // Atualiza a lista se um novo funcionário foi cadastrado
            }
            this.Show(); // Mostra novamente o formulário de gerenciamento
        }

        private void LimparDetalhes()
        {
            lblNomeValor.Text = "Nenhum funcionário selecionado";
            lblEmailValor.Text = string.Empty;
            lblCargoValor.Text = string.Empty;
            lblStatusValor.Text = string.Empty;
            lblDataCadastroValor.Text = string.Empty;
            lblUltimoAcessoValor.Text = string.Empty;
            btnAtivarInativar.Enabled = false;
            funcionarioSelecionadoId = -1;
        }

        private void TxtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (funcionarios != null)
            {
                string filtro = txtPesquisa.Text.Trim().ToLower();
                DataView dv = funcionarios.DefaultView;

                if (!string.IsNullOrEmpty(filtro))
                {
                    dv.RowFilter = $"nome_completo LIKE '%{filtro}%' OR email LIKE '%{filtro}%' OR Cargo LIKE '%{filtro}%'";
                }
                else
                {
                    dv.RowFilter = string.Empty;
                }
            }
        }
    }
}