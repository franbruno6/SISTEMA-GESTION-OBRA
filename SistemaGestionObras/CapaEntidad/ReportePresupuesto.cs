﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ReportePresupuesto
    {
        #region Variables Privadas
        private string numeroPresupuesto;
        private string nombreCliente;
        private string correo;
        private string direccion;
        private string localidad;
        private string provincia;
        private decimal montoTotal;
        private DateTime fechaRegistro;
        private string descripcion;
        #endregion

        #region Propiedades
        public string NumeroPresupuesto { get { return numeroPresupuesto; } set { numeroPresupuesto = value; } }
        public string NombreCliente { get { return nombreCliente; } set { nombreCliente = value; } }
        public string Correo { get { return correo; } set { correo = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public string Localidad { get { return localidad; } set { localidad = value; } }
        public string Provincia { get { return provincia; } set { provincia = value; } }
        public decimal MontoTotal { get { return montoTotal; } set { montoTotal = value; } }
        public DateTime FechaRegistro { get { return fechaRegistro; } set { fechaRegistro = value; } }
        public string Descripcion { get { return descripcion; } set { descripcion = value; } }
        #endregion
    }
}
