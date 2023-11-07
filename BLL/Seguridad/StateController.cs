using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Seguridad
{
    public class StateController
    {
       
        public int verificarpermisos(string permiso,int usuarioid) {

            DAL.Seguridad.StateControllerDAL state = new DAL.Seguridad.StateControllerDAL();

           return state.verificarpermisos(permiso, usuarioid);

        }


    }
}
