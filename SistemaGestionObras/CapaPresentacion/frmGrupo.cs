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
    public partial class frmGrupo : Form
    {
        CC_GrupoPermiso oCC_GrupoPermiso = new CC_GrupoPermiso();
        private Usuario _usuarioActual;
        public frmGrupo(Usuario oUsuario)
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
            menuvergrupo.Visible = true;

            btnactualizar_Click(sender, e);
        }
        private void btnactualizar_Click(object sender, EventArgs e)
        {
            datagridview.Rows.Clear();

            //MOSTRAR LOS GRUPOS
            List<GrupoPermiso> listaGrupoPermisos = oCC_GrupoPermiso.ListarGrupoPermisos();

            foreach (GrupoPermiso oGrupoPermiso in listaGrupoPermisos)
            {
                datagridview.Rows.Add(
                    "",
                    oGrupoPermiso.IdGrupoPermiso,
                    oGrupoPermiso.IdComponente,
                    oGrupoPermiso.Nombre,
                    oGrupoPermiso.Estado == true ? 1 : 0,
                    oGrupoPermiso.Estado == true ? "Activo" : "Inactivo"
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
                txtid.Text = datagridview.Rows[indice].Cells["IdGrupoPermiso"].Value.ToString();
                txtidcomponente.Text = datagridview.Rows[indice].Cells["IdComponente"].Value.ToString();
            }
        }
        private void datagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int indiceFila = e.RowIndex;
            int indiceColumna = e.ColumnIndex;

            if (indiceFila >= 0 && indiceColumna >= 0)
            {
                menuvergrupo_Click(sender, e);
            }
        }
        private void menuvergrupo_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                AbrirModal("VerDetalle", Convert.ToInt32(txtid.Text));
            }
            else
            {
                MessageBox.Show("Debe seleccionar un grupo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void menuagregargrupo_Click(object sender, EventArgs e)
        {
            AbrirModal("Agregar", 0);
        }
        private void menumodificargrupo_Click(object sender, EventArgs e)
        {
            AbrirModal("Editar", Convert.ToInt32(txtid.Text));
        }
        private void AbrirModal(string tipoModal, int idGrupoPermiso)
        {
            using (var modal = new mdDetalleGrupoPermiso(tipoModal, idGrupoPermiso))
            {
                var resultado = modal.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    btnactualizar_Click(null, null);
                }
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
        }
        private void menueliminargrupo_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "" && txtidcomponente.Text != "")
            {
                DialogResult resultado = MessageBox.Show("¿Está seguro de eliminar el grupo?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    GrupoPermiso oGrupoPermiso = new GrupoPermiso();
                    oGrupoPermiso.IdGrupoPermiso = Convert.ToInt32(txtid.Text);
                    oGrupoPermiso.IdComponente = Convert.ToInt32(txtidcomponente.Text);

                    string mensaje;
                    bool respuesta = oCC_GrupoPermiso.EliminarGrupoPermiso(oGrupoPermiso, out mensaje);

                    if (respuesta)
                    {
                        MessageBox.Show("Grupo eliminado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnactualizar_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un grupo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}
