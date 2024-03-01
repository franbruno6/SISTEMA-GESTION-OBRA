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
        }
        public override void Accion(ComprobanteObra comprobante)
        {
            throw new NotImplementedException();
        }
    }
}
