using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ODS_Software_Argentina_TFI.Web_Services
{
    /// <summary>
    /// Descripción breve de TicketsSoporte
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class TicketsSoporte : System.Web.Services.WebService
    {

        [WebMethod]
        public string DevolverTicketsSoportenoLeidos()
        {
            BLL.WebServices.TicketsSoporteConcreto serviciotickets = new  BLL.WebServices.TicketsSoporteConcreto();

            return serviciotickets.LlamarWebService();


        }

    }
}
