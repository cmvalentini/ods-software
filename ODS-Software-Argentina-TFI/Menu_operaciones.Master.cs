using ODS_Software_Argentina_TFI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI
{
    public partial class Menu_operaciones : System.Web.UI.MasterPage
    {
        BE.Usuario usuario = new BE.Usuario();
        List<BE.Permisos.Component> listaoperaciones = new List<BE.Permisos.Component>() ;
        BLL.PermisosComposite.Composite Composite = new BLL.PermisosComposite.Composite();
 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this is MasterPage)
            {
                traerpermisos();
            }
           
          
        }

        private void traerpermisos() {

            
            
            usuario._Usuario = Convert.ToString (Session["Usuario"]);
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

                    }

                }
            

              
            }
            catch (Exception )
            {

                throw;
            }

           



        }
        protected void btnBitacora_Click(object sender, EventArgs e)
        {
           Response.Redirect("Bitacora/Bitacora.aspx");
            
        }

        protected void btnhacerbackup_Click(object sender, EventArgs e)
        {

        }

        protected void btnUsuarios_Click(object sender, EventArgs e)
        {
            Response.Redirect("AMB_Usuario/Usuarios.aspx");
        }

        protected void btnBitacora_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Bitacora/Bitacora.aspx");

        }

        public void mostrarmodal(string msj, BE.ControlException.TipoEventoException tee)
        {
            ExceptionModal em = new ExceptionModal();
            em.MostrarModal(msj, tee);
              
            
        }

        
    }
}