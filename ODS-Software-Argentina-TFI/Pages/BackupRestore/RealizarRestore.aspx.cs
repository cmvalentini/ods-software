using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages.BackupRestore
{
    public partial class RealizarRestore : System.Web.UI.Page
    {
        BLL.Seguridad.BitacoraBLL logbll = new BLL.Seguridad.BitacoraBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
            }
        }

        protected void btnRestore_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.Seguridad.BackUpResrore backrestore = new BLL.Seguridad.BackUpResrore();
                backrestore.RealizarRestore();
                (this.Master as Menu_operaciones).mostrarmodal("Restore Realizado con Éxito", BE.ControlException.TipoEventoException.Info);
                int usuarioid = (int)Session["UsuarioID"];
                logbll.IngresarDatoBitacora("Restore", "Restore Realizado", "Alta", usuarioid);

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