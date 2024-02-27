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
    public partial class frmCliente : Form
    {
        private CC_Cliente oCC_Cliente = new CC_Cliente();
        private Usuario _usuarioActual;
        public frmCliente(Usuario oUsuario)
        {
            _usuarioActual = oUsuario;
            InitializeComponent();
        }
        private void frmCliente_Load(object sender, EventArgs e)
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

            foreach(ToolStripMenuItem menu in menu.Items)
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
            menuvercliente.Visible = true;

            btnactualizar_Click(sender, e);
        }
        private void AbrirModal(string tipoModal, int idCliente)
        {
            using (var modal = new mdDetalleCliente(tipoModal, idCliente))
            {
                var resultado = modal.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    btnactualizar_Click(null, null);
                }
            }
        }
        private void menuvercliente_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                AbrirModal("VerDetalle", Convert.ToInt32(txtid.Text));
            }
            else
            {
                MessageBox.Show("Seleccione un cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void menuagregarcliente_Click(object sender, EventArgs e)
        {
            AbrirModal("Agregar", 0);
        }
        private void menumodificarcliente_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                AbrirModal("Editar", Convert.ToInt32(txtid.Text));
            }
            else
            {
                MessageBox.Show("Seleccione un cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void menueliminarcliente_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                if (MessageBox.Show("¿Está seguro de eliminar el cliente?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    bool eliminado = oCC_Cliente.EliminarCliente(Convert.ToInt32(txtid.Text), Convert.ToInt32(txtidpersona.Text), out mensaje);

                    if (eliminado)
                    {
                        MessageBox.Show("Cliente eliminado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Debe seleccionar un cliente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void btnactualizar_Click(object sender, EventArgs e)
        {
            datagridview.Rows.Clear();

            //MOSTRAR LOS CLIENTES
            List<Cliente> listaClientes = oCC_Cliente.ListarClientes();

            foreach (Cliente oCliente in listaClientes)
            {
                datagridview.Rows.Add(
                    "",
                    oCliente.IdCliente,
                    oCliente.IdPersona,
                    oCliente.NombreCompleto,
                    oCliente.Correo,
                    oCliente.Documento,
                    oCliente.Telefono,
                    oCliente.Direccion,
                    oCliente.Localidad,
                    oCliente.Estado == true ? 1 : 0,
                    oCliente.Estado == true ? "Activo" : "Inactivo"
                    );
            }

            //CONFIGURA QUE NO ESTE SELECCIONADA NINGUNA FILA
            datagridview.ClearSelection();

            txtid.Text = "";
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
        }
        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            btnbuscar_Click(sender, e);
            if (txtbusqueda.Text.Trim() == "")
            {
                btnlimpiar_Click(sender, e);
            }
        }
        private void cbobusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnbuscar_Click(sender, e);
            if (txtbusqueda.Text.Trim() == "")
            {
                btnlimpiar_Click(sender, e);
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
                txtid.Text = datagridview.Rows[indice].Cells["idCliente"].Value.ToString();
                txtidpersona.Text = datagridview.Rows[indice].Cells["idPersona"].Value.ToString();
            }
        }
        private void datagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indiceFila = e.RowIndex;
            int indiceColumna = e.ColumnIndex;

            if (indiceFila >= 0 && indiceColumna >= 0)
            {
                menuvercliente_Click(sender, e);
            }
        }
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
