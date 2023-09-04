using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Usuario
{
    public class Usuario
    {
        BE.Seguridad.Encriptacion crip = new BE.Seguridad.Encriptacion();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        DAL.UsuarioDAL UsuarioDAL = new DAL.UsuarioDAL();
        string clavesinencriptar = "";
        string claveencriptada = "";
        BE.Usuario usuBE = new BE.Usuario();
        public List<BE.Usuario> GetUsuarios(List<BE.Usuario> listausuarios)
        {
            listausuarios = UsuarioDAL.GetUsuarios(listausuarios);
            return listausuarios;
        }

        public BE.Usuario GetbyID(BE.Usuario usube)
        {
            usube = UsuarioDAL.GetbyID(usube);
            return usube;
        }

        public BE.Usuario CreateUser(BE.Usuario usube)
        {
          
            cryp.CrearPassword(crip);
            clavesinencriptar = crip.Result;

            crip.TextoEncriptado = cryp.Encriptar(clavesinencriptar);
            claveencriptada = crip.Result;

            usube.clavesinencriptar = clavesinencriptar;
            usube.Clave = claveencriptada;

            usube = UsuarioDAL.CreateUser(usube);
            return usube;
        }

        public BE.Usuario UpdateUser(BE.Usuario usube)
        {
            usube = UsuarioDAL.UpdateUser(usube);

            return usube;
        }
    }
}
