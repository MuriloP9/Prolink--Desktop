using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProLinkDesktop
{
    public partial class FrmAdicionarWebinar : Form
    {
        private readonly string _connectionString = "Password=etesp; Persist Security Info=True; User ID=sa; Initial Catalog=prolink01; Data Source=" + Environment.MachineName;

        public FrmAdicionarWebinar()
        {
            InitializeComponent();
            CarregarTheme();
        }

        private void CarregarTheme()
        {
            this.BackColor = Color.FromArgb(34, 36, 49);

            lblTitulo.ForeColor = Color.White;
            lblTema.ForeColor = Color.White;
            lblDataHora.ForeColor = Color.White;
            lblPalestrante.ForeColor = Color.White;
            lblLink.ForeColor = Color.White;
            lblDescricao.ForeColor = Color.White;

            txtTema.BackColor = Color.FromArgb(46, 51, 73);
            txtTema.ForeColor = Color.White;
            txtTema.BorderStyle = BorderStyle.FixedSingle;

            dtpDataHora.CalendarMonthBackground = Color.FromArgb(46, 51, 73);
            dtpDataHora.CalendarTitleBackColor = Color.FromArgb(46, 51, 73);
            dtpDataHora.CalendarTitleForeColor = Color.White;
            dtpDataHora.CalendarTrailingForeColor = Color.Gray;

            txtPalestrante.BackColor = Color.FromArgb(46, 51, 73);
            txtPalestrante.ForeColor = Color.White;
            txtPalestrante.BorderStyle = BorderStyle.FixedSingle;

            txtLink.BackColor = Color.FromArgb(46, 51, 73);
            txtLink.ForeColor = Color.White;
            txtLink.BorderStyle = BorderStyle.FixedSingle;

            txtDescricao.BackColor = Color.FromArgb(46, 51, 73);
            txtDescricao.ForeColor = Color.White;
            txtDescricao.BorderStyle = BorderStyle.FixedSingle;

            btnSalvar.BackColor = Color.FromArgb(0, 126, 249);
            btnSalvar.ForeColor = Color.White;
            btnSalvar.FlatStyle = FlatStyle.Flat;
            btnSalvar.FlatAppearance.BorderSize = 0;

            btnCancelar.BackColor = Color.FromArgb(255, 80, 80);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.FlatAppearance.BorderSize = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    using (var connection = new SqlConnection(_connectionString))
                    using (var cmd = new SqlCommand(
                        "INSERT INTO Webinar (tema, data_hora, palestrante, link, descricao, ativo) " +
                        "VALUES (@tema, @data_hora, @palestrante, @link, @descricao, 1)", connection))
                    {
                        cmd.Parameters.AddWithValue("@tema", txtTema.Text);
                        cmd.Parameters.AddWithValue("@data_hora", dtpDataHora.Value);
                        cmd.Parameters.AddWithValue("@palestrante", txtPalestrante.Text);
                        cmd.Parameters.AddWithValue("@link", txtLink.Text);
                        cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);

                        connection.Open();
                        cmd.ExecuteNonQuery();

                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar webinar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtTema.Text))
            {
                MessageBox.Show("Informe o tema do webinar", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPalestrante.Text))
            {
                MessageBox.Show("Informe o nome do palestrante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLink.Text) || !txtLink.Text.StartsWith("http"))
            {
                MessageBox.Show("Informe um link válido (deve começar com http)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}