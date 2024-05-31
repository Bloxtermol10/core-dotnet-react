using System.ComponentModel.DataAnnotations;

namespace CoreORM.Entities
{
    [TableSchema("Comunes")]
    public class Profesion
    {
        [Key]
        public int idProfesion { get; set; }

        [Required(ErrorMessage = "El nombre de la profesión es obligatorio.")]
        public string nomProfesion { get; set; }
        public string? usuarioCrea { get; set; }
        public DateTime? fechaCrea { get; set; }
        public string? usuarioModifica { get; set; }
        public DateTime? fechaModifica { get; set; }
    }
}
