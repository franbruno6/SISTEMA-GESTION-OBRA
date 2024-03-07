using CapaEntidad.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaEntidad.State
{
    public class CuentaSaldada : Estado
    {
        public override string Valor
        {
            get
            {
                return "Cuenta Saldada";
            }
        }
        public override string ProximoEstado
        {
            get
            {
                return "Cuenta Saldada";
            }
        }
        public override void CambiarEstado(ComprobanteObra comprobante)
        {
            MessageBox.Show("La cuenta ya se encuentra saldada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }
        public override void Accion(ComprobanteObra comprobante)
        {
            string mensaje = "Estimado, este correo anuncia que la obra número " + comprobante.NumeroComprobante + ", ubicada en la dirección: " + comprobante.Direccion + " ha sido saldada.\n\n" +
                "Adjuntamos recibo con la fecha del pago.\n\n" +
                "Envíamos un cordial saludo de parte de Bruno Cercos.";
            string asunto = "Anuncio obra número: " + comprobante.NumeroComprobante;

            Correo correo = new Correo();
            correo.EnviarCorreo(comprobante.oCliente.Correo, asunto, mensaje, comprobante.PathArchivo);
        }
    }
}
