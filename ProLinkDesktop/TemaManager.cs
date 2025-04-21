using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace ProLinkDesktop
{
    public static class TemaManager
    {
        // Aplica o tema global a um formulário e seus controles
        public static void AplicarTema(Form form, bool temaEscuro)
        {
            if (temaEscuro)
            {
                AplicarTemaEscuro(form);
            }
            else
            {
                AplicarTemaClaro(form);
            }
        }

        private static void AplicarTemaEscuro(Form form)
        {
            // Cores do tema escuro padrão
            form.BackColor = Color.FromArgb(32, 36, 55); // Fundo escuro

            foreach (Control c in form.Controls)
            {
                AplicarTemaEscuroControle(c);
            }
        }

        private static void AplicarTemaClaro(Form form)
        {
            // Cores do tema claro (azul/cinza claro/branco)
            form.BackColor = Color.White; // Fundo branco

            foreach (Control c in form.Controls)
            {
                AplicarTemaClaroControle(c);
            }
        }

        private static void AplicarTemaEscuroControle(Control c)
        {
            // Personalização para cada tipo de controle no tema escuro
            if (c is Button btn)
            {
                btn.BackColor = Color.FromArgb(67, 74, 105); // Azul médio
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.FromArgb(46, 51, 73);
            }
            else if (c is TextBox txt)
            {
                txt.BackColor = Color.FromArgb(46, 51, 73); // Azul escuro
                txt.ForeColor = Color.White;
                txt.BorderStyle = BorderStyle.FixedSingle;
            }
            else if (c is Label lbl)
            {
                lbl.ForeColor = Color.White;
            }
            else if (c is Panel pnl)
            {
                pnl.BackColor = Color.FromArgb(46, 51, 73); // Painéis azul escuro
            }
            else if (c is DataGridView dgv)
            {
                dgv.BackgroundColor = Color.FromArgb(32, 36, 55);
                dgv.DefaultCellStyle.BackColor = Color.FromArgb(32, 36, 55);
                dgv.DefaultCellStyle.ForeColor = Color.White;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(46, 51, 73);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            }
            // Adicione outros controles conforme necessário...

            // Aplica recursivamente a controles filhos
            if (c.HasChildren)
            {
                foreach (Control child in c.Controls)
                {
                    AplicarTemaEscuroControle(child);
                }
            }
        }

        private static void AplicarTemaClaroControle(Control c)
        {
            // Personalização para cada tipo de controle no tema claro
            if (c is Button btn)
            {
                btn.BackColor = Color.FromArgb(0, 123, 255); // Azul vibrante
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            }
            else if (c is TextBox txt)
            {
                txt.BackColor = Color.White;
                txt.ForeColor = Color.Black;
                txt.BorderStyle = BorderStyle.FixedSingle;

                // Força atualização da borda
                if (!txt.Multiline)
                {
                    txt.Enabled = false;
                    txt.Enabled = true;
                }
            }
            else if (c is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(64, 64, 64); // Cinza escuro
            }
            else if (c is Panel pnl)
            {
                pnl.BackColor = Color.FromArgb(240, 240, 240); // Cinza muito claro
            }
            else if (c is DataGridView dgv)
            {
                dgv.BackgroundColor = Color.White;
                dgv.DefaultCellStyle.BackColor = Color.White;
                dgv.DefaultCellStyle.ForeColor = Color.Black;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            }
            // Adicione outros controles conforme necessário...

            // Aplica recursivamente
            if (c.HasChildren)
            {
                foreach (Control child in c.Controls)
                {
                    AplicarTemaClaroControle(child);
                }
            }
        }

        // Método para atualizar o tema de todos os forms abertos
        public static void AtualizarTemaGlobal(bool temaEscuro)
        {
            foreach (Form form in Application.OpenForms)
            {
                AplicarTema(form, temaEscuro);
                form.Refresh();
            }
        }
    }
}