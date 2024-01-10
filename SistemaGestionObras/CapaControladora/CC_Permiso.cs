using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Permiso
    {
        private CD_Componente objetoCD = new CD_Componente();
        public List<Permiso> ListarPermisos(int idUsuario)
        {
            return objetoCD.ListarPermisos(idUsuario);
        }
    }
}
