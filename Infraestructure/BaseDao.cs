using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Core.Models;

namespace Core.Infraestructure
{
    public class BaseDao
    {
        protected string? connectionString;

        public int? intNull = null;
        public bool? boolNull = null;
        public decimal? decimalNull = null;
        public DateTime? dateNull = null;
        protected SqlConnection connection;
        public IConfiguration configuration { get; set; }

        //El constructor
        public BaseDao(IConfiguration configuration)
        {
            this.configuration = configuration;
            connectionString = configuration.GetConnectionString("DefaultConnection");
            connection = new SqlConnection(connectionString);
        }

        private void LlenarParametros(SqlCommand command, params Parametro[] param)
        {
            if (param != null)
            {
                foreach (var p in param)
                {
                    command.Parameters.Add(new SqlParameter(p.Name, p.Type) { Value = p.Data ?? DBNull.Value });
                }
            }
        }

        public DataSet EjecutarStoredProcedureDataSet(string procedure, params Parametro[] param)
        {
            DataSet ds = new DataSet();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    LlenarParametros(command, param);

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(ds);
                    }
                }
            }

            return ds;
        }

        public DataTable EjecutarStoredProcedureDataTable(string procedure, params Parametro[] param)
        {
            return EjecutarStoredProcedureDataSet(procedure, param).Tables[0];
        }

        public DataTable EjecutarConsultaDataTable(string query, params Parametro[] param)
        {
            DataSet ds = new DataSet();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;
                    LlenarParametros(command, param);

                    using (var adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(ds);
                    }
                }
            }

            return ds.Tables[0];
        }

        public DataRow EjecutarStoredProcedureDataRow(string procedure, params Parametro[] param)
        {
            var dt = EjecutarStoredProcedureDataTable(procedure, param);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }

        public object EjecutarStoredProcedureRetornaValor(string procedure, params Parametro[] param)
        {
            object result;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    LlenarParametros(command, param);

                    connection.Open();
                    result = command.ExecuteScalar();
                }
            }

            return result;
        }

        public void EjecutarStoredProcedure(string procedure, params Parametro[] param)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    LlenarParametros(command, param);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public bool validarNulo(object objeto)
        {
            return objeto == DBNull.Value;
        }
    }
}
