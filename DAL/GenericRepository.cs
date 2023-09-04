using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL
{
   public class GenericRepository<T> where T : class
    {
        Conexion con = Conexion.GetInstance();
        private string _connectionString = @"Data Source=DESKTOP-VF25GBN\SERVERCHARLY;Initial Catalog = ODS_SOFT; Integrated Security = True";
        DataTable dt = new DataTable();
        public GenericRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetAll(string tableName)
        {
             
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM {tableName}";



                dt = con.Ejecutarreader(query);
                
            }
            return dt;
        }
        public GenericRepository() { }

        public DataTable GetAllbyID(string columnas,string tableName,string condicion)
        {
            List<T> entities = new List<T>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string query = $"SELECT {columnas} FROM {tableName} where {condicion}";
                SqlCommand command = new SqlCommand(query, connection);

                using (SqlDataReader reader = command.ExecuteReader())
                {

                    dt.Load(reader);
                }
            }
            return dt;
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
