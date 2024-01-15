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
        public frmDetalleUsuario(string tipoFormulario,int idUsuario)
        {
            _idUsuario = idUsuario;
            _tipoFormulario = tipoFormulario;
            oUsuario = new CC_Usuario().ListarUsuarios().Where(u => u.IdUsuario == _idUsuario).FirstOrDefault();
            InitializeComponent();
        }

        private void frmDetalleUsuario_Load(object sender, EventArgs e)
        {
            configurarFormulario();
        }
        private void configurarFormulario()
        {
            cboestado.Items.Add(new OpcionCombo("1", "Activo"));
            cboestado.Items.Add(new OpcionCombo("0", "Inactivo"));
            cboestado.SelectedIndex = 0;
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";

            if (_tipoFormulario == "VerDetalle")
            {
                txtnombrecompleto.Enabled = false;
                txtdocumento.Enabled = false;
                txtcorreo.Enabled = false;
                cboestado.Enabled = false;

                txtnombrecompleto.Text = oUsuario.NombreCompleto.ToString();
                txtdocumento.Text = oUsuario.Documento.ToString();
                txtcorreo.Text = oUsuario.Correo.ToString();
                cboestado.SelectedValue = oUsuario.Estado == true ? "1" : "0";
            }
            if (_tipoFormulario == "Agregar")
            {
                lblsubtitulo.Text = "Agregar Usuario";
                gboxclave.Visible = true;
                btnaccion.Text = "Agregar";
            }
            if (_tipoFormulario == "Editar")
            {
                lblsubtitulo.Text = "Editar Usuario";
                gboxclave.Visible = true;
                btnaccion.Text = "Editar";

                txtnombrecompleto.Text = oUsuario.NombreCompleto.ToString();
                txtdocumento.Text = oUsuario.Documento.ToString();
                txtcorreo.Text = oUsuario.Correo.ToString();
                cboestado.SelectedValue = oUsuario.Estado == true ? "1" : "0";
                txtclave.Text = oUsuario.Clave.ToString();
            }
        }
        private void btnvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnaccion_Click(object sender, EventArgs e)
        {
            if (_tipoFormulario == "Agregar")
            {
                int idUsuarioRegistrado = new CC_Usuario().AgregarUsuario(new Usuario()
                {
                    NombreCompleto = txtnombrecompleto.Text,
                    Documento = txtdocumento.Text,
                    Correo = txtcorreo.Text,
                    Clave = txtclave.Text,
                    Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
                }, out string mensaje);

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
            if (_tipoFormulario == "Editar")
            {
                bool usuarioEditado = new CC_Usuario().EditarUsuario(new Usuario()
                {
                    IdUsuario = _idUsuario,
                    IdPersona = oUsuario.IdPersona,
                    NombreCompleto = txtnombrecompleto.Text,
                    Documento = txtdocumento.Text,
                    Correo = txtcorreo.Text,
                    Clave = txtclave.Text,
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
        }
    }
}
