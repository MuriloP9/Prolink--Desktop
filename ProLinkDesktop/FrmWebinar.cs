using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProLinkDesktop
{
    public partial class FrmWebinar : Form
    {
        private readonly string _connectionString = "Password=etesp; Persist Security Info=True; User ID=sa; Initial Catalog=prolink01; Data Source=" + Environment.MachineName;

        public FrmWebinar()
        {
            InitializeComponent();
            ConfigurarGrid();
            CarregarWebinars();
            VerificarWebinarsExpirados();
        }

        private void ConfigurarGrid()
        {
            dgvWebinars.AutoGenerateColumns = false;
            dgvWebinars.AllowUserToAddRows = false;
            dgvWebinars.AllowUserToDeleteRows = false;
            dgvWebinars.ReadOnly = true;
            dgvWebinars.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvWebinars.MultiSelect = false;
            dgvWebinars.RowHeadersVisible = false;

            // Estilo do grid no padrão escuro
            dgvWebinars.BackgroundColor = Color.FromArgb(32, 36, 55);
            dgvWebinars.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            dgvWebinars.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvWebinars.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            dgvWebinars.DefaultCellStyle.BackColor = Color.FromArgb(32, 36, 55);
            dgvWebinars.DefaultCellStyle.ForeColor = Color.White;
            dgvWebinars.DefaultCellStyle.SelectionBackColor = Color.FromArgb(67, 74, 105);
            dgvWebinars.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvWebinars.EnableHeadersVisualStyles = false;
            dgvWebinars.GridColor = Color.FromArgb(67, 74, 105);

            // Definindo as colunas
            dgvWebinars.Columns.Clear();

            // Coluna ID (oculta)
            dgvWebinars.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "id_webinar",
                DataPropertyName = "id_webinar",
                HeaderText = "ID",
                Visible = false
            });

            // Coluna Tema
            dgvWebinars.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "tema",
                DataPropertyName = "tema",
                HeaderText = "Tema do Webinar",
                Width = 200
            });

            // Coluna Data e Hora
            dgvWebinars.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "data_hora",
                DataPropertyName = "data_hora",
                HeaderText = "Data e Hora",
                Width = 150
            });

            // Coluna Palestrante
            dgvWebinars.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "palestrante",
                DataPropertyName = "palestrante",
                HeaderText = "Palestrante",
                Width = 180
            });

            // Coluna Link
            var colLink = new DataGridViewLinkColumn()
            {
                Name = "link",
                DataPropertyName = "link",
                HeaderText = "Link de Acesso",
                Width = 150,
                ActiveLinkColor = Color.FromArgb(0, 126, 249),
                LinkBehavior = LinkBehavior.SystemDefault,
                LinkColor = Color.FromArgb(0, 126, 249),
                VisitedLinkColor = Color.FromArgb(0, 126, 249)
            };
            dgvWebinars.Columns.Add(colLink);

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
                    SelectionForeColor = Color.White,
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            };
            dgvWebinars.Columns.Add(btnAcoes);
        }

        private void CarregarWebinars()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "SELECT id_webinar, tema, FORMAT(data_hora, 'dd/MM/yyyy HH:mm') as data_hora, " +
                    "palestrante, link FROM Webinar WHERE ativo = 1 ORDER BY data_hora DESC", connection))
                {
                    connection.Open();
                    var adapter = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvWebinars.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar webinars: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerificarWebinarsExpirados()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    "UPDATE Webinar SET ativo = 0 WHERE ativo = 1 AND data_hora < GETDATE()", connection))
                {
                    connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        CarregarWebinars();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao verificar webinars expirados: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var frm = new FrmAdicionarWebinar();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CarregarWebinars();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvWebinars.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um webinar para editar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var id = Convert.ToInt32(dgvWebinars.SelectedRows[0].Cells["id_webinar"].Value);
            var frm = new FrmAdicionarWebinar(id);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                CarregarWebinars();
            }
        }

        private void btnInativar_Click(object sender, EventArgs e)
        {
            if (dgvWebinars.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um webinar para inativar", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var id = Convert.ToInt32(dgvWebinars.SelectedRows[0].Cells["id_webinar"].Value);
            var tema = dgvWebinars.SelectedRows[0].Cells["tema"].Value.ToString();

            if (MessageBox.Show($"Deseja realmente inativar o webinar '{tema}'?", "Confirmação",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new SqlConnection(_connectionString))
                    using (var cmd = new SqlCommand(
                        "UPDATE Webinar SET ativo = 0 WHERE id_webinar = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        CarregarWebinars();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao inativar webinar: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvWebinars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // Clicou no link
            if (e.ColumnIndex == dgvWebinars.Columns["link"]?.Index)
            {
                var link = dgvWebinars.Rows[e.RowIndex].Cells["link"].Value?.ToString();
                if (!string.IsNullOrEmpty(link))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(link);
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível abrir o link", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // Clicou no botão de ações
            else if (e.ColumnIndex == dgvWebinars.Columns["colAcoes"]?.Index)
            {
                btnEditar.PerformClick();
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            if (dgvWebinars.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = $"tema LIKE '%{txtBusca.Text}%' OR " +
                                          $"palestrante LIKE '%{txtBusca.Text}%' OR " +
                                          $"data_hora LIKE '%{txtBusca.Text}%'";
            }
        }
    }
}