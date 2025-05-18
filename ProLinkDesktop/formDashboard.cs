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
        private readonly string _connectionString = "Password=etesp; Persist Security Info=True; User ID=sa; Initial Catalog=prolink01; Data Source=" + Environment.MachineName;
        private readonly Form1 _formPrincipal;

        public formDashboard(Form1 formPrincipal)
        {
            InitializeComponent();
            _formPrincipal = formPrincipal;

            // Carrega os dados imediatamente ao criar o formulário
            this.Load += (s, e) => AtualizarDados();
        }

        public void AtualizarDados()
        {
            try
            {
                CarregarUltimoAcessoAdm();
                CarregarNumeroEmpresas();
                CarregarNumeroUsuarios();
                AtualizarStatusUsuarios();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao atualizar dashboard: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarUltimoAcessoAdm()
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(
                @"SELECT TOP 1 F.nome_completo, F.email, H.data_login
                FROM HistoricoAcessos H
                JOIN Funcionario F ON H.id_funcionario = F.id_funcionario
                WHERE H.id_funcionario != @idAtual
                ORDER BY H.data_login DESC", connection))
            {
                cmd.Parameters.AddWithValue("@idAtual", _formPrincipal.IdFuncionario);
                connection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblAcessoEmail.Text = $"{reader["nome_completo"]} ({reader["email"]})";
                        lblAcessoHorario.Text = Convert.ToDateTime(reader["data_login"]).ToString("dd/MM/yyyy HH:mm");
                    }
                    else
                    {
                        lblAcessoEmail.Text = "Nenhum acesso anterior";
                        lblAcessoHorario.Text = "--/--/---- --:--";
                    }
                }
            }
        }

        private void CarregarNumeroEmpresas()
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("SELECT COUNT(DISTINCT empresa) FROM Vagas", connection))
            {
                connection.Open();
                lblNEmpresas.Text = cmd.ExecuteScalar().ToString();
            }
        }

        private void CarregarNumeroUsuarios()
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand("SELECT COUNT(*) FROM Usuario", connection))
            {
                connection.Open();
                lblNUsuario.Text = cmd.ExecuteScalar().ToString();
            }
        }

        private void AtualizarStatusUsuarios()
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(
                @"SELECT 
                SUM(CASE WHEN ativo = 1 THEN 1 ELSE 0 END) AS Ativos,
                COUNT(*) AS Total
                FROM Usuario", connection))
            {
                connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        int ativos = reader.GetInt32(0);
                        int total = reader.GetInt32(1);
                        int percentual = total > 0 ? (ativos * 100) / total : 0;

                        CpbInatividade.Value = percentual;
                        CpbInatividade.Text = $"{percentual}%";
                        CpbInatividade.ProgressColor = percentual >= 70 ? Color.FromArgb(46, 204, 113) :
                                                    percentual >= 40 ? Color.FromArgb(241, 196, 15) :
                                                    Color.FromArgb(231, 76, 60);

                        lblAtividade.Text = $"{ativos} de {total} usuários ativos";
                    }
                }
            }
        }

        private void CpbInatividade_Click(object sender, EventArgs e) => AtualizarStatusUsuarios();
    }
}