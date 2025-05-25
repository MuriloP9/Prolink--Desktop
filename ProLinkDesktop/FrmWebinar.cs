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
            CarregarTheme();
            CarregarWebinars();
        }

        private void CarregarTheme()
        {
            this.BackColor = Color.FromArgb(34, 36, 49);
            dgvWebinars.BackgroundColor = Color.FromArgb(34, 36, 49);
            dgvWebinars.GridColor = Color.FromArgb(64, 64, 64);
            dgvWebinars.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            dgvWebinars.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvWebinars.RowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvWebinars.RowsDefaultCellStyle.ForeColor = Color.White;
            dgvWebinars.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            dgvWebinars.EnableHeadersVisualStyles = false;

            btnAdicionar.BackColor = Color.FromArgb(0, 126, 249);
            btnAdicionar.ForeColor = Color.White;
            btnAdicionar.FlatStyle = FlatStyle.Flat;
            btnAdicionar.FlatAppearance.BorderSize = 0;

            btnInativar.BackColor = Color.FromArgb(255, 80, 80);
            btnInativar.ForeColor = Color.White;
            btnInativar.FlatStyle = FlatStyle.Flat;
            btnInativar.FlatAppearance.BorderSize = 0;

            lblTitulo.ForeColor = Color.White;
            txtBusca.BackColor = Color.FromArgb(46, 51, 73);
            txtBusca.ForeColor = Color.White;
            txtBusca.BorderStyle = BorderStyle.FixedSingle;
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

        private void ConfigurarGrid()
        {
            dgvWebinars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWebinars.Columns["id_webinar"].Visible = false;

            if (dgvWebinars.Columns["link"] != null)
            {
                dgvWebinars.Columns["link"].DefaultCellStyle.ForeColor = Color.FromArgb(0, 126, 249);
                dgvWebinars.Columns["link"].DefaultCellStyle.Font = new Font(dgvWebinars.Font, FontStyle.Underline);
            }

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
            if (e.ColumnIndex == dgvWebinars.Columns["link"]?.Index && e.RowIndex >= 0)
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