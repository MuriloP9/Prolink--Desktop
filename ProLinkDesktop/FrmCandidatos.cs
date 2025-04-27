using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace ProLinkDesktop
{
    public partial class FrmCandidatos : Form
    {
        private ClasseConexao conexao;
        private int idVaga;
        private const string ColunaEmail = "email";
        private const string ColunaIdUsuario = "id_usuario";

        public FrmCandidatos(int idVaga)
        {
            InitializeComponent();
            conexao = new ClasseConexao();
            this.idVaga = idVaga;
            ConfigurarDesign();
            ConfigurarGrid();
            CarregarCandidatos();
        }

        private void ConfigurarDesign()
        {
            // Configuração do formulário
            this.BackColor = Color.FromArgb(32, 36, 55);
            this.ForeColor = Color.White;

            // Configuração do botão
            btnFechar.BackColor = Color.FromArgb(67, 74, 105);
            btnFechar.FlatStyle = FlatStyle.Flat;
            btnFechar.FlatAppearance.BorderSize = 0;
            btnFechar.ForeColor = Color.White;
            btnFechar.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btnFechar.Cursor = Cursors.Hand;
        }

        private void ConfigurarGrid()
        {
            gridCandidatos.AutoGenerateColumns = false;
            gridCandidatos.AllowUserToAddRows = false;
            gridCandidatos.AllowUserToDeleteRows = false;
            gridCandidatos.ReadOnly = true;
            gridCandidatos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridCandidatos.MultiSelect = false;
            gridCandidatos.RowHeadersVisible = false;

            // Estilo do grid no padrão escuro
            gridCandidatos.BackgroundColor = Color.FromArgb(32, 36, 55);
            gridCandidatos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            gridCandidatos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

            // Configuração segura da fonte
            try
            {
                gridCandidatos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
            }
            catch
            {
                gridCandidatos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold);
            }

            gridCandidatos.DefaultCellStyle.BackColor = Color.FromArgb(32, 36, 55);
            gridCandidatos.DefaultCellStyle.ForeColor = Color.White;
            gridCandidatos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(67, 74, 105);
            gridCandidatos.DefaultCellStyle.SelectionForeColor = Color.White;
            gridCandidatos.EnableHeadersVisualStyles = false;
            gridCandidatos.GridColor = Color.FromArgb(67, 74, 105);

            // Definindo as colunas
            gridCandidatos.Columns.Clear();

            // Coluna ID (oculta)
            gridCandidatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = ColunaIdUsuario,
                DataPropertyName = ColunaIdUsuario,
                HeaderText = "ID",
                Visible = false
            });

            // Coluna Nome
            gridCandidatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "nome",
                DataPropertyName = "nome",
                HeaderText = "Nome",
                Width = 200
            });

            // Coluna Email
            gridCandidatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = ColunaEmail,
                DataPropertyName = ColunaEmail,
                HeaderText = "Email",
                Width = 200
            });

            // Coluna Formação
            gridCandidatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "formacao",
                DataPropertyName = "formacao",
                HeaderText = "Formação",
                Width = 200
            });

            // Coluna Status
            gridCandidatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "status",
                DataPropertyName = "status",
                HeaderText = "Status",
                Width = 100
            });

            // Coluna Ações (Exportar Relatório)
            var btnExportar = new DataGridViewButtonColumn()
            {
                Name = "colExportar",
                HeaderText = "Ações",
                Text = "Exportar Relatório",
                UseColumnTextForButtonValue = true,
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    BackColor = Color.FromArgb(0, 123, 255),
                    ForeColor = Color.White,
                    SelectionBackColor = Color.FromArgb(0, 123, 255),
                    SelectionForeColor = Color.White,
                    Font = new System.Drawing.Font("Segoe UI", 8, FontStyle.Bold)
                }
            };
            gridCandidatos.Columns.Add(btnExportar);

            // Configurar evento de clique
            gridCandidatos.CellClick += GridCandidatos_CellClick;
        }

        private void GridCandidatos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (gridCandidatos.Columns[e.ColumnIndex].Name == "colExportar")
            {
                if (gridCandidatos.Columns.Contains(ColunaEmail) &&
                    gridCandidatos.Rows[e.RowIndex].Cells[ColunaEmail].Value != null)
                {
                    string email = gridCandidatos.Rows[e.RowIndex].Cells[ColunaEmail].Value.ToString();
                    ExportarRelatorioPDF(email);
                }
                else
                {
                    MessageBox.Show("Não foi possível identificar o email do candidato.", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CarregarCandidatos()
        {
            try
            {
                string sql = $@"SELECT u.{ColunaIdUsuario}, u.nome, u.{ColunaEmail}, p.formacao, c.status
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

        private void ExportarRelatorioPDF(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email do candidato não foi fornecido.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string sql = $@"SELECT u.*, p.* 
                            FROM Usuario u
                            INNER JOIN Perfil p ON u.{ColunaIdUsuario} = p.{ColunaIdUsuario}
                            WHERE u.{ColunaEmail} = '{email}'";

                DataTable dt = conexao.executarSQL(sql);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Dados do candidato não encontrados.", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow candidato = dt.Rows[0];
                string nomeArquivo = $"Curriculo_{candidato["nome"].ToString().Replace(" ", "_")}.pdf";
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nomeArquivo);

                using (Document doc = new Document(PageSize.A4))
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                    doc.Open();

                    AdicionarLogo(doc);

                    // Título do documento
                    Paragraph titulo = new Paragraph("ProLink - Relatório de Candidato",
                        FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.DARK_GRAY));
                    titulo.Alignment = Element.ALIGN_CENTER;
                    titulo.SpacingAfter = 15;
                    doc.Add(titulo);

                    // Linha divisória
                    doc.Add(new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, BaseColor.GRAY, Element.ALIGN_CENTER, 1))));

                    // Seção de Dados Pessoais
                    AdicionarSecao(doc, "DADOS PESSOAIS");

                    // Tabela de dados pessoais
                    PdfPTable tabelaDados = new PdfPTable(2);
                    tabelaDados.WidthPercentage = 100;
                    tabelaDados.SetWidths(new float[] { 30, 70 });

                    AdicionarCelula(tabelaDados, "Nome:", candidato["nome"].ToString());
                    AdicionarCelula(tabelaDados, "Email:", candidato[ColunaEmail].ToString());
                    AdicionarCelula(tabelaDados, "Telefone:", ObterValorOuPadrao(candidato["telefone"]));
                    AdicionarCelula(tabelaDados, "Data Nascimento:",
                        candidato["dataNascimento"] != DBNull.Value ?
                        Convert.ToDateTime(candidato["dataNascimento"]).ToString("dd/MM/yyyy") : "Não informada");
                    AdicionarCelula(tabelaDados, "Endereço:", ObterValorOuPadrao(candidato["endereco"]));

                    doc.Add(tabelaDados);

                    // Seções de informações
                    AdicionarSecaoComConteudo(doc, "FORMAÇÃO ACADÊMICA", candidato["formacao"]);
                    AdicionarSecaoComConteudo(doc, "EXPERIÊNCIA PROFISSIONAL", candidato["experiencia_profissional"]);
                    AdicionarSecaoComConteudo(doc, "HABILIDADES", candidato["habilidades"]);
                    AdicionarSecaoComConteudo(doc, "PROJETOS E ESPECIALIZAÇÕES", candidato["projetos_especializacoes"]);

                    // Rodapé
                    AdicionarRodape(doc);
                }

                MessageBox.Show($"Relatório exportado com sucesso para:\n{filePath}", "Sucesso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar relatório: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdicionarLogo(Document doc)
        {
            try
            {
                // Verifica se o recurso existe
                var logoResource = Properties.Resources.ResourceManager.GetObject("globo_mundial");
                if (logoResource != null)
                {
                    using (var ms = new MemoryStream((byte[])logoResource))
                    {
                        var logo = iTextSharp.text.Image.GetInstance(ms);
                        logo.ScaleToFit(100f, 100f);
                        logo.Alignment = Element.ALIGN_CENTER;
                        doc.Add(logo);
                        doc.Add(new Paragraph(" "));
                    }
                }
                else
                {
                    AdicionarLogoTituloFallback(doc);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao adicionar logo: {ex.Message}");
                AdicionarLogoTituloFallback(doc);
            }
        }

        private void AdicionarLogoTituloFallback(Document doc)
        {
            Paragraph logoPlaceholder = new Paragraph("ProLink",
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, BaseColor.BLUE));
            logoPlaceholder.Alignment = Element.ALIGN_CENTER;
            doc.Add(logoPlaceholder);
        }

        private void AdicionarSecao(Document doc, string titulo)
        {
            Paragraph secao = new Paragraph(titulo,
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14, BaseColor.DARK_GRAY));
            secao.SpacingBefore = 20;
            secao.SpacingAfter = 10;
            doc.Add(secao);
        }

        private void AdicionarSecaoComConteudo(Document doc, string titulo, object conteudo)
        {
            AdicionarSecao(doc, titulo);
            doc.Add(new Paragraph(ObterValorOuPadrao(conteudo),
                FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
        }

        private string ObterValorOuPadrao(object valor, string padrao = "Não informado")
        {
            return valor != null && valor != DBNull.Value ? valor.ToString() : padrao;
        }

        private void AdicionarCelula(PdfPTable table, string label, string value)
        {
            PdfPCell cellLabel = new PdfPCell(new Phrase(label,
                FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK)));
            cellLabel.Border = PdfPCell.NO_BORDER;
            cellLabel.Padding = 5;
            cellLabel.HorizontalAlignment = Element.ALIGN_RIGHT;
            table.AddCell(cellLabel);

            PdfPCell cellValue = new PdfPCell(new Phrase(value,
                FontFactory.GetFont(FontFactory.HELVETICA, 12, BaseColor.BLACK)));
            cellValue.Border = PdfPCell.NO_BORDER;
            cellValue.Padding = 5;
            table.AddCell(cellValue);
        }

        private void AdicionarRodape(Document doc)
        {
            Paragraph rodape = new Paragraph($"Gerado em: {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}",
                FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10, BaseColor.GRAY));
            rodape.Alignment = Element.ALIGN_RIGHT;
            rodape.SpacingBefore = 20;
            doc.Add(rodape);
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}