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
    public partial class mdAgregarProductoAPresupuesto : Form
    {
        private CC_Producto oCC_Producto = new CC_Producto();
        public Producto oProducto { get; set; }
        public mdAgregarProductoAPresupuesto()
        {
            InitializeComponent();
        }

        private void mdAgregarProductoAPresupuesto_Load(object sender, EventArgs e)
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


            List<Producto> listaProductos = oCC_Producto.ListarProductos().Where(p => p.Estado).ToList();

            foreach (Producto oProducto in listaProductos)
            {
                datagridview.Rows.Add(
                    "",
                    oProducto.IdProducto,
                    oProducto.Codigo,
                    oProducto.Nombre,
                    oProducto.Categoria,
                    oProducto.Precio
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
            int indice = e.RowIndex;

            if (indice >= 0)
            {
                txtid.Text = datagridview.Rows[indice].Cells["idProducto"].Value.ToString();
            }
        }
        private void datagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indiceFila = e.RowIndex;
            int indiceColumna = e.ColumnIndex;

            if (indiceFila >= 0 && indiceColumna >= 0)
            {
                oProducto = new Producto();
                oProducto.IdProducto = Convert.ToInt32(datagridview.Rows[indiceFila].Cells["idProducto"].Value.ToString());
                oProducto.Codigo = datagridview.Rows[indiceFila].Cells["codigo"].Value.ToString();
                oProducto.Nombre = datagridview.Rows[indiceFila].Cells["nombre"].Value.ToString();
                oProducto.Precio = Convert.ToDecimal(datagridview.Rows[indiceFila].Cells["precio"].Value.ToString());
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
