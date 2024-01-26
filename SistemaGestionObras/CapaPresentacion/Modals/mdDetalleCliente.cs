﻿using CapaControladora;
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
        private Cliente _oCliente;
        private CC_Cliente oCC_Cliente = new CC_Cliente();
        public int idCliente { get; set; }
        
        public mdDetalleCliente(string tipoModal, int idCliente)
        {
            _idCliente = idCliente;
            _tipoModal = tipoModal;
            _oCliente = oCC_Cliente.ListarClientes().Where(c => c.IdCliente == _idCliente).FirstOrDefault();
            InitializeComponent();
        }
        private void mdDetalleCliente_Load(object sender, EventArgs e)
        {
            ConfigurarModal();
        }
        private void btnaccion_Click(object sender, EventArgs e)
        {
            if (!Validaciones.ValidarCamposVacios(Controls))
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
            Cliente cliente = new Cliente()
            {
                NombreCompleto = txtnombrecompleto.Text.Trim(),
                Documento = txtdocumento.Text.Trim(),
                Correo = txtcorreo.Text.Trim(),
                Telefono = txttelefono.Text.Trim(),
                Direccion = txtdireccion.Text.Trim(),
                Localidad = txtlocalidad.Text.Trim(),
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            };
            int idClienteRegistrado = oCC_Cliente.AgregarCliente(cliente, out string mensaje);

            if (idClienteRegistrado != 0)
            {
                MessageBox.Show("Cliente agregado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                idCliente = idClienteRegistrado;
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
                IdPersona = _oCliente.IdPersona,
                NombreCompleto = txtnombrecompleto.Text.Trim(),
                Documento = txtdocumento.Text.Trim(),
                Correo = txtcorreo.Text.Trim(),
                Telefono = txttelefono.Text.Trim(),
                Direccion = txtdireccion.Text.Trim(),
                Localidad = txtlocalidad.Text.Trim(),
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
            txtlocalidad.Enabled = false;
            btnaccion.Visible = false;

            txtnombrecompleto.Text = _oCliente.NombreCompleto.ToString();
            txtdocumento.Text = _oCliente.Documento.ToString();
            txtcorreo.Text = _oCliente.Correo.ToString();
            foreach (OpcionCombo opcion in cboestado.Items)
            {
                if (Convert.ToInt32(opcion.Valor) == (_oCliente.Estado == true ? 1 : 0))
                {
                    int indiceCombo = cboestado.Items.IndexOf(opcion);
                    cboestado.SelectedIndex = indiceCombo;
                    break;
                }
            }
            txttelefono.Text = _oCliente.Telefono.ToString();
            txtdireccion.Text = _oCliente.Direccion.ToString();
            txtlocalidad.Text = _oCliente.Localidad.ToString();
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

            txtnombrecompleto.Text = _oCliente.NombreCompleto.ToString();
            txtdocumento.Text = _oCliente.Documento.ToString();
            txtcorreo.Text = _oCliente.Correo.ToString();
            foreach (OpcionCombo opcion in cboestado.Items)
            {
                if (Convert.ToInt32(opcion.Valor) == (_oCliente.Estado == true ? 1 : 0))
                {
                    int indiceCombo = cboestado.Items.IndexOf(opcion);
                    cboestado.SelectedIndex = indiceCombo;
                    break;
                }
            }
            txttelefono.Text = _oCliente.Telefono.ToString();
            txtdireccion.Text = _oCliente.Direccion.ToString();
            txtlocalidad.Text = _oCliente.Localidad.ToString();
        }
        private void btnvolver_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Está seguro que desea salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtdocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
