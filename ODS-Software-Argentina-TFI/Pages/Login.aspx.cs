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
        BLL.Usuario.Usuario usuariobll = new BLL.Usuario.Usuario();
        BLL.Seguridad.DigitosVerificadoresBLL digitos = new BLL.Seguridad.DigitosVerificadoresBLL();
        BLL.Services.EmailSeviceBLL emailSevice = new BLL.Services.EmailSeviceBLL();
        BLL.IdiomaBLL IdiomaBLL = new BLL.IdiomaBLL();

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
                    logbll.IngresarDatoBitacora("LogIn", "Usuario no encontrado", "Medio", 1);
                    usu._Usuario = txtusuario.Text;
                    //busco usuario por el nombre
                    usu = usuariobll.GetbyUser(usu);
                   
                    //Si los intentos son mayores a 3 que no lo deje ingresar ya que esta bloqueado el usuario
                    if (usu.FlagIntentosLogin >= 3)
                    {
                        (this.Master as MP).mostrarmodal("El usuario se encuentra Bloqueado, se le enviará un correo a la casilla", BE.ControlException.TipoEventoException.Error);
                        emailSevice.enviarmail(usu);
                        logbll.IngresarDatoBitacora("LogIn", "Usuario Bloqueado"+ usu._Usuario +"", "Medio", 1);
                        digitos.RecalcularDigitosunatabla("Usuario");
                    }
                    //Si el usuario existe en la BD pero ingresaron mal la clave, se le incrementa el flag de intentos fallidos
                    else if (usu._Usuario != null) {
                        logbll.IngresarDatoBitacora("LogIn", "Contraseña incorrecta para usuario " + usu._Usuario, "Medio", 1);
                        (this.Master as MP).mostrarmodal("Contraseña invalida", BE.ControlException.TipoEventoException.Aviso);
                        usuariobll.SumarFlagIntentos(usu);
                    }
                }
                //Si el usuario es null, es porque lo ingresaron de manera incorrecta
                else if (usu._Usuario is null) {
                    logbll.IngresarDatoBitacora("LogIn", "Usuario no encontrado", "Medio", 1);

                    (this.Master as MP).mostrarmodal("Usuario no encontrado", BE.ControlException.TipoEventoException.Error);
                    digitos.RecalcularDigitosunatabla("Bitacora");
                }
                else if (usu.FlagIntentosLogin >= 3) {

                    (this.Master as MP).mostrarmodal("El usuario se encuentra Bloqueado", BE.ControlException.TipoEventoException.Error);


                }
                //En este apartado el usuario ingresó correctamente el nombre de usuario y clave
                else if (usu._Usuario != null && usu.FlagIntentosLogin < 3)
                {
                    //se registra en la bitacora
                    logbll.IngresarDatoBitacora("LogIn", "Login Exitoso", "Bajo", usu.UsuarioID);
                    //Se guardan las cookies de sesión
                     
                    Session["Usuarionombre"] = usu.Nombre;
                    Session["Usuario"] = usu._Usuario;
                    Session["UsuarioID"] = usu.UsuarioID;
                    Session["PerfilID"] = usu.PerfilID;
                    
                    digitos.RecalcularDigitosunatabla("Bitacora");

                   

                    Response.Redirect("MenuPrincipal.aspx");
                }
               
            }
            catch (Exception  )
            {
                //en este apartado arrojamos las execpciones por error
                (this.Master as MP).mostrarmodal("Ocurrio un error, por favor reintentar",BE.ControlException.TipoEventoException.Error);
                logbll.IngresarDatoBitacora("LogIn", "Ocurrio un error, por favor reintentar", "Medio",0);
                digitos.RecalcularDigitosunatabla("Bitacora");

            }



        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("BlanquearClave.aspx");

        }

        protected void DropIdiom_TextChanged(object sender, EventArgs e)
        {

            TraductorWeb.TraducirPagina(0,this);
        }

        protected void DropIdiom_SelectedIndexChanged(object sender, EventArgs e)
        {
            
 
        }

        protected void imgEnglish_Click(object sender, ImageClickEventArgs e)
        {
            Session["IdiomaID"] = 1;
            TraductorWeb.TraducirPagina(1,this);
        }

        protected void imgSpanish_Click(object sender, ImageClickEventArgs e)
        {
            Session["IdiomaID"] = 0;
            TraductorWeb.TraducirPagina(0, this);
        }
    }
}