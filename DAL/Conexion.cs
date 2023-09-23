using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Conexion
    {
        public static Conexion conexion_instancia;
        static string stringconexion = DevolverConexion();
        SqlConnection con = new SqlConnection(stringconexion);
        DataTable dt;

        public static Conexion GetInstance()
        {
            if (conexion_instancia == null)
            {
                conexion_instancia = new Conexion();
            }
            return conexion_instancia;
        }

        internal void EjecutarProcedureconListaParametros(string NombreParametro, SqlParameter parametro1)
        {
            Conectar();
            SqlCommand com = new SqlCommand(NombreParametro, con);
            com.CommandType = CommandType.StoredProcedure;

            com.Parameters.Add(parametro1);

            com.ExecuteReader();

            Desconectar();
        }

        internal bool EjecutarProcedureconListaParametros(string NombreParametro, List<SqlParameter> parametros)
        {
            try
            {
                Conectar();
                SqlCommand com = new SqlCommand(NombreParametro, con);
                com.CommandType = CommandType.StoredProcedure;

                foreach (SqlParameter item in parametros)
                {
                    com.Parameters.Add(item);
                }
                

                com.ExecuteReader();

                Desconectar();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }





        public  DataTable SPListarFull(string NomProc)
        {
            DataTable dt = new DataTable();  

            try
            {

                SqlCommand com = new SqlCommand(NomProc,con);
                
                com.CommandType = CommandType.StoredProcedure;
                
                Conectar();

                SqlDataReader reader = com.ExecuteReader();
                dt.Load(reader);
                Desconectar();

                return dt;

                 
              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                con.Close();
                //desconectar
            }

        }

        internal DataTable Selectsp(string storedProcedurev, List<SqlParameter> listaParams)
        {
           try
                {
                    DataTable dataTable = new DataTable();
                DataSet dataset = new DataSet();
                SqlCommand command = new SqlCommand(storedProcedurev, con);
                    command.CommandType = CommandType.StoredProcedure;
                   
                    if (listaParams != null)
                        command.Parameters.AddRange(listaParams.ToArray());
                    Conectar();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                dataAdapter.Fill(dataset);
                dataAdapter.Fill(dataTable);
                dataTable = dataset.Tables[0];
                Desconectar();
                    return dataTable;

                }
                catch (SqlException)
                {
                   
                    throw;
                }
            
        }

        public static string DevolverConexion()
        {
            try
            {
                string stringconexiontest = @"Data Source=DESKTOP-VF25GBN\SERVERCHARLY;Initial Catalog = ODS_SOFT; Integrated Security = True";

               // string stringconexiontest = ConfigurationManager.ConnectionStrings["conexion"].ToString();

                return stringconexiontest;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }


        internal void Conectar()
        {
            con.Close();
            if (con.State == ConnectionState.Open) { }
            else
            {
                con.Open();
            }
            Console.WriteLine("Conexion abierta Correctamente");
        }

        internal void Desconectar()
        {
            SqlConnection con = new SqlConnection(stringconexion);
            if (con.State == ConnectionState.Closed) { }
            else
            {
                con.Close();
            }

            Console.WriteLine("Conexion cerrada Correctamente");
        }

        internal DataTable Ejecutarreader(string sql)
        {
            SqlCommand com = new SqlCommand(sql, con);

            Conectar();

            SqlDataReader reader = com.ExecuteReader();
            dt = new DataTable();
            dt.Load(reader);
            Desconectar();

            return dt;

        }
        internal string Ejecutar(string sql)
        {
            try
            {
                Conectar();
                SqlCommand com = con.CreateCommand();
                com.CommandText = sql;
                int fil = com.ExecuteNonQuery();

                if (fil > 0)
                {
                    Console.WriteLine("Se ejecutó satisfactoriamente");
                    return "Se ejecutó satisfactoriamente";
                }
                else
                {
                    Console.WriteLine("No se pudo ejecutar la consulta");
                    return "No se pudo ejecutar la consulta";
                }

            }

            catch (Exception ex)
            {
                return ex.Message;

            }

            finally { Desconectar(); }

        }



    }
}
