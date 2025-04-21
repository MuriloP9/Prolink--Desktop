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
    public partial class FrmConfiguracoes : FormBase
    {
        private ConfiguracaoApp config;

        public FrmConfiguracoes()
        {
            InitializeComponent();
            config = ConfiguracaoApp.Carregar();
            CarregarConfiguracoes();
            ConfigurarToggleTheme();
        }

        private void CarregarConfiguracoes()
        {
            toggleTema.Checked = config.TemaEscuro;
            chkNotificacoes.Checked = config.NotificacoesAtivas;
            chkBackupAuto.Checked = config.BackupAutomatico;
        }

        private void SalvarConfiguracoes()
        {
            config.TemaEscuro = toggleTema.Checked;
            config.NotificacoesAtivas = chkNotificacoes.Checked;
            config.BackupAutomatico = chkBackupAuto.Checked;

            config.Salvar();
            AtualizarTemaGlobal();
        }

        private void AtualizarTemaGlobal()
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormBase formBase)
                {
                    formBase.AtualizarTema();
                }
            }
        }

        private void ConfigurarToggleTheme()
        {
            // Configuração visual do toggle
            toggleTema.Text = toggleTema.Checked ? "ON" : "OFF";
            toggleTema.ForeColor = toggleTema.Checked ? Color.White : Color.FromArgb(64, 64, 64);
            toggleTema.BackColor = toggleTema.Checked ? Color.FromArgb(67, 74, 105) : Color.LightGray;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarConfiguracoes();
            MessageBox.Show("Configurações salvas com sucesso!", "Sucesso",
                          MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toggleTema_CheckedChanged(object sender, EventArgs e)
        {
            ConfigurarToggleTheme();
            config.TemaEscuro = toggleTema.Checked;
            AtualizarTemaGlobal();
        }
    }
}