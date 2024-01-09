using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Permiso
    {
        #region Constructor
        public Permiso() { 
            oComponente = new Componente();
        }
        #endregion

        #region Variables Privadas
        private Componente componente;
        private string nombreMenu;
        #endregion

        #region Propiedades
        public Componente oComponente { get { return componente; } set { componente = value; } }
        public string NombreMenu { get {  return nombreMenu; } set {  nombreMenu = value; } }
        #endregion
    }
}
