using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_GrupoPermiso
    {
        CD_GrupoPermiso oCD_GrupoPermiso = new CD_GrupoPermiso();
        public List<GrupoPermiso> ListarGrupoPermisos()
        {
            try
            {
                return oCD_GrupoPermiso.ListarGrupoPermisos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
