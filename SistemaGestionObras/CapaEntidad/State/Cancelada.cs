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
        public override void CambiarEstado(ComprobanteObra comprobante)
        {
            MessageBox.Show("No se puede cambiar el estado de un comprobante cancelado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public override void Accion(ComprobanteObra comprobante)
        {
            throw new NotImplementedException();
        }
    }
}
