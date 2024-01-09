using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Producto
    {
        #region Variables Privadas
        private int idProducto;
        private string codigo;
        private string nombre;
        private string descripcion;
        private string categoria;
        private decimal precio;
        private bool estado;
        #endregion

        #region Propiedades
        public int IdProducto { get { return idProducto; } set { idProducto = value; } }
        public string Codigo { get {  return codigo; } set {  codigo = value; } }
        public string Nombre { get {  return nombre; } set {  nombre = value; } }
        public string Descripcion { get {  return descripcion; } set {  descripcion = value; } }
        public string Categoria { get {  return categoria; } set {  categoria = value; } }
        public decimal Precio { get {  return precio; } set {  precio = value; } }
        public bool Estado { get {  return estado; } set {  estado = value; } }
        #endregion
    }
}
