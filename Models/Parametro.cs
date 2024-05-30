using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Core.Models
{
    [Serializable]
    public struct Parametro
    {
        string _name;
        DbType _type;
        object _data;

        public Parametro(string name, object data, DbType type)
        {
            this._name = name;
            this._data = data;
            this._type = type;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public object Data
        {
            get { return _data; }
            set { _data = value; }
        }


        public DbType Type
        {
            get { return _type; }
            set { _type = value; }
        }

    }
}
