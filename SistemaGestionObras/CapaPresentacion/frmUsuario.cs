using CapaControladora;
using CapaEntidad;
using CapaPresentacion.CP_Usuario;
using CapaPresentacion.Utilidades;
using FontAwesome.Sharp;
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
    public partial class frmUsuario : Form
    {
        private static Form formularioActivo = null;

        public frmUsuario()
        {
            InitializeComponent();
        }
        private void frmUsuario_Load(object sender, EventArgs e)
        {
            //AbrirFormulario(formListaUsuario);

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

            //MOSTRAR LOS USUARIOS
            List<Usuario> listaUsuarios = new CC_Usuario().ListarUsuarios();

            foreach (Usuario oUsuario in listaUsuarios)
            {
                datagridview.Rows.Add(
                    "",
                    oUsuario.IdUsuario,
                    oUsuario.NombreCompleto,
                    oUsuario.Correo,
                    oUsuario.Documento,
                    oUsuario.Clave,
                    oUsuario.Estado == true ? 1 : 0,
                    oUsuario.Estado == true ? "Activo" : "Inactivo"
                    );
            }

            //CONFIGURA QUE NO ESTE SELECCIONADA NINGUNA FILA
            datagridview.ClearSelection();
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
                txtid.Text = datagridview.Rows[indice].Cells["idUsuario"].Value.ToString();
            }
        }
        private void AbrirFormulario(Form formulario)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            //CONFIGURO EL FORMULARIO
            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.Khaki;

            //AGREGO EL FORMULARIO AL CONTENEDOR
            contenedor.Controls.Add(formulario);
            formulario.Show();
            formulario.BringToFront();
        }
        private void menuverusuario_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                AbrirFormulario(new frmDetalleUsuario("VerDetalle", Convert.ToInt32(txtid.Text)));
            }
            else
            {
                MessageBox.Show("Debe seleccionar un usuario", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void menuagregarusuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmDetalleUsuario("Agregar", 0));
        }

        private void menumodificarusuario_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmDetalleUsuario("Editar", Convert.ToInt32(txtid.Text)));
        }

        private void btnactualizar_Click(object sender, EventArgs e)
        {
            datagridview.Rows.Clear();

            //MOSTRAR LOS USUARIOS
            List<Usuario> listaUsuarios = new CC_Usuario().ListarUsuarios();

            foreach (Usuario oUsuario in listaUsuarios)
            {
                datagridview.Rows.Add(
                    "",
                    oUsuario.IdUsuario,
                    oUsuario.NombreCompleto,
                    oUsuario.Correo,
                    oUsuario.Documento,
                    oUsuario.Clave,
                    oUsuario.Estado == true ? 1 : 0,
                    oUsuario.Estado == true ? "Activo" : "Inactivo"
                    );
            }

            //CONFIGURA QUE NO ESTE SELECCIONADA NINGUNA FILA
            datagridview.ClearSelection();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
        }
    }
}
