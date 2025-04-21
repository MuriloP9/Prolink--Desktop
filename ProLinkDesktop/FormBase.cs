using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProLinkDesktop
{
    public class FormBase : Form
    {
        public FormBase()
        {
            // Configurações comuns a todos os forms
            this.Font = new Font("Segoe UI", 9);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Aplica o tema quando o form é carregado
            this.Load += (s, e) => AplicarTema();
        }

        // Método para aplicar o tema
        public void AplicarTema()
        {
            var config = ConfiguracaoApp.Carregar();
            TemaManager.AplicarTema(this, config.TemaEscuro);

            // Chama métodos específicos de tema se existirem
            if (this is IFormTemaCustomizado)
            {
                ((IFormTemaCustomizado)this).AplicarTemaCustomizado();
            }
        }

        // Atualiza o tema em tempo real (para quando mudar nas configurações)
        public void AtualizarTema()
        {
            AplicarTema();
            this.Refresh();
        }
    }

    // Interface para forms que precisam de customização adicional
    public interface IFormTemaCustomizado
    {
        void AplicarTemaCustomizado();
    }
}