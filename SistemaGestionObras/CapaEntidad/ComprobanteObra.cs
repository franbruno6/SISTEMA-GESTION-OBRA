using CapaEntidad.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ComprobanteObra : ISujetoComprobante
    {
        #region Constructor
        public ComprobanteObra()
        {
            oPresupuesto = new Presupuesto();
            oUsuario = new Usuario();
            oCliente = new Cliente();
            observadores = new List<IObservadorCliente>();
        }
        #endregion

        #region Variables Privadas
        private int idComprobanteObra;
        private Presupuesto presupuesto;
        private Usuario usuario;
        private Cliente cliente;
        private string numeroComprobante;
        private decimal montoTotal;
        private string estadoObra;
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
        public string EstadoObra { 
            get 
            {  
                return estadoObra; 
            } 
            set
            {  
                estadoObra = value; 
                this.NotificarObservadores();
            } 
        }
        public DateTime FechaRegistro { get {  return fechaRegistro; } set {  fechaRegistro = value; } }
        #endregion

        #region Observer
        private List<IObservadorCliente> observadores;
        public void AgregarObservador(IObservadorCliente observador)
        {
            if (!observadores.Contains(observador))
            {
                observadores.Add(observador);
            }
            else
            {
                throw new Exception("El cliente ya se encuentra registrado");
            }
        }
        public void EliminarObservador(IObservadorCliente observador)
        {
            if (observadores.Contains(observador))
            {
                observadores.Remove(observador);
            }
            else
            {
                throw new Exception("El cliente no se encuentra registrado");
            }
        }
        public void NotificarObservadores()
        {
            foreach (IObservadorCliente observador in observadores)
            {
                observador.Actualizar(this);
            }
        }
        #endregion

    }
}
