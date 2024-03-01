using CapaEntidad.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.State
{
    public class Finalizada : Estado
    {
        public override string Valor
        {
            get
            {
                return "Finalizada";
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
            comprobante.SetEstado(new CuentaSaldada());
        }
        public override void Accion(ComprobanteObra comprobante)
        {
            string mensaje = "Estimado, este correo anuncia que la obra número " + comprobante.NumeroComprobante + ", ubicada en la dirección: " + comprobante.Direccion + " ha sido finalizada.\n" +
               "Puede acercarse al negocio ubicado en calle Eva Peron 9547 a abonar el saldo restante.\n\n" + 
               "Envíamos un cordial saludo de parte de Bruno Cercos.";
            string asunto = "Anuncio obra número: " + comprobante.NumeroComprobante;

            Correo correo = new Correo();
            correo.EnviarCorreo(comprobante.oCliente.Correo, asunto, mensaje, "");
        }
    }
}
