﻿using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Utilidades;
using iTextSharp.text.pdf.security;
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
    public partial class mdListaComprobante : Form
    {
        private CC_ComprobanteObra oCC_ComprobanteObra = new CC_ComprobanteObra();
        public int IdComprobante { get; set; }

        public mdListaComprobante()
        {
            InitializeComponent();
        }
        private void mdAgregarComprobante_Load(object sender, EventArgs e)
        {
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

            List<ComprobanteObra> listaComprobantes = oCC_ComprobanteObra.ListarComprobante().OrderByDescending(p => p.NumeroComprobante).ToList();

            foreach (ComprobanteObra comprobante in listaComprobantes)
            {
                datagridview.Rows.Add(
                    "",
                    comprobante.IdComprobanteObra,
                    comprobante.NumeroComprobante,
                    comprobante.oCliente.NombreCompleto,
                    comprobante.Direccion,
                    comprobante.Localidad,
                    comprobante.Provincia,
                    comprobante.MontoTotal,
                    comprobante.GetEstado(),
                    comprobante.FechaRegistro
                );
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
        private void datagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indiceFila = e.RowIndex;
            int indiceColumna = e.ColumnIndex;

            if (indiceFila >= 0 && indiceColumna >= 0)
            {
                IdComprobante = Convert.ToInt32(datagridview.Rows[indiceFila].Cells["idComprobante"].Value.ToString());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataGridViewU.FiltrarDataGridView(datagridview, cbobusqueda, txtbusqueda);
        }
        private void btnvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            DataGridViewU.FiltrarDataGridView(datagridview, cbobusqueda, txtbusqueda);
        }
    }
}
