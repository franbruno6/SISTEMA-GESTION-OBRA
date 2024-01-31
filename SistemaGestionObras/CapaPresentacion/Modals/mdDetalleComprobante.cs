using CapaControladora;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Modals
{
    public partial class mdDetalleComprobante : Form
    {
        private string _tipoModal;
        private int _idComprobante;
        private ComprobanteObra _oComprobante = new ComprobanteObra();
        private CC_ComprobanteObra oCC_ComprobanteObra = new CC_ComprobanteObra();
        private CC_Presupuesto oCC_Presupuesto = new CC_Presupuesto();
        private Presupuesto _oPresupuesto = new Presupuesto();
        private Usuario _usuarioActual;
        public mdDetalleComprobante(string tipoModal, int idComprobante, Usuario usuarioActual, int idPresupuesto)
        {
            _tipoModal = tipoModal;
            _idComprobante = idComprobante;
            _oComprobante = oCC_ComprobanteObra.ListarComprobante().Where(c => c.IdComprobanteObra == _idComprobante).FirstOrDefault();
            _usuarioActual = usuarioActual;
            _oPresupuesto = oCC_Presupuesto.ListarPresupuestos().Where(p => p.IdPresupuesto == idPresupuesto).FirstOrDefault();
            InitializeComponent();
        }
        private void mdDetalleComprobante_Load(object sender, EventArgs e)
        {
            switch (_tipoModal)
            {
                case "VerDetalle":
                    ConfigurarVerDetalle();
                    break;
                case "Agregar":
                    ConfigurarAgregar();
                    break;
            }
        }
        private void btnaccion_Click(object sender, EventArgs e)
        {
            switch (_tipoModal)
            {
                case "VerDetalle":
                    this.Close();
                    break;
                case "Agregar":
                    AgregarComprobante();
                    break;

            }
        }
        private void AgregarComprobante()
        {
            if (datagridview.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (Convert.ToDecimal(txtadelanto.Text) > Convert.ToDecimal(txtmontototal.Text))
            {
                MessageBox.Show("El adelanto de pago no puede ser mayor al monto total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtadelanto.Focus();
                return;
            }

            DataTable listaDetalle = new DataTable();

            listaDetalle.Columns.Add("IdProducto", typeof(int));
            listaDetalle.Columns.Add("Precio", typeof(decimal));
            listaDetalle.Columns.Add("Cantidad", typeof(int));
            listaDetalle.Columns.Add("MontoTotal", typeof(decimal));

            foreach (DataGridViewRow fila in datagridview.Rows)
            {
                listaDetalle.Rows.Add(
                    fila.Cells["idProducto"].Value,
                    fila.Cells["precio"].Value,
                    fila.Cells["cantidad"].Value,
                    fila.Cells["subTotal"].Value
                );
            }

            int idCorrelativo = oCC_ComprobanteObra.ObtenerCorrelativo();
            string numeroComprobante = string.Format("{0}", idCorrelativo.ToString().PadLeft(4, '0'));

            ComprobanteObra oComprobanteObra = new ComprobanteObra()
            {
                oUsuario = _usuarioActual,
                oCliente = _oPresupuesto.oCliente,
                oPresupuesto = _oPresupuesto,
                NumeroComprobante = numeroComprobante,
                Direccion = txtdireccion.Text,
                Localidad = txtlocalidad.Text,
                MontoTotal = Convert.ToDecimal(txtmontototal.Text),
                FechaRegistro = DateTime.Now,
                Adelanto = Convert.ToDecimal(txtadelanto.Text),
                Saldo = Convert.ToDecimal(txtsaldo.Text)
            };

            bool resultado = oCC_ComprobanteObra.AgregarComprobante(oComprobanteObra, listaDetalle, out string mensaje);

            if (resultado)
            {
                MessageBox.Show("Comprobante de obra numero " + numeroComprobante + " registrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ConfigurarAgregar()
        {
            this.Text = "Agregar Comprobante";
            btnaccion.Text = "Agregar";
            lblsubtitulo.Text = "Agregar Comprobante";


            datagridview.Columns["cantidad"].ReadOnly = false;
            
            txtnombrecliente.Text = _oPresupuesto.oCliente.NombreCompleto;
            txttelefono.Text = _oPresupuesto.oCliente.Telefono;
            txtcorreo.Text = _oPresupuesto.oCliente.Correo;
            txtdireccion.Text = _oPresupuesto.Direccion;
            txtlocalidad.Text = _oPresupuesto.Localidad;
            txtidcliente.Text = _oPresupuesto.oCliente.IdCliente.ToString();
            txtestadoobra.Text = "Pendiente";

            datagridview.Rows.Clear();

            List<DetallePresupuesto> listaDetalle = oCC_Presupuesto.ListarDetalle(_oPresupuesto.IdPresupuesto);

            foreach (DetallePresupuesto oDetalle in listaDetalle)
            {
                datagridview.Rows.Add(
                "",
                oDetalle.oProducto.IdProducto,
                oDetalle.oProducto.Codigo,
                oDetalle.oProducto.Nombre,
                oDetalle.Precio,
                oDetalle.Cantidad,
                oDetalle.MontoTotal
            );
            }
            datagridview.ClearSelection();
            CalcularMontoTotal();
        }
        private void ConfigurarVerDetalle()
        {
            this.Text = "Detalle Comprobante";
            btnaccion.Text = "Aceptar";
            btnaccion.IconChar = FontAwesome.Sharp.IconChar.Check;
            lblsubtitulo.Text = "Comprobante numero " + _oComprobante.NumeroComprobante;

            txtnombrecliente.Text = _oComprobante.oCliente.NombreCompleto;
            txttelefono.Text = _oComprobante.oCliente.Telefono;
            txtcorreo.Text = _oComprobante.oCliente.Correo;
            txtdireccion.Text = _oComprobante.Direccion;
            txtlocalidad.Text = _oComprobante.Localidad;
            txtestadoobra.Text = _oComprobante.EstadoObra;

            txtadelanto.Enabled = false;
            txtdireccion.Enabled = false;
            txtlocalidad.Enabled = false;

            txtmontototal.Text = _oComprobante.MontoTotal.ToString();
            txtadelanto.Text = _oComprobante.Adelanto.ToString();
            txtsaldo.Text = _oComprobante.Saldo.ToString();

            btnagregar.Visible = false;
            btneliminar.Visible = false;

            datagridview.Rows.Clear();

            List<DetalleComprobanteObra> listaDetalle = oCC_ComprobanteObra.ListarDetalle(_idComprobante);

            foreach (DetalleComprobanteObra oDetalle in listaDetalle)
            {
                datagridview.Rows.Add(
                "",
                oDetalle.oProducto.IdProducto,
                oDetalle.oProducto.Codigo,
                oDetalle.oProducto.Nombre,
                oDetalle.Precio,
                oDetalle.Cantidad,
                oDetalle.MontoTotal
            );
            }
            datagridview.Enabled = false;
            datagridview.ClearSelection();

            if (_oComprobante.EstadoObra == "Cuenta saldada")
            {
                txtadelanto.Visible = false;
                lbladelanto.Visible = false;
            }
        }
        private void CalcularMontoTotal()
        {
            decimal montoTotal = 0;

            foreach (DataGridViewRow row in datagridview.Rows)
            {
                montoTotal += Convert.ToDecimal(row.Cells["subtotal"].Value);
            }
            txtmontototal.Text = montoTotal.ToString();
            CalcularSaldo(montoTotal);

        }
        private void CalcularSaldo(decimal montoTotal)  
        {
            decimal adelanto;
            decimal saldo;

            adelanto = Convert.ToDecimal(txtadelanto.Text);
            saldo = montoTotal - adelanto;
            txtsaldo.Text = saldo.ToString();
        }
        private void btnagregar_Click(object sender, EventArgs e)
        {
            using (var modal = new mdAgregarProductoAPresupuesto())
            {
                var resultado = modal.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    txtid.Text = modal.oProducto.IdProducto.ToString();

                    foreach (DataGridViewRow row in datagridview.Rows)
                    {
                        if (row.Cells["idProducto"].Value.ToString() == txtid.Text)
                        {
                            MessageBox.Show("El producto ya se encuentra en la lista", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    datagridview.Rows.Add(
                        "",
                        modal.oProducto.IdProducto,
                        modal.oProducto.Codigo,
                        modal.oProducto.Nombre,
                        modal.oProducto.Precio,
                        1,
                        modal.oProducto.Precio
                        );
                    CalcularMontoTotal();
                }
                datagridview.ClearSelection();
                txtid.Text = "";
            }
        }
        private void btneliminar_Click(object sender, EventArgs e)
        {
            int indice = datagridview.CurrentRow.Index;

            if (indice >= 0)
            {
                datagridview.Rows.RemoveAt(indice);
            }

            datagridview.ClearSelection();
            txtid.Text = "";
            CalcularMontoTotal();
        }
        private void btnvolver_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;

            if (indice >= 0)
            {
                txtid.Text = datagridview.Rows[indice].Cells["idProducto"].Value.ToString();
                datagridview.Rows[indice].Cells["cantidad"].ReadOnly = false;
                datagridview.Rows[indice].Cells["cantidad"].Selected = true;
            }
        }
        private void datagridview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (datagridview.Columns[e.ColumnIndex].Name == "cantidad")
                {
                    if (datagridview.Rows[e.RowIndex].Cells["cantidad"].Value == null)
                    {
                        return;
                    }
                    int cantidad = Convert.ToInt32(datagridview.Rows[e.RowIndex].Cells["cantidad"].Value);
                    decimal precio = Convert.ToDecimal(datagridview.Rows[e.RowIndex].Cells["precio"].Value);

                    datagridview.Rows[e.RowIndex].Cells["subTotal"].Value = cantidad * precio;

                    CalcularMontoTotal();
                }
            }
        }
        private void datagridview_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                e.PaintBackground(e.ClipBounds, true);

                var w = Properties.Resources.check.Width;
                var h = Properties.Resources.check.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.check, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }
        private void datagridview_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (datagridview.CurrentCell.ColumnIndex == 5)
            {
                TextBox textBox = e.Control as TextBox;

                if (textBox != null)
                {
                    // Asociar el evento KeyPress al control TextBox
                    textBox.KeyPress -= TextBox_KeyPress; // Asegurarse de eliminar el controlador existente
                    textBox.KeyPress += TextBox_KeyPress;
                }
            }
        }
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números y la tecla de retroceso (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtadelanto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (txtadelanto.Text.Trim().Length == 0 && e.KeyChar.ToString() == ",")
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
        private void txtsaldo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void txtadelanto_TextChanged(object sender, EventArgs e)
        {
            CalcularSaldo(Convert.ToDecimal(txtmontototal.Text));
        }
    }
}
