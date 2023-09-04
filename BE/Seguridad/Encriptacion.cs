using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Seguridad
{
   public class Encriptacion
    {
        public string Result { get; set; }

        public int Longitud { get; set; }
        public string Texto { get; set; }

        public string TextoEncriptado { get; set; }

        public Encriptacion() { }

    }
}
