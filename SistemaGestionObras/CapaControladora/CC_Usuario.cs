using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Usuario
    {
        private CD_Usuario oCD_Usuario = new CD_Usuario();

        public List<Usuario> ListarUsuarios()
        {
            try
            {
                return oCD_Usuario.ListarUsuarios();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
