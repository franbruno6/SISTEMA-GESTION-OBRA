using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Modals;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmAuditoria : Form
    {
        private ComprobanteObra _oComprobanteObra;
        private List<Hist_ComprobanteObra> _listaHistorica;
        private CC_ComprobanteObra oCC_ComprobanteObra = new CC_ComprobanteObra();
        private CC_Auditoria oCC_Auditoria = new CC_Auditoria();
        public frmAuditoria()
        {
            InitializeComponent();
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            using (var modal = new mdListaComprobante())
            {
                var resultado = modal.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _oComprobanteObra = oCC_ComprobanteObra.ListarComprobante().Where(c => c.IdComprobanteObra == modal.IdComprobante).FirstOrDefault();
                    _listaHistorica = oCC_Auditoria.ListarHistComprobante(modal.IdComprobante);

                    txtnombrecliente.Text = _oComprobanteObra.oCliente.NombreCompleto;
                    txttelefono.Text = _oComprobanteObra.oCliente.Telefono;
                    txtcorreo.Text = _oComprobanteObra.oCliente.Correo;
                    txtdireccion.Text = _oComprobanteObra.Direccion;
                    txtlocalidad.Text = _oComprobanteObra.Localidad;
                    txtprovincia.Text = _oComprobanteObra.Provincia;
                    txtdescripcion.Text = _oComprobanteObra.Descripcion;
                    lblsubtitulo.Text = "Auditoría de Comprobante N° " + _oComprobanteObra.NumeroComprobante;

                    datagridview.Rows.Clear();
                    
                    foreach (Hist_ComprobanteObra historico in _listaHistorica)
                    {
                        datagridview.Rows.Add(
                        historico.Fecha.ToString("dd/MM/yyyy"),
                        historico.EstadoActual,
                        historico.EstadoPrevio,
                        historico.Adelanto,
                        historico.Saldo,
                        historico.MontoTotal,
                        historico.oComprobanteObra.oUsuario.NombreCompleto
                        );
                    }

                }
            }
        }
        private void btnexportar_Click(object sender, EventArgs e)
        {

        }
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
