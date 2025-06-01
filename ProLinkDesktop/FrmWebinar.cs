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
            CarregarWebinars();
            VerificarWebinarsExpirados();
        }

        private void CarregarWebinars()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SELECT id_webinar, tema, FORMAT(data_hora, 'dd/MM/yyyy HH:mm') as data_hora, palestrante, link FROM Webinar WHERE ativo = 1 ORDER BY data_hora DESC", connection))
                {
                    connection.Open();
                    var adapter = new SqlDataAdapter(cmd);
                    var dt = new DataTable();
                    adapter.Fill(dt);

                    dgvWebinars.DataSource = dt;
                    ConfigurarGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar webinars: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerificarWebinarsExpirados()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("UPDATE Webinar SET ativo = 0 WHERE ativo = 1 AND data_hora < GETDATE()", connection))
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
                MessageBox.Show($"Erro ao verificar webinars expirados: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            dgvWebinars.Columns["id_webinar"].Visible = false;

            if (dgvWebinars.Columns["link"] != null)
            {
                dgvWebinars.Columns["link"].DefaultCellStyle.ForeColor = Color.FromArgb(0, 126, 249);
                dgvWebinars.Columns["link"].DefaultCellStyle.Font = new Font(dgvWebinars.Font, FontStyle.Underline);
            }

            // Configurar estilo das células
            dgvWebinars.DefaultCellStyle.BackColor = Color.FromArgb(32, 36, 55);
            dgvWebinars.DefaultCellStyle.ForeColor = Color.White;
            dgvWebinars.DefaultCellStyle.SelectionBackColor = Color.FromArgb(67, 74, 105);
            dgvWebinars.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvWebinars.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            dgvWebinars.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvWebinars.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 51, 73);

            dgvWebinars.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(40, 45, 65);

            dgvWebinars.ClearSelection();
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
                MessageBox.Show("Selecione um webinar para editar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Selecione um webinar para inativar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    using (var cmd = new SqlCommand("UPDATE Webinar SET ativo = 0 WHERE id_webinar = @id", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        CarregarWebinars();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao inativar webinar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvWebinars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvWebinars.Columns["link"]?.Index)
            {
                var link = dgvWebinars.Rows[e.RowIndex].Cells["link"].Value.ToString();
                if (!string.IsNullOrEmpty(link))
                {
                    try
                    {
                        System.Diagnostics.Process.Start(link);
                    }
                    catch
                    {
                        MessageBox.Show("Não foi possível abrir o link", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtBusca_TextChanged(object sender, EventArgs e)
        {
            if (dgvWebinars.DataSource is DataTable dt)
            {
                dt.DefaultView.RowFilter = $"tema LIKE '%{txtBusca.Text}%' OR palestrante LIKE '%{txtBusca.Text}%'";
            }
        }
    }
}