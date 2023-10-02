using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages
{
    public partial class LandingPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnbuystandard_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito/Carrito.aspx?op=S");
        }

        protected void btnBuyFree_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito/Carrito.aspx?op=F");
        }

        protected void btnbuyPremium_Click(object sender, EventArgs e)
        {
            Response.Redirect("Carrito/Carrito.aspx?op=P");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}