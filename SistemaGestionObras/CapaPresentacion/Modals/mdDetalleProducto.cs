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
    public partial class mdDetalleProducto : Form
    {
        private readonly string _tipoModal;
        private readonly int _idProducto;
        private Producto _oProducto;
        private CC_Producto oCC_Producto = new CC_Producto();
        public mdDetalleProducto(string tipoModal, int idProducto)
        {
            _tipoModal = tipoModal;
            _idProducto = idProducto;
            _oProducto = oCC_Producto.ListarProductos().Where(u => u.IdProducto == _idProducto).FirstOrDefault();
            InitializeComponent();
        }
        private void mdDetalleProducto_Load(object sender, EventArgs e)
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
            txtnombre.Enabled = false;
            txtcodigo.Enabled = false;
            txtcategoria.Enabled = false;
            txtdescripcion.Enabled = false;
            txtprecio.Enabled = false;
            cboestado.Enabled = false;
            btnaccion.Visible = false;

            txtnombre.Text = _oProducto.Nombre.ToString();
            txtcodigo.Text = _oProducto.Codigo.ToString();
            txtcategoria.Text = _oProducto.Categoria.ToString();
            txtdescripcion.Text = _oProducto.Descripcion.ToString();
            txtprecio.Text = _oProducto.Precio.ToString();
            foreach (OpcionCombo opcion in cboestado.Items)
            {
                if (Convert.ToInt32(opcion.Valor) == (_oProducto.Estado == true ? 1 : 0))
                {
                    int indiceCombo = cboestado.Items.IndexOf(opcion);
                    cboestado.SelectedIndex = indiceCombo;
                    break;
                }
            }
        }
        private void ConfigurarAgregar()
        {
            this.Text = "Agregar Producto";
            lblsubtitulo.Text = "Agregar Producto";
            btnaccion.Text = "Agregar";
        }
        private void ConfigurarEditar()
        {
            this.Text = "Editar Permiso";
            lblsubtitulo.Text = "Editar Permiso";
            btnaccion.Text = "Editar";

            txtnombre.Text = _oProducto.Nombre.ToString();
            txtcodigo.Text = _oProducto.Codigo.ToString();
            txtcategoria.Text = _oProducto.Categoria.ToString();
            txtdescripcion.Text = _oProducto.Descripcion.ToString();
            txtprecio.Text = _oProducto.Precio.ToString();
            foreach (OpcionCombo opcion in cboestado.Items)
            {
                if (Convert.ToInt32(opcion.Valor) == (_oProducto.Estado == true ? 1 : 0))
                {
                    int indiceCombo = cboestado.Items.IndexOf(opcion);
                    cboestado.SelectedIndex = indiceCombo;
                    break;
                }
            }
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
                    AgregarProducto();
                    break;
                case "Editar":
                    EditarProducto();
                    break;
            }
        }
        private void AgregarProducto()
        {
            int idProductoRegistrado = oCC_Producto.AgregarProducto(new Producto()
            {
                Nombre = txtnombre.Text,
                Codigo = txtcodigo.Text,
                Descripcion = txtdescripcion.Text,
                Categoria = txtcategoria.Text,
                Precio = Convert.ToDecimal(txtprecio.Text),
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            }, out string mensaje);

            if (idProductoRegistrado > 0)
            {
                MessageBox.Show("Producto registrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditarProducto()
        {
            bool productoEditado = oCC_Producto.EditarProducto(new Producto()
            {
                IdProducto = _idProducto,
                Nombre = txtnombre.Text,
                Codigo = txtcodigo.Text,
                Descripcion = txtdescripcion.Text,
                Categoria = txtcategoria.Text,
                Precio = Convert.ToDecimal(txtprecio.Text),
                Estado = Convert.ToInt32(((OpcionCombo)cboestado.SelectedItem).Valor) == 1 ? true : false
            }, out string mensaje);

            if (productoEditado)
            {
                MessageBox.Show("Producto editado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnvolver_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void txtprecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (txtprecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
            {
                e.Handled = true;
            }
            else if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ",")
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void txtcodigo_KeyPress(object sender, KeyPressEventArgs e)
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
