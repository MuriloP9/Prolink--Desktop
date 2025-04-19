using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ProLinkDesktop
{
    public partial class Form1 : Form
    {
        private string _nomeUsuario;
        private int _nivelAcesso;

        // Propriedades
        public string NomeUsuario
        {
            get => _nomeUsuario;
            set { _nomeUsuario = value; lblUsuario.Text = value; }
        }

        public int NivelAcesso
        {
            get => _nivelAcesso;
            set { _nivelAcesso = value; ConfigurarBotoesPorNivel(); }
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        private Button activeButton;

        public Form1()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            // Configuração inicial
            pnlNav.Height = btnMenu.Height;
            pnlNav.Top = btnMenu.Top;
            pnlNav.Left = btnMenu.Left;
            btnMenu.BackColor = Color.FromArgb(46, 51, 73);
            activeButton = btnMenu;

            lblTitle.Text = "Menu";
            CarregarForm(new formDashboard());
        }

        // Métodos de controle de acesso
        private void ConfigurarBotoesPorNivel()
        {
            btnGerenciarFuncionarios.Visible = (_nivelAcesso == 0);  // Só Admin (0)
            btnGerenciarUsuarios.Visible = (_nivelAcesso <= 1);     // Admin e Gerente (0-1)
            ReorganizarBotoes();
        }

        private void ReorganizarBotoes()
        {
            int posY = btnMenu.Bottom + 10;

            if (btnGerenciarFuncionarios.Visible)
            {
                btnGerenciarFuncionarios.Location = new Point(btnMenu.Left, posY);
                posY = btnGerenciarFuncionarios.Bottom + 10;
            }

            if (btnGerenciarUsuarios.Visible)
            {
                btnGerenciarUsuarios.Location = new Point(btnMenu.Left, posY);
                posY = btnGerenciarUsuarios.Bottom + 10;
            }

            // Botões fixos
            btnOportunidades.Location = new Point(btnMenu.Left, posY);
            btnConfiguracoes.Location = new Point(btnMenu.Left, btnOportunidades.Bottom + 10);
            btnSair.Location = new Point(btnMenu.Left, btnConfiguracoes.Bottom + 10);
        }

        // Métodos auxiliares
        private void ResetButtonColors()
        {
            if (activeButton != null)
                activeButton.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void SetActiveButton(Button button)
        {
            ResetButtonColors();
            activeButton = button;
            activeButton.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void CarregarForm(Form form)
        {
            pnlFormLoader.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlFormLoader.Controls.Add(form);
            form.Show();
        }

        // Eventos dos botões (mantenha os existentes, só adicione os novos)
        private void btnMenu_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMenu);
            pnlNav.Top = btnMenu.Top;
            lblTitle.Text = "Menu";
            CarregarForm(new formDashboard());
        }

        private void btnOportunidades_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnOportunidades);
            pnlNav.Top = btnOportunidades.Top;
            lblTitle.Text = "Oportunidades";
            CarregarForm(new frmOportunidades());
        }

        private void btnGerenciarUsuarios_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnGerenciarUsuarios);
            pnlNav.Top = btnGerenciarUsuarios.Top;
            lblTitle.Text = "Gerenciar Usuários";
            CarregarForm(new FrmExportarRelatorios());
        }

        private void btnGerenciarFuncionarios_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnGerenciarFuncionarios);
            pnlNav.Top = btnGerenciarFuncionarios.Top;
            lblTitle.Text = "Gerenciar Funcionarios";
            CarregarForm(new FrmCadastrarEmpresas());
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnConfiguracoes);
            pnlNav.Top = btnConfiguracoes.Top;
            lblTitle.Text = "Configurações";
            CarregarForm(new FrmConfiguracoes());
        }

        private void btnSair_Click(object sender, EventArgs e) => Application.Exit();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Perfil";
            CarregarForm(new FrmPerfil());
        }

        private void lblUsuario_Click(object sender, EventArgs e) => pictureBox1_Click(sender, e);
    }
}