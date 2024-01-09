using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetallePresupuesto
    {
        #region Constructor
        public DetallePresupuesto()
        {
            oPresupuesto = new Presupuesto();
            oProducto = new Producto();
        }
        #endregion

        #region Variables Privadas
        private int idDetallePresupuesto;
        private Presupuesto presupuesto;
        private Producto producto;
        private decimal precio;
        private int cantidad;
        private decimal montoTotal;
        #endregion

        #region Propiedades
        public int IdDetallePresupuesto { get { return idDetallePresupuesto; } set { idDetallePresupuesto = value; } }
        public Presupuesto oPresupuesto { get { return presupuesto; } set { presupuesto = value; } }
        public Producto oProducto { get { return producto; } set { producto = value; } }
        public decimal Precio { get {  return precio; } set {  precio = value; } }
        public int Cantidad { get {  return cantidad; } set {  cantidad = value; } }
        public decimal MontoTotal { get {  return montoTotal; } set {  montoTotal = value; } }
        #endregion  
    }
}
