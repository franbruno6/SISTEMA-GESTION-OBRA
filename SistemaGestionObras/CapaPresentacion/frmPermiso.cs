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

namespace CapaPresentacion
{
    public partial class frmPermiso : Form
    {
        private CC_Permiso oCCPermiso = new CC_Permiso();
        public frmPermiso()
        {
            InitializeComponent();
        }
        private void frmPermiso_Load(object sender, EventArgs e)
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

            btnactualizar_Click(sender, e);
        }
        private void btnactualizar_Click(object sender, EventArgs e)
        {
            datagridview.Rows.Clear();

            //MOSTRAR LOS PERMISOS
            List<Permiso> listaPermisos = oCCPermiso.ListarPermisos();

            foreach (Permiso oPermiso in listaPermisos)
            {
                datagridview.Rows.Add(
                    "",
                    oPermiso.IdPermiso,
                    oPermiso.IdComponente,
                    oPermiso.Nombre,
                    oPermiso.NombreMenu,
                    oPermiso.Estado == true ? 1 : 0,
                    oPermiso.Estado == true ? "Activo" : "Inactivo"
                    );
            }

            //CONFIGURA QUE NO ESTE SELECCIONADA NINGUNA FILA
            datagridview.ClearSelection();

            txtid.Text = "";
            txtidcomponente.Text = "";
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
                txtid.Text = datagridview.Rows[indice].Cells["idPermiso"].Value.ToString();
                txtidcomponente.Text = datagridview.Rows[indice].Cells["idComponente"].Value.ToString();
            }
        }
        private void datagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indiceFila = e.RowIndex;
            int indiceColumna = e.ColumnIndex;

            if (indiceFila >= 0 && indiceColumna >= 0)
            {
                //menuverusuario_Click(sender, e);
            }
        }
    }
}
