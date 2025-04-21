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
            // Configuração básica do DataGridView
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

            // Botão de Detalhes
            var btnDetalhes = new DataGridViewButtonColumn()
            {
                Text = "Editar",
                UseColumnTextForButtonValue = true,
                HeaderText = "Ações",
                Width = 80
            };
            gridOportunidades.Columns.Add(btnDetalhes);
        }

        private void CarregarVagas()
        {
            try
            {
                string sql = @"SELECT v.id_vaga, v.titulo_vaga, v.localizacao, v.tipo_emprego, 
                             a.nome_area, v.empresa, f.nome_completo AS cadastrado_por
                             FROM Vagas v
                             INNER JOIN AreaAtuacao a ON v.id_area = a.id_area
                             INNER JOIN Funcionario f ON v.id_func = f.id_funcionario";

                DataTable dt = conexao.executarSQL(sql);
                gridOportunidades.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar vagas: " + ex.Message, "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            FrmAdicionarVaga formAdicionar = new FrmAdicionarVaga();
            if (formAdicionar.ShowDialog() == DialogResult.OK)
            {
                CarregarVagas(); // Recarrega as vagas após adicionar uma nova
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarVagas();
        }

        }
    }
