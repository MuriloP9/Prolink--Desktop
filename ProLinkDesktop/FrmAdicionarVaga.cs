using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLinkDesktop
{
    public partial class FrmAdicionarVaga : Form
    {
        private ClasseConexao conexao;

        public FrmAdicionarVaga()
        {
            InitializeComponent();
            conexao = new ClasseConexao();
            CarregarAreasAtuacao();
            ConfigurarFormulario();
        }

        private void ConfigurarFormulario()
        {
            // Configuração básica do formulário
            this.Text = "Adicionar Nova Vaga";
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Estilo dos controles
            foreach (Control control in this.Controls)
            {
                if (control is Label)
                {
                    control.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
                }
                else if (control is TextBox || control is ComboBox)
                {
                    control.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Regular);
                    control.BackColor = Color.White;
                }
            }
        }

        private void CarregarAreasAtuacao()
        {
            try
            {
                string sql = "SELECT id_area, nome_area FROM AreaAtuacao ORDER BY nome_area";
                DataTable dt = conexao.executarSQL(sql);

                // DEBUG: Verifique os dados retornados
                Debug.WriteLine("Dados da Área de Atuação:");
                foreach (DataRow row in dt.Rows)
                {
                    Debug.WriteLine($"ID: {row["id_area"]}, Nome: {row["nome_area"]}");
                }

                cmbArea.DataSource = dt;
                cmbArea.DisplayMember = "nome_area";
                cmbArea.ValueMember = "id_area";

                // DEBUG: Verifique o binding
                Debug.WriteLine($"Configuração do ComboBox: DisplayMember={cmbArea.DisplayMember}, ValueMember={cmbArea.ValueMember}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar áreas: " + ex.ToString(), "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                int idFuncionario = ObterIdFuncionarioLogado();
                int idUsuario = ObterIdUsuarioLogado();

                // Verifique se os IDs são válidos
                if (idFuncionario <= 0 || idUsuario <= 0)
                {
                    MessageBox.Show("IDs de usuário/funcionário inválidos!", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string sql = @"INSERT INTO Vagas 
                     (id_func, titulo_vaga, localizacao, tipo_emprego, id_area, id_usuario, empresa)
                     VALUES 
                     (@id_func, @titulo, @localizacao, @tipo, @id_area, @id_usuario, @empresa)";

                using (SqlCommand comando = new SqlCommand(sql))
                {
                    // Converta explicitamente os valores para evitar problemas de tipo
                    comando.Parameters.AddWithValue("@id_func", idFuncionario);
                    comando.Parameters.AddWithValue("@titulo", txtTitulo.Text.Trim());
                    comando.Parameters.AddWithValue("@localizacao", txtLocalizacao.Text.Trim());
                    comando.Parameters.AddWithValue("@tipo", cmbTipoEmprego.SelectedItem.ToString());
                    comando.Parameters.AddWithValue("@id_area", Convert.ToInt32(cmbArea.SelectedValue));
                    comando.Parameters.AddWithValue("@id_usuario", idUsuario);
                    comando.Parameters.AddWithValue("@empresa", txtEmpresa.Text.Trim());

                    // DEBUG: Mostrar os valores que estão sendo enviados
                    string debugInfo = $"Valores enviados:\n" +
                                     $"ID Funcionário: {idFuncionario}\n" +
                                     $"Título: {txtTitulo.Text.Trim()}\n" +
                                     $"Localização: {txtLocalizacao.Text.Trim()}\n" +
                                     $"Tipo: {cmbTipoEmprego.SelectedItem}\n" +
                                     $"Área: {cmbArea.SelectedValue} (Texto: {cmbArea.Text})\n" +
                                     $"ID Usuário: {idUsuario}\n" +
                                     $"Empresa: {txtEmpresa.Text.Trim()}";

                    Debug.WriteLine(debugInfo); // Visualizar no Output do Visual Studio
                                                // MessageBox.Show(debugInfo); // Descomente para ver os valores em uma mensagem

                    int linhasAfetadas = conexao.manutencaoDB_Parametros(comando);

                    if (linhasAfetadas > 0)
                    {
                        MessageBox.Show("Vaga cadastrada com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        // Teste direto no banco com os mesmos valores
                        string testeSQL = $"Teste no SQL: INSERT INTO Vagas VALUES " +
                                        $"({idFuncionario}, '{txtTitulo.Text.Trim()}', " +
                                        $"'{txtLocalizacao.Text.Trim()}', " +
                                        $"'{cmbTipoEmprego.SelectedItem}', " +
                                        $"{cmbArea.SelectedValue}, {idUsuario}, " +
                                        $"'{txtEmpresa.Text.Trim()}')";

                        Debug.WriteLine(testeSQL);
                        MessageBox.Show($"Falha ao cadastrar. Execute manualmente no SQL:\n{testeSQL}",
                                        "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERRO DETALHADO:\n{ex.ToString()}", "Erro Grave",
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

            if (string.IsNullOrWhiteSpace(txtEmpresa.Text))
            {
                MessageBox.Show("Por favor, informe o nome da empresa.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmpresa.Focus();
                return false;
            }

            return true;
        }

        // Métodos auxiliares - você precisará implementar conforme sua lógica de autenticação
        private int ObterIdFuncionarioLogado()
        {
            // Implemente conforme seu sistema
            return 1; // Exemplo - substitua pelo valor real
        }

        private int ObterIdUsuarioLogado()
        {
            // Implemente conforme seu sistema
            return 1; // Exemplo - substitua pelo valor real
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}