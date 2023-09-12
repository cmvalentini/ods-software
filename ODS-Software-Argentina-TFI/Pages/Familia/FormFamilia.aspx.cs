using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages.Familia
{
    public partial class FormFamilia : System.Web.UI.Page
    {

        public static string id;
        public static string op;
        BLL.Familia.FamiliaBLL familybll = new BLL.Familia.FamiliaBLL();
        BE.Familia.Familia familybe = new BE.Familia.Familia();
        BLL.Seguridad.BitacoraBLL logbll = new BLL.Seguridad.BitacoraBLL();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        id = Request.QueryString["id"].ToString();
                    }
                    if (Request.QueryString["op"] != null)
                    {
                        op = Request.QueryString["op"].ToString();
                        switch (op)
                        {
                            case "C":
                                this.lbltitulo.Text = "Crear nueva Familia";
                                this.BtnCreate.Visible = true;
                                break;
                            case "R":
                                this.lbltitulo.Text = "Consultar Familia";
                                mostrarinfo();
                                //this.btnRead.Visible = true;
                                break;
                            case "U":
                                this.lbltitulo.Text = "Modificar Familia";
                                mostrarinfo();
                                this.BtnUpdate.Visible = true;
                                break;
                            case "D":
                                this.lbltitulo.Text = "Eliminar Familia";
                                mostrarinfo();
                                this.BtnDelete.Visible = true;
                                break;

                        }

                    }

                }
            }
            catch (Exception)
            {
                (this.Master as MP).mostrarmodal("Ocurrio un error, por favor reintentar", BE.ControlException.TipoEventoException.Error);
            }



        }
        private void mostrarinfo() {
            try
            {
                familybe.FamiliaID = Convert.ToInt16(id);
                familybe = familybll.GetbyID(familybe);
                txtDescPerfil.Text = familybe.DescPerfil;
                txtNombrePerfil.Text = familybe.NombrePerfil;
 
              
            }
            catch (Exception)
            {
                 
                (this.Master as Menu_operaciones).mostrarmodal("Ha ocurrido un error", BE.ControlException.TipoEventoException.Aviso);
            }
        }


protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListFamilia.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            familybe.FamiliaID = Convert.ToInt16(id);
            familybe = familybll.DeleteFamily(familybe);
            (this.Master as Menu_operaciones).mostrarmodal("Familia Eliminada", BE.ControlException.TipoEventoException.Info);
           
        }
        // PONER BITACORA EN LOS BOTONES!!
        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            familybe.FamiliaID = Convert.ToInt16(id);
            familybe.NombrePerfil = txtNombrePerfil.Text;
            familybe.DescPerfil = txtDescPerfil.Text;

            familybe = familybll.ModifyFamily(familybe);

            //nm.showMsg("Familia Modificada", this.Page);
            (this.Master as Menu_operaciones).mostrarmodal("Permisos modificados", BE.ControlException.TipoEventoException.Info);
             

        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                familybe.NombrePerfil = txtNombrePerfil.Text;
                familybe.DescPerfil = txtDescPerfil.Text;

                familybe = familybll.CreateFamily(familybe);
                //BITACORAA
                logbll.IngresarDatoBitacora("Creación Familia", "Creacion Familia exitosa :" + txtNombrePerfil.Text + " ", "Medio", Convert.ToInt32(Session["UsuarioID"]));
                (this.Master as Menu_operaciones).mostrarmodal("Familia Creada exitosamente", BE.ControlException.TipoEventoException.Info);

            }
            catch (Exception)
            {
                (this.Master as Menu_operaciones).mostrarmodal("Ocurrio un error, por favor reintentar", BE.ControlException.TipoEventoException.Error);

            }

        }
    }
}