using System;
using System.Data;
using System.Data.SqlClient;
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
                chkAtiva.Visible = true;
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

            // Configurar navegação por Enter
            txtTitulo.KeyDown += NavigateToNextControl;
            txtEmpresa.KeyDown += NavigateToNextControl;
            txtLocalizacao.KeyDown += NavigateToNextControl;
            cmbTipoEmprego.KeyDown += NavigateToNextControlCombo;
            cmbArea.KeyDown += NavigateToNextControlCombo;
            txtSalario.KeyDown += NavigateToNextControlNumeric;
            txtRequisitos.KeyDown += NavigateToNextControlMultiline;
            txtBeneficios.KeyDown += NavigateToNextControlMultiline;
        }

        private void NavigateToNextControl(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void NavigateToNextControlCombo(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (((ComboBox)sender).DroppedDown)
                {
                    ((ComboBox)sender).DroppedDown = false;
                    return;
                }
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void NavigateToNextControlNumeric(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        private void NavigateToNextControlMultiline(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
                e.Handled = e.SuppressKeyPress = true;
            }
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
                string sql = $@"SELECT titulo_vaga, empresa, localizacao, tipo_emprego, id_area, 
                             salario, requisitos, beneficios, ativa
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
                    txtSalario.Text = row["salario"] != DBNull.Value ? Convert.ToDecimal(row["salario"]).ToString("N2") : "";
                    txtRequisitos.Text = row["requisitos"].ToString();
                    txtBeneficios.Text = row["beneficios"].ToString();
                    chkAtiva.Checked = Convert.ToBoolean(row["ativa"]);
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
                    string sql = @"UPDATE Vagas SET 
                                 titulo_vaga = @titulo,
                                 empresa = @empresa,
                                 localizacao = @localizacao,
                                 tipo_emprego = @tipo,
                                 id_area = @id_area,
                                 salario = @salario,
                                 requisitos = @requisitos,
                                 beneficios = @beneficios,
                                 ativa = @ativa
                                 WHERE id_vaga = @id_vaga";

                    using (SqlCommand comando = new SqlCommand(sql))
                    {
                        comando.Parameters.AddWithValue("@titulo", txtTitulo.Text.Trim());
                        comando.Parameters.AddWithValue("@empresa", txtEmpresa.Text.Trim());
                        comando.Parameters.AddWithValue("@localizacao", txtLocalizacao.Text.Trim());
                        comando.Parameters.AddWithValue("@tipo", cmbTipoEmprego.SelectedItem.ToString());
                        comando.Parameters.AddWithValue("@id_area", Convert.ToInt32(cmbArea.SelectedValue));
                        comando.Parameters.AddWithValue("@salario", string.IsNullOrEmpty(txtSalario.Text) ? (object)DBNull.Value : Convert.ToDecimal(txtSalario.Text));
                        comando.Parameters.AddWithValue("@requisitos", string.IsNullOrEmpty(txtRequisitos.Text) ? (object)DBNull.Value : txtRequisitos.Text.Trim());
                        comando.Parameters.AddWithValue("@beneficios", string.IsNullOrEmpty(txtBeneficios.Text) ? (object)DBNull.Value : txtBeneficios.Text.Trim());
                        comando.Parameters.AddWithValue("@ativa", chkAtiva.Checked);
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
                    int idFuncionario = ObterIdFuncionarioLogado();
                    int idUsuario = ObterIdUsuarioLogado();

                    if (idFuncionario <= 0 || idUsuario <= 0)
                    {
                        MessageBox.Show("Não foi possível identificar o usuário/funcionário logado.", "Erro",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string sql = @"INSERT INTO Vagas 
                                 (id_funcionario, titulo_vaga, empresa, localizacao, tipo_emprego, 
                                 id_area, salario, requisitos, beneficios, id_usuario, ativa)
                                 VALUES 
                                 (@id_funcionario, @titulo, @empresa, @localizacao, @tipo, 
                                 @id_area, @salario, @requisitos, @beneficios, @id_usuario, 1)";

                    using (SqlCommand comando = new SqlCommand(sql))
                    {
                        comando.Parameters.AddWithValue("@id_funcionario", idFuncionario);
                        comando.Parameters.AddWithValue("@titulo", txtTitulo.Text.Trim());
                        comando.Parameters.AddWithValue("@empresa", txtEmpresa.Text.Trim());
                        comando.Parameters.AddWithValue("@localizacao", txtLocalizacao.Text.Trim());
                        comando.Parameters.AddWithValue("@tipo", cmbTipoEmprego.SelectedItem.ToString());
                        comando.Parameters.AddWithValue("@id_area", Convert.ToInt32(cmbArea.SelectedValue));
                        comando.Parameters.AddWithValue("@salario", string.IsNullOrEmpty(txtSalario.Text) ? (object)DBNull.Value : Convert.ToDecimal(txtSalario.Text));
                        comando.Parameters.AddWithValue("@requisitos", string.IsNullOrEmpty(txtRequisitos.Text) ? (object)DBNull.Value : txtRequisitos.Text.Trim());
                        comando.Parameters.AddWithValue("@beneficios", string.IsNullOrEmpty(txtBeneficios.Text) ? (object)DBNull.Value : txtBeneficios.Text.Trim());
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

            if (!string.IsNullOrEmpty(txtSalario.Text) && !decimal.TryParse(txtSalario.Text, out _))
            {
                MessageBox.Show("Por favor, informe um valor de salário válido.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalario.Focus();
                return false;
            }

            return true;
        }

        private int ObterIdFuncionarioLogado()
        {
            // Implemente a lógica para obter o ID do funcionário logado
            return 1; // Exemplo
        }

        private int ObterIdUsuarioLogado()
        {
            // Implemente a lógica para obter o ID do usuário logado
            return 1; // Exemplo
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}