using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ProLinkDesktop
{
    public partial class frmOportunidades : Form
    {
        private ClasseConexao conexao;

        public frmOportunidades()
        {
            InitializeComponent();
            conexao = new ClasseConexao();
            ConfigurarDesign();
            ConfigurarGrid();
            CarregarVagas();
        }

        private void ConfigurarDesign()
        {
            this.BackColor = Color.FromArgb(32, 36, 55);
            this.ForeColor = Color.White;

            foreach (Button btn in new[] { btnAdicionar, btnAtualizar })
            {
                btn.BackColor = Color.FromArgb(67, 74, 105);
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
            }
        }

        private void ConfigurarGrid()
        {
            gridOportunidades.AutoGenerateColumns = false;
            gridOportunidades.AllowUserToResizeRows = false;
            gridOportunidades.AllowUserToResizeColumns = false;
            gridOportunidades.AllowUserToAddRows = false;
            gridOportunidades.AllowUserToDeleteRows = false;
            gridOportunidades.ReadOnly = true;
            gridOportunidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridOportunidades.MultiSelect = false;
            gridOportunidades.RowHeadersVisible = false;

            gridOportunidades.BackgroundColor = Color.FromArgb(32, 36, 55);
            gridOportunidades.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            gridOportunidades.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridOportunidades.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            gridOportunidades.DefaultCellStyle.BackColor = Color.FromArgb(32, 36, 55);
            gridOportunidades.DefaultCellStyle.ForeColor = Color.White;
            gridOportunidades.DefaultCellStyle.SelectionBackColor = Color.FromArgb(67, 74, 105);
            gridOportunidades.DefaultCellStyle.SelectionForeColor = Color.White;
            gridOportunidades.EnableHeadersVisualStyles = false;
            gridOportunidades.GridColor = Color.FromArgb(67, 74, 105);

            gridOportunidades.Columns.Clear();

            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "id_vaga",
                DataPropertyName = "id_vaga",
                HeaderText = "ID",
                Visible = false
            });

            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "titulo_vaga",
                HeaderText = "Título da Vaga",
                Width = 200
            });

            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "empresa",
                HeaderText = "Empresa",
                Width = 150
            });

            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "localizacao",
                HeaderText = "Localização",
                Width = 120
            });

            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "tipo_emprego",
                HeaderText = "Tipo",
                Width = 100
            });

            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "nome_area",
                HeaderText = "Área",
                Width = 120
            });

            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "colCandidatos",
                HeaderText = "Candidatos",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });

            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "total_candidatos",
                HeaderText = "Total Candidatos",
                Visible = false
            });

            var btnAcoes = new DataGridViewButtonColumn()
            {
                Name = "colAcoes",
                HeaderText = "Ações",
                Width = 80,
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    BackColor = Color.FromArgb(67, 74, 105),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.FromArgb(67, 74, 105),
                    SelectionForeColor = Color.White
                }
            };
            gridOportunidades.Columns.Add(btnAcoes);

            gridOportunidades.CellFormatting += GridOportunidades_CellFormatting;
            gridOportunidades.CellClick += GridOportunidades_CellClick;
        }

        private void CarregarVagas()
        {
            try
            {
                string sql = @"SELECT v.id_vaga, v.titulo_vaga, v.empresa, v.localizacao, v.tipo_emprego, 
                             a.nome_area, f.nome_completo AS cadastrado_por, v.ativa,
                            (SELECT COUNT(*) FROM Candidatura c WHERE c.id_vaga = v.id_vaga) AS total_candidatos
                             FROM Vagas v
                             INNER JOIN AreaAtuacao a ON v.id_area = a.id_area
                             INNER JOIN Funcionario f ON v.id_funcionario = f.id_funcionario
                             WHERE v.ativa = 1";

                DataTable dt = conexao.executarSQL(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    gridOportunidades.DataSource = dt;
                    Debug.WriteLine($"Vagas carregadas: {dt.Rows.Count}");
                }
                else
                {
                    gridOportunidades.DataSource = null;
                    MessageBox.Show("Nenhuma vaga ativa encontrada.", "Informação",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar vagas: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Erro: {ex.ToString()}");
            }
        }

        private void GridOportunidades_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gridOportunidades.Columns[e.ColumnIndex].Name == "colCandidatos" && e.RowIndex >= 0)
            {
                try
                {
                    object value = gridOportunidades.Rows[e.RowIndex].Cells["total_candidatos"].Value;
                    int totalCandidatos = (value == null || value == DBNull.Value) ? 0 : Convert.ToInt32(value);
                    e.Value = totalCandidatos.ToString();
                    e.FormattingApplied = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Erro ao formatar célula: {ex.Message}");
                    e.Value = "0";
                }
            }
        }

        private void GridOportunidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                var idVagaCell = gridOportunidades.Rows[e.RowIndex].Cells["id_vaga"];

                // Verifica se o ID da vaga é válido
                if (idVagaCell.Value == null || idVagaCell.Value == DBNull.Value)
                {
                    MessageBox.Show("Vaga inválida ou sem ID.", "Aviso",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(idVagaCell.Value.ToString(), out int idVaga))
                {
                    MessageBox.Show("ID da vaga em formato inválido.", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verifica se clicou na coluna de AÇÕES (EDITAR)
                if (gridOportunidades.Columns[e.ColumnIndex].Name == "colAcoes")
                {
                    using (var frmEditarVaga = new FrmAdicionarVaga(idVaga))
                    {
                        if (frmEditarVaga.ShowDialog() == DialogResult.OK)
                        {
                            CarregarVagas(); // Atualiza a lista após edição
                        }
                    }
                }
                // Verifica se clicou na coluna de CANDIDATOS
                else if (gridOportunidades.Columns[e.ColumnIndex].Name == "colCandidatos")
                {
                    // Pega o número de candidatos da célula
                    int totalCandidatos = 0;
                    var cellCandidatos = gridOportunidades.Rows[e.RowIndex].Cells["colCandidatos"];
                    if (cellCandidatos.Value != null && cellCandidatos.Value != DBNull.Value)
                    {
                        totalCandidatos = Convert.ToInt32(cellCandidatos.Value);
                    }

                    // Só abre se tiver candidatos
                    if (totalCandidatos > 0)
                    {
                        using (var frmCandidatos = new FrmCandidatos(idVaga))
                        {
                            this.Hide(); // Esconde o form atual
                            frmCandidatos.ShowDialog();
                            this.Show(); // Mostra novamente quando fechar
                        }
                    }
                    else
                    {
                        MessageBox.Show("Esta vaga não possui candidatos.", "Informação",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro inesperado: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Erro detalhado: {ex.ToString()}");
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            FrmAdicionarVaga formAdicionar = new FrmAdicionarVaga();
            if (formAdicionar.ShowDialog() == DialogResult.OK)
            {
                CarregarVagas();
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarVagas();
        }
    }
}