using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CapaPresentacion.Utilidades
{
    public class Correo
    {
        public static readonly string correoElectronico = ConfigurationManager.AppSettings["CorreoElectronico"].ToString();
        public static readonly string claveCorreo = ConfigurationManager.AppSettings["ClaveCorreo"].ToString();
        public bool EnviarCorreo(string correoDestino, string asunto, string mensaje)
        {
            bool resultado;
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(correoElectronico, "Francisco Bruno");
                mail.To.Add(correoDestino);

                mail.Subject = asunto;
                mail.Body = mensaje;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential(correoElectronico, claveCorreo);
                smtp.EnableSsl = true;
                smtp.Send(mail);

                resultado = true;
            }
            catch (Exception ex)
            {
                resultado = false;
                throw ex;
            }
            return resultado;
        }
    }
}
