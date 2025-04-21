using System;
using System.Data;
using System.Data.SqlClient;

public class ClasseConexao
{
    private static readonly string connectionString = "Password=etesp; Persist Security Info=True; User ID=sa; Initial Catalog=Prolink; Data Source=(local)"; // ou seu nome de servidor fixo

    public SqlConnection conectar()
    {
        SqlConnection conexao = new SqlConnection(connectionString);
        try
        {
            if (conexao.State != ConnectionState.Open)
            {
                conexao.Open();
            }
            return conexao;
        }
        catch (SqlException ex)
        {
            // Log do erro (você pode implementar um sistema de log)
            Console.WriteLine($"Erro ao conectar: {ex.Message}");
            conexao.Dispose();
            throw; // Relança a exceção para ser tratada pelo chamador
        }
    }

    public void desconectar(SqlConnection connection)
    {
        try
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao desconectar: {ex.Message}");
        }
    }

    public DataTable executarSQL(String comando_sql)
    {
        SqlConnection conexao = null;
        try
        {
            conexao = conectar();
            SqlDataAdapter adaptador = new SqlDataAdapter(comando_sql, conexao);
            DataSet ds = new DataSet();
            adaptador.Fill(ds);
            return ds.Tables[0];
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao executar SQL: {ex.Message}");
            return null;
        }
        finally
        {
            desconectar(conexao);
        }
    }

    public bool manutencaoDB(String comando_sql)
    {
        SqlConnection conexao = null;
        try
        {
            conexao = conectar();
            SqlCommand comando = new SqlCommand(comando_sql, conexao);
            comando.ExecuteNonQuery();
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro na manutenção do DB: {ex.Message}");
            return false;
        }
        finally
        {
            desconectar(conexao);
        }
    }

    public int manutencaoDB_Parametros(SqlCommand comando)
    {
        SqlConnection conexao = null;
        try
        {
            conexao = conectar();
            comando.Connection = conexao;
            int linhasAfetadas = comando.ExecuteNonQuery();
            return linhasAfetadas;
        }
        catch (Exception ex)
        {
            // Log do erro completo
            Console.WriteLine($"Erro na manutenção com parâmetros: {ex.ToString()}");
            return 0;
        }
        finally
        {
            if (conexao != null && conexao.State == ConnectionState.Open)
            {
                conexao.Close();
            }
        }
    }
}