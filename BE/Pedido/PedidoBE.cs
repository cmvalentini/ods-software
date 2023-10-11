using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Pedido
{
    public class PedidoBE
    {


        public string Servicio { get; set; }
        public Empresa empresa;
        public Usuario Usuario;
        public PedidoBE(Usuario _usu, Empresa _empresa,string _Servicio) {

       
            empresa = _empresa;
            Servicio = _Servicio;
            Usuario = _usu;

        }
    }
}
