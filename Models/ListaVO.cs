using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    [Serializable]
    public class ListaVO
    {
        private object _id;

        private string _nombre;

        public ListaVO(Object id, String nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }


        public ListaVO()
        {

        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }


        public object Id
        {
            get { return _id; }
            set { _id = value; }
        }

    }
}
