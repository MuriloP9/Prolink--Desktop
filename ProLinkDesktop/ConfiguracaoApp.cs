using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Drawing;

namespace ProLinkDesktop
{
    public class ConfiguracaoApp
    {
        // Configurações de Tema
        public bool TemaEscuro { get; set; } = true;
        public string CorPrimaria { get; set; } = "#2E3349"; // Azul escuro padrão
        public string CorSecundaria { get; set; } = "#434A69"; // Azul mais claro
        public string CorFundo { get; set; } = "#FFFFFF"; // Branco para tema claro

        // Configurações de Usuário
        public string NomeUsuario { get; set; }
        public string Email { get; set; }
        public bool ManterConectado { get; set; }

        // Configurações de Sistema
        public bool NotificacoesAtivas { get; set; } = true;
        public bool BackupAutomatico { get; set; } = false;
        public DateTime UltimoBackup { get; set; }

        // Método para converter hex para Color
        public Color ObterCorPrimaria()
        {
            return ColorTranslator.FromHtml(CorPrimaria);
        }

        // Salva as configurações em XML
        public void Salvar()
        {
            try
            {
                var serializer = new XmlSerializer(typeof(ConfiguracaoApp));
                using (var writer = new StreamWriter("config.xml"))
                {
                    serializer.Serialize(writer, this);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar configurações: {ex.Message}");
            }
        }

        // Carrega as configurações do XML
        public static ConfiguracaoApp Carregar()
        {
            try
            {
                if (File.Exists("config.xml"))
                {
                    var serializer = new XmlSerializer(typeof(ConfiguracaoApp));
                    using (var reader = new StreamReader("config.xml"))
                    {
                        return (ConfiguracaoApp)serializer.Deserialize(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar configurações: {ex.Message}");
            }
            return new ConfiguracaoApp(); // Retorna padrão se não existir
        }
    }
}
