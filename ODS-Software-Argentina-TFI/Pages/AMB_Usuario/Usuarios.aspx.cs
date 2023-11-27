using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages.AMB_Usuario
{
    public partial class Usuarios : System.Web.UI.Page
    {
        string id;
        List<BE.Usuario> listausuarios = new List<BE.Usuario>();
        static string permiso = "abmusuario";
        BLL.Seguridad.StateController state = new BLL.Seguridad.StateController();
        // /Pages/Login.aspx
       
        protected void Page_Load(object sender, EventArgs e)
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

            //redirect si no tiene permisos
            if (state.verificarpermisos(permiso, (int)Session["UsuarioID"]) == 1)
            {
                
                GetUsuarios();
            }
            else
            {
                Response.Redirect("~/Pages/Login.aspx");
            }
            
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("FUsersA.aspx?op=C");
        }

        protected void btnUpdateUser_Click(object sender, EventArgs e)
        {
            Button btnconsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnconsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("FUsersA.aspx?id="+id +"&op=U");
        }

        protected void btnReadUser_Click(object sender, EventArgs e)
        {
           
            Button btnconsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnconsultar.NamingContainer;
            id = selectedrow.Cells[1].Text;
            Response.Redirect("FUsersA.aspx?id=" + id+"&op=R");
        }

        protected void btnDeleteUser_Click(object sender, EventArgs e)
        {
            Button btnconsultar = (Button)sender;
            GridViewRow selectedrow = (GridViewRow)btnconsultar.NamingContainer;
            id = selectedrow.Cells[0].Text;
            Response.Redirect("FUsersA.aspx?id=" + id + "&op=D");
        }

        private void GetUsuarios() {
            BLL.Usuario.Usuario usuarios = new BLL.Usuario.Usuario();
            listausuarios = usuarios.GetUsuarios(listausuarios);
            dvgUsers.DataSource = listausuarios;
            dvgUsers.DataBind();

        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MenuPrincipal.aspx");

        }
    }
}