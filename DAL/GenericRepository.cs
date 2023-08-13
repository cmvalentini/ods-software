using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class GenericRepository<T> where T : class
    {
         
        private string _connectionString = @"Data Source=DESKTOP-VF25GBN\SERVERCHARLY;Initial Catalog = ODS_SOFT; Integrated Security = True";

        public GenericRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<T> GetAll(string tableName)
        {
            List<T> entities = new List<T>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName}";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Aquí necesitas implementar la lógica para convertir el reader en un objeto T
                        // y agregarlo a la lista de entidades
                    }
                }
            }
            return entities;
        }

        // Implementa métodos para Insert, Update y Delete
        // ...

        // Ejemplo de Insert:
        public void Insert(string tableName, Dictionary<string, object> columnValues)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string columns = string.Join(", ", columnValues.Keys);
                string values = "@" + string.Join(", @", columnValues.Values);
                string query = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
                SqlCommand command = new SqlCommand(query, connection);

                foreach (var columnValue in columnValues)
                {
                    command.Parameters.AddWithValue("@" + columnValue.Key, columnValue.Value);
                }

                command.ExecuteNonQuery();
            }
        }


    }
}
