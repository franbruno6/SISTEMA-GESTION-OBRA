using CapaControladora;
using CapaEntidad;
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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btningresar_Click(object sender, EventArgs e)
        {
            //List < Usuario > TEST = new CC_Usuario().ListarUsuarios();


            Usuario oUsuario = new CC_Usuario().ListarUsuarios().Where(u => u.Documento == txtnumerodocumento.Text && u.Clave == txtclave.Text).FirstOrDefault();
            
            if (oUsuario != null)
            {
                Inicio inicio = new Inicio(oUsuario);

                inicio.Show();
                this.Hide();

                inicio.FormClosing += frm_closing;
            }
            else
            {
                MessageBox.Show("Usuario o clave incorrectos","Mensaje",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
        private void frm_closing(object sender, FormClosingEventArgs e)
        {
            txtnumerodocumento.Text = "";
            txtclave.Text = "";
            txtnumerodocumento.Select();
            this.Show();
        }

    }
}
