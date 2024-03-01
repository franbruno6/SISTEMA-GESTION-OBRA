using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Utilidades
{
    public static class Validaciones
    {
        public static bool ValidarCamposVacios(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is TextBox textBox && textBox.Visible && textBox.Text.Trim() == string.Empty)
                {
                    textBox.Focus();
                    return false;
                }
                else if (control.HasChildren)
                {
                    if (!ValidarCamposVacios(control.Controls))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static bool ValidarClaves(string clave1, string clave2)
        {
            if (clave1 != clave2)
            {
                MessageBox.Show("Las claves no coinciden", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        public static bool ValidarCorreo(string correo)
        {
            string patronCorreo = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            Regex regex = new Regex(patronCorreo);

            if (!regex.IsMatch(correo))
            {
                MessageBox.Show("El correo ingresado no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
            //if (!correo.Contains("@") || !correo.Contains("."))
            //{
            //    MessageBox.Show("El correo ingresado no es válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}
            //return true;
        }
    }
}
