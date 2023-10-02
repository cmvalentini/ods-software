using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages.Familia
{
    public partial class AsignarPermisosUsuario : System.Web.UI.Page
    {

        BLL.PermisosComposite.ManejadorPerfilUsuarios mpu = new BLL.PermisosComposite.ManejadorPerfilUsuarios();
        List<BE.Permisos.Component> listaoperaciones = new List<BE.Permisos.Component>();
        List<BE.Permisos.Component> listaoperacionesperfil = new List<BE.Permisos.Component>();
        BLL.PermisosComposite.Composite Composite = new BLL.PermisosComposite.Composite();
        BE.Familia.Familia PerfilBE = new BE.Familia.Familia();
        List<BE.Familia.Familia> listafamilias = new List<BE.Familia.Familia>();
        List<BE.Usuario> listausuarios = new List<BE.Usuario>();
        BLL.Familia.FamiliaBLL familiaBLL = new BLL.Familia.FamiliaBLL();
        BLL.Usuario.Usuario usuariobll = new BLL.Usuario.Usuario();
        BE.Usuario usuariobe = new BE.Usuario();
        BLL.Seguridad.BitacoraBLL logbll = new BLL.Seguridad.BitacoraBLL();
        BLL.Seguridad.DigitosVerificadoresBLL digBLL = new BLL.Seguridad.DigitosVerificadoresBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!this.IsPostBack)
            {
                listafamilias = familiaBLL.GetFamilias(listafamilias);

                ddlRolList.DataSource = listafamilias;
                ddlRolList.DataTextField = "NombrePerfil";
                ddlRolList.DataValueField = "NombrePerfil";
                ddlRolList.DataBind();

                listausuarios = usuariobll.GetUsuarios(listausuarios);

                ddlUserList.DataSource = listausuarios;
                ddlUserList.DataTextField = "_Usuario";
                ddlUserList.DataValueField = "_Usuario";
                ddlUserList.DataBind();

            }



        }

        protected void ddlRolList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ordenarlistas();
        }

        private void ordenarlistas() {

            PerfilBE.NombrePerfil = ddlRolList.SelectedItem.Value;
            String rolSelected = ddlRolList.SelectedItem.ToString();
            String rolSelected1 = ddlRolList.SelectedIndex.ToString();

            listAssing.Items.Clear();
            listNotAssing.Items.Clear();
            listaoperacionesperfil.Clear();
            listaoperacionesperfil = mpu.MostrarListaOperaciones(PerfilBE);
            listaoperaciones.Clear();
            listaoperaciones = mpu.GetOperaciones();

            for (int i = 0; i < listaoperaciones.Count; i++)
            {
                for (int j = 0; j < listaoperacionesperfil.Count; j++)
                {
                    listaoperaciones = listaoperaciones.OrderBy(x => x.Nombre).ToList();
                    listaoperacionesperfil = listaoperacionesperfil.OrderBy(x => x.Nombre).ToList();

                    if (listaoperaciones[i].Nombre == listaoperacionesperfil[j].Nombre)
                    {
                        listaoperaciones.Remove(listaoperaciones[i]);

                    }
                }
            }

            foreach (BE.Permisos.Component item in listaoperaciones)
            {
                listNotAssing.Items.Add(item.Nombre);
            }

            foreach (BE.Permisos.Component item in listaoperacionesperfil)
            {
                listAssing.Items.Add(item.Nombre);
            }

        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                string ope = listNotAssing.SelectedItem.Value;

                listAssing.Items.Add(ope);


                listNotAssing.Items.Remove(ope);

            }
            catch (Exception)
            {

                (this.Master as Menu_operaciones).mostrarmodal("Seleccione un elemento", BE.ControlException.TipoEventoException.Aviso);
            }
        }

        protected void btnDesasignar_Click(object sender, EventArgs e)
        {
            try
            {
                string ope = listAssing.SelectedItem.Value;

                listNotAssing.Items.Add(ope);


                listAssing.Items.Remove(ope);

            }
            catch (Exception)
            {

                (this.Master as Menu_operaciones).mostrarmodal("Seleccione un elemento", BE.ControlException.TipoEventoException.Aviso);
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {

            try
            {
                for (int i = 0; i < listAssing.Items.Count; i++)
                {
                    BE.Permisos.Component componente = new BE.Permisos.Component(listAssing.Items[i].Value);
                    listaoperacionesperfil.Add(componente);

                }
                PerfilBE.NombrePerfil = ddlRolList.SelectedItem.Value;
                usuariobe._Usuario = ddlUserList.SelectedItem.Value;
                mpu.UpdatePermisosUsuario(usuariobe, listaoperacionesperfil);

                (this.Master as Menu_operaciones).mostrarmodal("Permisos Aplicados Correctamente", BE.ControlException.TipoEventoException.Info);

                int usuarioid = (int)Session["UsuarioID"];
                logbll.IngresarDatoBitacora("Asignación de Permisos Usuario ", "cambio de " + usuariobe._Usuario + " a " + PerfilBE.NombrePerfil + "", "Medio", usuarioid);
                digBLL.RecalcularDigitosunatabla("Bitacora");
                digBLL.RecalcularDigitosunatabla("usuariopatente");
                
            }
            catch (Exception)
            {
                (this.Master as Menu_operaciones).mostrarmodal("Ocurrio un error", BE.ControlException.TipoEventoException.Error);

                throw;
            }
         
        }

        protected void btnback_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/MenuPrincipal.aspx");
        }

        protected void ddlUserList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnAplicarFamilia_Click(object sender, EventArgs e)
        {
            try
            {
                PerfilBE.NombrePerfil = ddlRolList.SelectedItem.Value;
                usuariobe._Usuario = ddlUserList.SelectedItem.Value;

                mpu.AsignarPerfilaUsuario(PerfilBE, usuariobe);

                (this.Master as Menu_operaciones).mostrarmodal("Familia Aplicada", BE.ControlException.TipoEventoException.Info);

                digBLL.RecalcularDigitosunatabla("Usuario");
            }
            catch (Exception)
            {
                (this.Master as Menu_operaciones).mostrarmodal("Ocurrió un error", BE.ControlException.TipoEventoException.Info);

                throw;
            }
           

          
        }
    }
}