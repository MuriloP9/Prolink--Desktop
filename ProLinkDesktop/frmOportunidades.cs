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
            ConfigurarDesign();
            ConfigurarGrid();
            CarregarVagas();
        }

        private void ConfigurarDesign()
        {
            // Configuração do formulário
            this.BackColor = Color.FromArgb(32, 36, 55);
            this.ForeColor = Color.White;

            // Configuração dos botões
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
            gridOportunidades.AllowUserToAddRows = false;
            gridOportunidades.AllowUserToDeleteRows = false;
            gridOportunidades.ReadOnly = true;
            gridOportunidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridOportunidades.MultiSelect = false;
            gridOportunidades.RowHeadersVisible = false;

            // Estilo do grid no padrão escuro
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

            // Definindo as colunas
            gridOportunidades.Columns.Clear();

            // Coluna ID (oculta)
            gridOportunidades.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "id_vaga",
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
                    Bitmap bmp = new Bitmap(120, 20);

                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        // Desenha o fundo transparente
                        g.Clear(Color.Transparent);

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
                            g.FillEllipse(Brushes.LightBlue, 5, 2, 16, 16);
                        }

                        // Desenha o número de candidatos ao lado do ícone
                        using (var font = new Font("Segoe UI", 8, FontStyle.Regular))
                        {
                            g.DrawString(totalCandidatos.ToString(),
                                        font,
                                        Brushes.White,
                                        new PointF(25, 3));
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
                else if (gridOportunidades.Columns[e.ColumnIndex].Name == "colAcoes")
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

                    using (var frmEditarVaga = new FrmAdicionarVaga(idVaga))
                    {
                        if (frmEditarVaga.ShowDialog() == DialogResult.OK)
                        {
                            CarregarVagas();
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