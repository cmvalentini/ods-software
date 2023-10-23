using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages
{
    public partial class BlanquearClave : System.Web.UI.Page
    {
        BE.Usuario UsuBE = new BE.Usuario();
        BLL.Usuario.Usuario USU = new BLL.Usuario.Usuario();
        BLL.Seguridad.DigitosVerificadoresBLL digitos = new BLL.Seguridad.DigitosVerificadoresBLL();
        BLL.Seguridad.BitacoraBLL bitacora = new BLL.Seguridad.BitacoraBLL();
        BLL.sesion sesionusuario = BLL.sesion.GetInstance();
         
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
        }

       

        protected void btncambiar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!verificarClave(txtclavenueva.Text))
                {
                    (this.Master as MP).mostrarmodal("La Clave debe tener minimo 8 digitos, mayusculas, minusculas y numeros. Por favor  verificar", BE.ControlException.TipoEventoException.Error);

                }
                UsuBE._Usuario = txtusuario.Text;
                UsuBE.Clave = txtclavevieja.Text; 
              UsuBE =  sesionusuario.GetUsuariosesion(UsuBE);
                if (UsuBE.UsuarioID.ToString() != "" )
                {
                    UsuBE = USU.CambiarClave(UsuBE, txtclavenueva.Text);
                    digitos.RecalcularDigitosunatabla("usuario");
                    bitacora.IngresarDatoBitacora("LogIn", "Cambio de Clave", "Bajo", UsuBE.UsuarioID);
                    digitos.RecalcularDigitosunatabla("Bitacora");
                    (this.Master as MP).mostrarmodal("Clave cambiada con exito", BE.ControlException.TipoEventoException.Info);

                }

            }
            catch (Exception)
            {

                (this.Master as MP).mostrarmodal("Ocurrio un error, por favor llamar al usuario Webmaster", BE.ControlException.TipoEventoException.Error);

            }

        }

        private bool verificarClave(string passWord) {

            int validConditions = 0;
            foreach (char c in passWord)
            {
                if (c >= 'a' && c <= 'z')
                {
                    validConditions++;
                    break;
                }
            }
            foreach (char c in passWord)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 0) return false;
            foreach (char c in passWord)
            {
                if (c >= '0' && c <= '9')
                {
                    validConditions++;
                    break;
                }
            }
            if (validConditions == 1) return false;
            //if (validConditions == 2)
            //{
            //    char[] special = { '@', '#', '$', '%', '^', '&', '+', '=' }; // or whatever    
            //    if (passWord.IndexOfAny(special) == -1) return false;
            //}
            return true;
        }
    }
}