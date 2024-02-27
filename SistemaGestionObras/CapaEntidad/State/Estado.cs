using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad.State
{
    public abstract class Estado
    {
        public abstract string Valor { get; }
        public abstract void CambiarEstado(ComprobanteObra comprobante);
        public abstract void Accion(ComprobanteObra comprobante);
    }
}
