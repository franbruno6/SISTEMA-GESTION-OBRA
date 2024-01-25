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
    public partial class mdListaPresupuestos : Form
    {
        private CC_Presupuesto oCC_Presupuesto = new CC_Presupuesto();
        public int IdPresupuesto { get; set; }
        public mdListaPresupuestos()
        {
            InitializeComponent();
        }

        private void mdListaPresupuestos_Load(object sender, EventArgs e)
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

            List<Presupuesto> listaPresupuestos = oCC_Presupuesto.ListarPresupuestos().OrderByDescending(p => p.NumeroPresupuesto).ToList();

            foreach (Presupuesto presupuesto in listaPresupuestos)
            {
                datagridview.Rows.Add(
                    "",
                    presupuesto.IdPresupuesto,
                    presupuesto.NumeroPresupuesto,
                    presupuesto.NombreCliente,
                    presupuesto.Direccion,
                    presupuesto.Localidad,
                    presupuesto.MontoTotal
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
        private void datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void datagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indiceFila = e.RowIndex;
            int indiceColumna = e.ColumnIndex;

            if (indiceFila >= 0 && indiceColumna >= 0)
            {
                IdPresupuesto = Convert.ToInt32(datagridview.Rows[indiceFila].Cells["idPresupuesto"].Value.ToString());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
