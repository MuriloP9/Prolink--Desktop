using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace ProLinkDesktop
{
    public partial class FrmGerenciarUsuarios : Form
    {
        private ClasseConexao conexao;
        private DataTable usuarios;
        private int usuarioSelecionadoId = -1;

        public FrmGerenciarUsuarios()
        {
            InitializeComponent();
            conexao = new ClasseConexao();
            ConfigurarDesign();
            CarregarUsuarios();
            LimparDetalhes();
        }

        private void ConfigurarDesign()
        {
            // Configuração do formulário
            this.BackColor = Color.FromArgb(32, 36, 55);
            this.ForeColor = Color.White;

            // Configuração do DataGridView (somente leitura)
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.AllowUserToResizeRows = false;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.BackgroundColor = Color.FromArgb(32, 36, 55);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.DefaultCellStyle.BackColor = Color.FromArgb(32, 36, 55);
            dgvUsuarios.DefaultCellStyle.ForeColor = Color.White;
            dgvUsuarios.DefaultCellStyle.SelectionBackColor = Color.FromArgb(67, 74, 105);
            dgvUsuarios.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvUsuarios.EnableHeadersVisualStyles = false;

            // Configuração dos botões
            btnAtivarInativar.BackColor = Color.FromArgb(67, 74, 105);
            btnAtualizar.BackColor = Color.FromArgb(67, 74, 105);
            foreach (Button btn in new[] { btnAtivarInativar, btnAtualizar })
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

        private void CarregarUsuarios()
        {
            try
            {
                string query = @"SELECT id_usuario, nome, email, dataNascimento, telefone, 
                               CASE WHEN data_geracao_qr IS NULL THEN 'Inativo' ELSE 'Ativo' END AS Status,
                               data_geracao_qr AS 'Último Login' 
                               FROM Usuario ORDER BY nome";

                usuarios = conexao.executarSQL(query);
                dgvUsuarios.DataSource = usuarios;

                if (dgvUsuarios.Columns.Count > 0)
                {
                    dgvUsuarios.Columns["id_usuario"].Visible = false;
                    dgvUsuarios.Columns["dataNascimento"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvUsuarios.Columns["Último Login"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
                usuarioSelecionadoId = Convert.ToInt32(row.Cells["id_usuario"].Value);

                // Preencher detalhes do usuário
                lblNomeValor.Text = row.Cells["nome"].Value.ToString();
                lblEmailValor.Text = row.Cells["email"].Value.ToString();
                lblTelefoneValor.Text = row.Cells["telefone"].Value?.ToString() ?? "Não informado";

                if (row.Cells["dataNascimento"].Value != DBNull.Value)
                {
                    lblDataNascValor.Text = Convert.ToDateTime(row.Cells["dataNascimento"].Value).ToString("dd/MM/yyyy");
                }
                else
                {
                    lblDataNascValor.Text = "Não informado";
                }

                if (row.Cells["Último Login"].Value != DBNull.Value)
                {
                    lblUltimoLoginValor.Text = Convert.ToDateTime(row.Cells["Último Login"].Value).ToString("dd/MM/yyyy HH:mm");
                }
                else
                {
                    lblUltimoLoginValor.Text = "Nunca acessou";
                }

                string status = row.Cells["Status"].Value.ToString();
                lblStatusValor.Text = status;
                lblStatusValor.ForeColor = status == "Ativo" ? Color.LightGreen : Color.OrangeRed;

                btnAtivarInativar.Text = status == "Ativo" ? "Inativar Usuário" : "Ativar Usuário";
                btnAtivarInativar.Enabled = true;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarUsuarios();
            LimparDetalhes();
        }

        private void btnAtivarInativar_Click(object sender, EventArgs e)
        {
            if (usuarioSelecionadoId == -1) return;

            try
            {
                bool estaAtivo = lblStatusValor.Text == "Ativo";
                string mensagem = estaAtivo ?
                    "Tem certeza que deseja inativar este usuário? Ele não poderá fazer login." :
                    "Tem certeza que deseja ativar este usuário? Ele poderá fazer login novamente.";

                if (MessageBox.Show(mensagem, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string updateQuery = estaAtivo ?
                        "UPDATE Usuario SET data_geracao_qr = NULL WHERE id_usuario = @id" :
                        "UPDATE Usuario SET data_geracao_qr = GETDATE() WHERE id_usuario = @id";

                    SqlCommand updateCmd = new SqlCommand(updateQuery);
                    updateCmd.Parameters.AddWithValue("@id", usuarioSelecionadoId);

                    if (conexao.manutencaoDB_Parametros(updateCmd) > 0)
                    {
                        MessageBox.Show(estaAtivo ? "Usuário inativado com sucesso!" : "Usuário ativado com sucesso!",
                            "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CarregarUsuarios();
                        LimparDetalhes();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao alterar status do usuário: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparDetalhes()
        {
            lblNomeValor.Text = "Nenhum usuário selecionado";
            lblEmailValor.Text = string.Empty;
            lblTelefoneValor.Text = string.Empty;
            lblDataNascValor.Text = string.Empty;
            lblUltimoLoginValor.Text = string.Empty;
            lblStatusValor.Text = string.Empty;
            btnAtivarInativar.Enabled = false;
            usuarioSelecionadoId = -1;
        }

        private void TxtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (usuarios != null)
            {
                string filtro = txtPesquisa.Text.Trim().ToLower();
                DataView dv = usuarios.DefaultView;

                if (!string.IsNullOrEmpty(filtro))
                {
                    dv.RowFilter = $"nome LIKE '%{filtro}%' OR email LIKE '%{filtro}%' OR telefone LIKE '%{filtro}%'";
                }
                else
                {
                    dv.RowFilter = string.Empty;
                }
            }
        }
    }
}