using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

namespace ODS_Software_Argentina_TFI.Pages.Familia
{
    public partial class FormFamilia : System.Web.UI.Page
    {
        public static string permiso = "ABMFamilias";
        public static string id;
        public static string op;
        BLL.Familia.FamiliaBLL familybll = new BLL.Familia.FamiliaBLL();
        BE.Familia.Familia familybe = new BE.Familia.Familia();
        BLL.Seguridad.BitacoraBLL logbll = new BLL.Seguridad.BitacoraBLL();
        BLL.Seguridad.DigitosVerificadoresBLL digBLL = new BLL.Seguridad.DigitosVerificadoresBLL();
        BLL.Seguridad.StateController state = new BLL.Seguridad.StateController();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
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
                    else
                    {
                        Response.Redirect("~/Pages/Login.aspx");

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
           digBLL.RecalcularDigitosunatabla("PerfilUsuario");


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
            logbll.IngresarDatoBitacora("Modificación Familia", "Creación Familia exitosa :" + txtNombrePerfil.Text + " ", "Medio", Convert.ToInt32(Session["UsuarioID"]));

            digBLL.RecalcularDigitosunatabla("PerfilUsuario");

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
                digBLL.RecalcularDigitosunatabla("PerfilUsuario");

                exportarxml(familybe);
            }
            catch (Exception)
            {
                (this.Master as Menu_operaciones).mostrarmodal("Ocurrio un error, por favor reintentar", BE.ControlException.TipoEventoException.Error);

            }

        }

        private void exportarxml(BE.Familia.Familia familiabe)
        {
            #region exportarxml

            XmlSerializer xsSubmit = new XmlSerializer(typeof(BE.Familia.Familia));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, familiabe);
                    xml = sww.ToString(); // Your XML
                }
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xml);

            string filePath = Server.MapPath("~/" + familiabe.NombrePerfil + "__familia.xml");

            xdoc.Save(filePath);


            // Provide a download link for the generated XML file
            Response.Clear();
            Response.ContentType = "application/xml";
            Response.AppendHeader("Content-Disposition", "attachment; filename=__familia.xml");
            Response.TransmitFile(filePath);
            Response.End();
            #endregion


        }



    }
}