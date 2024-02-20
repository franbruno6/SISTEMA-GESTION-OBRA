using CapaControladora;
using CapaEntidad;
using CapaPresentacion.CP_Usuario;
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
    public partial class frmPresupuesto : Form
    {
        private CC_Presupuesto oCC_Presupuesto = new CC_Presupuesto();
        private Usuario _usuarioActual;
        public frmPresupuesto(Usuario oUsuario)
        {
            _usuarioActual = oUsuario;
            InitializeComponent();
        }
        private void frmPresupuesto_Load(object sender, EventArgs e)
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

            foreach (ToolStripMenuItem menu in menu.Items)
            {
                bool encontrado = _usuarioActual.GetPermisos().Any(p => p.NombreMenu == menu.Name);

                if (encontrado)
                {
                    menu.Visible = true;
                }
                else
                {
                    menu.Visible = false;
                }
            }
            menuverpresupuesto.Visible = true;

            btnactualizar_Click(sender, e);
        }
        private void btnactualizar_Click(object sender, EventArgs e)
        {
            datagridview.Rows.Clear();

            //MOSTRAR LOS PRESUPUESTOS
            List<Presupuesto> listaPresupuestos = oCC_Presupuesto.ListarPresupuestos();
            listaPresupuestos = listaPresupuestos.OrderByDescending(p => p.NumeroPresupuesto).ToList();

            foreach (Presupuesto oPresupuesto in listaPresupuestos)
            {
                datagridview.Rows.Add(
                    "",
                    oPresupuesto.IdPresupuesto,
                    oPresupuesto.oUsuario.IdUsuario,
                    oPresupuesto.oCliente.IdCliente,
                    oPresupuesto.NumeroPresupuesto,
                    oPresupuesto.oCliente.NombreCompleto,
                    oPresupuesto.oCliente.Documento,
                    oPresupuesto.oCliente.Telefono,
                    oPresupuesto.Direccion,
                    oPresupuesto.Localidad,
                    oPresupuesto.MontoTotal,
                    oPresupuesto.FechaRegistro.ToString("dd-MM-yyyy")
                    );
            }

            //CONFIGURA QUE NO ESTE SELECCIONADA NINGUNA FILA
            datagridview.ClearSelection();

            txtid.Text = "";
            txtidusuario.Text = "";
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            DataGridViewU.FiltrarDataGridView(datagridview, cbobusqueda, txtbusqueda);
        }
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";

            foreach (DataGridViewRow fila in datagridview.Rows)
            {
                fila.Visible = true;
            }

            datagridview.ClearSelection();
            txtid.Text = "";
            txtidusuario.Text = "";
        }
        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            DataGridViewU.FiltrarDataGridView(datagridview, cbobusqueda, txtbusqueda);
        }
        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewU.FiltrarDataGridView(datagridview, cbobusqueda, txtbusqueda);
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
        private void datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;

            if (indice >= 0)
            {
                txtid.Text = datagridview.Rows[indice].Cells["idPresupuesto"].Value.ToString();
                txtidusuario.Text = datagridview.Rows[indice].Cells["idUsuario"].Value.ToString();
            }
        }
        private void datagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indiceFila = e.RowIndex;
            int indiceColumna = e.ColumnIndex;

            if (indiceFila >= 0 && indiceColumna >= 0)
            {
                menuverpresupuesto_Click(sender, e);
            }
        }
        private void menuverpresupuesto_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim() != "")
            {
                AbrirModal("VerDetalle", Convert.ToInt32(txtid.Text));
            }
            else
            {
                MessageBox.Show("Debe seleccionar un presupuesto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }   
        }
        private void menuagregarpresupuesto_Click(object sender, EventArgs e)
        {
            AbrirModal("Agregar",0);
        }
        private void AbrirModal(string tipoModal, int idPresupuesto)
        {
            using (var modal = new mdDetallePresupuesto(tipoModal, idPresupuesto, _usuarioActual))
            {
                var resultado = modal.ShowDialog();
            }
            btnactualizar_Click(null, null);
        }
        private void menumodificarpresupuesto_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un presupuesto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Presupuesto oPresupuesto = oCC_Presupuesto.ListarPresupuestoSinComprobante().Where(p => p.IdPresupuesto == Convert.ToInt32(txtid.Text)).FirstOrDefault();
                if (oPresupuesto != null)
                {
                    AbrirModal("Editar", Convert.ToInt32(txtid.Text));
                }
                else
                {
                    MessageBox.Show("No se puede modificar el presupuesto. Esta asociado a un comprobante", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void menueliminarpresupuesto_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim() != "")
            {
                if (MessageBox.Show("¿Está seguro de eliminar el presupuesto?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    bool eliminado = oCC_Presupuesto.EliminarPresupuesto(Convert.ToInt32(txtid.Text), out mensaje);

                    if (eliminado)
                    {
                        MessageBox.Show("Presupuesto eliminado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnactualizar_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un presupuesto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
