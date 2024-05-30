using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
     [Serializable]
     public class CredencialesVO
    {
        public string id { get; set; }
        public string servicio { get; set; }
        public string nombre { get; set; }  
        public string valor { get; set;}

    }
}
