using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Pedido
{
   public class PedidoBLL
    {
        DAL.Pedido.PedidoDal PedidoDal = new DAL.Pedido.PedidoDal();
        
        public int IngresarPedido(BE.Pedido.PedidoBE pedidoBE) {
            
            return PedidoDal.IngresarPedido(pedidoBE);

        }

    }
}
