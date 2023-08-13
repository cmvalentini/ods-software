using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
   public class sesion
    {
        private static sesion _instancia;

         public static sesion GetInstance()
        {
            if (_instancia == null)
            {
                _instancia = new sesion();
            }
            return _instancia;
        }

        public BE.Usuario GetUsuariosesion(BE.Usuario usu) {
            DAL.UsuarioDAL usuariodal = DAL.UsuarioDAL.GetInstance();
            usu = usuariodal.GetUsuariosesion(usu);
            return usu;
        }

        public sesion() { }


    }
}
