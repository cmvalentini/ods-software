using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
        BLL.Seguridad.DigitosVerificadoresBLL dvbll = new BLL.Seguridad.DigitosVerificadoresBLL();

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
                    break;
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

                BE.Pedido.PedidoBE pedido = new BE.Pedido.PedidoBE(USUARIO, empresa, op);
                BLL.Pedido.PedidoBLL pedidoBLL = new BLL.Pedido.PedidoBLL();

                pedidoBLL.IngresarPedido(pedido);

                logbll.IngresarDatoBitacora("Compra Servicio", "Creación Servicio Pendiente verificacion:" + txtEmpresa.Text + " ", "Medio", Convert.ToInt32(Session["UsuarioID"]));
                // (this.Master as Menu_operaciones).mostrarmodal("Creación usuario exitosa", BE.ControlException.TipoEventoException.Aviso);

                digBLL.RecalcularDigitosunatabla("Bitacora");
                digBLL.RecalcularDigitosunatabla("Usuario");
                digBLL.RecalcularDigitosunatabla("Pedido");
                btndownload.Visible = true;
                btndownload.Enabled = true;

                 
                ScriptManager.RegisterStartupScript(this, this.GetType(), "popup", "alert('Gracias por su Compra, un representante se pondrá en contacto')", true);


            }
        }

        protected void PRINT_Click(object sender, EventArgs e)
        {
            #region Exportar PDF
            const String API_KEY = "valentini.carlos.marcelo@gmail.com_16a241fce21f64f57c002ec4955def6d11cf1555deea4451a8baf62311d0034794c65331";
            const string DestinationFile = @"C:\Users\Public\Downloads\_Sales_Document.pdf";
            WebClient webClient = new WebClient();
            webClient.Headers.Add("x-api-key", API_KEY);
            //template html
            string url = "https://api.pdf.co/v1/pdf/convert/from/html";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("templateId", 1);
            parameters.Add("name", Path.GetFileName(DestinationFile));
            parameters.Add("margins", "40px 20px 20px 20px");
            parameters.Add("paperSize", "Letter");
            parameters.Add("orientation", "Portrait");
            parameters.Add("header", "");
            parameters.Add("printBackground", true);
            parameters.Add("footer", "");
            parameters.Add("async", false);
            parameters.Add("encrypt", false);

            //  parameters.Add("templateData", "{\"paid\": true,\"invoice_id\": \"0021\",\"invoice_date\": \"August 29, 2041\",\"invoice_dateDue\": \"September 29, 2041\",\"issuer_name\": \"ODS SOFTWARE\",\"issuer_company\": \"Research Lab\",\"issuer_address\": \"435 South La Fayette Park Place, Argentina, CA 90057\",\"issuer_website\": \"www.example.com\",\"issuer_email\": \"info@odssoft.com\",\"client_name\": \"Cyberdyne Systems\",\"client_company\": \"Cyberdyne Systems\",\"client_address\": \"18144 El Camino Real, Sunnyvale, California\",\"client_email\": \"sales@example.com\",\"items\": [    {    \"name\": \"T-800 Prototype Research\",    \"price\": 1000.00     },   {    \"name\": \"T-800 Cloud Sync Setup\",   \"price\": 300.00     }  ],\"discount\": 100,\"tax\": 87,\"total\": 1287,\"note\": \"thank you for choosing us\"}"
            DateTime fechaemision =  DateTime.Now;
            DateTime fechavencimiento = DateTime.Now;
            fechavencimiento.AddDays(5);
            parameters.Add("templateData", "{\"paid\": true,\"invoice_id\": \"0021\",\"invoice_date\": \"" + fechaemision + "\",\"invoice_dateDue\": \"" + fechavencimiento + "\",\"issuer_name\": \"ODS SOFTWARE\",\"issuer_company\": \"ODS SOFTWARE\",\"issuer_address\": \"Lorenzini 1709 Buenos Aires, Argentina, CA 90057\",\"issuer_website\": \"www.example.com\",\"issuer_email\": \"info@odssoft.com\",\"client_name\": \"" + txtrepresentantelegalApellido.Text + "\",\"client_company\": \"" + txtEmpresa.Text + "\",\"client_address\": \"" + txtaddress.Text + "\",\"client_email\": \"" + txtEmpresa.Text + "\",\"items\": [    {    \"name\": \"Servicio ODS Standard\",    \"price\": 3500.00     }  ],\"discount\": 0,\"tax\": 200,\"total\": 3700,\"note\": \"thank you for choosing us\"}"

) ;

            string jsonPayload = JsonConvert.SerializeObject(parameters);


            string response = webClient.UploadString(url, jsonPayload);
            JObject json = JObject.Parse(response);
            if (json["error"].ToObject<bool>() == false)
            {
                string resultFileUrl = json["url"].ToString();
                Console.WriteLine(resultFileUrl);
                webClient.DownloadFile(resultFileUrl, DestinationFile);
                Console.WriteLine("Generated PDF file saved as \"{0}\" file.", DestinationFile);

                webClient.Dispose();

                Console.WriteLine();

            }
            else
            {

            }

            #endregion

        }
    }
}