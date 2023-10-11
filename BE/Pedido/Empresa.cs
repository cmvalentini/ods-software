using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Pedido
{
  public class Empresa : Usuario
    {
        public string URLComprobante { get; set; }
        public string URLDatosEmpresa { get; set; }

    }
}
