using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CapaControladora
{
    public class CC_Cliente
    {
        private CD_Cliente oCD_Cliente = new CD_Cliente();
        public List<Cliente> ListarClientes()
        {
            try
            {
                return oCD_Cliente.ListarClientes();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
