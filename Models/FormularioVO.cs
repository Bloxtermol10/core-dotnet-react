using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    [Serializable]
    public class FormularioVO 
    {
        public int IdFormulario { get; set; }
        public string NomFormulario { get; set; }
        public string Direccion { get; set; }
        public int? IdPadre { get; set; }
        public bool Visible { get; set; }
        public string RutaIcono { get; set; }
         

    }
}
