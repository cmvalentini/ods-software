using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ODS_Software_Argentina_TFI.Pages.Carrito
{
    public partial class Carrito : System.Web.UI.Page
    {
        string op = "S"; //valor por defecto 
        BLL.Seguridad.DigitosVerificadoresBLL digBLL = new BLL.Seguridad.DigitosVerificadoresBLL();
        BE.Seguridad.Encriptacion encriptacion = new BE.Seguridad.Encriptacion();
        BE.Usuario USUARIO = new BE.Usuario();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Seguridad.BitacoraBLL logbll = new BLL.Seguridad.BitacoraBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
           
            op = Request.QueryString["op"].ToString();
            switch (op)
            {
                case "S":
                    
                    break;
                case "F":
                   
                    lbllicense.Text = "1 ODS License";
                    lblcommunity.Text = "Community Blog";
                    lbltast.Text = "Task Limit";
                    lblcontractors.Text = "Contractors Limit";

                    break;
                case "P":
                    lbllicense.Text = "Unlimited ODS License and 1 ISO License";
                    lblcommunity.Text = "Community Blog";
                    lbltast.Text = "Task Limit";
                    lblcontractors.Text = "Contractors Limit";
                    break;
                case "D":
                    lbllicense.Text = "Unlimited ODS License and 2 ISO License";
                    lblcommunity.Text = "Community Blog";
                    lbltast.Text = "Task Limit";
                    lblcontractors.Text = "Contractors Limit";
                    break;

            }

             
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        protected void btnCompreas_Click(object sender, EventArgs e)
        {
            if (FileUploadComprobante.HasFile && FileUploadEmpresa.HasFile)
            {
                string ruta = Server.MapPath("~/ClientImages/");
                string PathArchivo = Path.Combine(ruta + txtEmpresa.Text + FileUploadEmpresa.FileName);
                string PathComprobante = Path.Combine(ruta + txtEmpresa.Text + FileUploadComprobante.FileName);

                FileUploadEmpresa.SaveAs(PathArchivo);
                FileUploadComprobante.SaveAs(PathComprobante);

              
                USUARIO._Usuario = txtEmpresa.Text;
                USUARIO.Nombre = txtrepresentantelegalnombre.Text;
                USUARIO.Apellido = txtrepresentantelegalApellido.Text;
                USUARIO.Dni = Convert.ToInt32(txtDniEmpresa.Text);
                USUARIO.Email = txtemail.Text;
                encriptacion = cryp.CrearPassword();
                USUARIO.Clave = encriptacion.Result;
                USUARIO.PerfilID = 2;
                USUARIO.Habilitado = true;

                BE.Pedido.Empresa empresa = new BE.Pedido.Empresa();
                empresa.Nombre = txtEmpresa.Text;
                empresa.URLComprobante = PathComprobante;
                empresa.URLDatosEmpresa = PathArchivo;

                BE.Pedido.PedidoBE pedido = new BE.Pedido.PedidoBE(USUARIO,empresa, op);
                BLL.Pedido.PedidoBLL pedidoBLL = new BLL.Pedido.PedidoBLL();
                
                pedidoBLL.IngresarPedido(pedido);

                logbll.IngresarDatoBitacora("Compra Servicio", "Creación Servicio Pendiente verificacion:" + txtEmpresa.Text + " ", "Medio", Convert.ToInt32(Session["UsuarioID"]));
                // (this.Master as Menu_operaciones).mostrarmodal("Creación usuario exitosa", BE.ControlException.TipoEventoException.Aviso);
                
                digBLL.RecalcularDigitosunatabla("Bitacora");
                digBLL.RecalcularDigitosunatabla("Usuario");
                digBLL.RecalcularDigitosunatabla("Pedido");
                Response.Redirect("Login.aspx");
            }
            else
            {

            }

        }
    }
}