using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Reporte
    {
        private CD_Reporte oCD_Reporte = new CD_Reporte();
        public List<ReportePresupuesto> ListarReportePresupuesto(string fechaInicio, string fechaFin)
        {
            try
            {
                return oCD_Reporte.ListarReportePresupuesto(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<ReporteComprobante> ListarReporteComprobante(string fechaInicio, string fechaFin)
        {
            try
            {
                return oCD_Reporte.ListarReporteComprobante(fechaInicio, fechaFin);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
