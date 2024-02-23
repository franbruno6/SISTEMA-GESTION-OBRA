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
            if (!Validaciones.ValidarCamposVacios(Controls))
            {
                MessageBox.Show("Debe completar todos los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Usuario oUsuario = new CC_Usuario().ListarUsuarios().Where(u => u.Documento == txtnumerodocumento.Text).FirstOrDefault();

            if (oUsuario != null)
            {
                if (oUsuario.Estado == false)
                {
                    MessageBox.Show("El usuario se encuentra inactivo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                
                bool claveCorrecta = oUsuario.VerificarClave(txtclave.Text);

                if (claveCorrecta)
                {
                    
                    Inicio inicio = new Inicio(oUsuario);

                    inicio.Show();
                    this.Hide();

                    inicio.FormClosing += frm_closing;
                }
                else
                {
                    MessageBox.Show("Usuario o clave incorrectos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
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

        private void LogIn_Paint(object sender, PaintEventArgs e)
        {
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);

            ControlPaint.DrawBorder(e.Graphics, rect, Color.Black, 2, ButtonBorderStyle.Solid, Color.Black, 2, ButtonBorderStyle.Solid, Color.Black, 2, ButtonBorderStyle.Solid, Color.Black, 2, ButtonBorderStyle.Solid);
        }

        private void txtnumerodocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                txtclave.Select();
            }
        }
        private void txtclave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btningresar_Click(sender, e);
            }
        }
    }
}
