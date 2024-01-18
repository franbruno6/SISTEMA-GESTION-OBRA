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
    public partial class mdDetalleUsuario : Form
    {
        private readonly string _tipoModal;
        private int _idUsuario;
        private Usuario oUsuario;
        private CC_Usuario oCC_Usuario = new CC_Usuario();
        public mdDetalleUsuario(string tipoModal,int idUsuario)
        {
            _idUsuario = idUsuario;
            _tipoModal = tipoModal;
            oUsuario = oCC_Usuario.ListarUsuarios().Where(u => u.IdUsuario == _idUsuario).FirstOrDefault();
            InitializeComponent();
        }
        private void frmDetalleUsuario_Load(object sender, EventArgs e)
        {
            ConfigurarModal();
        }
        private void btnaccion_Click(object sender, EventArgs e)
        {
            if (_tipoModal != "RestablacerClave")
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
            switch (_tipoModal)
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
                this.DialogResult = DialogResult.OK;
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
                this.DialogResult = DialogResult.OK;
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
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigurarModal()
        {
            cboestado.Items.Add(new OpcionCombo(1, "Activo"));
            cboestado.Items.Add(new OpcionCombo(0, "Inactivo"));
            cboestado.SelectedIndex = 0;
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";

            switch (_tipoModal)
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
            this.Text = "Ver Detalle";
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
            this.Text = "Agregar Usuario";
            lblsubtitulo.Text = "Agregar Usuario";
            panelclave.Visible = true;
            btnaccion.Text = "Agregar";
        }
        private void ConfigurarEditar()
        {
            this.Text = "Editar Usuario";
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
            this.Text = "Restablecer Clave";
            lblsubtitulo.Text = "Restablecer Clave";

            panelclave.Visible = true;
            btnaccion.Text = "Restablecer Clave";
            panelclave.BringToFront();
            panelclave.Location = new Point(13, 160);
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
            if (MessageBox.Show("¿Está seguro que desea salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
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
