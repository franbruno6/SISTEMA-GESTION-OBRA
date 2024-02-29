using CapaEntidad.Utilidades;
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
            string mensaje = "Estimado, este correo anuncia que la obra número " + comprobante.NumeroComprobante + " a sido señada.";
            string asunto = "Anuncio obra número: " + comprobante.NumeroComprobante;

            Correo correo = new Correo();
            correo.EnviarCorreo(comprobante.oCliente.Correo, asunto, mensaje);
        }
    }
}
