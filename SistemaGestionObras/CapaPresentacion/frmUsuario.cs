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
        private static IconMenuItem menuActivo = null;
        private static Form formularioActivo = null;

        public frmUsuario()
        {
            InitializeComponent();
        }

        private void frmUsuario_Load(object sender, EventArgs e)
        {
            AbrirFormulario(new frmListaUsuario());
        }
        private void AbrirFormulario(Form formulario)
        {
            //if (menuActivo != null)
            //{
            //    menuActivo.BackColor = Color.White;
            //}
            //menu.BackColor = Color.Silver;
            //menuActivo = menu;

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
        }

    }
}
