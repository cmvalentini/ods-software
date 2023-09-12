using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Seguridad
{
   public class BitacoraBLL
    {
        BE.Seguridad.BitacoraBE log = new BE.Seguridad.BitacoraBE();
        DAL.Seguridad.BitacoraDAL logdal = new DAL.Seguridad.BitacoraDAL();
        List<BE.Seguridad.BitacoraBE> listabitacora = new List<BE.Seguridad.BitacoraBE>();
        public List<BE.Seguridad.BitacoraBE> ConsultarBitacora(string fechadesde, string fechahasta, string sqlcriticidad, string sqlusuario)
        {
            listabitacora = logdal.ConsultarBitacora(fechadesde, fechahasta, sqlcriticidad, sqlusuario);
            return listabitacora;

        }

        public List<BE.Seguridad.BitacoraBE> ListarBitacora()
        {
            listabitacora.Clear();
            listabitacora = logdal.ListarBitacora();
            return listabitacora;
        }

        
        public BE.Seguridad.BitacoraBE IngresarDatoBitacora(string NombreOperacion, string Descripcion, string Criticidad, int Usuarioid)
        {

            BE.Seguridad.BitacoraBE log = new BE.Seguridad.BitacoraBE();
            

            log.result = logdal.IngresarDatoBitacora(NombreOperacion, Descripcion, Criticidad, Usuarioid).ToString();

            return log;

        }

    }
}
