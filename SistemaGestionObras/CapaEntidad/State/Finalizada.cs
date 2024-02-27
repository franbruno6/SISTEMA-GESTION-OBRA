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
        public override void CambiarEstado(ComprobanteObra comprobante)
        {
            comprobante.SetEstado(new CuentaSaldada());
        }
        public override void Accion(ComprobanteObra comprobante)
        {
            throw new NotImplementedException();
        }
    }
}
