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


        public Form1()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            pnlNav.Height = btnMenu.Height;
            pnlNav.Top = btnMenu.Top;
            pnlNav.Left = btnMenu.Left;
            btnMenu.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Menu";
            this.pnlFormLoader.Controls.Clear();
            formDashboard FormDashboard_vrb = new formDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FormDashboard_vrb);
            FormDashboard_vrb.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnMenu.Height;
            pnlNav.Top = btnMenu.Top;
            pnlNav.Left = btnMenu.Left;
            btnMenu.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Menu";
            this.pnlFormLoader.Controls.Clear();
            formDashboard FormDashboard_vrb = new formDashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FormDashboard_vrb);
            FormDashboard_vrb.Show();
        }

        private void btnOportunidades_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnOportunidades.Height;
            pnlNav.Top = btnOportunidades.Top;
            btnOportunidades.BackColor = Color.FromArgb(46, 51, 73);

            lblTitle.Text = "Oportunidades";
            this.pnlFormLoader.Controls.Clear();
            frmOportunidades FormDashboard_vrb = new frmOportunidades() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormDashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.pnlFormLoader.Controls.Add(FormDashboard_vrb);
            FormDashboard_vrb.Show();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnExportar.Height;
            pnlNav.Top = btnExportar.Top;
            btnExportar.BackColor = Color.FromArgb(46, 51, 73);

        }

        private void btnContato_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnContato.Height;
            pnlNav.Top = btnContato.Top;
            btnContato.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnConfiguracoes.Height;
            pnlNav.Top = btnConfiguracoes.Top;
            btnConfiguracoes.BackColor = Color.FromArgb(46, 51, 73);
        }

        //perfil

        private void btnMenu_Leave(object sender, EventArgs e)
        {
             btnMenu.BackColor = Color.FromArgb(24, 30, 54);
        }
        private void btnOportunidades_Leave(object sender, EventArgs e)
                {
                    btnOportunidades.BackColor = Color.FromArgb(24, 30, 54);
                }
        
        private void btnExportar_Leave(object sender, EventArgs e)
        {
            btnExportar.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnContato_Leave(object sender, EventArgs e)
        {
            btnContato.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnConfiguracoes_Leave(object sender, EventArgs e)
        {
            btnConfiguracoes.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

      
    }
}

