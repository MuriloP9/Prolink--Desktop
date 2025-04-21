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
    }
}