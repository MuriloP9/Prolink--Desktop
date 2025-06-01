using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ProLinkDesktop
{
    public partial class FrmAdicionarWebinar : Form
    {
        private readonly string _connectionString = "Password=etesp; Persist Security Info=True; User ID=sa; Initial Catalog=prolink01; Data Source=" + Environment.MachineName;
        private int _webinarId = -1;
        private bool _modoEdicao = false;

        public FrmAdicionarWebinar()
        {
            InitializeComponent();
            this.AcceptButton = btnSalvar;
        }

        public FrmAdicionarWebinar(int webinarId) : this()
        {
            _webinarId = webinarId;
            _modoEdicao = true;
            this.Text = "Editar Webinar";
            CarregarDadosWebinar();
        }

        private void CarregarDadosWebinar()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand("SELECT tema, data_hora, palestrante, link, descricao FROM Webinar WHERE id_webinar = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", _webinarId);
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            txtTema.Text = reader["tema"].ToString();
                            dtpDataHora.Value = Convert.ToDateTime(reader["data_hora"]);
                            txtPalestrante.Text = reader["palestrante"].ToString();
                            txtLink.Text = reader["link"].ToString();
                            txtDescricao.Text = reader["descricao"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados do webinar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    using (var connection = new SqlConnection(_connectionString))
                    {
                        string query;
                        if (_modoEdicao)
                        {
                            query = "UPDATE Webinar SET tema = @tema, data_hora = @data_hora, " +
                                    "palestrante = @palestrante, link = @link, descricao = @descricao " +
                                    "WHERE id_webinar = @id";
                        }
                        else
                        {
                            query = "INSERT INTO Webinar (tema, data_hora, palestrante, link, descricao, ativo) " +
                                    "VALUES (@tema, @data_hora, @palestrante, @link, @descricao, 1)";
                        }

                        using (var cmd = new SqlCommand(query, connection))
                        {
                            cmd.Parameters.AddWithValue("@tema", txtTema.Text);
                            cmd.Parameters.AddWithValue("@data_hora", dtpDataHora.Value);
                            cmd.Parameters.AddWithValue("@palestrante", txtPalestrante.Text);
                            cmd.Parameters.AddWithValue("@link", txtLink.Text);
                            cmd.Parameters.AddWithValue("@descricao", txtDescricao.Text);

                            if (_modoEdicao)
                            {
                                cmd.Parameters.AddWithValue("@id", _webinarId);
                            }

                            connection.Open();
                            cmd.ExecuteNonQuery();

                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
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
                txtTema.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtPalestrante.Text))
            {
                MessageBox.Show("Informe o nome do palestrante", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPalestrante.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLink.Text) || !txtLink.Text.StartsWith("http"))
            {
                MessageBox.Show("Informe um link válido (deve começar com http)", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLink.Focus();
                return false;
            }

            return true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void txtTema_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtpDataHora.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void dtpDataHora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPalestrante.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtPalestrante_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLink.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtLink_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDescricao.Focus();
                e.SuppressKeyPress = true;
            }
        }

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !txtDescricao.Text.EndsWith(Environment.NewLine))
            {
                btnSalvar.PerformClick();
                e.SuppressKeyPress = true;
            }
        }
    }
}