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

        // Connection string corrigida - usando SQL Server Express local
        private readonly string _connectionString = @"Server=.\SQLEXPRESS;Database=prolink01;User Id=sa;Password=etesp;";

        // Alternativa com autenticação Windows (comente a linha acima e descomente esta se preferir):
        // private readonly string _connectionString = @"Server=.\SQLEXPRESS;Database=prolink01;Integrated Security=true;";

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
                {
                    connection.Open();

                    // Atualiza registros existentes sem data_logout
                    using (var cmd = new SqlCommand(@"
                        UPDATE HistoricoAcessos 
                        SET data_logout = GETDATE() 
                        WHERE id_funcionario = @id 
                          AND data_logout IS NULL 
                          AND tipo_acesso = 'F'", connection))
                    {
                        cmd.Parameters.AddWithValue("@id", IdFuncionario);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar logout: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConfigurarBotoesPorNivel()
        {
            // Nível 0 = Super Admin (vê tudo)
            // Nível 1 = Admin (vê quase tudo, exceto gerenciar funcionários)
            // Nível 2 = Funcionário comum (acesso básico)

            btnGerenciarFuncionarios.Visible = (_nivelAcesso == 0);
            btnGerenciarUsuarios.Visible = (_nivelAcesso <= 1);

            ReorganizarBotoes();
        }

        private void ReorganizarBotoes()
        {
            var posY = btnMenu.Bottom + 10;
            var buttons = new[] {
                btnGerenciarFuncionarios,
                btnGerenciarUsuarios,
                btnOportunidades,
                btnWebinar,
                btnConfiguracoes,
                btnSair
            };

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
            try
            {
                pnlFormLoader.Controls.Clear();
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                pnlFormLoader.Controls.Add(form);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar formulário: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Event handlers
        private void btnMenu_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMenu);
            lblTitle.Text = "Menu";
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
            CarregarForm(new FrmConfiguracoes(IdFuncionario));
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja realmente sair do sistema?",
                "Confirmar Saída", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                RegistrarLogout();
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnWebinar);
            lblTitle.Text = "Webinar";
            CarregarForm(new FrmWebinar());
        }

        // Método auxiliar para testar conexão (opcional)
        public bool TestarConexao()
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}