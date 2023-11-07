using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Seguridad
{
   public  class StateControllerDAL
    {
        DataTable dt = new DataTable();
        DAL.Conexion con = Conexion.GetInstance();


        public int verificarpermisos(string permiso, int usuario)
        {

            string sql = "select * from patente p inner join usuariopatente up on up.PatenteID = p.PatenteID " +
                " where p.Descripcion = '" + permiso + "' " +
                " and up.UsuarioID  = " + usuario;

            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                return 1;

            }

            return 0;


        }
}
}
