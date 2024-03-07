using CapaEntidad.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaEntidad.State
{
    public class Cancelada : Estado
    {
        public override string Valor
        {
            get
            {
                return "Cancelada";
            }
        }
        public override string ProximoEstado
        {
            get
            {
                return "Cancelada";
            }
        }
        public override void CambiarEstado(ComprobanteObra comprobante)
        {
            MessageBox.Show("No se puede cambiar el estado de un comprobante cancelado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        public override void Accion(ComprobanteObra comprobante)
        {
            string mensaje = "Estimado, este correo anuncia que la obra número " + comprobante.NumeroComprobante + ", ubicada en la dirección: " + comprobante.Direccion + " ha sido cancelada.\n\n" +
                "Envíamos un cordial saludo de parte de Bruno Cercos.";
            string asunto = "Anuncio obra número: " + comprobante.NumeroComprobante;

            Correo correo = new Correo();
            correo.EnviarCorreo(comprobante.oCliente.Correo, asunto, mensaje, "");
        }
    }
}
