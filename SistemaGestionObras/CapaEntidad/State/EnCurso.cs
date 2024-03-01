using CapaEntidad.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.State
{
    public class EnCurso : Estado
    {
        public override string Valor
        {
            get
            {
                return "En Curso";
            }
        }
        public override string ProximoEstado
        {
            get
            {
                return "Finalizada";
            }
        }
        public override void CambiarEstado(ComprobanteObra comprobante)
        {
            comprobante.SetEstado(new Finalizada());
        }
        public override void Accion(ComprobanteObra comprobante)
        {
            string mensaje = "Estimado, este correo anuncia que la obra número " + comprobante.NumeroComprobante + ", ubicada en la dirección: " + comprobante.Direccion + " ha comenzado el día de la fecha.\n\n" +
               "Envíamos un cordial saludo de parte de Bruno Cercos.";
            string asunto = "Anuncio obra número: " + comprobante.NumeroComprobante;

            Correo correo = new Correo();
            correo.EnviarCorreo(comprobante.oCliente.Correo, asunto, mensaje, "");
        }
    }
}
