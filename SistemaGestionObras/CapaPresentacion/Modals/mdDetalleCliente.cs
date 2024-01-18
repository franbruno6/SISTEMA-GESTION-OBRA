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

namespace CapaPresentacion.Modals
{
    public partial class mdDetalleCliente : Form
    {
        private readonly string _tipoModal;
        private int _idCliente;
        private Cliente oCliente;
        private CC_Cliente oCC_Cliente = new CC_Cliente();
        
        public mdDetalleCliente(string tipoModal, int idCliente)
        {
            _idCliente = idCliente;
            _tipoModal = tipoModal;
            oCliente = oCC_Cliente.ListarClientes().Where(c => c.IdCliente == _idCliente).FirstOrDefault();
            InitializeComponent();
        }
        private void mdDetalleCliente_Load(object sender, EventArgs e)
        {
            ConfigurarModal();
        }
        private void btnaccion_Click(object sender, EventArgs e)
        {
            if (!ValidarTextosVacios())
            {
                MessageBox.Show("Debe completar todos los campos", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            switch (_tipoModal)
            {
                case "Agregar":
                    AgregarCliente();
                    break;
                case "Editar":
                    EditarCliente();
                    break;
            }
        }
        private void AgregarCliente()
        {
            int idClienteRegistrado = oCC_Cliente.AgregarCliente(new Cliente()
            {
                NombreCompleto = txtnombrecompleto.Text.Trim(),
                Documento = txtdocumento.Text.Trim(),
                Correo = txtcorreo.Text.Trim(),
                Telefono = txttelefono.Text.Trim(),
                Direccion = txtdireccion.Text.Trim(),
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            }, out string mensaje);

            if (idClienteRegistrado != 0)
            {
                MessageBox.Show("Cliente agregado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditarCliente()
        {
            bool clienteEditado = oCC_Cliente.EditarCliente(new Cliente()
            {
                IdCliente = _idCliente,
                IdPersona = oCliente.IdPersona,
                NombreCompleto = txtnombrecompleto.Text.Trim(),
                Documento = txtdocumento.Text.Trim(),
                Correo = txtcorreo.Text.Trim(),
                Telefono = txttelefono.Text.Trim(),
                Direccion = txtdireccion.Text.Trim(),
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            }, out string mensaje);

            if (clienteEditado)
            {
                MessageBox.Show("Cliente editado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            }
        }
        private void ConfigurarVerDetalle()
        {
            this.Text = "Ver Detalle";
            txtnombrecompleto.Enabled = false;
            txtdocumento.Enabled = false;
            txtcorreo.Enabled = false;
            cboestado.Enabled = false;
            txttelefono.Enabled = false;
            txtdireccion.Enabled = false;
            btnaccion.Visible = false;

            txtnombrecompleto.Text = oCliente.NombreCompleto.ToString();
            txtdocumento.Text = oCliente.Documento.ToString();
            txtcorreo.Text = oCliente.Correo.ToString();
            foreach (OpcionCombo opcion in cboestado.Items)
            {
                if (Convert.ToInt32(opcion.Valor) == (oCliente.Estado == true ? 1 : 0))
                {
                    int indiceCombo = cboestado.Items.IndexOf(opcion);
                    cboestado.SelectedIndex = indiceCombo;
                    break;
                }
            }
            txttelefono.Text = oCliente.Telefono.ToString();
            txtdireccion.Text = oCliente.Direccion.ToString();
        }
        private void ConfigurarAgregar()
        {
            this.Text = "Agregar Cliente";
            lblsubtitulo.Text = "Agregar Cliente";
            btnaccion.Text = "Agregar";
        }
        private void ConfigurarEditar()
        {
            this.Text = "Editar Cliente";
            lblsubtitulo.Text = "Editar Cliente";
            btnaccion.Text = "Editar";

            txtnombrecompleto.Text = oCliente.NombreCompleto.ToString();
            txtdocumento.Text = oCliente.Documento.ToString();
            txtcorreo.Text = oCliente.Correo.ToString();
            foreach (OpcionCombo opcion in cboestado.Items)
            {
                if (Convert.ToInt32(opcion.Valor) == (oCliente.Estado == true ? 1 : 0))
                {
                    int indiceCombo = cboestado.Items.IndexOf(opcion);
                    cboestado.SelectedIndex = indiceCombo;
                    break;
                }
            }
            txttelefono.Text = oCliente.Telefono.ToString();
            txtdireccion.Text = oCliente.Direccion.ToString();
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
            if (txtdireccion.Text.Trim() == string.Empty)
            {
                return false;
            }
            if (txtdireccion.Text.Trim() == string.Empty)
            {
                return false;
            }
            return true;
        }
        private void btnvolver_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Está seguro que desea salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
