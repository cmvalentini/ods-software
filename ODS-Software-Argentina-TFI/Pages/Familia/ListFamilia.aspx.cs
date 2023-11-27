using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages.Familia
{
    public partial class ListFamilia : System.Web.UI.Page
    {
        string id;
        BLL.Familia.FamiliaBLL familiaBLL = new BLL.Familia.FamiliaBLL();
        List<BE.Familia.Familia> listafamilias = new List<BE.Familia.Familia>();
        public static string permiso = "ABMFamilias";
        BLL.Seguridad.StateController state = new BLL.Seguridad.StateController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                if (state.verificarpermisos(permiso, (int)Session["UsuarioID"]) == 1)
                {
                    if (Session["IdiomaID"] is null)
                    {
                        Session["IdiomaID"] = 0;
                        TraductorWeb.TraducirPagina((int)Session["IdiomaID"], this);
                    }
                    else
                    {
                        TraductorWeb.TraducirPagina((int)Session["IdiomaID"], this);
                    }
                    GetFamilias();
                }
                else
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
            }
        }

        private void GetFamilias() {

            listafamilias = familiaBLL.GetFamilias(listafamilias);
            dvgFamilys.DataSource = listafamilias;
            dvgFamilys.DataBind();
        }

        protected void btnCreateFamily_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormFamilia.aspx?op=C");
        }

        protected void btnUpdateFamily_Click(object sender, EventArgs e)
        {
            Button btnupdatefamily = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnupdatefamily.NamingContainer;
            id = selectedrow.Cells[3].Text;
            Response.Redirect("FormFamilia.aspx?id=" + id + "&op=U");
        }

        protected void btnReadFamily_Click(object sender, EventArgs e)
        {

        }

        protected void btnDeleteFamily_Click(object sender, EventArgs e)
        {
            Button btndeletefamily = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btndeletefamily.NamingContainer;
            id = selectedrow.Cells[3].Text;
            Response.Redirect("FormFamilia.aspx?id=" + id + "&op=D");
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MenuPrincipal.aspx");
        }
    }
    }
