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
        private static Usuario usuarioActual;
        private static IconMenuItem menuActivo = null;
        private static Form formularioActivo = null;

        public Inicio(Usuario oUsuario)
        {
            usuarioActual = oUsuario;
            
            InitializeComponent();
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> listaPermisos = new CC_Permiso().ListarPermisos(usuarioActual.IdUsuario);

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
            
            lblusuario.Text = usuarioActual.NombreCompleto;
        }
        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if(menuActivo != null)
            {
                menuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            menuActivo = menu;

            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            //CONFIGURO EL FORMULARIO
            formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.Goldenrod;

            //AGREGO EL FORMULARIO AL CONTENEDOR
            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void menuusarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuario());
        }

        private void menupermisos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmPermiso());
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
    }
}
