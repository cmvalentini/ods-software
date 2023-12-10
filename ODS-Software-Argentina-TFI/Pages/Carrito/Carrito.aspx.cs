using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IronPdf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SelectPdf;
using HtmlToPdf = SelectPdf.HtmlToPdf;

namespace ODS_Software_Argentina_TFI.Pages.Carrito
{
    public partial class Carrito : System.Web.UI.Page
    {
        BE.Pedido.Empresa empresa = new BE.Pedido.Empresa();
        string op = "S"; //valor por defecto 
        BLL.Seguridad.DigitosVerificadoresBLL digBLL = new BLL.Seguridad.DigitosVerificadoresBLL();
        BE.Seguridad.Encriptacion encriptacion = new BE.Seguridad.Encriptacion();
        BE.Usuario USUARIO = new BE.Usuario();
        BLL.Seguridad.EncriptacionBLL cryp = new BLL.Seguridad.EncriptacionBLL();
        BLL.Seguridad.BitacoraBLL logbll = new BLL.Seguridad.BitacoraBLL();
        BLL.Seguridad.DigitosVerificadoresBLL dvbll = new BLL.Seguridad.DigitosVerificadoresBLL();
        BLL.Pedido.PedidoBLL pedidoBLL = new BLL.Pedido.PedidoBLL();
        int IVA;
        int preciosiniva;

        protected void Page_Load(object sender, EventArgs e)
        {
           
            op = Request.QueryString["op"].ToString();
            switch (op)
            {
                case "S":
                    lbllicense.Text = "Unlimited ODS License and 2 ISO License";
                    lblcommunity.Text = "Community Blog";
                    lbltast.Text = "Task Limit";
                    lblcontractors.Text = "Contractors Limit";
                    lblPrice.Text = "2.500.000";
                    IVA = 525000;
                    preciosiniva = 1975000;
                    lblService2.Text = "Standard";
                    break;
                    
                case "F":

                    lbllicense.Text = "1 ODS License";
                    lblcommunity.Text = "Community Blog";
                    lbltast.Text = "Task Limit";
                    lblcontractors.Text = "Contractors Limit";
                    lblPrice.Text = "0";
                    lblService2.Text = "Free";
                    IVA = 0;
                    preciosiniva = 0;
                    break;
                case "P":

                    lbllicense.Text = "Unlimited ODS License and 1 ISO License";
                    lblcommunity.Text = "Community Blog";
                    lbltast.Text = "Task Limit";
                    lblcontractors.Text = "Contractors Limit";
                    lblPrice.Text = "5.000.000";
                    lblService2.Text = "Premium";
                    IVA = 1050000;
                    preciosiniva = 3950000;
                    break;
                case "D":
                    lbllicense.Text = "Unlimited ODS License and 2 ISO License";
                    lblcommunity.Text = "Community Blog";
                    lbltast.Text = "Task Limit";
                    lblcontractors.Text = "Contractors Limit";
                    IVA = 1050000;
                    preciosiniva = 3950000;
                    lblService2.Text = "Premium";
                    break;

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

        protected void btnLogin_Click(object sender, EventArgs e)
        {

        }

        protected void btnCompreas_Click(object sender, EventArgs e)
        {
            
               


                USUARIO._Usuario = txtempresa.Text;
                USUARIO.Nombre = txtrepresentantelegalnombre.Text;
                USUARIO.Apellido = txtrepresentantelegalapellido.Text;
                USUARIO.Dni = Convert.ToInt32(txtdniempresa.Text);
                USUARIO.Email = txtemail.Text;
                encriptacion = cryp.CrearPassword();
                USUARIO.Clave = encriptacion.Result;
                USUARIO.PerfilID = 2;
                USUARIO.Habilitado = true;

               
                empresa.Nombre = txtempresa.Text;
                empresa.URLComprobante = @"C:\Users\Charly\Downloads\" + txtempresa.Text ;
                empresa.URLDatosEmpresa = @"C:\Users\Charly\Downloads\" + txtempresa.Text;

                BE.Pedido.PedidoBE pedido = new BE.Pedido.PedidoBE(USUARIO, empresa, op);
            

                pedidoBLL.IngresarPedido(pedido);

                logbll.IngresarDatoBitacora("Compra Servicio", "Creación Servicio Pendiente verificacion:" + txtempresa.Text + " ", "Medio", Convert.ToInt32(Session["UsuarioID"]));
                
                digBLL.RecalcularDigitosunatabla("Bitacora");
                digBLL.RecalcularDigitosunatabla("Usuario");
                digBLL.RecalcularDigitosunatabla("Pedido");
                btndownload.Visible = true;
                btndownload.Enabled = true;

                 
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Gracias por su Compra, un representante se pondrá en contacto')", true);


            
        }
 
        protected void PRINT_Click(object sender, EventArgs e)
        {
            #region ArmarComprobante

            string html = ObtenerRecursoHTML("ODS_Software_Argentina_TFI.Invoice.html");

            int n_factura =  pedidoBLL.GetLastInvoiceNumer();

          
            n_factura = n_factura + 1;
            string final = html.Replace("{{FECHA_OPERACION}}", DateTime.Now.ToString())
               .Replace("{{NOMBRE_NEGOCIO}}", txtempresa.Text)
               .Replace("{{DIRECCION_NEGOCIO}}", txtaddress.Text)
               .Replace("{{EMAIL_NEGOCIO}}", txtemail.Text)
               .Replace("{{N_FACTURA}}", n_factura.ToString())
               .Replace("{{MONTO_TOTAL}}", lblPrice.Text)
               .Replace("{{SERVICIO}}", lblService2.Text)
               .Replace("{{SERVICIO_DESCRIPCION}}", "Servicio Implementación ")
               .Replace("{{SERVICIO-SIN-IVA}}", preciosiniva.ToString())
               .Replace("{{MONTO_TOTAL}}",lblPrice.Text)
               .Replace("{{IVA}}", IVA.ToString());


            using (MemoryStream ms = new MemoryStream())
            {
                HtmlToPdf converter = new HtmlToPdf();

                // convierte el HTML a PDF
                SelectPdf.PdfDocument doc = converter.ConvertHtmlString(final);
                doc.Save(ms);
                 
                byte[] DocumentoPDF = ms.ToArray();

                BLL.Services.EmailSeviceBLL emailbll = new BLL.Services.EmailSeviceBLL();

                emailbll.enviarmailconadjunto(DocumentoPDF, txtemail.Text);

                //create your file at filePath
               
                //  File(DocumentoPDF, System.Net.Mime.MediaTypeNames.Application.Octet, "Invoice"+ n_factura + ".pdf");



            }



            #endregion

        }

        private void File(byte[] fileBytes, string octet, string v)
        {
            throw new NotImplementedException();
        }

        private static string ObtenerRecursoHTML(string recurso)
        {
            var assembly = Assembly.GetExecutingAssembly();
            string[] lista = assembly.GetManifestResourceNames();

            string[] lista2 = Assembly.GetExecutingAssembly().GetManifestResourceNames();
             
            //var lista = assembly.GetManifestResourceNames();
            using (var stream = assembly.GetManifestResourceStream(recurso))
            {
                if (stream == null)
                {
                    throw new Exception("Recurso no encontrado");
                }
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }



        }
        



    }
}