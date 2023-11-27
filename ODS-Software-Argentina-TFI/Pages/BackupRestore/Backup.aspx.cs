using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages.BackupRestore
{
    public partial class Backup : System.Web.UI.Page
    {

        public static string permiso = "HacerBackUp";
        BLL.Seguridad.BitacoraBLL logbll = new BLL.Seguridad.BitacoraBLL();
        BLL.Seguridad.StateController state = new BLL.Seguridad.StateController();
        BLL.Seguridad.DigitosVerificadoresBLL digBLL = new BLL.Seguridad.DigitosVerificadoresBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

                }
                else
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
            }
        }

        protected void btnBackup_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.Seguridad.BackUpResrore backrestore = new BLL.Seguridad.BackUpResrore();
               backrestore.RealizarBackUp();
                (this.Master as Menu_operaciones).mostrarmodal("BACK UP Realizado con Éxito", BE.ControlException.TipoEventoException.Info);
                int usuarioid = (int)Session["UsuarioID"];
                logbll.IngresarDatoBitacora("Back Up", "Back Up Realizado", "Alta", usuarioid);
                digBLL.RecalcularDigitosunatabla("Bitacora");
                
            }
            catch (Exception)
            {
                (this.Master as Menu_operaciones).mostrarmodal("Ocurrió un error, por favor contacte al administrador", BE.ControlException.TipoEventoException.Error);

                throw;
            }
        
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MenuPrincipal.aspx");
        }
    }
}