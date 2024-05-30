using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Core.Models;
using Microsoft.Extensions.Configuration;

namespace Core.Infraestructure
{
    public class ComunesDao : BaseDao
    {
        public ComunesDao(IConfiguration configuration) : base(configuration)
        {
        }

        #region [Constants]

        // Procedimientos almacenados
        private const string COMUNES_CARGARCOMBOS = "spCargarCombos";
        private const string RELACION_INSERTA = "spInsertaRelacion";

        // Constantes
        public const string LISTA_id = "Id";
        public const string LISTA_nombre = "Nombre";

        #endregion

        // Método para obtener lista por nombre
        public List<ListaVO> ObtenerLista(string nombre)
        {
            try
            {
                List<ListaVO> listaObjetos = new List<ListaVO>();
                DataTable w = EjecutarConsultaDataTable(ObtenerSQL(nombre));
                foreach (DataRow dr in w.Rows)
                {
                    ListaVO item = CargaListaVO(dr);
                    listaObjetos.Add(item);
                }
                return listaObjetos;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Método para obtener lista por nombre y filtro
        public List<ListaVO> ObtenerLista(string nombre, string idFiltro)
        {
            try
            {
                List<ListaVO> listaObjetos = new List<ListaVO>();
                string SQL = ObtenerSQL(nombre);
                SQL = SQL.Replace("?", idFiltro);
                DataTable w = EjecutarConsultaDataTable(SQL);
                foreach (DataRow dr in w.Rows)
                {
                    ListaVO item = CargaListaVO(dr);
                    listaObjetos.Add(item);
                }
                return listaObjetos;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Método para obtener lista por nombre y múltiples filtros
        public List<ListaVO> ObtenerLista(string nombre, string[] filtro)
        {
            try
            {
                List<ListaVO> listaObjetos = new List<ListaVO>();
                string SQL = ObtenerSQL(nombre);
                for (int i = 0; i < filtro.Length; i++)
                {
                    SQL = SQL.Replace("?" + (i + 1), filtro[i]);
                }
                DataTable w = EjecutarConsultaDataTable(SQL);
                foreach (DataRow dr in w.Rows)
                {
                    ListaVO item = CargaListaVO(dr);
                    listaObjetos.Add(item);
                }
                return listaObjetos;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Método para obtener lista en formato DataTable por nombre y filtro
        public DataTable ObtenerListaTabla(string nombre, string filtro)
        {
            try
            {
                string SQL = ObtenerSQL(nombre);
                if (!string.IsNullOrEmpty(filtro))
                {
                    SQL = SQL.Replace("?", filtro);
                }
                DataTable w = EjecutarConsultaDataTable(SQL);
                return w;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Método para obtener lista en formato DataTable por nombre y múltiples filtros
        public DataTable ObtenerListaTabla(string nombre, string[] filtro)
        {
            try
            {
                string SQL = ObtenerSQL(nombre);
                for (int i = 0; i < filtro.Length; i++)
                {
                    SQL = SQL.Replace("?" + (i + 1), filtro[i]);
                }
                DataTable w = EjecutarConsultaDataTable(SQL);
                return w;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Método privado para obtener SQL
        private string ObtenerSQL(string nombre)
        {
            try
            {
                Parametro valParam = new Parametro("nombre", nombre, DbType.String);
                DataRow dr = EjecutarStoredProcedureDataRow(COMUNES_CARGARCOMBOS, valParam);
                return dr[0].ToString();
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Método privado para cargar ListaVO
        private ListaVO CargaListaVO(DataRow dr)
        {
            if (dr == null) return null;

            ListaVO retorno = new ListaVO
            {
                Id = dr[LISTA_id],
                Nombre = dr[LISTA_nombre].ToString()
            };
            return retorno;
        }

        // Método para obtener lista por procedimiento almacenado
        public List<ListaVO> ObtenerListaBySp(string sp)
        {
            try
            {
                List<ListaVO> listaObjetos = new List<ListaVO>();
                DataTable w = EjecutarStoredProcedureDataTable(sp);
                foreach (DataRow dr in w.Rows)
                {
                    ListaVO item = CargaListaVO(dr);
                    listaObjetos.Add(item);
                }
                return listaObjetos;
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Método para insertar relación
        public void RelacionInsert(RelacionParamVO inserta)
        {
            try
            {
                Parametro[] valParam = new Parametro[]
                {
                    new Parametro("PARAMETRO", inserta.Parametro, DbType.String),
                    new Parametro("TIPO", inserta.Inserta, DbType.Boolean),
                    new Parametro("VAL_LIST1", inserta.ValorCombo, DbType.Int32),
                    new Parametro("VAL_LIST2", inserta.ValorLista, DbType.Int32),
                    new Parametro("USUARIO", inserta.Usuario, DbType.String),
                    new Parametro("FECHA", inserta.Fecha, DbType.DateTime)
                };
                EjecutarStoredProcedure(RELACION_INSERTA, valParam);
            }
            catch (SqlException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
