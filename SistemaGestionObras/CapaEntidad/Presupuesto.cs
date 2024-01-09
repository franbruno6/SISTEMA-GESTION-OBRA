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
            usuario = new Usuario();
        }
        #endregion

        #region Variables Privadas
        private int idPresupuesto;
        private Usuario usuario;
        private string numeroPresupuesto;
        private string nombreCliente;
        private string direccion;
        private decimal montoTotal;
        private string fechaRegistro;
        #endregion

        #region Propiedades
        public int IdPresupuesto { get { return idPresupuesto; } set { idPresupuesto = value; } }
        public Usuario oUsuario { get { return usuario; } set { usuario = value; } }
        public string NumeroPresupuesto { get { return numeroPresupuesto; } set { numeroPresupuesto = value; } }
        public string NombreCliente { get { return nombreCliente; } set { nombreCliente = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public decimal MontoTotal { get { return montoTotal; } set { montoTotal = value; } }
        public string FechaRegistro { get { return fechaRegistro; } set { fechaRegistro = value; } }
        #endregion
    }
}
