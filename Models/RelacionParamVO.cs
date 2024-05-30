using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    [Serializable]
    public class RelacionParamVO
    {
        public String Parametro { get; set; }
        public Boolean Inserta { get; set; }
        public Int32 ValorCombo { get; set; }
        public Int32 ValorLista { get; set; }
        public String Usuario { get; set; }
        public DateTime Fecha { get; set; }
    }
}
