using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        BE.Usuario usu = new BE.Usuario();
        BLL.sesion sesionusuario = BLL.sesion.GetInstance();
        BLL.Seguridad.BitacoraBLL logbll = new BLL.Seguridad.BitacoraBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnaceptar_Click(object sender, EventArgs e)
        {
            
          
            try
            {
                usu._Usuario = txtusuario.Text;
                usu.Clave = txtclave.Text;
                sesionusuario.GetUsuariosesion(usu);
                if (usu._Usuario is null)
                {
                    throw new Exception();

                }
                else if (usu._Usuario != null && usu.FlagIntentosLogin < 3)
                {
                    //entra
                    Session["Usuarionombre"] = usu.Nombre;
                    Session["Usuario"] = usu._Usuario;
                    Session["UsuarioID"] = usu.UsuarioID;
                    logbll.IngresarDatoBitacora("LogIn", "Login Exitoso", "Bajo", usu.UsuarioID);
                    Response.Redirect("MenuPrincipal.aspx");
                }
               
            }
            catch (Exception  )
            {
                (this.Master as MP).mostrarmodal("Ocurrio un error, por favor reintentar",BE.ControlException.TipoEventoException.Error);
                logbll.IngresarDatoBitacora("LogIn", "Ocurrio un error, por favor reintentar", "Medio",0);

            }



        }
    }
}