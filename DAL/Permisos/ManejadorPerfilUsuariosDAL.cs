using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BE.Permisos;
using BE.Familia;

namespace DAL.Permisos
{
    public class ManejadorPerfilUsuariosDAL 
    {
        DataTable dt = new DataTable();
        Conexion con = Conexion.GetInstance();
        GenericRepository<BE.Permisos.Component> GenericRepository = new GenericRepository<BE.Permisos.Component>();
        
        List<BE.Permisos.Component> listapermisos = new List<BE.Permisos.Component>();

        public List<BE.Permisos.Component> obtenerhijos(List<BE.Permisos.Component> hijos, Usuario usuario)
        {
            string columna = "p.Descripcion";
            string tabla = "patente p inner join usuariopatente up on up.PatenteID = p.PatenteID";
            string condicion = "up.UsuarioID in ("+usuario.UsuarioID +")";
            dt = GenericRepository.GetAllbyID(columna, tabla, condicion);

            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("entró reader MPUDAL" + Convert.ToString(dt.Rows[0][0].ToString()));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BE.Permisos.Component componente = new BE.Permisos.Component("");

                    componente.Nombre = dt.Rows[i]["Descripcion"].ToString();

                    hijos.Add(componente);
                }

            }


            return hijos;
        }

        public List<Component> GetOperaciones()
        {
            string sql = "select distinct p.Descripcion from patente p ";
            dt = con.Ejecutarreader(sql);
            List<BE.Permisos.Component> listaoperaciones = new List<BE.Permisos.Component>();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {
                    BE.Permisos.Component component = new Component("");

                    component.Nombre = item[0].ToString();


                    listaoperaciones.Add(component);
                }

            }
            return listaoperaciones;

        }

        public List<Component> MostrarListaOperaciones(Familia perfilBE)
        {
            string sql = " select p.Descripcion from PerfilPatente pp inner join PerfilUsuario pu " +
                            "on pp.Perfilusuarioid = pu.PerfilUsuarioID" +
                    "  inner join patente p on p.PatenteID = pp.PatenteID" +
            " where pu.NombrePerfil in ('" + perfilBE.NombrePerfil + "')";
            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("entró reader MPUDAL" + Convert.ToString(dt.Rows[0][0].ToString()));

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    BE.Permisos.Component componente = new BE.Permisos.Component("");

                    componente.Nombre = dt.Rows[i]["Descripcion"].ToString();

                    listapermisos.Add(componente);
                }

            }


            return listapermisos;
        }
    }
}
