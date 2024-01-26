using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Presupuesto
    {
        #region Constructor
        public Presupuesto()
        {
            oUsuario = new Usuario();
            oCliente = new Cliente();
        }
        #endregion

        #region Variables Privadas
        private int idPresupuesto;
        private Usuario usuario;
        private Cliente cliente;
        private string numeroPresupuesto;
        private string direccion;
        private string localidad;
        private decimal montoTotal;
        private DateTime fechaRegistro;
        #endregion

        #region Propiedades
        public int IdPresupuesto { get { return idPresupuesto; } set { idPresupuesto = value; } }
        public Usuario oUsuario { get { return usuario; } set { usuario = value; } }
        public Cliente oCliente { get { return cliente; } set { cliente = value; } }
        public string NumeroPresupuesto { get { return numeroPresupuesto; } set { numeroPresupuesto = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public string Localidad { get { return localidad; } set { localidad = value; } }
        public decimal MontoTotal { get { return montoTotal; } set { montoTotal = value; } }
        public DateTime FechaRegistro { get { return fechaRegistro; } set { fechaRegistro = value; } }
        #endregion
    }
}
