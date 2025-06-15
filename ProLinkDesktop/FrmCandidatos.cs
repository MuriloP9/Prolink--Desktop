using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;

namespace ProLinkDesktop
{
    public partial class FrmCandidatos : Form
    {
        private ClasseConexao conexao = new ClasseConexao();
        private int idVaga;
        private const string ColunaEmail = "email";
        private const string ColunaIdUsuario = "id_usuario";
        private const string ColunaIdCandidatura = "id_candidatura";
        private DataTable dtCandidatos;

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
            btnFechar.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btnFechar.Cursor = Cursors.Hand;

            btnSalvar.BackColor = Color.FromArgb(67, 74, 105);
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.FlatAppearance.BorderSize = 0;
            btnSalvar.ForeColor = Color.White;
            btnSalvar.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btnSalvar.Cursor = Cursors.Hand;
            btnSalvar.Enabled = false;

            btnPDF.BackColor = Color.FromArgb(67, 74, 105);
            btnPDF.FlatStyle = FlatStyle.Flat;
            btnPDF.FlatAppearance.BorderSize = 0;
            btnPDF.ForeColor = Color.White;
            btnPDF.Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold);
            btnPDF.Cursor = Cursors.Hand;
            btnPDF.Enabled = false;
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
            gridCandidatos.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
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
                Name = "id_perfil",
                DataPropertyName = "id_perfil",
                HeaderText = "ID Perfil",
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
            colStatus.Items.AddRange("Pendente", "Aprovado", "Recusado");
            gridCandidatos.Columns.Add(colStatus);

