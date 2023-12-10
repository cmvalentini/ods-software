using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seguridad
{
    public class BackRestoreDal
    {
        public void RealizarBackUp()
        {
            SqlParameter Parametro1 = new SqlParameter("@CANT", Convert.ToInt16(3));
         

            try
            {
                DAL.Conexion con = new Conexion();

                con.EjecutarProcedureconListaParametros("RealizarBackUp", Parametro1);

                Console.WriteLine("Back Up exitoso");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Revise el acceso a la carpeta " + ex.Message);
            }

        }

        public void RealizarRestore()
        {
            try
            {
                string stringcon = @"Data Source=DESKTOP-VF25GBN\SERVERCHARLY;Initial Catalog = master; Integrated Security = True";

                SqlConnection con1 = new SqlConnection(stringcon);
                con1.Open();

                SqlCommand com = new SqlCommand("RealizarRestore", con1);
                com.CommandType = CommandType.StoredProcedure;

                SqlParameter Parametro1 = new SqlParameter("@CANT", 3);

                com.Parameters.Add(Parametro1);


                com.ExecuteReader();

                con1.Close();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }

        }
    }
}
