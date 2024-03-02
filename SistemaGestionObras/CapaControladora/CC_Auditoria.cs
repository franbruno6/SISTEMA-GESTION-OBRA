using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Auditoria
    {
        private CD_Auditoria oCD_Auditoria = new CD_Auditoria();
        public List<Hist_ComprobanteObra> ListarHistComprobante(int idComprobanteObra)
        {
            try
            {
                return oCD_Auditoria.ListarHistComprobante(idComprobanteObra);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
