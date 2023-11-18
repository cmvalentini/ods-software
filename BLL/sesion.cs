using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class sesion
    {
        //se realiza una sesion estatica para que no pueden estarla modificando
        private static sesion _instancia;

        //hacemos un singleton de la sesion
         public static sesion GetInstance()
        {
            if (_instancia == null)
            {
                _instancia = new sesion();
            }
            return _instancia;
        }
        //se llama a la sesión del usuario
        public BE.Usuario GetUsuariosesion(BE.Usuario usu) {
            DAL.UsuarioDAL usuariodal = DAL.UsuarioDAL.GetInstance();
            usu = usuariodal.GetUsuariosesion(usu);
            return usu;
        }

        public sesion() { }


    }
}
