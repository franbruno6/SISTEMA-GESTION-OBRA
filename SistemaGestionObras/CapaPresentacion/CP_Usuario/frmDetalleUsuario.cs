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

namespace CapaPresentacion.CP_Usuario
{
    public partial class frmDetalleUsuario : Form
    {
        private readonly string _tipoFormulario;
        private int _idUsuario;
        private Usuario oUsuario;
        private CC_Usuario oCC_Usuario = new CC_Usuario();
        public frmDetalleUsuario(string tipoFormulario,int idUsuario)
        {
            _idUsuario = idUsuario;
            _tipoFormulario = tipoFormulario;
            oUsuario = oCC_Usuario.ListarUsuarios().Where(u => u.IdUsuario == _idUsuario).FirstOrDefault();
            InitializeComponent();
        }
        private void frmDetalleUsuario_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();
        }
        private void btnaccion_Click(object sender, EventArgs e)
        {
            if (_tipoFormulario != "RestablacerClave")
            {
                if (!ValidarTextosVacios())
                {
                    MessageBox.Show("Debe completar todos los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            if (panelclave.Visible == true)
            {
                if (!ValidarCamposClaves())
                {
                    return;
                }
            }
            switch (_tipoFormulario)
            {
                case "Agregar":
                    AgregarUsuario();
                    break;
                case "Editar":
                    EditarUsuario();
                    break;
                case "RestablacerClave":
                    RestablecerClave();
                    break;
            }
        }
        private void AgregarUsuario() {
            string claveHash = Usuario.GenerarClaveHash(txtclave.Text);

            int idUsuarioRegistrado = oCC_Usuario.AgregarUsuario(new Usuario()
            {
                NombreCompleto = txtnombrecompleto.Text,
                Documento = txtdocumento.Text,
                Correo = txtcorreo.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            }, claveHash, out string mensaje);

            if (idUsuarioRegistrado > 0)
            {
                MessageBox.Show("Usuario registrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditarUsuario()
        {
            bool usuarioEditado = oCC_Usuario.EditarUsuario(new Usuario()
            {
                IdUsuario = _idUsuario,
                IdPersona = oUsuario.IdPersona,
                NombreCompleto = txtnombrecompleto.Text,
                Documento = txtdocumento.Text,
                Correo = txtcorreo.Text,
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            }, out string mensaje);

            if (usuarioEditado)
            {
                MessageBox.Show("Usuario editado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RestablecerClave()
        {
            string claveHash = Usuario.GenerarClaveHash(txtclave.Text);
            bool claveRestablecida = oCC_Usuario.RestablecerClave(_idUsuario, claveHash, out string mensaje);

            if (claveRestablecida)
            {
                MessageBox.Show("Clave restablecida correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigurarFormulario()
        {
            cboestado.Items.Add(new OpcionCombo(1, "Activo"));
            cboestado.Items.Add(new OpcionCombo(0, "Inactivo"));
            cboestado.SelectedIndex = 0;
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";

            switch (_tipoFormulario)
            {
                case "VerDetalle":
                    ConfigurarVerDetalle();
                    break;
                case "Agregar":
                    ConfigurarAgregar();
                    break;
                case "Editar":
                    ConfigurarEditar();
                    break;
                case "RestablacerClave":
                    ConfigurarRestablecerClave();
                    break;
            }
        }
        private void ConfigurarVerDetalle()
        {
            txtnombrecompleto.Enabled = false;
            txtdocumento.Enabled = false;
            txtcorreo.Enabled = false;
            cboestado.Enabled = false;
            btnaccion.Visible = false;

            txtnombrecompleto.Text = oUsuario.NombreCompleto.ToString();
            txtdocumento.Text = oUsuario.Documento.ToString();
            txtcorreo.Text = oUsuario.Correo.ToString();
            foreach (OpcionCombo opcion in cboestado.Items)
            {
                if (Convert.ToInt32(opcion.Valor) == (oUsuario.Estado == true ? 1 : 0))
                {
                    int indiceCombo = cboestado.Items.IndexOf(opcion);
                    cboestado.SelectedIndex = indiceCombo;
                    break;
                }
            }
        }
        private void ConfigurarAgregar()
        {
            lblsubtitulo.Text = "Agregar Usuario";
            panelclave.Visible = true;
            btnaccion.Text = "Agregar";
        }
        private void ConfigurarEditar()
        {
            lblsubtitulo.Text = "Editar Usuario";
            btnaccion.Text = "Editar";

            txtnombrecompleto.Text = oUsuario.NombreCompleto.ToString();
            txtdocumento.Text = oUsuario.Documento.ToString();
            txtcorreo.Text = oUsuario.Correo.ToString();
            foreach (OpcionCombo opcion in cboestado.Items)
            {
                if (Convert.ToInt32(opcion.Valor) == (oUsuario.Estado == true ? 1 : 0))
                {
                    int indiceCombo = cboestado.Items.IndexOf(opcion);
                    cboestado.SelectedIndex = indiceCombo;
                    break;
                }
            }
        }
        private void ConfigurarRestablecerClave()
        {
            lblsubtitulo.Text = "Restablecer Clave";

            panelclave.Visible = true;
            btnaccion.Text = "Restablecer Clave";
            panelclave.BringToFront();
            panelclave.Location = new Point(13, 194);
            btnaccion.BringToFront();

            txtnombrecompleto.Visible = false;
            txtcorreo.Visible = false;
            txtdocumento.Visible = false;
            cboestado.Visible = false;
            lblnombrecompleto.Visible = false;
            lbldocumento.Visible = false;
            lblcorreo.Visible = false;
            lblestado.Visible = false;

            btnaccion.IconChar = FontAwesome.Sharp.IconChar.Key;
            btnaccion.Text = "Restablecer Contraseña";
        }
        private bool ValidarCamposClaves()
        {
            if (txtclave.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Debe completar la clave", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtconfirmarclave.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Debe completar la confirmacion de la clave", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtclave.Text != txtconfirmarclave.Text)
            {
                MessageBox.Show("Las claves no coinciden", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private bool ValidarTextosVacios()
        {
            if (txtnombrecompleto.Text.Trim() == string.Empty)
            {
                return false;
            }
            if (txtdocumento.Text.Trim() == string.Empty)
            {
                return false;
            }
            if (txtcorreo.Text.Trim() == string.Empty)
            {
                return false;
            }

            return true;
        }
        private void btnvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnverclave_MouseDown(object sender, MouseEventArgs e)
        {
            txtclave.PasswordChar = '\0';
            txtconfirmarclave.PasswordChar = '\0';
        }
        private void btnverclave_MouseUp(object sender, MouseEventArgs e)
        {
            txtclave.PasswordChar = '*';
            txtconfirmarclave.PasswordChar = '*';
        }
    }
}
