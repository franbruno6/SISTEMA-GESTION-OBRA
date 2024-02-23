﻿using CapaControladora;
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
            menuvercomprobante.Visible = true;

            btnactualizar_Click(null, null);
        }
        private void btnactualizar_Click(object sender, EventArgs e)
        {
            datagridview.Rows.Clear();

            //MOSTRAR LOS COMPROBANTES
            List<ComprobanteObra> listaComprobante = oCC_ComprobanteObra.ListarComprobante();
            listaComprobante = listaComprobante.OrderByDescending(c => c.NumeroComprobante).ToList();

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
            if (tipoModal == "Modificar")
            {
                using (var modal = new mdModificarComprobante(tipoModal, idComprobante, _usuarioActual))
                {
                    var resultado = modal.ShowDialog();
                }
                btnactualizar_Click(null, null);
                return;
            }
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
        private void menumodificarcomprobante_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim() != "")
            {
                int indiceFila = datagridview.CurrentRow.Index;
                string estadoObra = datagridview.Rows[indiceFila].Cells["estado"].Value.ToString();
                if (estadoObra == "Cuenta saldada")
                {
                    MessageBox.Show("No se puede modificar el comprobante numero " + datagridview.Rows[indiceFila].Cells["numeroComprobante"].Value.ToString() + " porque ya esta finalizado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else if (estadoObra == "Cancelada")
                {
                    MessageBox.Show("No se puede modificar el comprobante numero " + datagridview.Rows[indiceFila].Cells["numeroComprobante"].Value.ToString() + " porque ya esta cancelado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                AbrirModal("Modificar", Convert.ToInt32(txtid.Text), Convert.ToInt32(txtidpresupuesto.Text));
            }
            else
            {
                MessageBox.Show("Debe seleccionar un comprobante", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void menucancelarcomprobante_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim() != "")
            {
                CancelarComprobante();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un comprobante", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void CancelarComprobante()
        {
            ComprobanteObra oComprobante = oCC_ComprobanteObra.ListarComprobante().Where(c => c.IdComprobanteObra == Convert.ToInt32(txtid.Text)).FirstOrDefault();

            if (MessageBox.Show("Esta seguro de cancelar el comprobante numero " + oComprobante.NumeroComprobante + "?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string mensaje = string.Empty;

                if (oCC_ComprobanteObra.ModificarEstadoComprobante(oComprobante.IdComprobanteObra, _usuarioActual.IdUsuario, "Cancelada", out mensaje))
                {
                    MessageBox.Show("El comprobante numero " + oComprobante.NumeroComprobante + " ah sido cancelado de forma correcta.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnactualizar_Click(null, null);
                }
                else
                {
                    MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            btnbuscar_Click(sender, e);
            if (txtbusqueda.Text.Trim() == "")
            {
                btnlimpiar_Click(sender, e);
            }
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (datagridview.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in datagridview.Rows)
                {
                    if (fila.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                    {
                        fila.Visible = true;
                    }
                    else
                    {
                        fila.Visible = false;
                    }
                }
            }
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
            txtidpresupuesto.Text = "";
        }

        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbusqueda_TextChanged(null,null);
        }
    }
}
