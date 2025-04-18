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
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );

        private Button activeButton; // Variável para rastrear o botão ativo

        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));

            // Configuração inicial
            pnlNav.Height = btnMenu.Height;
            pnlNav.Top = btnMenu.Top;
            pnlNav.Left = btnMenu.Left;
            btnMenu.BackColor = Color.FromArgb(46, 51, 73);
            activeButton = btnMenu;

            lblTitle.Text = "Menu";
            this.pnlFormLoader.Controls.Clear();
            formDashboard FormDashboard_vrb = new formDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FormDashboard_vrb);
            FormDashboard_vrb.Show();
        }

        private void ResetButtonColors()
        {
            if (activeButton != null)
            {
                activeButton.BackColor = Color.FromArgb(24, 30, 54); // Cor padrão dos botões
            }
        }

        private void SetActiveButton(Button button)
        {
            ResetButtonColors();
            activeButton = button;
            activeButton.BackColor = Color.FromArgb(46, 51, 73); // Cor do botão ativo
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMenu);

            pnlNav.Height = btnMenu.Height;
            pnlNav.Top = btnMenu.Top;
            pnlNav.Left = btnMenu.Left;

            lblTitle.Text = "Menu";
            this.pnlFormLoader.Controls.Clear();
            formDashboard FormDashboard_vrb = new formDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FormDashboard_vrb);
            FormDashboard_vrb.Show();
        }

        private void btnOportunidades_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnOportunidades);

            pnlNav.Height = btnOportunidades.Height;
            pnlNav.Top = btnOportunidades.Top;

            lblTitle.Text = "Oportunidades";
            this.pnlFormLoader.Controls.Clear();
            frmOportunidades FormDashboard_vrb = new frmOportunidades() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FormDashboard_vrb);
            FormDashboard_vrb.Show();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnExportar);

            pnlNav.Height = btnExportar.Height;
            pnlNav.Top = btnExportar.Top;

            lblTitle.Text = "Exportar Relatórios";
            this.pnlFormLoader.Controls.Clear();
            FrmExportarRelatorios FormDashboard_vrb = new FrmExportarRelatorios() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FormDashboard_vrb);
            FormDashboard_vrb.Show();
        }

        private void btnCadastrarEmpresa_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnCadastrarEmpresa);

            pnlNav.Height = btnCadastrarEmpresa.Height;
            pnlNav.Top = btnCadastrarEmpresa.Top;

            lblTitle.Text = "Cadastrar Empresas";
            this.pnlFormLoader.Controls.Clear();
            FrmCadastrarEmpresas FormDashboard_vrb = new FrmCadastrarEmpresas()
            {
                Dock = DockStyle.Fill,
                TopLevel = false,
                TopMost = true
            };
            FormDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FormDashboard_vrb);
            FormDashboard_vrb.Show();
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnConfiguracoes);

            pnlNav.Height = btnConfiguracoes.Height;
            pnlNav.Top = btnConfiguracoes.Top;

            lblTitle.Text = "Configurações";
            this.pnlFormLoader.Controls.Clear();
            FrmConfiguracoes FormDashboard_vrb = new FrmConfiguracoes() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FormDashboard_vrb);
            FormDashboard_vrb.Show();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Perfil";
            this.pnlFormLoader.Controls.Clear();
            FrmPerfil FormDashboard_vrb = new FrmPerfil() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FormDashboard_vrb);
            FormDashboard_vrb.Show();
        }

        private void lblUsuario_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Perfil";
            this.pnlFormLoader.Controls.Clear();
            FrmPerfil FormDashboard_vrb = new FrmPerfil() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FormDashboard_vrb);
            FormDashboard_vrb.Show();
        }
    }
}