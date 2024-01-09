using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class GrupoPermiso
    {
        #region Constructor
        public GrupoPermiso()
        {
            oComponente = new Componente();
        }
        #endregion

        #region Variables Privadas
        private Componente componente;
        private string nombreGrupo;
        #endregion

        #region Propiedades
        public Componente oComponente { get { return componente; } set { componente = value; } }
        public string NombreGrupo { get {  return nombreGrupo; } set {  nombreGrupo = value; } }
        #endregion
    }
}
