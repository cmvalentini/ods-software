using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Controllers
{
    public partial class AlertControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ShowAlert(String message, String title)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>customAlert.alert('" + message + "','" + title + "');</script>");
        }
        public void ShowAlert(String message)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>customAlert.alert('" + message + "');</script>");
        }

        public void ShowError(String message, String title)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>customAlert.error('" + message + "','" + title + "');</script>");
        }

        public void ShowError(String message)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "Scripts", "<script>customAlert.error('" + message + "');</script>");
        }


    }
}