using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Persona
    {
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public int Dni { get; set; }
        public string telefono { get; set; }
        public string Domicilio { get; set; }
        public string Result { get; set; }



    }
}
