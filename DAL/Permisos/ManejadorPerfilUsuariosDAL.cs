using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAL.Permisos
{
    public class ManejadorPerfilUsuariosDAL 
    {
        
        GenericRepository<BE.Permisos.Component> GenericRepository = new GenericRepository<BE.Permisos.Component>();
        DataTable dt = new DataTable();
       
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



    }
}
