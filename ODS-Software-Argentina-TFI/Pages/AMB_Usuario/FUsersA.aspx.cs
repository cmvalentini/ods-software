using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Serialization;

namespace ODS_Software_Argentina_TFI.Pages.AMB_Usuario
{
    public partial class FUsersA : System.Web.UI.Page
    {
        public static string id;
        public static string op;
        public static string permiso = "abmusuario";
        BLL.Usuario.Usuario usuariobll = new BLL.Usuario.Usuario();
        BE.Usuario usube = new BE.Usuario();
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
                                    this.lbltitulo.Text = "Crear nuevo Usuario";
                                    this.BtnCreate.Visible = true;
                                    break;
                                case "R":
                                    this.lbltitulo.Text = "Consultar Usuario";
                                    mostrarinfo();
                                    //this.btnRead.Visible = true;
                                    break;
                                case "U":
                                    this.lbltitulo.Text = "Modificar Usuario";
                                    mostrarinfo();
                                    this.BtnUpdate.Visible = true;
                                    break;
                                case "D":
                                    this.lbltitulo.Text = "Eliminar Usuario";
                                    mostrarinfo();
                                    this.BtnDelete.Visible = true;
                                    break;

                            }

                        }
                    
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
            catch (Exception)
            {
                (this.Master as MP).mostrarmodal("Ocurrio un error, por favor reintentar", BE.ControlException.TipoEventoException.Error);
            }
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                usube._Usuario = txtUsuario.Text;
                usube.Apellido = txtapellido.Text;
                usube.Email = txtemail.Text;
                usube.Nombre = txtnombre.Text;

                if (chkHabilitado.Checked)
                {
                    usube.Habilitado = true;
                }
                else
                {
                    usube.Habilitado = false;
                }

                 usube = usuariobll.CreateUser(usube);
                //Modal 

    
                logbll.IngresarDatoBitacora("Creación Usuario", "Creación usuario exitosa :"+txtUsuario.Text+" ", "Medio", Convert.ToInt32(Session["UsuarioID"]));
                (this.Master as Menu_operaciones).mostrarmodal("Creación usuario exitosa", BE.ControlException.TipoEventoException.Aviso);
                digBLL.RecalcularDigitosunatabla("Bitacora");
                digBLL.RecalcularDigitosunatabla("Usuario");
                exportarxml(usube);


            }
            catch (Exception)
            {
                (this.Master as Menu_operaciones).mostrarmodal("Ocurrio un error, por favor reintentar", BE.ControlException.TipoEventoException.Error);


            }


        }

        private void mostrarinfo() {
            try
            {
                usube.UsuarioID = Convert.ToInt16(id);
                usube = usuariobll.GetbyID(usube);

                txtapellido.Text = usube.Apellido;
                txtnombre.Text = usube.Nombre;
                txtUsuario.Text = usube._Usuario;
                txtemail.Text = usube.Email;

                if (usube.Habilitado == true)
                {
                    chkHabilitado.Checked = true;
                }
                throw new Exception();   
            }
            catch (Exception)
            { 

                (this.Master as Menu_operaciones).mostrarmodal("Ha Ocurrido un error", BE.ControlException.TipoEventoException.Aviso);
            }
           

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            usube.UsuarioID = Convert.ToInt32(id);
            usube._Usuario = txtUsuario.Text;
            usube.Apellido = txtapellido.Text;
            usube.Email = txtemail.Text;
            usube.Nombre = txtnombre.Text;

            if (chkHabilitado.Checked)
            {
                usube.Habilitado = true;
            }
            else
            {
                usube.Habilitado = false;
            }

            usube = usuariobll.UpdateUser(usube);
            
            logbll.IngresarDatoBitacora("Actualizacion de Usuario", "Actualización de usuario exitosa :" + txtUsuario.Text + " ", "Medio", Convert.ToInt32(Session["UsuarioID"]));
            (this.Master as Menu_operaciones).mostrarmodal("Modificación usuario exitosa", BE.ControlException.TipoEventoException.Aviso);
            digBLL.RecalcularDigitosunatabla("Bitacora");
            digBLL.RecalcularDigitosunatabla("Usuario");
          
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            logbll.IngresarDatoBitacora("Eliminación de Usuario", "Eliminación de usuario exitosa :" + txtUsuario.Text + " ", "Alto", Convert.ToInt32(Session["UsuarioID"]));
            (this.Master as Menu_operaciones).mostrarmodal("Eliminación usuario exitosa", BE.ControlException.TipoEventoException.Aviso);
            digBLL.RecalcularDigitosunatabla("Bitacora");
            digBLL.RecalcularDigitosunatabla("Usuario");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

        protected void BtnRead_Click(object sender, EventArgs e)
        {

        }

        void CargarDatos() {

            usube = usuariobll.GetbyID(usube);
            txtUsuario.Text = usube._Usuario;
            txtnombre.Text = usube.Nombre;
            txtapellido.Text = usube.Apellido;
            txtemail.Text = usube.Email;
            if (usube.Habilitado.ToString() == "1")
            {
                chkHabilitado.Checked = true;
            }
            logbll.IngresarDatoBitacora("Carga de datos Usuario", " "+txtnombre.Text + txtUsuario.Text + " ", "Bajo", Convert.ToInt32(Session["UsuarioID"]));
            digBLL.RecalcularDigitosunatabla("Bitacora");
        }


        private void exportarxml(BE.Usuario usu) {
            #region exportarxml

            XmlSerializer xsSubmit = new XmlSerializer(typeof(BE.Usuario));
            var xml = "";

            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, usu);
                    xml = sww.ToString(); // Your XML
                }
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(xml);

            string filePath = Server.MapPath("~/"+usu._Usuario+"__usuario.xml");

            xdoc.Save(filePath);
           
             
            // Provide a download link for the generated XML file
            Response.Clear();
            Response.ContentType = "application/xml";
            Response.AppendHeader("Content-Disposition", "attachment; filename=__usuario.xml");
            Response.TransmitFile(filePath);
            Response.End();
            #endregion


        }


    }
}