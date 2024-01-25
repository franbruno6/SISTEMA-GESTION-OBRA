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
    public partial class mdDetalleComprobante : Form
    {
        private string _tipoModal;
        private int _idComprobante;
        private ComprobanteObra _oComprobante = new ComprobanteObra();
        private CC_ComprobanteObra oCC_ComprobanteObra = new CC_ComprobanteObra();
        private Usuario _usuarioActual;
        public mdDetalleComprobante(string tipoModal, int idComprobante, Usuario usuarioActual)
        {
            _tipoModal = tipoModal;
            _idComprobante = idComprobante;
            _oComprobante = oCC_ComprobanteObra.ListarComprobante().Where(c => c.IdComprobanteObra == _idComprobante).FirstOrDefault();
            _usuarioActual = usuarioActual;
            InitializeComponent();
        }

        private void mdDetalleComprobante_Load(object sender, EventArgs e)
        {

        }
    }
}
