using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Models;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace Core.ORM
{
    public class DbSet<T> where T : class, new()
    {
        private readonly SqlConnection _connection;
        private readonly string _schema;

        public DbSet(SqlConnection connection, string schema )
        {
            _connection = connection;
            _schema = schema;
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

        public IEnumerable<T> ToList()
        {
            List<T> entities = new List<T>();
            string tableName = $"{_schema}.{typeof(T).Name}";
            string query = $"SELECT * FROM {tableName}";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        T entity = new T();
                        foreach (DataColumn column in dataTable.Columns)
                        {
                            PropertyInfo prop = typeof(T).GetProperty(column.ColumnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
                            if (prop != null && row[column] != DBNull.Value)
                            {
                                // Handle nullable DateTime properties
                                if (prop.PropertyType == typeof(DateTime?) && row[column] is DateTime)
                                {
                                    prop.SetValue(entity, (DateTime?)row[column]);
                                }
                                else
                                {
                                    prop.SetValue(entity, Convert.ChangeType(row[column], prop.PropertyType));
                                }
                            }
                        }
                        entities.Add(entity);
                    }
                }

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
            return entities;
        }

        public void Add(T entity)
        {
            string tableName = $"{_schema}.{typeof(T).Name}";
            var properties = typeof(T).GetProperties()
                .Where(p => p.GetCustomAttribute<KeyAttribute>() == null); // Excluir la propiedad clave

            string columns = string.Join(", ", properties.Select(p => p.Name));
            string values = string.Join(", ", properties.Select(p => "@" + p.Name));
            string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                foreach (var prop in properties)
                {
                    command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(entity) ?? DBNull.Value);
                }

                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                command.ExecuteNonQuery();

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }
        public void Update(T entity)
        {
            string tableName = $"{_schema}.{typeof(T).Name}";
            var keyProperty = typeof(T).GetProperties()
                .FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null);
            var properties = typeof(T).GetProperties()
                .Where(p => p.GetCustomAttribute<KeyAttribute>() == null);

            if (keyProperty == null)
            {
                throw new InvalidOperationException("No key attribute found on entity.");
            }

            string setClause = string.Join(", ", properties.Select(p => p.Name + " = @" + p.Name));
            string query = $"UPDATE {tableName} SET {setClause} WHERE {keyProperty.Name} = @{keyProperty.Name}";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@" + keyProperty.Name, keyProperty.GetValue(entity));
                foreach (var prop in properties)
                {
                    command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(entity) ?? DBNull.Value);
                }

                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                command.ExecuteNonQuery();

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

      
        public void Remove(T entity)
        {
            string tableName = $"{_schema}.{typeof(T).Name}";
            var keyProperty = typeof(T).GetProperties()
                .FirstOrDefault(p => p.GetCustomAttribute<KeyAttribute>() != null);

            if(keyProperty == null)
            {
                throw new InvalidOperationException("No key attribute found on entity.");
            }


            string query = $"DELETE FROM {tableName} WHERE {keyProperty.Name} = @{keyProperty.Name}";

            using (SqlCommand command = new SqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue($"@{keyProperty.Name}", keyProperty.GetValue(entity));

                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }

                command.ExecuteNonQuery();

                if (_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                }
            }
        }

        public DataSet EjecutarStoredProcedureDataSet(string procedure, params Parametro[] param)
        {
            DataSet ds = new DataSet();

            using (var command = new SqlCommand(procedure, _connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                LlenarParametros(command, param);

                using (var adapter = new SqlDataAdapter(command))
                {
                    if (_connection.State == ConnectionState.Closed)
                    {
                        _connection.Open();
                    }

                    adapter.Fill(ds);

                    if (_connection.State == ConnectionState.Open)
                    {
                        _connection.Close();
                    }
                }
            }

            return ds;
        }

        public DataTable EjecutarStoredProcedureDataTable(string procedure, params Parametro[] param)
        {
            return EjecutarStoredProcedureDataSet(procedure, param).Tables[0];
        }

        public DataRow EjecutarStoredProcedureDataRow(string procedure, params Parametro[] param)
        {
            var dt = EjecutarStoredProcedureDataTable(procedure, param);
            return dt.Rows.Count > 0 ? dt.Rows[0] : null;
        }
    }

    public class DbContext
    {
        private readonly SqlConnection _connection;

        public DbContext(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public DbSet<T> Set<T>() where T : class, new()
        {
            var schema = typeof(T).GetCustomAttribute<TableSchemaAttribute>()?.Schema ?? "dbo";
            return new DbSet<T>(_connection, schema);
        }
    }
}
