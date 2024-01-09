using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ComprobanteObra
    {
        #region Constructor
        public ComprobanteObra()
        {
            oPresupuesto = new Presupuesto();
            oUsuario = new Usuario();
        }
        #endregion

        #region Variables Privadas
        private int idComprobanteObra;
        private Presupuesto presupuesto;
        private Usuario usuario;
        private string numeroComprobante;
        private string documentoCliente;
        private string direccion;
        private decimal montoTotal;
        private string estadoObra;
        private string fechaRegistro;
        #endregion

        #region Propiedades
        public int IdComprobanteObra { get { return idComprobanteObra; } set { idComprobanteObra = value; } }
        public Presupuesto oPresupuesto { get { return presupuesto; } set { presupuesto = value; } }
        public Usuario oUsuario { get { return usuario; } set { usuario = value; } }
        public string NumeroComprobante { get {  return numeroComprobante; } set {  numeroComprobante = value; } }
        public string DocumentoCliente { get {  return documentoCliente; } set {  documentoCliente = value; } }
        public string Direccion { get {  return direccion; } set {  direccion = value; } }
        public decimal MontoTotal { get {  return montoTotal; } set {  montoTotal = value; } }
        public string EstadoObra { get {  return estadoObra; } set {  estadoObra = value; } }
        public string FechaRegistro { get {  return fechaRegistro; } set {  fechaRegistro = value; } }
        #endregion
    }
}
