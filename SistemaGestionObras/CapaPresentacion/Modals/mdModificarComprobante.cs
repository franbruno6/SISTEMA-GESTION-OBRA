using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Utilidades;
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
    public partial class mdModificarComprobante : Form
    {
        private string _tipoModal;
        private int _idComprobante;
        private Usuario _usuarioActual;
        private ComprobanteObra _oComprobanteObra = new ComprobanteObra();
        private CC_ComprobanteObra oCC_ComprobanteObra = new CC_ComprobanteObra();
        public mdModificarComprobante(string tipoModal, int idComprobante, Usuario usuarioActual)
        {
            _tipoModal = tipoModal;
            _idComprobante = idComprobante;
            _usuarioActual = usuarioActual;
            _oComprobanteObra = oCC_ComprobanteObra.ListarComprobante().Where(c => c.IdComprobanteObra == _idComprobante).FirstOrDefault();
            InitializeComponent();
        }

        private void mdModificarComprobante_Load(object sender, EventArgs e)
        {
            cboestado.DataSource = new List<OpcionCombo>
            {
                new OpcionCombo("Pendiente", "Pendiente"),
                new OpcionCombo("En curso", "En curso"),
                new OpcionCombo("Finalizada", "Finalizada"),
                new OpcionCombo("Cuenta saldada", "Cuenta saldada")
            };
            switch (_oComprobanteObra.EstadoObra)
            {
                case "Pendiente":
                    cboestado.SelectedIndex = 0;
                    break;
                case "En curso":
                    cboestado.SelectedIndex = 1;
                    break;
                case "Finalizada":
                    cboestado.SelectedIndex = 2;
                    break;
                case "Cuenta saldada":
                    cboestado.SelectedIndex = 3;
                    break;
            }
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
        }
        private void btnguardar_Click(object sender, EventArgs e)
        {
            string estadoObra = cboestado.SelectedValue.ToString();

            if (MessageBox.Show("Esta seguro de modificar el estado a \"" + estadoObra + "\"?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = string.Empty;

                if (oCC_ComprobanteObra.ModificarEstadoComprobante(_idComprobante, _usuarioActual.IdUsuario, estadoObra, out mensaje))
                {
                    MessageBox.Show("El estado de la obra numero " + _oComprobanteObra.NumeroComprobante + " ah sido actualizado a \"" + estadoObra + "\"", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
