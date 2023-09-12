using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages
{
    public partial class MenuPrincipal : System.Web.UI.Page
    {
        BE.Usuario usuario = new BE.Usuario();
        List<BE.Permisos.Component> listaoperaciones = new List<BE.Permisos.Component>();
        BLL.PermisosComposite.Composite Composite = new BLL.PermisosComposite.Composite();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
                traerpermisos();
            }


        }

        private void traerpermisos()
        {

            usuario._Usuario = Convert.ToString(Session["Usuario"]);
            usuario.UsuarioID = Convert.ToInt16(Session["UsuarioID"]);
            listaoperaciones = Composite.obtenerhijos(listaoperaciones, usuario);
            this.MapeoComponentes(listaoperaciones);

        }

        private void MapeoComponentes(IList<BE.Permisos.Component> listaoperaciones)
        {
            try
            {
                foreach (var i in listaoperaciones)
                {
                    string var = i.Nombre.ToString();
                    switch (var) //iterar los permisos
                    {
                        case "HacerBackUp":

                            this.btnBackUp.Enabled = true;
                            this.btnBackUp.Visible = true;
                            break;

                        case "abmusuario":

                            this.btnUsuarios.Enabled = true;
                            this.btnBackUp.Visible = true;
                            break;

                        case "consultarbitacora":
                            btnBitacora.Enabled = true;
                            btnBitacora.Visible = true;
                            break;

                        case "ABMFamilias":
                            BtnPermisos.Enabled = true;
                            BtnPermisos.Visible = true;
                            break;

                        case "AsignarPermisos":
                            BtnasignarPermisos.Enabled = true;
                            BtnasignarPermisos.Visible = true;
                            break;

                    }

                }

            }
            catch (Exception)
            {
                throw;
            }


        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("AMB_Usuario/Usuarios.aspx");
        }



        protected void btnBitacora_Click(object sender, EventArgs e)
        {

            Response.Redirect("Bitacora/Bitacora.aspx");

        }

        protected void btnhacerbackup_Click(object sender, EventArgs e)
        {

        }

        protected void BtnPermisos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Familia/ListFamilia.aspx");
        }

        protected void BtnasignarPermisos_Click(object sender, EventArgs e)
        {
            Response.Redirect("Familia/AsignarPermisosFamilia.aspx");
        }
    }
}