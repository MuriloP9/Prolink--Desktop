using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProLinkDesktop
{
    public partial class FrmGerenciarUsuarios : Form
    {
        private ClasseConexao conexao;
        private DataTable Usuarios;
        private int usuarioSelecionadoId = -1;
        private Button btnAnalisarFoto;

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
            this.BackColor = Color.FromArgb(32, 36, 55);
            this.ForeColor = Color.White;

            // Configuração do DataGridView
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

            // Configuração dos botões existentes
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

            // CRIAR E CONFIGURAR BOTÃO ANALISAR FOTO
            CriarBotaoAnalisarFoto();

            // Configuração do painel de detalhes
            pnlDetalhes.BackColor = Color.FromArgb(46, 51, 73);
            pnlDetalhes.BorderStyle = BorderStyle.FixedSingle;
            lblStatusValor.Font = new Font(lblStatusValor.Font, FontStyle.Bold);
        }

        private void CriarBotaoAnalisarFoto()
        {
            // Remover botão anterior se existir
            if (btnAnalisarFoto != null)
            {
                this.Controls.Remove(btnAnalisarFoto);
                btnAnalisarFoto.Dispose();
            }

            // Criar novo botão
            btnAnalisarFoto = new Button();
            btnAnalisarFoto.Name = "btnAnalisarFoto";
            btnAnalisarFoto.Text = "Analisar Foto";
            btnAnalisarFoto.BackColor = Color.FromArgb(67, 74, 105);
            btnAnalisarFoto.FlatStyle = FlatStyle.Flat;
            btnAnalisarFoto.FlatAppearance.BorderSize = 0;
            btnAnalisarFoto.ForeColor = Color.White;
            btnAnalisarFoto.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnAnalisarFoto.Cursor = Cursors.Hand;
            btnAnalisarFoto.Enabled = false;
            btnAnalisarFoto.UseVisualStyleBackColor = false;

            // Definir tamanho e posição
            btnAnalisarFoto.Size = new Size(120, 35); // Mesmo tamanho dos outros botões
            btnAnalisarFoto.Location = new Point(btnAtivarInativar.Right + 10, btnAtivarInativar.Top);

            // Configurar ancoragem
            btnAnalisarFoto.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // Adicionar evento
            btnAnalisarFoto.Click += BtnAnalisarFoto_Click;

            // Adicionar ao formulário
            this.Controls.Add(btnAnalisarFoto);

            // Trazer para frente
            btnAnalisarFoto.BringToFront();

            // Debug - verificar se foi adicionado
            Console.WriteLine($"Botão Analisar Foto criado - Visible: {btnAnalisarFoto.Visible}, Location: {btnAnalisarFoto.Location}, Size: {btnAnalisarFoto.Size}");
        }

        private void BtnAnalisarFoto_Click(object sender, EventArgs e)
        {
            if (usuarioSelecionadoId == -1) return;

            try
            {
                FrmAnalise frmAnalise = new FrmAnalise(usuarioSelecionadoId);
                frmAnalise.ShowDialog();

                // Atualizar lista de usuários após análise
                CarregarUsuarios();
                LimparDetalhes();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir análise: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarUsuarios()
        {
            try
            {
                string query = @"SELECT 
                    id_usuario, 
                    nome, 
                    email, 
                    dataNascimento, 
                    telefone, 
                    CASE WHEN ativo = 1 THEN 'Ativo' ELSE 'Inativo' END AS Status,
                    FORMAT(data_criacao, 'dd/MM/yyyy HH:mm') AS 'Data Criação',
                    FORMAT(ultimo_acesso, 'dd/MM/yyyy HH:mm') AS 'Último Acesso'
                   FROM Usuario 
                   ORDER BY nome";

                Usuarios = conexao.executarSQL(query);

                if (Usuarios != null && Usuarios.Rows.Count > 0)
                {
                    dgvUsuarios.DataSource = Usuarios;

                    // Configurar colunas
                    dgvUsuarios.Columns["id_usuario"].Visible = false;
                    dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                    // Definir larguras específicas
                    dgvUsuarios.Columns["nome"].Width = 200;
                    dgvUsuarios.Columns["email"].Width = 180;
                    dgvUsuarios.Columns["telefone"].Width = 100;
                    dgvUsuarios.Columns["Status"].Width = 80;
                    dgvUsuarios.Columns["Data Criação"].Width = 150;
                    dgvUsuarios.Columns["Último Acesso"].Width = 150;

                    dgvUsuarios.AllowUserToResizeColumns = true;
                    dgvUsuarios.Columns["nome"].DefaultCellStyle.WrapMode = DataGridViewTriState.False;
                }
                else
                {
                    MessageBox.Show("Nenhum usuário encontrado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvUsuarios.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar usuários: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvUsuarios.DataSource = null;
            }
        }

        private void DgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsuarios.Rows[e.RowIndex].Cells["id_usuario"].Value != null)
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

                // CORRIGIDO: Usar a data de criação corretamente
                lblDataNascValor.Text = row.Cells["Data Criação"].Value?.ToString() ?? "N/A";
                lblUltimoLoginValor.Text = row.Cells["Último Acesso"].Value?.ToString() ?? "Nunca acessou";

                string status = row.Cells["Status"].Value.ToString();
                lblStatusValor.Text = status;
                lblStatusValor.ForeColor = status == "Ativo" ? Color.LightGreen : Color.OrangeRed;

                btnAtivarInativar.Text = status == "Ativo" ? "Inativar Usuário" : "Ativar Usuário";
                btnAtivarInativar.Enabled = true;

                // HABILITAR BOTÃO ANALISAR FOTO
                if (btnAnalisarFoto != null)
                {
                    btnAnalisarFoto.Enabled = true;
                }
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
                        "UPDATE Usuario SET ativo = 0 WHERE id_usuario = @id" :
                        "UPDATE Usuario SET ativo = 1 WHERE id_usuario = @id";

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

            // DESABILITAR BOTÃO ANALISAR FOTO
            if (btnAnalisarFoto != null)
            {
                btnAnalisarFoto.Enabled = false;
            }

            usuarioSelecionadoId = -1;
        }

        private void TxtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (Usuarios != null)
            {
                string filtro = txtPesquisa.Text.Trim();
                DataView dv = Usuarios.DefaultView;

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

        // Sobrescrever método para garantir que o botão seja criado após o form ser totalmente carregado
        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(value);
            if (value && btnAnalisarFoto == null)
            {
                CriarBotaoAnalisarFoto();
            }
        }
    }
}