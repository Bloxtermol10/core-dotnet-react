using System;
using System.ComponentModel.DataAnnotations;

namespace Core.ORM.Entities
{
    [TableSchema("Comunes")]
    public class Cargo
    {
        public int idColegio { get; set; }

        [Key]
        public int idCargo { get; set; }

        public string nomCargo { get; set; }

        public int nivelCargo { get; set; }

        public bool Activo { get; set; }

        public string usuarioCrea { get; set; }

        public DateTime fechaCrea { get; set; }

        public string usuarioModifica { get; set; }

        public DateTime fechaModifica { get; set; }

    }
}
