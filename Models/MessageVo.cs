using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class MessageVo
    {
        public int IdEmpresa { get; set; }
        public String Personas { get; set; }
        public string CodigoFuncionario { get; set; }
        public string CorreoFuncionario { get; set; }
        public int IdMessage { get; set; }
        public String Contacto1 { get; set; }
        public String Contacto2 { get; set; }
        public String Contacto3 { get; set; }
        public String EmailFrom { get; set; }
        public String EmailFromPW { get; set; }
        public String MessageBody { get; set; }
        public String MessageSubject { get; set; }
        public String SmtpClient { get; set; }
        public bool NotificacionPorCorreo { get; set; }
    }
}
