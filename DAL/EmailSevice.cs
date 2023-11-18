using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class EmailSevice
    {
        System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
        public void EnviarEmail(BE.Usuario usuBE) //mail y clave sin encriptar
        {
            string mensaje = "Se ha generado la clave: " + usuBE.clavesinencriptar + " para el usuario:" + usuBE._Usuario;

            msg.To.Add(usuBE.Email);
            msg.Subject = "clave Nuevo Usuario";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Bcc.Add("valentini.carlos.marcelo@gmail.com");
            msg.Body = "  " + mensaje.ToString() + "  .";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;

            msg.From = new System.Net.Mail.MailAddress("valentini.carlos.marcelo@gmail.com",msg.Subject);

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.UseDefaultCredentials = false;
            cliente.Credentials = new System.Net.NetworkCredential("softwareods@gmail.com", "aqekytiwqpxdrvks");

            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";


            cliente.Send(msg);

        }

        public void enviarmailconadjunto(byte[] documentoPDF, string correo)
        {
            string mensaje = "Adjuntamos la factura de Servicio. Muchas gracias ";

            msg.To.Add(correo);
            msg.Subject = "Gracias por usar ODS Software";
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Bcc.Add("valentini.carlos.marcelo@gmail.com");
            msg.Body = "  " + mensaje.ToString() + "  .";
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = false;

            msg.Attachments.Add(new Attachment(new MemoryStream(documentoPDF), "Factura.pdf"));
            msg.From = new System.Net.Mail.MailAddress("valentini.carlos.marcelo@gmail.com", msg.Subject);

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();
            cliente.UseDefaultCredentials = false;
            cliente.Credentials = new System.Net.NetworkCredential("softwareods@gmail.com", "aqekytiwqpxdrvks");

            cliente.Port = 587;
            cliente.EnableSsl = true;
            cliente.Host = "smtp.gmail.com";


            cliente.Send(msg);
        }
    }
}
