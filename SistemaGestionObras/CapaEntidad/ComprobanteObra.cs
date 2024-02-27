using CapaEntidad.State;
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
            oCliente = new Cliente();
            estadoObra = new Pendiente();
        }
        #endregion

        #region Variables Privadas
        private int idComprobanteObra;
        private Presupuesto presupuesto;
        private Usuario usuario;
        private Cliente cliente;
        private string numeroComprobante;
        private decimal montoTotal;
        private Estado estadoObra;
        //private string estadoObra;
        private DateTime fechaRegistro;
        private string direccion;
        private string localidad;
        private decimal adelanto;
        private decimal saldo;
        #endregion

        #region Propiedades
        public int IdComprobanteObra { get { return idComprobanteObra; } set { idComprobanteObra = value; } }
        public Presupuesto oPresupuesto { get { return presupuesto; } set { presupuesto = value; } }
        public Usuario oUsuario { get { return usuario; } set { usuario = value; } }
        public Cliente oCliente { get { return cliente; } set { cliente = value; } }
        public string NumeroComprobante { get {  return numeroComprobante; } set {  numeroComprobante = value; } }
        public string Direccion { get {  return direccion; } set {  direccion = value; } }
        public string Localidad { get {  return localidad; } set {  localidad = value; } }
        public decimal MontoTotal { get {  return montoTotal; } set {  montoTotal = value; } }
        public decimal Adelanto { get {  return adelanto; } set {  adelanto = value; } }
        public decimal Saldo { get {  return saldo; } set {  saldo = value; } }

        public DateTime FechaRegistro { get {  return fechaRegistro; } set {  fechaRegistro = value; } }
        #endregion

        #region State
        public void SetEstado(Estado estado)
        {
            estadoObra = estado;
        }
        public string GetEstado()
        {
            return estadoObra.Valor;
        }
        public void CambiarEstado()
        {
            estadoObra.CambiarEstado(this);
        }
        public void Accion()
        {
            estadoObra.Accion(this);
        }
        #endregion

    }
}
