using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;  
namespace ProLinkDesktop
{
    public partial class FormLogin : Form
    {
        private const string usuarioCorreto = "pedro@teste.com";
        private const string senhaCorreta = "1234";

        public FormLogin()
        {
            InitializeComponent();
                      txtUsuario.Select();

            txtUsuario.Multiline = false;
            txtSenha.Multiline = false;
            btnEntrar.Click += new EventHandler(btnEntrar_Click);
            btnSair.Click += new EventHandler(btnSair_Click);
            txtSenha.KeyDown += new KeyEventHandler(txtSenha_KeyDown);
            txtUsuario.KeyDown += new KeyEventHandler(txtUsuario_KeyDown);
        }
        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                if (ValidarEmail(txtUsuario.Text))
                {
                    txtSenha.Focus(); 
                }
                else
                {
                    MessageBox.Show("Por favor, insira um e-mail válido.");
                    txtUsuario.Select(); 
                }
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btnEntrar.PerformClick(); 
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
           
            if (txtUsuario.Text == usuarioCorreto && txtSenha.Text == senhaCorreta)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide(); 
            }
            else
            {
              
                MessageBox.Show("Usuário ou senha incorretos.");

                txtSenha.Clear();
                txtSenha.Focus(); 
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

  
        private bool ValidarEmail(string email)
        {
            
            string padraoEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(padraoEmail);
            return regex.IsMatch(email);
        }
    }
}
