using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Controllers
{
    public partial class CalendarControl : System.Web.UI.UserControl
    {
        BLL.Usuario.Usuario usuariobll = new BLL.Usuario.Usuario();
        List<BE.Usuario> listaUser = new List<BE.Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaUser = usuariobll.GetUsuarios(listaUser);

               //DropUsuario.Items.Add("");

                foreach (var user in listaUser)
                {
                    DropUsuario.Items.Add(user._Usuario.ToString());
                }

                CalDesde.Visible = false;
                CalHasta.Visible = false;

               // Traduccion.SuscribirObservador(this);
            }

           // Traducir(Session["Idioma"].ToString());
        }

        protected void ibDesde_Click(object sender, ImageClickEventArgs e)
        {
            if (CalDesde.Visible == true)
            {
                CalDesde.Visible = false;
            }
            else
            {
                CalDesde.Visible = true;
            }
        }

        protected void ibHasta_Click(object sender, ImageClickEventArgs e)
        {
               if (CalHasta.Visible == true)
                {
                    CalHasta.Visible = false;
                }
                else
                {
                    CalHasta.Visible = true;
                }

                lblError.Text = "";
        }

        protected void CalHasta_SelectionChanged(object sender, EventArgs e)
        {
            tbHasta.Text = CalHasta.SelectedDate.ToShortDateString();
            CalHasta.Visible = false;
        }

        protected void CalDesde_SelectionChanged(object sender, EventArgs e)
        {
            tbDesde.Text = CalDesde.SelectedDate.ToShortDateString();
            CalDesde.Visible = false;
        }

        public string GetFechaDesde()
        {
            return tbDesde.Text;
        }

        public string GetFechaHasta()
        {
            return tbHasta.Text;
        }

        public string GetUsuario()
        {
            return DropUsuario.SelectedValue;
        }

        public string GetCriticidad()
        {
            return DropCriticidad.SelectedValue;
        }

    }
}