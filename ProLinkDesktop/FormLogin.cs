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
    public partial class FormLogin : Form
    {
        // Defina o usuário e a senha específicos
        private const string usuarioCorreto = "Pedro";
        private const string senhaCorreta = "1234";

        public FormLogin()
        {
            InitializeComponent();
            //Usuario Selecionado ao iniciar 
            txtUsuario.Select();
            // Conecta os eventos de clique aos métodos
            btnEntrar.Click += new EventHandler(btnEntrar_Click);
            btnSair.Click += new EventHandler(btnSair_Click);
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            // Verifique se o usuário e a senha inseridos correspondem aos valores definidos
            if (txtUsuario.Text == usuarioCorreto && txtSenha.Text == senhaCorreta)
            {
                // Login bem-sucedido
                MessageBox.Show("Login bem-sucedido!");

                // Abra a Form1
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide(); // Opcional: esconde a janela de login
            }
            else
            {
                // Login falhou
                MessageBox.Show("Usuário ou senha incorretos.");
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            // Fechar a aplicação
            Application.Exit();
        }
    }
}