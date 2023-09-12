﻿using System;
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
        public List<BE.Permisos.Component> MostrarListaOperaciones(BE.Familia.Familia perfilBE)
        {
            listapermisos.Clear();
            listapermisos = ManejadorPerfilUsuariosDAL.MostrarListaOperaciones(perfilBE);
            return listapermisos;
        }

        public List<BE.Permisos.Component> GetOperaciones()
        {
            List<BE.Permisos.Component> listapermisos2 = new List<BE.Permisos.Component>();
            listapermisos2 = ManejadorPerfilUsuariosDAL.GetOperaciones();
            return listapermisos2;
        }
    }
}
