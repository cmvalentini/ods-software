using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.WebServices
{
   public class TicketsSoporteConcreto : IStrategy
    {
        public string LlamarWebService()
        {
            DAL.WebServices.WebServices webServices = new DAL.WebServices.WebServices();
            return webServices.TicketsSoporte_ContretoStrategy();
        }
    }
}
