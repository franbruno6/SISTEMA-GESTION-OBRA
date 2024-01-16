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
        public int AgregarUsuario(Usuario oUsuario, out string mensaje)
        {
            try
            {
                return oCD_Usuario.AgregarUsuario(oUsuario, out mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool EditarUsuario(Usuario oUsuario, out string mensaje)
        {
            try
            {
                return oCD_Usuario.EditarUsuario(oUsuario, out mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public bool RestablecerClave(int idUsuario, string clave, out string mensaje)
        {
            try
            {
                return oCD_Usuario.RestablecerClave(idUsuario, clave, out mensaje);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
