using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ProLinkDesktop
{
    public partial class FrmCandidatos : Form
    {
        private ClasseConexao conexao;
        private int idVaga;

        public FrmCandidatos(int idVaga)
        {
            InitializeComponent();
            conexao = new ClasseConexao();
            this.idVaga = idVaga;
            ConfigurarGrid();
            CarregarCandidatos();
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

            // Estilo do cabeçalho
            gridCandidatos.EnableHeadersVisualStyles = false;
            gridCandidatos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
            gridCandidatos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            gridCandidatos.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);

            // Definindo as colunas
            gridCandidatos.Columns.Clear();

            // Coluna Nome
            gridCandidatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "nome",
                HeaderText = "Nome",
                Width = 200
            });

            // Coluna Email
            gridCandidatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "email",
                HeaderText = "Email",
                Width = 200
            });

            // Coluna Formação
            gridCandidatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "formacao",
                HeaderText = "Formação",
                Width = 250
            });

            // Coluna Status
            gridCandidatos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "status",
                HeaderText = "Status",
                Width = 100
            });
        }

        private void CarregarCandidatos()
        {
            try
            {
                string sql = $@"SELECT u.nome, u.email, p.formacao, c.status
                             FROM Candidatura c
                             INNER JOIN Perfil p ON c.id_perfil = p.id_perfil
                             INNER JOIN Usuario u ON p.id_usuario = u.id_usuario
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
