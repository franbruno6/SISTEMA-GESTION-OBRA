using CapaControladora;
using CapaEntidad;
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
    public partial class Inicio : Form
    {
        private static Usuario _usuarioActual;
        private static IconMenuItem _menuActivo = null;
        private static Form _formularioActivo = null;

        public Inicio(Usuario oUsuario = null)
        {
            if (oUsuario == null)
            {
                _usuarioActual = new Usuario() { NombreCompleto = "Admin" , IdUsuario = 1};
                _usuarioActual.SetPermisos(new CC_Permiso().ListarPermisosPorId(_usuarioActual.IdUsuario));
            }
            else
            {
                _usuarioActual = oUsuario;
            }
            //_usuarioActual = oUsuario;
            //_usuarioActual.SetPermisos(new CC_Permiso().ListarPermisos(_usuarioActual.IdUsuario));

            InitializeComponent();
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> listaPermisos = _usuarioActual.GetPermisos();
            
            //List<Permiso> listaPermisos = new CC_Permiso().ListarPermisos(_usuarioActual.IdUsuario);

            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = listaPermisos.Any(p => p.NombreMenu == iconmenu.Name);

                if (encontrado)
                {
                    iconmenu.Visible = true;
                }
                else
                {
                    iconmenu.Visible = false;
                }
            }

            foreach (ToolStripMenuItem menu in menupermiso.DropDownItems)
            {
                bool encontrado = listaPermisos.Any(p => p.NombreMenu == menu.Name);

                if (encontrado)
                {
                    menu.Visible = true;
                }
                else
                {
                    menu.Visible = false;
                }
            }

            lblusuario.Text = _usuarioActual.NombreCompleto;
        }
        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if(_menuActivo != null)
            {
                _menuActivo.BackColor = Color.PaleGoldenrod;
            }
            menu.BackColor = Color.Silver;
            _menuActivo = menu;

            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
            }

            //CONFIGURO EL FORMULARIO
            _formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.Khaki;

            //AGREGO EL FORMULARIO AL CONTENEDOR
            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void menuusarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuario());
        }
        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmCliente());
        }
        private void menuproductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProducto());
        }
        private void menupresupuestos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmPresupuesto());
        }
        private void menucomprobantes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmComprobante());
        }
        private void menu_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, menu.ClientRectangle,
                Color.Black, 0, ButtonBorderStyle.None,
                Color.Black, 0, ButtonBorderStyle.None,
                Color.Black, 0, ButtonBorderStyle.None,
                Color.Black, 1, ButtonBorderStyle.Solid);
        }
        private void menupermisosimple_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menupermiso, new frmPermiso());
        }

        private void menugrupo_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menupermiso, new frmGrupo());
        }
    }
}
