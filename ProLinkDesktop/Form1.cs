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
using System.Data.SqlClient;


namespace ProLinkDesktop
{
    public partial class Form1 : Form
    {
        // Variáveis de instância
        private string _nomeUsuario;
        private int _nivelAcesso;
        private readonly string _connectionString = "Password=etesp; Persist Security Info=True; User ID=sa; Initial Catalog=prolink01; Data Source=" + Environment.MachineName;
        private Button _activeButton;

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

        public int IdFuncionario { get; set; }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);

        public Form1()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            ConfigurarInterfaceInicial();
        }

        private void ConfigurarInterfaceInicial()
        {
            pnlNav.Height = btnMenu.Height;
            pnlNav.Top = btnMenu.Top;
            pnlNav.Left = btnMenu.Left;
            btnMenu.BackColor = Color.FromArgb(46, 51, 73);
            _activeButton = btnMenu;
            lblTitle.Text = "Menu";
            CarregarForm(new formDashboard(this));
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.UserClosing)
            {
                RegistrarLogout();
            }
        }

        private void RegistrarLogout()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                using (var cmd = new SqlCommand(
                    @"IF EXISTS (SELECT 1 FROM HistoricoAcessos WHERE id_funcionario = @id AND data_logout IS NULL)
                      UPDATE HistoricoAcessos SET data_logout = GETDATE() WHERE id_funcionario = @id AND data_logout IS NULL
                      ELSE
                      INSERT INTO HistoricoAcessos (id_funcionario, email, data_login, data_logout)
                      SELECT id_funcionario, email, DATEADD(MINUTE, -1, GETDATE()), GETDATE()
                      FROM Funcionario WHERE id_funcionario = @id", connection))
                {
                    cmd.Parameters.AddWithValue("@id", IdFuncionario);
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao registrar logout: {ex.Message}");
            }
        }

        private void ConfigurarBotoesPorNivel()
        {
            btnGerenciarFuncionarios.Visible = (_nivelAcesso == 0);
            btnGerenciarUsuarios.Visible = (_nivelAcesso <= 1);
            ReorganizarBotoes();
        }

        private void ReorganizarBotoes()
        {
            var posY = btnMenu.Bottom + 10;
            var buttons = new[] { btnGerenciarFuncionarios, btnGerenciarUsuarios, btnOportunidades, btnConfiguracoes, btnSair };

            foreach (var btn in buttons)
            {
                if (btn.Visible)
                {
                    btn.Location = new Point(btnMenu.Left, posY);
                    posY = btn.Bottom + 10;
                }
            }
        }

        private void SetActiveButton(Button button)
        {
            if (_activeButton != null)
                _activeButton.BackColor = Color.FromArgb(24, 30, 54);

            _activeButton = button;
            _activeButton.BackColor = Color.FromArgb(46, 51, 73);
            pnlNav.Top = button.Top;
        }

        public void CarregarForm(Form form)
        {
            pnlFormLoader.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            pnlFormLoader.Controls.Add(form);
            form.Show();
        }

        // Event handlers
        private void btnMenu_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMenu);
            lblTitle.Text = "Menu";

            // Cria uma nova instância do dashboard (sempre atualizada)
            CarregarForm(new formDashboard(this));
        }

        private void btnOportunidades_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnOportunidades);
            lblTitle.Text = "Oportunidades";
            CarregarForm(new frmOportunidades());
        }

        private void btnGerenciarUsuarios_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnGerenciarUsuarios);
            lblTitle.Text = "Gerenciar Usuários";
            CarregarForm(new FrmGerenciarUsuarios());
        }

        private void btnGerenciarFuncionarios_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnGerenciarFuncionarios);
            lblTitle.Text = "Gerenciar Funcionarios";
            CarregarForm(new FrmGerenciarFuncionarios(_nivelAcesso));
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnConfiguracoes);
            lblTitle.Text = "Configurações";
            CarregarForm(new FrmConfiguracoes());
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            RegistrarLogout();
            Application.Exit();
        }
    }
}