using CapaEntidad.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Hist_ComprobanteObra
    {
        #region Variables Privadas
        private int idHistComprobanteObra;
        private ComprobanteObra comprobanteObra;
        private string estadoActual;
        private string estadoPrevio;
        private DateTime fecha;
        private decimal adelanto;
        private decimal saldo;
        private decimal montoTotal;
        private string operacion;
        #endregion

        #region Propiedades
        public int IdHistComprobanteObra { get { return idHistComprobanteObra; } set { idHistComprobanteObra = value; } }
        public ComprobanteObra oComprobanteObra { get { return comprobanteObra; } set { comprobanteObra = value; } }
        public string EstadoActual { get { return estadoActual; } set { estadoActual = value; } }
        public string EstadoPrevio { get { return estadoPrevio; } set { estadoPrevio = value; } }
        public DateTime Fecha { get { return fecha; } set { fecha = value; } }
        public decimal MontoTotal { get { return montoTotal; } set { montoTotal = value; } }
        public decimal Adelanto { get { return adelanto; } set { adelanto = value; } }
        public decimal Saldo { get { return saldo; } set { saldo = value; } }
        public string Operacion { get { return operacion; } set { operacion = value; } }
        #endregion
    }
}
