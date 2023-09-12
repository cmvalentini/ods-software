using ODS_Software_Argentina_TFI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI
{
    public partial class Menu_operaciones : System.Web.UI.MasterPage
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            
          
        }

    


        public void mostrarmodal(string msj, BE.ControlException.TipoEventoException tee)
        {
            ExceptionModal.MostrarModal(msj, tee);


        }

        
    }
}