using BE.Seguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seguridad
{
    public class BitacoraDAL
    {
        
        BE.Seguridad.BitacoraBE logBE = new BE.Seguridad.BitacoraBE();
     //   DigitosVerificadoresDAL dv = new DigitosVerificadoresDAL();
        Conexion con = new Conexion();

        public BE.Seguridad.BitacoraBE IngresarDatoBitacora(string nombreOperacion, string descripcion, string criticidad, int usuarioid)
        {

            string sql = "insert into Bitacora(NombreOperacion,Descripcion,UsuarioID,Criticidad,FechayHora) values ('"
                        + nombreOperacion + "','" + descripcion + "'," + usuarioid + ",'"
                        + criticidad + "',getdate())";

            logBE.result = con.Ejecutar(sql);
           // dv.RecalcularDVH();


            return logBE;

        }

        public List<BE.Seguridad.BitacoraBE> ListarBitacora()
        {
            DataTable dt = new DataTable();
            List<BE.Seguridad.BitacoraBE> Listar = new List<BE.Seguridad.BitacoraBE>();

            try
            {

                dt = con.SPListarFull("ListarBitacora");

                if (dt.Rows.Count > 0)
                {

                    foreach (DataRow item in dt.Rows)
                    {
                        BE.Seguridad.BitacoraBE BitacoraBE = new BE.Seguridad.BitacoraBE();
                        BitacoraBE.NombreOperacion = item[4].ToString();
                        BitacoraBE.Descripcion = item[2].ToString();
                        BitacoraBE.Usuarioid = Convert.ToInt16(item[1].ToString());
                        BitacoraBE.Criticidad = item[3].ToString();
                        BitacoraBE.FechayHora = Convert.ToDateTime(item[5].ToString());
                        Listar.Add(BitacoraBE);
                    }
                    Console.WriteLine("entró reader DAL.bitacora.ConsultarBitacora" + Convert.ToString(dt.Rows[0][0].ToString()));

                }
            }
            catch
            {
                Listar = null;

            }


            return Listar;
        }

     
        public List<BE.Seguridad.BitacoraBE> ConsultarBitacora(string fechadesde, string fechahasta, string sqlcriticidad, string sqlusuario)
        {
            List<BE.Seguridad.BitacoraBE> listabitacora = new List<BE.Seguridad.BitacoraBE>();


            DataTable dt = new DataTable();

            string sql =
         "select NombreOperacion, Descripcion, b.UsuarioID, Criticidad, FechayHora from Bitacora b " +
         " inner join Usuario u ON b.UsuarioID = u.UsuarioID " +
         " where fechayhora BETWEEN '" + fechadesde + "' AND '" + fechahasta +
         " 23:59' " +
         " and Criticidad IN(" + sqlcriticidad + ")" +
         " AND b.UsuarioID IN(" + sqlusuario + ")";

            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow item in dt.Rows)
                {
                    BE.Seguridad.BitacoraBE BitacoraBE = new BE.Seguridad.BitacoraBE();
                    BitacoraBE.NombreOperacion = item[0].ToString();
                    BitacoraBE.Descripcion = item[1].ToString();
                    BitacoraBE.Usuarioid = Convert.ToInt16(item[2].ToString());
                    BitacoraBE.Criticidad = item[3].ToString();
                    BitacoraBE.FechayHora = Convert.ToDateTime(item[4].ToString());
                    listabitacora.Add(BitacoraBE);
                }
                Console.WriteLine("entró reader DAL.bitacora.ConsultarBitacora" + Convert.ToString(dt.Rows[0][0].ToString()));

            }

            return listabitacora;

        }

    }
}
