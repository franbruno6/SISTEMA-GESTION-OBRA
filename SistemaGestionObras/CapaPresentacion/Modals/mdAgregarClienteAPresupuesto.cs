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
    public partial class mdAgregarClienteAPresupuesto : Form
    {
        private CC_Cliente oCC_Cliente = new CC_Cliente();
        public int idcliente { get; set; }
        public mdAgregarClienteAPresupuesto()
        {
            InitializeComponent();
        }
        private void mdAgregarClienteAPresupuesto_Load(object sender, EventArgs e)
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

            //MOSTRAR LOS CLIENTES
            List<Cliente> listaClientes = oCC_Cliente.ListarClientes().Where(c => c.Estado).ToList();

            foreach (Cliente oCliente in listaClientes)
            {
                datagridview.Rows.Add(
                    "",
                    oCliente.IdCliente,
                    oCliente.NombreCompleto,
                    oCliente.Telefono,
                    oCliente.Direccion,
                    oCliente.Localidad,
                    oCliente.Correo
                    );
            }

            //CONFIGURA QUE NO ESTE SELECCIONADA NINGUNA FILA
            datagridview.ClearSelection();

            txtid.Text = "";
            txtbusqueda.Select();
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
                txtid.Text = datagridview.Rows[indice].Cells["idCliente"].Value.ToString();
            }
        }
        private void datagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indiceFila = e.RowIndex;
            int indiceColumna = e.ColumnIndex;

            if (indiceFila >= 0 && indiceColumna >= 0)
            {
                idcliente = Convert.ToInt32(txtid.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        private void btnvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btncrearcliente_Click(object sender, EventArgs e)
        {
            using (var modal = new mdDetalleCliente("Agregar",0))
            {
                var resultado = modal.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    idcliente = modal.idCliente;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }
    }
}
