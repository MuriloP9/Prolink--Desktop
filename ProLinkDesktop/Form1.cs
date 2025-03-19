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
            pnlNav.Height = btnDashBoard.Height;
            pnlNav.Top = btnDashBoard.Top;
            pnlNav.Left = btnDashBoard.Left;
            btnDashBoard.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnDashBoard_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnDashBoard.Height;
            pnlNav.Top = btnDashBoard.Top;
            pnlNav.Left = btnDashBoard.Left;
            btnDashBoard.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnAnalystics_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnAnalystics.Height;
            pnlNav.Top = btnAnalystics.Top;
            btnAnalystics.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnCalendario_Click(object sender, EventArgs e)
        {
            pnlNav.Height = btnCalendario.Height;
            pnlNav.Top = btnCalendario.Top;
            btnCalendario.BackColor = Color.FromArgb(46, 51, 73);
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

        private void btnDashBoard_Leave(object sender, EventArgs e)
        {
            btnDashBoard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnAnalystics_Leave(object sender, EventArgs e)
        {
            btnAnalystics.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnCalendario_Leave(object sender, EventArgs e)
        {
            btnCalendario.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnContato_Leave(object sender, EventArgs e)
        {
            btnContato.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnConfiguracoes_Leave(object sender, EventArgs e)
        {
            btnConfiguracoes.BackColor = Color.FromArgb(24, 30, 54);
        }
    }
}

