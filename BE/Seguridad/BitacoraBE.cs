using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Seguridad
{
   public class BitacoraBE
    {
        public string Accion { get; set; }
        public string Criticidad { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechayHora { get; set; }
        public string NombreOperacion { get; set; }
        public int Usuarioid { get; set; }
        public string result { get; set; }

        public BitacoraBE() { }

        public BitacoraBE(int _usuaroid,string _descripcion, string _criticidad, string _accion, DateTime _fecha)
        {
            Usuarioid = _usuaroid;
            Descripcion = _descripcion;
            Criticidad = _criticidad;
            Accion = _accion;
            FechayHora = _fecha;
        }


    }
}
