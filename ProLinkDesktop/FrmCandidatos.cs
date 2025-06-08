using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProLinkDesktop
{
    public partial class FrmCandidatos : Form
    {
        private ClasseConexao conexao;
        private int idVaga;
        private const string ColunaEmail = "email";
        private const string ColunaIdUsuario = "id_usuario";
        private const string ColunaIdCandidatura = "id_candidatura";

        public FrmCandidatos(int idVaga)
        {
            InitializeComponent();
            this.idVaga = idVaga;
            ConfigurarDesign();
            ConfigurarGrid();
            CarregarCandidatos();
        }

        private void ConfigurarDesign()
        {
            this.BackColor = Color.FromArgb(32, 36, 55);
            this.ForeColor = Color.White;

            btnFechar.BackColor = Color.FromArgb(67, 74, 105);
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.ForeColor = Color.White;
            btnFechar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnFechar.Cursor = Cursors.Hand;
        }

        private void ConfigurarGrid()
        {
            gridCandidatos.AutoGenerateColumns = false;
            gridCandidatos.AllowUserToAddRows = false;
            gridCandidatos.AllowUserToDeleteRows = false;
            gridCandidatos.ReadOnly = false;
            gridCandidatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridCandidatos.MultiSelect = false;
            gridCandidatos.RowHeadersVisible = false;

            gridCandidatos.BackgroundColor = Color.FromArgb(32, 36, 55);
            gridCandidatos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            gridCandidatos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridCandidatos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            gridCandidatos.DefaultCellStyle.BackColor = Color.FromArgb(32, 36, 55);
            gridCandidatos.DefaultCellStyle.ForeColor = Color.White;
            gridCandidatos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(67, 74, 105);
            gridCandidatos.DefaultCellStyle.SelectionForeColor = Color.White;
            gridCandidatos.EnableHeadersVisualStyles = false;
            gridCandidatos.GridColor = Color.FromArgb(67, 74, 105);

            gridCandidatos.Columns.Clear();

            gridCandidatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = ColunaIdCandidatura,
                DataPropertyName = ColunaIdCandidatura,
                HeaderText = "ID Candidatura",
                Visible = false
            });

            gridCandidatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = ColunaIdUsuario,
                DataPropertyName = ColunaIdUsuario,
                HeaderText = "ID",
                Visible = false
            });

            gridCandidatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "nome",
                DataPropertyName = "nome",
                HeaderText = "Nome",
                Width = 200,
                ReadOnly = true
            });

            gridCandidatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = ColunaEmail,
                DataPropertyName = ColunaEmail,
                HeaderText = "Email",
                Width = 200,
                ReadOnly = true
            });

            gridCandidatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "formacao",
                DataPropertyName = "formacao",
                HeaderText = "Formação",
                Width = 200,
                ReadOnly = true
            });

            DataGridViewComboBoxColumn colStatus = new DataGridViewComboBoxColumn()
            {
                Name = "status",
                HeaderText = "Status",
                DataPropertyName = "status",
                Width = 150,
                FlatStyle = FlatStyle.Flat
            };
            colStatus.Items.AddRange("Pendente", "Aprovado", "Rejeitado", "Em análise");
            gridCandidatos.Columns.Add(colStatus);

            gridCandidatos.CellEndEdit += GridCandidatos_CellEndEdit;
            gridCandidatos.DataError += GridCandidatos_DataError;
        }

        private void CarregarCandidatos()
        {
            try
            {
                string sql = $@"SELECT c.{ColunaIdCandidatura}, u.{ColunaIdUsuario}, u.nome, u.{ColunaEmail}, 
                             p.formacao, c.status
                             FROM Candidatura c
                             INNER JOIN Perfil p ON c.id_perfil = p.id_perfil
                             INNER JOIN Usuario u ON p.{ColunaIdUsuario} = u.{ColunaIdUsuario}
                             WHERE c.id_vaga = {idVaga}";

                DataTable dt = conexao.executarSQL(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    gridCandidatos.DataSource = dt;
                }
                else
                {
                    gridCandidatos.DataSource = null;
                    MessageBox.Show("Nenhum candidato encontrado para esta vaga.", "Informação",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar candidatos: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GridCandidatos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (gridCandidatos.Columns[e.ColumnIndex].Name == "status")
            {
                try
                {
                    int idCandidatura = Convert.ToInt32(gridCandidatos.Rows[e.RowIndex].Cells[ColunaIdCandidatura].Value);
                    string novoStatus = gridCandidatos.Rows[e.RowIndex].Cells["status"].Value.ToString();

                    string sql = $"UPDATE Candidatura SET status = '{novoStatus}' WHERE {ColunaIdCandidatura} = {idCandidatura}";
                    bool sucesso = conexao.manutencaoDB(sql);

                    if (!sucesso)
                    {
                        MessageBox.Show("Erro ao atualizar status.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        CarregarCandidatos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar status: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CarregarCandidatos();
                }
            }
        }

        private void GridCandidatos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (gridCandidatos.Columns[e.ColumnIndex].Name == "status")
            {
                MessageBox.Show("Por favor, selecione um status válido.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.ThrowException = false;
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}