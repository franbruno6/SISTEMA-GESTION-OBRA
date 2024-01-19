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
    public partial class frmPermiso : Form
    {
        private CC_Permiso oCCPermiso = new CC_Permiso();
        private Usuario _usuarioActual;
        public frmPermiso(Usuario oUsuario)
        {
            _usuarioActual = oUsuario;
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
            menuverdetallepermisosimple.Visible = true;

            btnactualizar_Click(sender, e);
        }
        private void AbrirModal()
        {
            if (txtid.Text.Trim() != "")
            {
                int idPermiso = Convert.ToInt32(txtid.Text);

                using (var modal = new mdDetallePermisoSimple(idPermiso))
                {
                    var resultado = modal.ShowDialog();
                }
                btnactualizar_Click(null, null);
            }
            else
            {
                MessageBox.Show("Debe seleccionar un permiso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void menuverdetallepermisosimple_Click(object sender, EventArgs e)
        {
            AbrirModal();
        }
        private void menumodificarestadopermiso_Click(object sender, EventArgs e)
        {
            if (txtid.Text.Trim() != "")
            {
                string estado = datagridview.Rows[datagridview.CurrentRow.Index].Cells["estadoValor"].Value.ToString();
                string nuevoEstado = string.Empty;
                bool valorEstado = true;
                if (estado == "Activo")
                {
                    nuevoEstado = "Inactivo";
                    valorEstado = false;
                }
                else
                {
                    nuevoEstado = "Activo";
                    valorEstado = true;
                }

                if (MessageBox.Show("¿Está seguro de cambiar el estado de permiso a " + nuevoEstado + "?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string mensaje = string.Empty;

                    bool editado = oCCPermiso.EditarEstado(Convert.ToInt32(txtidcomponente.Text), valorEstado, out mensaje);

                    if (editado)
                    {
                        MessageBox.Show("Estado editado correctamente.\nSe recomienda reiniciar el sistema", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                MessageBox.Show("Debe seleccionar un permiso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
                AbrirModal();
            }
            
        }
    }
}
