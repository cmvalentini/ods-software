using BE.Pedido;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Pedido
{
    public class PedidoDal
    {
        DataTable dt = new DataTable();
        Conexion con = Conexion.GetInstance();
        UsuarioDAL usuarioDAL = new UsuarioDAL();

        public int IngresarPedido(BE.Pedido.PedidoBE pedidoBE)
        {
            try
            {
                usuarioDAL.CreateUser(pedidoBE.Usuario);


                string sql = "insert into pedido (NombreEmpresa,URLComprobante,URLDatosEmpresa,UsuarioID,Servicio)" +
                " select top(1) '" + pedidoBE.Usuario._Usuario + "','" + pedidoBE.empresa.URLComprobante + "', " +
                 " '" + pedidoBE.empresa.URLDatosEmpresa + "', UsuarioID,'" + pedidoBE.Servicio + "' from usuario " +
                    " order by UsuarioID desc ";
                string resultado = con.Ejecutar(sql);


                EmailSevice mail = new EmailSevice();
                mail.EnviarEmail(pedidoBE.Usuario);

                return 1;
            }
            catch (Exception)
            {

                return 2;
            }

        }

        public int GetLastInvoiceNumer()
        {
            string sql = "select top(1)PedidoID from Pedido order by 1 desc";

            dt = con.Ejecutarreader(sql);
            int numerofactura = 5;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow item in dt.Rows)
                {

                    numerofactura = Convert.ToInt32(item[0].ToString());
                }
            }
            return numerofactura;
        }
    }
}
