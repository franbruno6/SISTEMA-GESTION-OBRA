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
    public partial class mdDetallePresupuesto : Form
    {
        private readonly string _tipoModal;
        private int _idPresupuesto;
        private Presupuesto _oPresupuesto;
        private CC_Presupuesto oCC_Presupuesto = new CC_Presupuesto();
        private Usuario _usuarioActual;
        public mdDetallePresupuesto(string tipoModal, int idPresupuesto, Usuario oUsuario)
        {
            _tipoModal = tipoModal;
            _idPresupuesto = idPresupuesto;
            _usuarioActual = oUsuario;
            _oPresupuesto = oCC_Presupuesto.ListarPresupuestos().Where(p => p.IdPresupuesto == _idPresupuesto).FirstOrDefault();
            InitializeComponent();
        }

        private void mdDetallePresupuesto_Load(object sender, EventArgs e)
        {
            ConfigurarModal();
        }
        private void ConfigurarModal()
        {
            datagridview.Rows.Clear();

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
            };
        }
        private void ConfigurarVerDetalle()
        {

        }
        private void ConfigurarAgregar()
        {
            this.Text = "Agregar Presupuesto";
            btnaccion.Text = "Agregar";
            lblsubtitulo.Text = "Agregar Presupuesto";

            datagridview.Columns["cantidad"].ReadOnly = false;
        }
        private void ConfigurarEditar()
        {

        }
        private void AgregarPresupuesto()
        {
            if (datagridview.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtidcliente.Text.Trim() == "")
            {
                MessageBox.Show("Debe seleccionar un cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            int idCorrelativo = oCC_Presupuesto.ObtenerCorrelativo();
            string numeroPresupuesto = string.Format("{0}", idCorrelativo.ToString().PadLeft(6, '0'));

            Presupuesto oPresupuesto = new Presupuesto()
            {
                oUsuario = new Usuario()
                {
                    IdUsuario = _usuarioActual.IdUsuario
                },
                NumeroPresupuesto = numeroPresupuesto,
                NombreCliente = txtnombrecliente.Text,
                TelefonoCliente = txttelefono.Text,
                Direccion = txtdireccion.Text,
                Localidad = txtlocalidad.Text,
                MontoTotal = Convert.ToDecimal(txtmontototal.Text),
                FechaRegistro = DateTime.Now.ToString("yyyy-MM-dd")
            };

            bool resultado = oCC_Presupuesto.AgregarPresupuesto(oPresupuesto, listaDetalle, out string mensaje);

            if (resultado)
            {
                MessageBox.Show("Presupuesto numero " + numeroPresupuesto + "registrado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            using (var modal = new mdAgregarClienteAPresupuesto())
            {
                var resultado = modal.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    txtidcliente.Text = modal.oCliente.IdCliente.ToString();

                    txtnombrecliente.Text = modal.oCliente.NombreCompleto;
                    txttelefono.Text = modal.oCliente.Telefono;
                    txtdireccion.Text = modal.oCliente.Direccion;
                }
            }
        }

        private void btnvolver_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro que desea salir?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void txtidcliente_TextChanged(object sender, EventArgs e)
        {
            if (txtidcliente.Text.Trim() == "")
            {
                txtnombrecliente.Enabled = false;
                txttelefono.Enabled = false;
                txtdireccion.Enabled = false;
                txtlocalidad.Enabled = false;
            }
            else
            {
                txtnombrecliente.Enabled = true;
                txttelefono.Enabled = true;
                txtdireccion.Enabled = true;
                txtlocalidad.Enabled = true;
            }
        }

        private void datagridview_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (datagridview.Columns[e.ColumnIndex].Name == "cantidad")
                {
                    int cantidad = Convert.ToInt32(datagridview.Rows[e.RowIndex].Cells["cantidad"].Value);
                    decimal precio = Convert.ToDecimal(datagridview.Rows[e.RowIndex].Cells["precio"].Value);

                    datagridview.Rows[e.RowIndex].Cells["subTotal"].Value = cantidad * precio;

                    CalcularMontoTotal();
                }
            }
        }

        private void CalcularMontoTotal()
        {
            decimal montoTotal = 0;

            foreach (DataGridViewRow fila in datagridview.Rows)
            {
                decimal subTotal = Convert.ToDecimal(fila.Cells["subTotal"].Value);

                montoTotal += subTotal;
                txtmontototal.Text = montoTotal.ToString();
            }
        }
        private void datagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int indice = e.RowIndex;

            if (indice >= 0)
            {
                txtid.Text = datagridview.Rows[indice].Cells["idProducto"].Value.ToString();
            }

            if (indice >= 0)
            {
                datagridview.Rows[indice].Cells["cantidad"].ReadOnly = false;
                datagridview.Rows[indice].Cells["cantidad"].Selected = true;
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

        private void btnaccion_Click(object sender, EventArgs e)
        {
            switch (_tipoModal)
            {
                case "Agregar":
                    AgregarPresupuesto();
                    break;
                case "Editar":
                    break;
            }
        }

    }
}
