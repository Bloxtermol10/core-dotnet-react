using System;
using System.ComponentModel.DataAnnotations;

namespace Core.ORM.Entities
{
    [TableSchema("Seguridad")]
    public class Usuario
    {
        [Key]
        public int idUsuario { get; set; }

        public int idColegio { get; set; }

        public string nombreUsuario { get; set; }

        public string clave { get; set; }

        public DateTime caducaClave { get; set; }

        public bool activo { get; set; }

        public bool externo { get; set; }

        public int tipoUsuario { get; set; }

        public string usuarioCrea { get; set; }

        public DateTime fechaCrea { get; set; }

        public string usuarioModifica { get; set; }

        public DateTime fechaModifica { get; set; }

    }
}
