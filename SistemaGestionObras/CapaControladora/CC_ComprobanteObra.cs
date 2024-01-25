using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_ComprobanteObra
    {
        private CD_ComprobanteObra oCD_ComprobanteObra = new CD_ComprobanteObra();
        public List<ComprobanteObra> ListarComprobante()
        {
            try
            {
                return oCD_ComprobanteObra.ListarComprobante();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
