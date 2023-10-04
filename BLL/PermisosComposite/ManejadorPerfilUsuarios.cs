using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.PermisosComposite
{
    public class ManejadorPerfilUsuarios
    {
        DAL.Permisos.ManejadorPerfilUsuariosDAL ManejadorPerfilUsuariosDAL = new DAL.Permisos.ManejadorPerfilUsuariosDAL();
        List<BE.Permisos.Component> listapermisos = new List<BE.Permisos.Component>();
       

        public List<BE.Permisos.Component> GetOperaciones()
        {
            List<BE.Permisos.Component> listapermisos2 = new List<BE.Permisos.Component>();
            listapermisos2 = ManejadorPerfilUsuariosDAL.GetOperaciones();
            return listapermisos2;
        }

        public void AsignarPerfilaUsuario(BE.Familia.Familia perfilBE, BE.Usuario usuariobe)
        {
            ManejadorPerfilUsuariosDAL.AsignarPerfilaUsuario(perfilBE, usuariobe);
        }

        public void UpdatePermisosUsuario(BE.Usuario usuariobe, List<BE.Permisos.Component> listaoperacionesperfil)
        {
            ManejadorPerfilUsuariosDAL.UpdatePermisosUsuario(usuariobe, listaoperacionesperfil);
        }

        public List<BE.Permisos.Component> MostrarListaOperacionesUsuario(BE.Usuario usuariobe)
        {
            listapermisos.Clear();
            listapermisos = ManejadorPerfilUsuariosDAL.MostrarListaOperacionesUsuario(usuariobe);
            return listapermisos;
        }

        public List<BE.Permisos.Component> MostrarListaOperaciones(BE.Familia.Familia perfilBE)
        {
            listapermisos.Clear();
            listapermisos = ManejadorPerfilUsuariosDAL.MostrarListaOperaciones(perfilBE);
            return listapermisos;
        }



    }
}
