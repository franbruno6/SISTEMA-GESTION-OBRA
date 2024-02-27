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
        public override void CambiarEstado(ComprobanteObra comprobante)
        {
            comprobante.SetEstado(new Finalizada());
        }
        public override void Accion(ComprobanteObra comprobante)
        {
            throw new NotImplementedException();
        }
    }
}
