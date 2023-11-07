using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.WebServices
{
    public class UsuariosActivos_ConcretoStrategy : IStrategy
    {
        public string LlamarWebService()
        {
            DAL.WebServices.WebServices ws = new DAL.WebServices.WebServices();
            return ws.DevolverUsuariosActivos_ContretoStrategy();
         }
    }
}
