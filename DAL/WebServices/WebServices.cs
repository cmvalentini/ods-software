using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.WebServices
{
   public class WebServices
    {
        DataTable dt = new DataTable();
        string servicio = "";

        public string EstadisticaMVS_ContretoStrategy()
        {
            string sql = "select top(1)servicio from Pedido group by servicio order by count(servicio) desc";

            Conexion con = new Conexion();
            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {
                
                foreach (DataRow item in dt.Rows)
                {
                    servicio = item[0].ToString();
                }

            }

            return servicio;

        }

        public string TicketsSoporte_ContretoStrategy()
        {
            string sql = " select count(ticketid) as ticketsnoleidos from TicketsSoporte where leido = 0 ";

            Conexion con = new Conexion();
            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow item in dt.Rows)
                {
                    servicio = item[0].ToString();
                }
            }
            return servicio;

        }

        public string DevolverUsuariosActivos_ContretoStrategy()
        {
            string sql = "  select count(*) from ClientSession  where Activo = 1 ";

            Conexion con = new Conexion();
            dt = con.Ejecutarreader(sql);

            if (dt.Rows.Count > 0)
            {

                foreach (DataRow item in dt.Rows)
                {
                    servicio = item[0].ToString();
                }
            }
            return servicio;

        }



    }
}
