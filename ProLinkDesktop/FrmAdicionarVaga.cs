using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ProLinkDesktop
{
    public partial class FrmAdicionarVaga : Form
    {
        private ClasseConexao conexao;
        private bool editMode = false;
        private int vagaId = -1;

        public FrmAdicionarVaga(int vagaId = -1)
        {
            InitializeComponent();
            conexao = new ClasseConexao();
            CarregarAreasAtuacao();
            ConfigurarFormulario();

            this.vagaId = vagaId;
            this.editMode = vagaId > 0;

            if (editMode)
            {
                this.Text = "Editar Vaga";
                btnSalvar.Text = "Salvar Alterações";
                CarregarDadosVaga();
            }
        }

        private void ConfigurarFormulario()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            cmbTipoEmprego.Items.AddRange(new string[] { "full-time", "part-time", "internship" });
        }

        private void CarregarAreasAtuacao()
        {
            try
            {
                string sql = "SELECT id_area, nome_area FROM AreaAtuacao ORDER BY nome_area";
                DataTable dt = conexao.executarSQL(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    cmbArea.DataSource = dt;
                    cmbArea.DisplayMember = "nome_area";
                    cmbArea.ValueMember = "id_area";
                }
                else
                {
                    MessageBox.Show("Nenhuma área de atuação cadastrada.", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar áreas: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarDadosVaga()
        {
            try
            {
                string sql = $@"SELECT titulo_vaga, empresa, localizacao, tipo_emprego, id_area 
                             FROM Vagas WHERE id_vaga = {vagaId}";

                DataTable dt = conexao.executarSQL(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    txtTitulo.Text = row["titulo_vaga"].ToString();
                    txtEmpresa.Text = row["empresa"].ToString();
                    txtLocalizacao.Text = row["localizacao"].ToString();
                    cmbTipoEmprego.SelectedItem = row["tipo_emprego"].ToString();
                    cmbArea.SelectedValue = Convert.ToInt32(row["id_area"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados da vaga: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                if (editMode)
                {
                    // Modo edição
                    string sql = @"UPDATE Vagas SET 
                                 titulo_vaga = @titulo,
                                 empresa = @empresa,
                                 localizacao = @localizacao,
                                 tipo_emprego = @tipo,
                                 id_area = @id_area
                                 WHERE id_vaga = @id_vaga";

                    using (SqlCommand comando = new SqlCommand(sql))
                    {
                        comando.Parameters.AddWithValue("@titulo", txtTitulo.Text.Trim());
                        comando.Parameters.AddWithValue("@empresa", txtEmpresa.Text.Trim());
                        comando.Parameters.AddWithValue("@localizacao", txtLocalizacao.Text.Trim());
                        comando.Parameters.AddWithValue("@tipo", cmbTipoEmprego.SelectedItem.ToString());
                        comando.Parameters.AddWithValue("@id_area", Convert.ToInt32(cmbArea.SelectedValue));
                        comando.Parameters.AddWithValue("@id_vaga", vagaId);

                        int linhasAfetadas = conexao.manutencaoDB_Parametros(comando);

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Vaga atualizada com sucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                else
                {
                    // Modo adição
                    int idFuncionario = ObterIdFuncionarioLogado();
                    int idUsuario = ObterIdUsuarioLogado();

                    if (idFuncionario <= 0 || idUsuario <= 0)
                    {
                        MessageBox.Show("Não foi possível identificar o usuário/funcionário logado.", "Erro",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sql = @"INSERT INTO Vagas 
                                 (id_funcionario, titulo_vaga, empresa, localizacao, tipo_emprego, id_area, id_usuario)
                                 VALUES 
                                 (@id_funcionario, @titulo, @empresa, @localizacao, @tipo, @id_area, @id_usuario)";

                    using (SqlCommand comando = new SqlCommand(sql))
                    {
                        comando.Parameters.AddWithValue("@id_funcionario", idFuncionario);
                        comando.Parameters.AddWithValue("@titulo", txtTitulo.Text.Trim());
                        comando.Parameters.AddWithValue("@empresa", txtEmpresa.Text.Trim());
                        comando.Parameters.AddWithValue("@localizacao", txtLocalizacao.Text.Trim());
                        comando.Parameters.AddWithValue("@tipo", cmbTipoEmprego.SelectedItem.ToString());
                        comando.Parameters.AddWithValue("@id_area", Convert.ToInt32(cmbArea.SelectedValue));
                        comando.Parameters.AddWithValue("@id_usuario", idUsuario);

                        int linhasAfetadas = conexao.manutencaoDB_Parametros(comando);

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Vaga cadastrada com sucesso!", "Sucesso",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao {(editMode ? "atualizar" : "cadastrar")} vaga: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Erro detalhado: {ex.ToString()}");
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("Por favor, informe o título da vaga.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmpresa.Text))
            {
                MessageBox.Show("Por favor, informe o nome da empresa.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmpresa.Focus();
                return false;
            }

            if (cmbTipoEmprego.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecione o tipo de emprego.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoEmprego.Focus();
                return false;
            }

            if (cmbArea.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, selecione a área de atuação.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbArea.Focus();
                return false;
            }

            return true;
        }

        private int ObterIdFuncionarioLogado()
        {
            return 1; // Substitua pela lógica real
        }

        private int ObterIdUsuarioLogado()
        {
            return 1; // Substitua pela lógica real
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}