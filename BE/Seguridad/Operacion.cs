using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Seguridad
{
    public class Operacion
    {
        public string NombreOperacion { get; set; }
        public int OperacionId { get; set; }

        public Operacion(string nombreoperacion)
        {
            NombreOperacion = nombreoperacion;
        }

        public Operacion() { }

    }
}
