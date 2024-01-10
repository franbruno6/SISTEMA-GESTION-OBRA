using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Usuario : Persona
    {
        #region Variables Privadas
        private int idUsuario;
        private string clave;
        private bool estado;
        private string fecharegistro;
        #endregion

        #region Propiedades
        public int IdUsuario { get { return idUsuario; } set { idUsuario = value; } }
        public string Clave { get {  return clave; } set {  clave = value; } }
        public bool Estado { get { return estado; } set {  estado = value; } }
        public string FechaRegistro { get {  return fecharegistro; } set {  fecharegistro = value; } }
        #endregion
    }
}
