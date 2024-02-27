using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaEntidad.State
{
    public class Pendiente : Estado
    {
        public override string Valor
        {
            get
            {
                return "Pendiente";
            }
        }
        public override void CambiarEstado(ComprobanteObra comprobante)
        {
            comprobante.SetEstado(new EnCurso());
        }
        public override void Accion(ComprobanteObra comprobante)
        {
            string msge = "La obra se encuentra en curso";
            string from = "franciscobruno_tdp@outlook.com";
            string displayName = "Francisco Bruno";

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(from, displayName);
                mail.To.Add(comprobante.oCliente.Correo);

                mail.Subject = "Obra " + comprobante.NumeroComprobante + "en curso";
                mail.Body = msge;
                mail.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587);
                smtp.Credentials = new System.Net.NetworkCredential(from, "Tdp12345");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
            MessageBox.Show("La obra se encuentra en curso " + Valor, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
