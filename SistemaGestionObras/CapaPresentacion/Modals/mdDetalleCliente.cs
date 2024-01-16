using CapaControladora;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Modals
{
    public partial class mdDetalleCliente : Form
    {
        private readonly string _tipoModal;
        private int _idCliente;
        private Cliente oCliente;
        private CC_Cliente oCC_Cliente = new CC_Cliente();
        
        public mdDetalleCliente(string tipoModal, int idCliente)
        {
            _idCliente = idCliente;
            _tipoModal = tipoModal;
            oCliente = oCC_Cliente.ListarClientes().Where(c => c.IdCliente == _idCliente).FirstOrDefault();
            InitializeComponent();
        }

    }
}
