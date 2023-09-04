using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 

namespace ODS_Software_Argentina_TFI.Pages
{
    public partial class ExceptionModal : System.Web.UI.UserControl
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        internal void MostrarModal(string msj, BE.ControlException.TipoEventoException tipo) {

            
            switch (tipo)
            {
                case BE.ControlException.TipoEventoException.Error:
                     
                    MensajeHeader.Text = "Error";
                    HeaderModal.Attributes["class"] = "modal-header bg-danger";
                    break;
                case BE.ControlException.TipoEventoException.Info:
                    MensajeHeader.Text = "Aviso";
                    HeaderModal.Attributes["class"] = "modal-header bg-info";

                    break;

                case BE.ControlException.TipoEventoException.Aviso:
                    MensajeHeader.Text = "Advertencia";
                    HeaderModal.Attributes["class"] = "modal-header bg-warning";
                    break;

            }


            MensajeCuerpo.Text = msj;
            string script = "var myModal = new bootstrap.Modal(document.getElementById('modal'), {backdrop: 'static',  keyboard: false});myModal.toggle();";

            ScriptManager.RegisterStartupScript(this,this.GetType(), "popup", script, true);
        }

    }
}