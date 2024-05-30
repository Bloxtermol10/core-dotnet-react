using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    [Serializable]
    public class AutocompleteFormulario
    {
        public String NomCiudad { get; set; }
        public String NomDepartamento { get; set; }
        public String NomPais { get; set; }
        public int? IdCiudad { get; set; }
        public int? idprovincia { get; set; }
        public int? idpais { get; set; }
    }
    [Serializable]
    public class AutocompleteActividadEconomica
    {
        public String Nombre { get; set; }
        public int IdAct { get; set; }
    }
}
