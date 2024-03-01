using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaEntidad.Utilidades
{
    public class Correo
    {
        public static readonly string correoElectronico = ConfigurationManager.AppSettings["CorreoElectronico"].ToString();
        public static readonly string claveCorreo = ConfigurationManager.AppSettings["ClaveCorreo"].ToString();
        public void EnviarCorreo(string correoDestino, string asunto, string mensaje, string pathArchivo)
        {
            try
            {
                SmtpClient smtp = new SmtpClient("smtp.office365.com");
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.Credentials = new System.Net.NetworkCredential(correoElectronico, claveCorreo);

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(correoElectronico, "Francisco Bruno");
                mail.To.Add(correoDestino);
                mail.Subject = asunto;
                mail.Body = mensaje;

                if (pathArchivo != "")
                {
                    Attachment archivo = new Attachment(pathArchivo);
                    mail.Attachments.Add(archivo);
                }

                smtp.Send(mail);

                MessageBox.Show("Correo enviado correctamente", "Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
