using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Seguridad
{
    public class BackUpResrore
    {
        public void RealizarBackUp()
        {
            DAL.Seguridad.BackRestoreDal BackRestoreDal = new DAL.Seguridad.BackRestoreDal();
            BackRestoreDal.RealizarBackUp();
        }

        public void RealizarRestore()
        {
            DAL.Seguridad.BackRestoreDal BackRestoreDal = new DAL.Seguridad.BackRestoreDal();
            BackRestoreDal.RealizarRestore();
        }
    }
}
