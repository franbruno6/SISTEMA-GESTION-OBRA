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
    public partial class mdListaPermisoSimple : Form
    {
        public mdListaPermisoSimple()
        {
            InitializeComponent();
        }

        private void mdListaPermisoSimple_Load(object sender, EventArgs e)
        {

        }
        private void datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;

            if (indice >= 0)
            {
                txtid.Text = datagridview.Rows[indice].Cells["IdComponente"].Value.ToString();
                txtnombremenu.Text = datagridview.Rows[indice].Cells["Nombre"].Value.ToString();

                foreach (OpcionCombo opcion in cboestado.Items)
                {
                    if (Convert.ToInt32(opcion.Valor) == (Convert.ToBoolean(datagridview.Rows[indice].Cells["estado"].Value.ToString()) == true ? 1 : 0))
                    {
                        int indiceCombo = cboestado.Items.IndexOf(opcion);
                        cboestado.SelectedIndex = indiceCombo;
                        break;
                    }
                }
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
    }
}
