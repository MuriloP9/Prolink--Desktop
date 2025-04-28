using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProLinkDesktop
{
    public partial class formDashboard : Form
    {
        private string connectionString = "Password=etesp; Persist Security Info=True; User ID=sa; Initial Catalog=Prolink; Data Source=" + Environment.MachineName;
        private Form1 _formPrincipal;

        public formDashboard(Form1 formPrincipal)
        {
            InitializeComponent();
            _formPrincipal = formPrincipal;
            CarregarUltimoAcessoAdm();
            CarregarNumeroEmpresas();
            CarregarNumeroUsuarios();
            AtualizarStatusUsuarios(); // Novo método adicionado
        }

        private void CarregarUltimoAcessoAdm()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"SELECT TOP 1 F.email, F.ultimo_acesso, F.nome_completo
                           FROM Funcionario F
                           WHERE F.ultimo_acesso IS NOT NULL
                           AND F.id_funcionario != @idAtual
                           ORDER BY F.ultimo_acesso DESC";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@idAtual", _formPrincipal.IdFuncionario);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string email = reader["email"].ToString();
                                string nome = reader["nome_completo"].ToString();
                                DateTime ultimoAcesso = Convert.ToDateTime(reader["ultimo_acesso"]);

                                lblAcessoEmail.Text = $"{nome} ({email})";
                                lblAcessoHorario.Text = ultimoAcesso.ToString("dd/MM/yyyy - HH:mm");
                            }
                            else
                            {
                                lblAcessoEmail.Text = "Nenhum acesso registrado";
                                lblAcessoHorario.Text = "--/--/---- --:--";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar último acesso: " + ex.Message);
                    lblAcessoEmail.Text = "Erro ao carregar";
                    lblAcessoHorario.Text = "--/--/---- --:--";
                }
            }
        }

        private void CarregarNumeroEmpresas()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(DISTINCT empresa) AS TotalEmpresas FROM Vagas";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        int totalEmpresas = (int)cmd.ExecuteScalar();
                        lblNEmpresas.Text = totalEmpresas.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar número de empresas: " + ex.Message);
                    lblNEmpresas.Text = "0";
                }
            }
        }

        private void CarregarNumeroUsuarios()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) AS TotalUsuarios FROM Usuario";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        int totalUsuarios = (int)cmd.ExecuteScalar();
                        lblNUsuario.Text = totalUsuarios.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar número de usuários: " + ex.Message);
                    lblNUsuario.Text = "0";
                }
            }
        }

        private void AtualizarStatusUsuarios()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT 
                                    SUM(CASE WHEN ativo = 1 THEN 1 ELSE 0 END) AS Ativos,
                                    COUNT(*) AS Total
                                    FROM Usuario";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int ativos = Convert.ToInt32(reader["Ativos"]);
                                int total = Convert.ToInt32(reader["Total"]);
                                int percentual = (total > 0) ? (ativos * 100) / total : 0;

                                // Configura o Circular ProgressBar
                                CpbInatividade.Value = percentual;
                                CpbInatividade.Text = $"{percentual}%";
                                CpbInatividade.ProgressColor = (percentual >= 70) ?
                                    Color.FromArgb(46, 204, 113) : // Verde
                                    (percentual >= 40 ? Color.FromArgb(241, 196, 15) : // Amarelo
                                    Color.FromArgb(231, 76, 60));   // Vermelho

                                // Atualiza o label conforme solicitado
                                lblAtividade.Text = $"{ativos} de {total} usuários estão ativos";
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    CpbInatividade.Text = "Err";
                    CpbInatividade.ProgressColor = Color.Gray;
                    lblAtividade.Text = "Erro ao carregar dados";
                    MessageBox.Show("Erro ao carregar status de usuários: " + ex.Message);
                }
            }
        }

        private void CpbInatividade_Click(object sender, EventArgs e)
        {
            AtualizarStatusUsuarios(); // Atualiza ao clicar
        }
    }
}