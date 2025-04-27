using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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
            ConfigurarGrid();
            CarregarVagas();
        }

        private void ConfigurarGrid()
        {
            gridOportunidades.AutoGenerateColumns = false;
            gridOportunidades.AllowUserToAddRows = false;
            gridOportunidades.AllowUserToDeleteRows = false;
            gridOportunidades.ReadOnly = true;
            gridOportunidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridOportunidades.MultiSelect = false;
            gridOportunidades.RowHeadersVisible = false;

            // Estilo do cabeçalho
            gridOportunidades.EnableHeadersVisualStyles = false;
            gridOportunidades.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            gridOportunidades.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridOportunidades.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);

            // Definindo as colunas
            gridOportunidades.Columns.Clear();

            // Coluna ID (oculta)
            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "id_vaga", // Nome deve ser exatamente "id_vaga"
                DataPropertyName = "id_vaga",
                HeaderText = "ID",
                Visible = false
            });

            // Coluna Título
            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "titulo_vaga",
                HeaderText = "Título da Vaga",
                Width = 200
            });

            // Coluna Empresa
            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "empresa",
                HeaderText = "Empresa",
                Width = 150
            });

            // Coluna Localização
            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "localizacao",
                HeaderText = "Localização",
                Width = 120
            });

            // Coluna Tipo de Emprego
            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "tipo_emprego",
                HeaderText = "Tipo",
                Width = 100
            });

            // Coluna Área
            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "nome_area",
                HeaderText = "Área",
                Width = 120
            });

            // Coluna Candidatos
            var colCandidatos = new DataGridViewImageColumn()
            {
                Name = "colCandidatos",
                HeaderText = "Candidatos",
                Width = 120,
                ImageLayout = DataGridViewImageCellLayout.Normal
            };
            gridOportunidades.Columns.Add(colCandidatos);

            // Coluna Total Candidatos (oculta)
            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "total_candidatos",
                HeaderText = "Total Candidatos",
                Visible = false
            });

            // Botão de Ações
            var btnAcoes = new DataGridViewButtonColumn()
            {
                Name = "colAcoes",
                HeaderText = "Ações",
                Width = 80,
                Text = "Editar",
                UseColumnTextForButtonValue = true
            };
            gridOportunidades.Columns.Add(btnAcoes);

            // Configurar eventos
            gridOportunidades.CellFormatting += GridOportunidades_CellFormatting;
            gridOportunidades.CellClick += GridOportunidades_CellClick;
        }

        private void CarregarVagas()
        {
            try
            {
                string sql = @"SELECT v.id_vaga, v.titulo_vaga, v.empresa, v.localizacao, v.tipo_emprego, 
                             a.nome_area, f.nome_completo AS cadastrado_por,
                             (SELECT COUNT(*) FROM Candidatura c WHERE c.id_vaga = v.id_vaga) AS total_candidatos
                             FROM Vagas v
                             INNER JOIN AreaAtuacao a ON v.id_area = a.id_area
                             INNER JOIN Funcionario f ON v.id_funcionario = f.id_funcionario";

                DataTable dt = conexao.executarSQL(sql);

                if (dt != null && dt.Rows.Count > 0)
                {
                    gridOportunidades.DataSource = dt;
                    Debug.WriteLine($"Vagas carregadas: {dt.Rows.Count}");
                }
                else
                {
                    gridOportunidades.DataSource = null;
                    MessageBox.Show("Nenhuma vaga encontrada.", "Informação",
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

                    // Cria um bitmap com tamanho adequado
                    Bitmap bmp = new Bitmap(120, 20); // Aumentei a largura para caber o texto

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        // Desenha o fundo branco
                        g.FillRectangle(Brushes.White, 0, 0, bmp.Width, bmp.Height);

                        // Tenta carregar a imagem do arquivo
                        Image icon = null;
                        if (File.Exists("Oportunidades.png"))
                        {
                            try
                            {
                                icon = Image.FromFile("Oportunidades.png");
                                // Redimensiona a imagem para 16x16 se necessário
                                if (icon.Width != 16 || icon.Height != 16)
                                {
                                    icon = new Bitmap(icon, new Size(16, 16));
                                }
                            }
                            catch
                            {
                                icon = null;
                            }
                        }

                        // Desenha o ícone (ou um círculo azul se a imagem não existir)
                        if (icon != null)
                        {
                            g.DrawImage(icon, new Rectangle(5, 2, 16, 16));
                        }
                        else
                        {
                            g.FillEllipse(Brushes.Blue, 5, 2, 16, 16);
                        }

                        // Desenha o número de candidatos ao lado do ícone
                        using (var font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular))
                        {
                            g.DrawString(totalCandidatos.ToString(),
                                        font,
                                        Brushes.Black,
                                        new PointF(25, 3)); // Posição ajustada para ficar ao lado do ícone
                        }
                    }

                    e.Value = bmp;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Erro ao formatar célula: {ex.Message}");
                    e.Value = null;
                }
            }
        }

        private void GridOportunidades_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            try
            {
                // Verifica se clicou na coluna de candidatos
                if (gridOportunidades.Columns[e.ColumnIndex].Name == "colCandidatos")
                {
                    var idVagaCell = gridOportunidades.Rows[e.RowIndex].Cells["id_vaga"];

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

                    AbrirFormCandidatos(idVaga);
                }
                // Verifica se clicou na coluna de ações (editar)
                else if (gridOportunidades.Columns[e.ColumnIndex].Name == "colAcoes")
                {
                    // Pega o ID da vaga da linha clicada
                    var idVagaCell = gridOportunidades.Rows[e.RowIndex].Cells["id_vaga"];

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

                    // Abre o formulário de edição
                    using (var frmEditarVaga = new FrmAdicionarVaga(idVaga))
                    {
                        if (frmEditarVaga.ShowDialog() == DialogResult.OK)
                        {
                            CarregarVagas(); // Atualiza o grid após edição
                        }
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

        private void AbrirFormCandidatos(int idVaga)
        {
            try
            {
                using (var frmCandidatos = new FrmCandidatos(idVaga))
                {
                    this.Hide();
                    frmCandidatos.ShowDialog();
                    this.Show();
                    CarregarVagas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir candidatos: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Show();
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