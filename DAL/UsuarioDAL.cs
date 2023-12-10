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
        GenericRepository<BE.Usuario> GenericRepository = new GenericRepository<BE.Usuario>();

        public List<Usuario> GetUsuarios(List<Usuario> listausuarios)
        {
            string sql = "select * from Usuario";
            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    BE.Usuario USUBE = new BE.Usuario();
                    
                    USUBE.UsuarioID = Convert.ToInt32(item[0].ToString());
                    USUBE._Usuario = Convert.ToString(item[1].ToString());
                    USUBE.Apellido = Convert.ToString(item[4].ToString()); 
                    USUBE.Nombre = Convert.ToString(item[3].ToString()); 
                    USUBE.Email = Convert.ToString(item[6].ToString()); 
                    USUBE.Dni = Convert.ToInt32(item[5].ToString()); 
                    USUBE.Habilitado = Convert.ToBoolean(item[7].ToString()); 

                    listausuarios.Add(USUBE);
                }
               
            }
            return listausuarios;
        }

        public Usuario CambiarClave(Usuario usu)
        {
            string sql = "Update Usuario set Clave = '" + usu.Clave + "' " +
                 " where Usuario = '" + usu._Usuario + "'";
                  

            usu.Result = con.Ejecutar(sql);
             
            return usu;
        }

        public void UpdateUserwithpassword(Usuario usube)
        {
            string sql = "update usuario set Clave = '" + usube.clavesinencriptar + "',FlagIntentosLogin = 0 " +
                         " where Usuarioid = " + usube.UsuarioID + "";

            usube.OResult = con.Ejecutar(sql);
             

            
        }

        public Usuario GetbyUser(Usuario USUBE)
        {
            string sql = "select usuarioid,usuario,Email,FlagIntentosLogin from Usuario where usuario ='" + USUBE._Usuario+"'";

            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    USUBE.UsuarioID = Convert.ToInt32(item[0].ToString());
                    USUBE._Usuario = Convert.ToString(item[1].ToString());
                    USUBE.Email = Convert.ToString(item[2].ToString());
                    USUBE.FlagIntentosLogin = Convert.ToInt32(item[3].ToString());
                }
            }
            return USUBE;
        }

        public void SumarFlagIntentos(Usuario usu)
        {
            string sql = "update usuario set FlagIntentosLogin = FlagIntentosLogin + 1 " +
                          " where Usuario = '"+usu._Usuario+"' ";
            con.Ejecutar(sql);
        }

        public Usuario UpdateUser(Usuario usube)
        {
            int habilitado = 0;
            if (usube.Habilitado == true)
            {
                habilitado = 1;
            }
            else
            {
                habilitado = 0;
            }
            string sql = "update usuario set Usuario = '" + usube._Usuario + "',Nombre = '" + usube.Nombre + "',Apellido = '" +
                usube.Apellido + "', email = '" + usube.Email + "',Habilitado = " + habilitado + 
                " where Usuarioid = " +usube.UsuarioID+"";

            usube.OResult = con.Ejecutar(sql);
            // dv.RecalcularDVH();

            return usube;
        }

        public Usuario CreateUser(Usuario usube)
        {
            string sql = "insert into Usuario  (Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin,PerfilID,DVH) values( '" + usube._Usuario + "',"
               + "'" + usube.Clave + "','" + usube.Nombre + "','" + usube.Apellido + "'," + usube.Dni + ",'" + usube.Email + "',1,0,0,'_DVH')";

            usube.OResult = con.Ejecutar(sql);
            // dv.RecalcularDVH();


            EmailSevice mail = new EmailSevice();
            mail.EnviarEmail(usube);

            return usube;


        }

        public Usuario GetbyID(Usuario usube)
        {
            string columna = "UsuarioID,Usuario,Nombre,Apellido,DNI,Email,Habilitado";
            string tabla = "Usuario u";
            string condicion = "u.UsuarioID in (" + usube.UsuarioID + ")";
            dt = GenericRepository.GetAllbyID(columna, tabla, condicion);


            foreach (DataRow item in dt.Rows)
            {
                usube.UsuarioID = Convert.ToInt32(item[0].ToString());
                usube._Usuario = Convert.ToString(item[1].ToString());
                usube.Apellido = Convert.ToString(item[3].ToString());
                usube.Nombre = Convert.ToString(item[2].ToString());
                usube.Dni = Convert.ToInt32(item[4].ToString());
                usube.Email = Convert.ToString(item[5].ToString());
                usube.Habilitado = Convert.ToBoolean(item[6].ToString());
            }

            return usube;
        }

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

            string sql = "select UsuarioID,Usuario,Clave,Nombre,Apellido,DNI,Email,Habilitado,FlagIntentosLogin,PerfilID From Usuario " +
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
           

                if (dt.Rows[0][9].ToString() == "")
                {
                    UsuBE.PerfilID = 0;
                }
                else
                {
                    UsuBE.PerfilID = Convert.ToInt32(dt.Rows[0][9].ToString());
                }
               
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
