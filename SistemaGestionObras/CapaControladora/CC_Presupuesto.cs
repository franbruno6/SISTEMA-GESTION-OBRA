using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Presupuesto
    {
        CD_Presupuesto oCD_Presupuesto = new CD_Presupuesto();
        public List<Presupuesto> ListarPresupuestos()
        {
            try
            {
                return oCD_Presupuesto.ListarPresupuestos();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int ObtenerCorrelativo()
        {
            try
            {
                return oCD_Presupuesto.ObtenerCorrelativo();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AgregarPresupuesto(Presupuesto oPresupuesto, DataTable listaDetalle, out string mensaje)
        {
            try
            {
                return oCD_Presupuesto.AgregarPresupuesto(oPresupuesto, listaDetalle, out mensaje);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<DetallePresupuesto> ListarDetalle(int idPresupuesto)
        {
            try
            {
                return oCD_Presupuesto.ListarDetalle(idPresupuesto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool EditarPresupuesto(Presupuesto oPresupuesto, DataTable listaDetalle, out string mensaje)
        {
            try
            {
                return oCD_Presupuesto.EditarPresupuesto(oPresupuesto, listaDetalle, out mensaje);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool EliminarPresupuesto(int idPresupuesto, out string mensaje)
        {
            try
            {
                return oCD_Presupuesto.EliminarPresupuesto(idPresupuesto, out mensaje);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Presupuesto> ListarPresupuestoSinComprobante()
        {
            try
            {
                return oCD_Presupuesto.ListarPresupuestoSinComprobante();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
