using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Cliente
    {
        #region Constructor
        public Cliente()
        {
            persona = new Persona();
        }
        #endregion

        #region Variables Privadas
        private int idCliente;
        private Persona persona;
        private string telefono;
        private string direccion;
        private bool estado;
        #endregion

        #region Properties
        public int IdCliente { get { return idCliente; } set { idCliente = value; } }
        public Persona oPersona { get { return persona; } set { persona = value; } }
        public string Telefono { get { return telefono; } set { telefono = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public bool Estado { get { return estado; } set { estado = value; } }
        #endregion
    }
}
