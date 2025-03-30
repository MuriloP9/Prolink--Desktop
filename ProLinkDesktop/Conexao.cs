using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ProLinkDesktop
{
    public class Conexao : IDisposable
    {
        private SqlConnection connection;

        // Método para abrir a conexão
        public Conexao()
        {
            string connectionString = "Data Source=localhost;Initial Catalog=Prolink;User ID=sa;Password=etesp";
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        // Método para executar uma query (SELECT) e retornar um DataTable
        public DataTable ExecuteQuery(string query, List<SqlParameter> parameters)
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters.ToArray());
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable result = new DataTable();
            adapter.Fill(result);
            return result;
        }

        // Método para executar uma query (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string query, List<SqlParameter> parameters)
        {
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddRange(parameters.ToArray());
            return command.ExecuteNonQuery();
        }

        // Método para fechar a conexão
        public void Dispose()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
