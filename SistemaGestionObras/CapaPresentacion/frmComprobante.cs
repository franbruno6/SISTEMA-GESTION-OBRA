using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Modals;
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

namespace CapaPresentacion
{
    public partial class frmComprobante : Form
    {
        private CC_ComprobanteObra oCC_ComprobanteObra = new CC_ComprobanteObra();
        private CC_Presupuesto oCC_Presupuesto = new CC_Presupuesto();
        private Usuario _usuarioActual;
        public frmComprobante(Usuario oUsuario)
        {
            _usuarioActual = oUsuario;
            InitializeComponent();
        }
        private void frmComprobante_Load(object sender, EventArgs e)
        {
            //CONFIGURACION DEL OPCION COMBO SELECCIONAR
            foreach (DataGridViewColumn columna in datagridview.Columns)
            {
                if (columna.Visible && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo(columna.Name, columna.HeaderText));
                }
            }
            cbobusqueda.SelectedIndex = 0;
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";

            //foreach (ToolStripMenuItem menu in menu.Items)
            //{
            //    bool encontrado = _usuarioActual.GetPermisos().Any(p => p.NombreMenu == menu.Name);

            //    if (encontrado)
            //    {
            //        menu.Visible = true;
            //    }
            //    else
            //    {
            //        menu.Visible = false;
            //    }
            //}
            //menuvercomprobante.Visible = true;

            btnactualizar_Click(null, null);
        }
        private void btnactualizar_Click(object sender, EventArgs e)
        {
            datagridview.Rows.Clear();

            //MOSTRAR LOS COMPROBANTES
            List<ComprobanteObra> listaComprobante = oCC_ComprobanteObra.ListarComprobante();
            listaComprobante = listaComprobante.OrderBy(c => c.NumeroComprobante).ToList();

            foreach (ComprobanteObra oComprobante in listaComprobante)
            {
                datagridview.Rows.Add(
                    "",
                    oComprobante.IdComprobanteObra,
                    oComprobante.oPresupuesto.IdPresupuesto,
                    oComprobante.oUsuario.IdUsuario,
                    oComprobante.NumeroComprobante,
                    oComprobante.oCliente.NombreCompleto,
                    oComprobante.oCliente.Telefono,
                    oComprobante.Direccion,
                    oComprobante.Localidad,
                    oComprobante.MontoTotal,
                    oComprobante.EstadoObra,
                    oComprobante.FechaRegistro.ToString("dd-MM-yyyy")
                    );
            }

            //CONFIGURA QUE NO ESTE SELECCIONADA NINGUNA FILA
            datagridview.ClearSelection();

            txtid.Text = "";
            txtidpresupuesto.Text = "";
        }
        private void menuagregarcomprobante_Click(object sender, EventArgs e)
        {
            using (var modal = new mdListaPresupuestos())
            {
                var resultado = modal.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    AbrirModal("Agregar", 0, modal.IdPresupuesto);
                }
            }
        }
        private void AbrirModal(string tipoModal, int idComprobante, int idPresupuesto)
        {
            using (var modal = new mdDetalleComprobante(tipoModal, idComprobante, _usuarioActual, idPresupuesto))
            {
                var resultado = modal.ShowDialog();
            }
        }
        private void datagridview_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                e.PaintBackground(e.ClipBounds, true);

                var w = Properties.Resources.check.Width;
                var h = Properties.Resources.check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
        private void menuvercomprobante_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim() != "")
            {
                AbrirModal("VerDetalle", Convert.ToInt32(txtid.Text), Convert.ToInt32(txtidpresupuesto.Text));
            }
            else
            {
                MessageBox.Show("Debe seleccionar un comprobante", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;

            if (indice >= 0)
            {
                txtid.Text = datagridview.Rows[indice].Cells["idComprobante"].Value.ToString();
                txtidpresupuesto.Text = datagridview.Rows[indice].Cells["idPresupuesto"].Value.ToString();
            }
        }
        private void datagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indiceFila = e.RowIndex;
            int indiceColumna = e.ColumnIndex;

            if (indiceFila >= 0 && indiceColumna >= 0)
            {
                menuvercomprobante_Click(sender, e);
            }
        }
    }
}
