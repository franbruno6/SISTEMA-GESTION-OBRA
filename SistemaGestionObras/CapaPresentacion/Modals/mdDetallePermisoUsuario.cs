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
    public partial class mdDetallePermisoUsuario : Form
    {
        private readonly string _tipoModal;
        private int _idUsuario;
        private Usuario _oUsuario;
        private CC_Usuario oCC_Usuario = new CC_Usuario();
        private CC_UsuarioPermiso oCC_UsuarioPermiso = new CC_UsuarioPermiso();
        public mdDetallePermisoUsuario(string tipoModal, int idUsuario)
        {
            _tipoModal = tipoModal;
            _idUsuario = idUsuario;
            _oUsuario = oCC_Usuario.ListarUsuarios().Where(u => u.IdUsuario == _idUsuario).FirstOrDefault();
            InitializeComponent();
        }
        private void mdDetallePermisoUsuario_Load(object sender, EventArgs e)
        {
            cboestado.Items.Add(new OpcionCombo(1, "Activo"));
            cboestado.Items.Add(new OpcionCombo(0, "Inactivo"));
            cboestado.SelectedIndex = 0;
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";

            datagridview.Rows.Clear();

            txtnombrecompleto.Focus();

            switch (_tipoModal)
            {
                case "VerDetalle":
                    ConfigurarVerDetalle();
                    break;
                case "Editar":
                    ConfigurarEditar();
                    break;
            };
        }
        private void ConfigurarVerDetalle()
        {
            this.Text = "Ver detalle de usuario";
            txtnombrecompleto.Text = _oUsuario.NombreCompleto.ToString();
            txtnombrecompleto.Enabled = false;
            cboestado.Enabled = false;
            btnagregar.Visible = false;
            btneliminar.Visible = false;
            btnaccion.Visible = false;

            foreach (OpcionCombo opcion in cboestado.Items)
            {
                if (Convert.ToInt32(opcion.Valor) == (_oUsuario.Estado == true ? 1 : 0))
                {
                    int indiceCombo = cboestado.Items.IndexOf(opcion);
                    cboestado.SelectedIndex = indiceCombo;
                    break;
                }
            }

            MostrarPermisos();
        }
        private void ConfigurarEditar()
        {
            this.Text = "Administrar permisos del usuario";
            lblsubtitulo.Text = "Administrar permisos del usuario";
            btnaccion.Text = "Guardar";

            txtnombrecompleto.Text = _oUsuario.NombreCompleto.ToString();
            txtnombrecompleto.Enabled = false;
            cboestado.Enabled = false;

            foreach (OpcionCombo opcion in cboestado.Items)
            {
                if (Convert.ToInt32(opcion.Valor) == (_oUsuario.Estado == true ? 1 : 0))
                {
                    int indiceCombo = cboestado.Items.IndexOf(opcion);
                    cboestado.SelectedIndex = indiceCombo;
                    break;
                }
            }

            MostrarPermisos();
        }
        private void MostrarPermisos()
        {
            //MOSTRAR LOS PERMISOS
            List<Componente> listaComponentes = oCC_UsuarioPermiso.ListarComponentesPorId(_idUsuario);

            foreach (Componente oComponente in listaComponentes)
            {
                datagridview.Rows.Add(
                    "",
                    oComponente.IdComponente,
                    oComponente.Nombre,
                    oComponente.TipoComponente,
                    oComponente.Estado == true ? 1 : 0,
                    oComponente.Estado == true ? "Activo" : "Inactivo"
                    );
            }

            //CONFIGURA QUE NO ESTE SELECCIONADA NINGUNA FILA
            datagridview.ClearSelection();
        }
        private void datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;

            if (indice >= 0)
            {
                txtid.Text = datagridview.Rows[indice].Cells["IdComponente"].Value.ToString();
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
        private void btnvolver_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
            using (var modal = new mdAgregarComponenteAGrupo())
            {
                var resultado = modal.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    txtid.Text = modal.oComponente.IdComponente.ToString();

                    foreach (DataGridViewRow row in datagridview.Rows)
                    {
                        if (row.Cells["IdComponente"].Value.ToString() == txtid.Text)
                        {
                            MessageBox.Show("El componente ya se encuentra en la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    datagridview.Rows.Add(
                        "",
                        modal.oComponente.IdComponente,
                        modal.oComponente.Nombre,
                        modal.oComponente.TipoComponente,
                        modal.oComponente.Estado == true ? 1 : 0,
                        modal.oComponente.Estado == true ? "Activo" : "Inactivo"
                        );
                }
                datagridview.ClearSelection();
                txtid.Text = "";
            }
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            int indice = datagridview.CurrentRow.Index;

            if (indice >= 0)
            {
                datagridview.Rows.RemoveAt(indice);
            }

            datagridview.ClearSelection();
            txtid.Text = "";
        }
        private void btnaccion_Click(object sender, EventArgs e)
        {
            if (datagridview.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un permiso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable listaComponentes = new DataTable();

            listaComponentes.Columns.Add("IdComponente", typeof(int));

            foreach (DataGridViewRow row in datagridview.Rows)
            {
                listaComponentes.Rows.Add(Convert.ToInt32(row.Cells["IdComponente"].Value));
            }

            bool resultado = oCC_UsuarioPermiso.EditarUsuarioPermiso(_idUsuario, listaComponentes, out string mensaje);

            if (resultado)
            {
                MessageBox.Show("Usuario editado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