            gridCandidatos.CellValueChanged += GridCandidatos_CellValueChanged;
            gridCandidatos.SelectionChanged += GridCandidatos_SelectionChanged;
            gridCandidatos.DataError += GridCandidatos_DataError;
        }
        private void CarregarCandidatos()
        {
            try
            {
                string sql = $@"SELECT c.{ColunaIdCandidatura}, u.{ColunaIdUsuario}, u.nome, u.{ColunaEmail}, 
                      p.formacao, c.status, p.id_perfil
                      FROM Candidatura c
                      INNER JOIN Perfil p ON c.id_perfil = p.id_perfil
                      INNER JOIN Usuario u ON p.{ColunaIdUsuario} = u.{ColunaIdUsuario}
                      WHERE c.id_vaga = {idVaga}";

                dtCandidatos = conexao.executarSQL(sql);

                if (dtCandidatos != null && dtCandidatos.Rows.Count > 0)
                {
                    gridCandidatos.DataSource = dtCandidatos;
                    btnPDF.Enabled = false;
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



        private void GridCandidatos_SelectionChanged(object sender, EventArgs e)
        {
            btnPDF.Enabled = gridCandidatos.SelectedRows.Count > 0;
        }

        private void GridCandidatos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridCandidatos.Columns[e.ColumnIndex].Name == "status")
            {
                btnSalvar.Enabled = true;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in gridCandidatos.Rows)
                {
                    if (row.IsNewRow) continue;

                    int idCandidatura = Convert.ToInt32(row.Cells[ColunaIdCandidatura].Value);
                    string novoStatus = row.Cells["status"].Value.ToString();

                    string sql = $"UPDATE Candidatura SET status = @status WHERE {ColunaIdCandidatura} = @idCandidatura";

                    SqlCommand cmd = new SqlCommand(sql);
                    cmd.Parameters.AddWithValue("@status", novoStatus);
                    cmd.Parameters.AddWithValue("@idCandidatura", idCandidatura);

                    int linhasAfetadas = conexao.manutencaoDB_Parametros(cmd);

                    if (linhasAfetadas <= 0)
                    {
                        MessageBox.Show($"Erro ao atualizar status para candidatura ID {idCandidatura}", "Erro",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                MessageBox.Show("Status dos candidatos atualizados com sucesso!", "Sucesso",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSalvar.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar status: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable ObterDadosCompletosPerfil(int idPerfil)
        {
            string sql = $@"SELECT p.*, u.nome, u.email 
                          FROM Perfil p
                          INNER JOIN Usuario u ON p.id_usuario = u.id_usuario
                          WHERE p.id_perfil = {idPerfil}";
            return conexao.executarSQL(sql);
        }
        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (gridCandidatos.SelectedRows.Count == 0) return;

            try
            {
                DataGridViewRow row = gridCandidatos.SelectedRows[0];
                int idPerfil = Convert.ToInt32(row.Cells["id_perfil"].Value);

                DataTable dtPerfil = ObterDadosCompletosPerfil(idPerfil);
                if (dtPerfil == null || dtPerfil.Rows.Count == 0)
                {
                    MessageBox.Show("Dados do perfil não encontrados.", "Erro",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataRow perfil = dtPerfil.Rows[0];
                string nome = perfil["nome"].ToString();
                string email = perfil["email"].ToString();

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                saveFileDialog.FileName = $"Curriculo_{nome.Replace(" ", "_")}.pdf";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    GerarPDFProfissional(perfil, saveFileDialog.FileName);
                    Process.Start(saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar PDF: {ex.Message}", "Erro",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GerarPDFProfissional(DataRow perfil, string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                Document doc = new Document(PageSize.A4, 40, 40, 40, 40);
                PdfWriter writer = PdfWriter.GetInstance(doc, fs);

                doc.Open();

                // Configurações de estilo
                iTextSharp.text.Font fonteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 24, new BaseColor(44, 62, 80));
                iTextSharp.text.Font fonteSecao = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, new BaseColor(44, 62, 80));
                iTextSharp.text.Font fonteSubSecao = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);
                iTextSharp.text.Font fonteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);
                iTextSharp.text.Font fonteRodape = FontFactory.GetFont(FontFactory.HELVETICA, 10, new BaseColor(119, 119, 119));

                // Cabeçalho
                Paragraph cabecalho = new Paragraph(perfil["nome"].ToString(), fonteTitulo);
                cabecalho.Alignment = Element.ALIGN_LEFT;
                cabecalho.SpacingAfter = 5f;
                doc.Add(cabecalho);

                Paragraph subtitulo = new Paragraph("Perfil profissional", fonteNormal);
                subtitulo.Alignment = Element.ALIGN_LEFT;
                subtitulo.SpacingAfter = 20f;
                doc.Add(subtitulo);

                // Linha divisória
                PdfPTable linhaDivisoria = new PdfPTable(1);
                linhaDivisoria.WidthPercentage = 100;
                PdfPCell cell = new PdfPCell(new Phrase(" "));
                cell.Border = PdfPCell.BOTTOM_BORDER;
                cell.BorderColor = new BaseColor(44, 62, 80);
                cell.BorderWidth = 2f;
                cell.FixedHeight = 15f;
                linhaDivisoria.AddCell(cell);
                doc.Add(linhaDivisoria);

                // Seção Dados Pessoais
                AdicionarSecao(doc, "Informações Pessoais", fonteSecao);

                PdfPTable tabelaDados = new PdfPTable(2);
                tabelaDados.WidthPercentage = 100;
                tabelaDados.SetWidths(new float[] { 30, 70 });
                tabelaDados.SpacingAfter = 15f;

                AdicionarCelulaInfo(tabelaDados, "Nome:", perfil["nome"].ToString(), fonteSubSecao, fonteNormal);
                AdicionarCelulaInfo(tabelaDados, "E-mail:", perfil["email"].ToString(), fonteSubSecao, fonteNormal);

                if (!string.IsNullOrEmpty(perfil["idade"].ToString()))
                    AdicionarCelulaInfo(tabelaDados, "Idade:", perfil["idade"].ToString(), fonteSubSecao, fonteNormal);

                AdicionarCelulaInfo(tabelaDados, "Endereço:", perfil["endereco"].ToString(), fonteSubSecao, fonteNormal);

                if (perfil.Table.Columns.Contains("dataNascimento") && !string.IsNullOrEmpty(perfil["dataNascimento"].ToString()))
                    AdicionarCelulaInfo(tabelaDados, "Data de Nascimento:", perfil["dataNascimento"].ToString(), fonteSubSecao, fonteNormal);

                if (perfil.Table.Columns.Contains("telefone") && !string.IsNullOrEmpty(perfil["telefone"].ToString()))
                    AdicionarCelulaInfo(tabelaDados, "Telefone:", perfil["telefone"].ToString(), fonteSubSecao, fonteNormal);

                doc.Add(tabelaDados);

                // Seção Formação
                if (!string.IsNullOrEmpty(perfil["formacao"].ToString()))
                {
                    AdicionarSecao(doc, "Formação Acadêmica", fonteSecao);
                    Paragraph formacao = new Paragraph(FormatarTexto(perfil["formacao"].ToString()), fonteNormal);
                    formacao.SpacingAfter = 15f;
                    doc.Add(formacao);
                }

                // Seção Experiência Profissional
                if (!string.IsNullOrEmpty(perfil["experiencia_profissional"].ToString()))
                {
                    AdicionarSecao(doc, "Experiência Profissional", fonteSecao);
                    Paragraph experiencia = new Paragraph(FormatarTexto(perfil["experiencia_profissional"].ToString()), fonteNormal);
                    experiencia.SpacingAfter = 15f;
                    doc.Add(experiencia);
                }

                // Seção Habilidades
                if (!string.IsNullOrEmpty(perfil["habilidades"].ToString()))
                {
                    AdicionarSecao(doc, "Habilidades", fonteSecao);
                    Paragraph habilidades = new Paragraph(FormatarTexto(perfil["habilidades"].ToString()), fonteNormal);
                    habilidades.SpacingAfter = 15f;
                    doc.Add(habilidades);
                }

                // Seção Projetos e Especializações
                if (!string.IsNullOrEmpty(perfil["projetos_especializacoes"].ToString()))
                {
                    AdicionarSecao(doc, "Projetos e Especializações", fonteSecao);
                    Paragraph projetos = new Paragraph(FormatarTexto(perfil["projetos_especializacoes"].ToString()), fonteNormal);
                    projetos.SpacingAfter = 15f;
                    doc.Add(projetos);
                }

                // Seção Interesses
                if (!string.IsNullOrEmpty(perfil["interesses"].ToString()))
                {
                    AdicionarSecao(doc, "Interesses", fonteSecao);
                    Paragraph interesses = new Paragraph(FormatarTexto(perfil["interesses"].ToString()), fonteNormal);
                    interesses.SpacingAfter = 15f;
                    doc.Add(interesses);
                }

                // Rodapé
                Paragraph rodape = new Paragraph($"Gerado em {DateTime.Now.ToString("dd/MM/yyyy HH:mm")}", fonteRodape);
                rodape.Alignment = Element.ALIGN_CENTER;
                rodape.SpacingBefore = 30f;
                doc.Add(rodape);

                doc.Close();
            }
        }

        private string FormatarTexto(string texto)
        {
            // Substitui quebras de linha para manter a formatação
            return texto.Replace("\n", Environment.NewLine);
        }

        private void AdicionarSecao(Document doc, string titulo, iTextSharp.text.Font fonte)
        {
            Paragraph secao = new Paragraph(titulo, fonte);
            secao.SpacingBefore = 20f;
            secao.SpacingAfter = 10f;
            doc.Add(secao);

            // Linha divisória fina
            PdfPTable linha = new PdfPTable(1);
            linha.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell(new Phrase(" "));
            cell.Border = PdfPCell.BOTTOM_BORDER;
            cell.BorderColor = new BaseColor(238, 238, 238);
            cell.BorderWidth = 1f;
            cell.FixedHeight = 10f;
            linha.AddCell(cell);
            doc.Add(linha);
        }

        private void AdicionarCelulaInfo(PdfPTable tabela, string titulo, string conteudo, iTextSharp.text.Font fonteTitulo, iTextSharp.text.Font fonteConteudo)
        {
            PdfPCell cellTitulo = new PdfPCell(new Phrase(titulo, fonteTitulo));
            cellTitulo.Border = PdfPCell.NO_BORDER;
            cellTitulo.HorizontalAlignment = Element.ALIGN_LEFT;
            tabela.AddCell(cellTitulo);

            PdfPCell cellConteudo = new PdfPCell(new Phrase(conteudo, fonteConteudo));
            cellConteudo.Border = PdfPCell.NO_BORDER;
            cellConteudo.HorizontalAlignment = Element.ALIGN_LEFT;
            tabela.AddCell(cellConteudo);
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