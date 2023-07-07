using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RutasAPI.Data;
using RutasAPI.Repositories.Interfaces;
using System.Data;
using System.Data.Common;
using System.Reflection;
using System.Text;

namespace RutasAPI.Repositories.Implementacion
{
    public class RepositorioGenerico<TEntity, TType> where TEntity : class, new()
    {
        private readonly AppDbContext dbContext;
        private PropertyInfo[] _propertiesList;
        public RepositorioGenerico(AppDbContext dbContext)
        {
            _propertiesList = typeof(TEntity).GetProperties();
            this.dbContext = dbContext;
        }

        public async Task<bool> Crear(TEntity entity, TType store)
        {

            StringBuilder generatedValues = GenerateValues(_propertiesList, true, true);
            StringBuilder generatedColumns = new StringBuilder(generatedValues.ToString()).Replace("@", "");

            try
            {
                var connection = dbContext.Database.GetDbConnection();
                using (SqlCommand sqlCommand = new SqlCommand(store?.ToString(), (SqlConnection)connection))
                {
                    for (int i = 0; i < _propertiesList.Length; i++)
                    {
                        
                        object value = _propertiesList[i]?.GetValue(entity, null);
                        value = value == null ? DBNull.Value : value;
                        sqlCommand.Parameters.AddWithValue($"@{_propertiesList[i].Name}", value);
                    }

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    await sqlCommand.ExecuteNonQueryAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Actualizar(TEntity entity, TType store)
        {
            StringBuilder generatedValues = GenerateValues(_propertiesList, false);

            try
            {
                var connection = dbContext.Database.GetDbConnection();
                using (SqlCommand sqlCommand = new SqlCommand(store?.ToString(), (SqlConnection)connection))
                {
                    for (int i = 0; i < _propertiesList.Length; i++)
                    {
                        
                        object value = _propertiesList[i]?.GetValue(entity, null);
                        value = value == null ? DBNull.Value : value;
                        sqlCommand.Parameters.AddWithValue($"@{_propertiesList[i].Name}", value);
                    }

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    await sqlCommand.ExecuteNonQueryAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Eliminar(TEntity entity, TType store)
        {
            StringBuilder generatedValues = GenerateValues(_propertiesList, false);

            try
            {
                var connection = dbContext.Database.GetDbConnection();
                using (SqlCommand sqlCommand = new SqlCommand(store?.ToString(), (SqlConnection)connection))
                {
                    for (int i = 0; i < _propertiesList.Length; i++)
                    {
                        
                        object value = _propertiesList[i]?.GetValue(entity, null);
                        value = value == null ? DBNull.Value : value;
                        sqlCommand.Parameters.AddWithValue($"@{_propertiesList[i].Name}", value);
                    }

                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    await sqlCommand.ExecuteNonQueryAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<T>> LeerTodos<T>(TEntity entityIn, TType store) where T : new()
        {
            PropertyInfo[] entityPropertiesList = typeof(T).GetProperties().ToArray();

            List<T> entities = new List<T>();

            var connection = dbContext.Database.GetDbConnection();
            using (SqlCommand sqlCommand = new SqlCommand(store?.ToString(), (SqlConnection)connection))
            {
                try
                {
                    for (int i = 0; i < entityPropertiesList.Length; i++)
                    {
                        
                        object value = _propertiesList[i]?.GetValue(entityIn, null);
                        value = value == null ? DBNull.Value : value;
                        sqlCommand.Parameters.AddWithValue($"@{_propertiesList[i].Name}", value);
                    }

                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    sqlCommand.CommandTimeout = 76800;
                    
                    var reader = await sqlCommand.ExecuteReaderAsync();
                    var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
                    
                    while (reader.Read())
                    {
                        T entity = new T();

                        foreach (PropertyInfo pl in entityPropertiesList)
                        {
                            if (columns.Contains(pl.Name))
                            {
                                if (!reader[pl.Name].GetType().Equals(typeof(DBNull)))
                                {
                                    var property = entity.GetType().GetProperty(pl.Name, BindingFlags.Public | BindingFlags.Instance);

                                    property.SetValue(entity, reader[pl.Name], null);
                                }
                            }
                        }
                        entities.Add(entity);
                    }
                    return entities;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    throw;
                }
                finally
                {
                    if (connection != null)
                    {
                        connection.Dispose();
                    }

                    if (sqlCommand != null)
                    {
                        sqlCommand.Dispose();
                    }
                }
            }



        }

        private StringBuilder GenerateValues(PropertyInfo[] _propertiesList, bool isInsert, bool isAutoIncrement = true)
        {
            StringBuilder generateSet = new StringBuilder();


            for (int i = 0; i < _propertiesList.Length; i++)
            {
                string names = _propertiesList[i].Name.ToString();
                if ((isAutoIncrement && i == 0))
                {
                    continue;
                }
                if (isInsert)
                {
                    generateSet.Append($"@{names}, ");
                }
                else
                {
                    generateSet.Append($"{names} = @{names}, ");
                }
            }

            return generateSet.Remove(generateSet.Length - 2, 2);
        }

    }

}
