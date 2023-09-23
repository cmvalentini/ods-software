using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
  public  class EmailSeviceBLL
    {
        BE.Seguridad.Encriptacion crip = new BE.Seguridad.Encriptacion();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        DAL.EmailSevice es = new DAL.EmailSevice();
        string clavesinencriptar = "";
        string claveencriptada = "";


        public void enviarmail(BE.Usuario usube) {

            cryp.CrearPassword(crip);
            clavesinencriptar = crip.Result;

            crip.TextoEncriptado = cryp.Encriptar(clavesinencriptar);
            claveencriptada = crip.Result;

            usube.clavesinencriptar = clavesinencriptar;
            usube.Clave = claveencriptada;

            es.EnviarEmail(usube);
            

        }

    }
}
