using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class UsuarioDAL
    {
        private static UsuarioDAL _instanciausuario;
        BE.Usuario usuarioBE = new Usuario();
        DataTable dt = new DataTable();
        Conexion con = Conexion.GetInstance();
        public static UsuarioDAL GetInstance()
        {
            if (_instanciausuario == null)
            {
                _instanciausuario = new UsuarioDAL();
            }
            return _instanciausuario;
        }

        public Usuario GetUsuariosesion(BE.Usuario UsuBE)
        {

            string sql = "select UsuarioID,Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin From Usuario " +
                          " where usuario = '" + UsuBE._Usuario + "'" +
                          " and clave = '" + UsuBE.Clave + "' " +
                          " and Habilitado = 1";


            dt = con.Ejecutarreader(sql);



            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("entró reader " + Convert.ToString(dt.Rows[0][0].ToString()));

                UsuBE.UsuarioID = Convert.ToInt32(dt.Rows[0][0].ToString());
                UsuBE._Usuario = Convert.ToString(dt.Rows[0][1].ToString());
                UsuBE.Apellido = Convert.ToString(dt.Rows[0][4].ToString());
                UsuBE.Nombre = Convert.ToString(dt.Rows[0][3].ToString());
                UsuBE.Email = Convert.ToString(dt.Rows[0][6].ToString());
                UsuBE.Dni = Convert.ToInt32(dt.Rows[0][5].ToString());
                UsuBE.Habilitado = Convert.ToBoolean(dt.Rows[0][7].ToString());
                UsuBE.FlagIntentosLogin = Convert.ToInt32(dt.Rows[0][8].ToString());
 
                return UsuBE;

            }
            else
            {
                UsuBE._Usuario = null;
                UsuBE.Clave = null;

            }


            return UsuBE;
        }
    }
}
