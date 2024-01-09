using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleComprobanteObra
    {
        #region Constructor
        public DetalleComprobanteObra()
        {
            oComprobanteObra = new ComprobanteObra();
            oProducto = new Producto();
        }
        #endregion

        #region Variables Privadas
        private int idDetalleComprobanteObra;
        private ComprobanteObra comprobanteObra;
        private Producto producto;
        private decimal precio;
        private int cantidad;
        private decimal montoTotal;
        #endregion

        #region Propiedades
        public int IdDetalleComprobanteObra { get { return idDetalleComprobanteObra; } set { idDetalleComprobanteObra = value; } }
        public ComprobanteObra oComprobanteObra { get { return comprobanteObra; } set { comprobanteObra = value; } }
        public Producto oProducto { get { return producto; } set { producto = value; } }
        public decimal Precio { get {  return precio; } set {  precio = value; } }
        public int Cantidad { get {  return cantidad; } set {  cantidad = value; } }
        public decimal MontoTotal { get {  return montoTotal; } set {  montoTotal = value; } }
        #endregion
    }
}
