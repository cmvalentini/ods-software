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
        string permisosconcatenados;
        BE.Usuario usuario = new BE.Usuario();
        List<BE.Permisos.Component> listaoperaciones = new List<BE.Permisos.Component>();
        BLL.PermisosComposite.Composite Composite = new BLL.PermisosComposite.Composite();
        BE.Familia.Familia Familia = new BE.Familia.Familia();
        BLL.Familia.FamiliaBLL familybll = new BLL.Familia.FamiliaBLL();
        BLL.Seguridad.BitacoraBLL logbll = new BLL.Seguridad.BitacoraBLL();
        BLL.Seguridad.DigitosVerificadoresBLL digBLL = new BLL.Seguridad.DigitosVerificadoresBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
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

                traerpermisos();
                Familia.FamiliaID = (int)Session["PerfilID"];
                if (Familia.FamiliaID == 0)
                {

                }
                else
                {
                    Familia = familybll.GetbyID(Familia);
                    lblPerfil.Text = Familia.NombrePerfil;
                    lblPerfil.Visible = true;
                }
            }
       
            digBLL.RecalcularDigitosunatabla("Bitacora");
           List<Tuple<string, string>> listaErrores = digBLL.ValidarIntegridadSistema();

            if (listaErrores.Count != 0)
            {
                panelErrores.Visible = true;
                rptErrores.DataSource = listaErrores;
                rptErrores.DataBind();
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

                        case "HacerRestore":
                            BtnRestore.Enabled = true;
                            BtnRestore.Visible = true;
                            break;

                        case "digitosverificadores":
                            btnDigitosverificadores.Enabled = true;
                            btnDigitosverificadores.Visible = true;
                            break;

                        case "AsignarPermisos":
                            BtnasignarPermisos.Enabled = true;
                            BtnasignarPermisos.Visible = true;
                            BtnasignarPermisosusuario.Enabled = true;
                            BtnasignarPermisosusuario.Visible = true;
                            break;

                    }

                    permisosconcatenados = permisosconcatenados + " - " + i.Nombre +" ";
                    
                }
                Session["permisosconcatenados"] = permisosconcatenados;

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

        protected void imgbutton_Click(object sender, ImageClickEventArgs e)
        {

            permisosconcatenados = Session["permisosconcatenados"].ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('"+ permisosconcatenados + "')", true);

        }

        protected void BtnasignarPermisosusuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("Familia/AsignarPermisosUsuario.aspx");
        }

        protected void btnBackUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("BackUpRestore/RealizarBackUp.aspx");
        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            usuario._Usuario = Convert.ToString(Session["Usuario"]);
            usuario.UsuarioID = Convert.ToInt16(Session["UsuarioID"]);
            (this.Master as Menu_operaciones).mostrarmodal("Muchas gracias por utilizar nuestro sistema :-)", BE.ControlException.TipoEventoException.Info);
            logbll.IngresarDatoBitacora("LogOut", "Logout " + usuario._Usuario +" ", "Bajo", Convert.ToInt32(Session["UsuarioID"]));

            Session["Usuarionombre"] = null;
            Session["Usuario"] = null;
            Session["UsuarioID"] = null;
            Session["PerfilID"] = null;
            Session["permisosconcatenados"] = null;


            digBLL.RecalcularDigitosunatabla("Bitacora");
            Response.Redirect("~/Pages/Login.aspx");
        }

        protected void BtnRestore_Click(object sender, EventArgs e)
        {
            Response.Redirect("BackUpRestore/RealizarRestore.aspx");
        }

        protected void btnDigitosverificadores_Click(object sender, EventArgs e)
        {
            Response.Redirect("DigitosVerificadores/RecalcularDigitosVerificadores.aspx");
        }
    }
}