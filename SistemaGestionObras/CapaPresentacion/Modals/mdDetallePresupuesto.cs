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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using System.IO;
using System.Diagnostics;

namespace CapaPresentacion.Modals
{
    public partial class mdDetallePresupuesto : Form
    {
        private readonly string _tipoModal;
        private int _idPresupuesto;
        private Presupuesto _oPresupuesto;
        private Cliente _oCliente;
        private CC_Presupuesto oCC_Presupuesto = new CC_Presupuesto();
        private CC_Cliente oCC_Cliente = new CC_Cliente();
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
            Autocompletar();
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
                case "VerDetalle":
                    this.Close();
                    break;
                case "Agregar":
                    AgregarPresupuesto();
                    break;
                case "Editar":
                    EditarPresupuesto();
                    break;
            }
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

            DataTable listaDetalle = GenerarListaDetalle();

            string numeroPresupuesto = ObtenerNumeroPresupuesto();

            Presupuesto oPresupuesto = CrearPresupuesto(numeroPresupuesto);

            bool resultado = oCC_Presupuesto.AgregarPresupuesto(oPresupuesto, listaDetalle, out string mensaje);

            if (resultado)
            {
                if (MessageBox.Show("Presupuesto numero " + numeroPresupuesto + " registrado correctamente\n\nDesea exportarlo como PDF?", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _oPresupuesto = oPresupuesto;
                    btnexportar_Click(null, null);
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void EditarPresupuesto()
        {
            if (datagridview.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable listaDetalle = GenerarListaDetalle();

            Presupuesto oPresupuesto = CrearPresupuesto(_oPresupuesto.NumeroPresupuesto);

            bool resultado = oCC_Presupuesto.EditarPresupuesto(oPresupuesto, listaDetalle, out string mensaje);

            if (resultado)
            {
                MessageBox.Show("Presupuesto numero " + _oPresupuesto.NumeroPresupuesto + " editado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            this.Text = "Detalle Presupuesto " + _oPresupuesto.NumeroPresupuesto;
            btnaccion.Text = "Aceptar";
            lblsubtitulo.Text = "Detalle Presupuesto";
            btnaccion.Text = "Aceptar";
            btnaccion.IconChar = FontAwesome.Sharp.IconChar.Check;
            
            txtdireccion.Enabled = false;
            txtidcliente.Enabled = false;
            txtnombrecliente.Enabled = false;
            txttelefono.Enabled = false;
            txtlocalidad.Enabled = false;
            txtprovincia.Enabled = false;
            txtmontototal.Enabled = false;
            txtcorreo.Enabled = false;
            txtdescripcion.Enabled = false;

            datagridview.Columns["cantidad"].ReadOnly = true;
            datagridview.ReadOnly = true;
            datagridview.Enabled = false;

            btnagregar.Visible = false;
            btnbuscarcliente.Visible = false;
            btneliminar.Visible = false;
            btnexportar.Visible = true;

            txtnombrecliente.Text = _oPresupuesto.oCliente.NombreCompleto;
            txttelefono.Text = _oPresupuesto.oCliente.Telefono;
            txtdireccion.Text = _oPresupuesto.Direccion;
            txtlocalidad.Text = _oPresupuesto.Localidad;
            txtprovincia.Text = _oPresupuesto.Provincia;
            txtcorreo.Text = _oPresupuesto.oCliente.Correo;
            txtdescripcion.Text = _oPresupuesto.Descripcion;
            txtmontototal.Text = _oPresupuesto.MontoTotal.ToString();

            MostrarDetalle();
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
            this.Text = "Editar Presupuesto";
            btnaccion.Text = "Editar";
            lblsubtitulo.Text = "Editar Presupuesto";

            txtprovincia.Enabled = true;
            txtlocalidad.Enabled = true;
            txtdireccion.Enabled = true;

            txtnombrecliente.Text = _oPresupuesto.oCliente.NombreCompleto;
            txtidcliente.Text = _oPresupuesto.oCliente.IdCliente.ToString();
            txttelefono.Text = _oPresupuesto.oCliente.Telefono;
            txtdireccion.Text = _oPresupuesto.Direccion;
            txtlocalidad.Text = _oPresupuesto.Localidad;
            txtcorreo.Text = _oPresupuesto.oCliente.Correo;
            txtdescripcion.Text = _oPresupuesto.Descripcion;
            txtprovincia.Text = _oPresupuesto.Provincia;
            txtmontototal.Text = _oPresupuesto.MontoTotal.ToString();

            MostrarDetalle();
        }
        private void MostrarDetalle()
        {
            List<DetallePresupuesto> listaDetalle = oCC_Presupuesto.ListarDetalle(_idPresupuesto);

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
        private DataTable GenerarListaDetalle()
        {
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
            return listaDetalle;
        }
        private string ObtenerNumeroPresupuesto()
        {
            int idCorrelativo = oCC_Presupuesto.ObtenerCorrelativo();
            string numeroPresupuesto = string.Format("{0}", idCorrelativo.ToString().PadLeft(4, '0'));

            return numeroPresupuesto;
        }
        private Presupuesto CrearPresupuesto(string numeroPresupuesto)
        {
            Presupuesto oPresupuesto = new Presupuesto()
            {
                oUsuario = new Usuario()
                {
                    IdUsuario = _usuarioActual.IdUsuario
                },
                oCliente = new Cliente()
                {
                    IdCliente = Convert.ToInt32(txtidcliente.Text),
                    NombreCompleto = txtnombrecliente.Text,
                    Telefono = txttelefono.Text
                },
                NumeroPresupuesto = numeroPresupuesto,
                Direccion = txtdireccion.Text,
                Localidad = txtlocalidad.Text,
                Provincia = txtprovincia.Text,
                MontoTotal = Convert.ToDecimal(txtmontototal.Text),
                FechaRegistro = DateTime.Now,
                Descripcion = txtdescripcion.Text
            };
            if (_tipoModal == "Editar")
            {
                oPresupuesto.IdPresupuesto = _idPresupuesto;
            }
            return oPresupuesto;
        }
        private void btnbuscarcliente_Click(object sender, EventArgs e)
        {
            using (var modal = new mdAgregarClienteAPresupuesto())
            {
                var resultado = modal.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    txtidcliente.Text = modal.idcliente.ToString();

                    _oCliente = oCC_Cliente.ListarClientes().Where(c => c.IdCliente == modal.idcliente).FirstOrDefault();

                    txtnombrecliente.Text = _oCliente.NombreCompleto;
                    txttelefono.Text = _oCliente.Telefono;
                    txtcorreo.Text = _oCliente.Correo;
                    txtdireccion.Text = _oCliente.Direccion;
                    txtlocalidad.Text = _oCliente.Localidad;
                    txtprovincia.Text = _oCliente.Provincia;
                }
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
        private void txtidcliente_TextChanged(object sender, EventArgs e)
        {
            if (txtidcliente.Text.Trim() != "")
            {
                txtdireccion.Enabled = true;
                txtlocalidad.Enabled = true;
                txtprovincia.Enabled = true;
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

                e.Graphics.DrawImage(Properties.Resources.check, new System.Drawing.Rectangle(x, y, w, h));
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
        private void txtmontototal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void txtlocalidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }
        private void Autocompletar()
        {
            List<string> localidadesDB = oCC_Presupuesto.ListarLocalidades();
            AutoCompleteStringCollection localidades = new AutoCompleteStringCollection();
            localidades.AddRange(localidadesDB.ToArray());
            txtlocalidad.AutoCompleteCustomSource = localidades;

            List<string> provinciasDB = oCC_Presupuesto.ListarProvincias();
            AutoCompleteStringCollection provincias = new AutoCompleteStringCollection();
            provincias.AddRange(provinciasDB.ToArray());
            txtprovincia.AutoCompleteCustomSource = provincias;

            List<string> descripcionDB = oCC_Presupuesto.ListarDescripcion();
            AutoCompleteStringCollection descripcion = new AutoCompleteStringCollection();
            descripcion.AddRange(descripcionDB.ToArray());
            txtdescripcion.AutoCompleteCustomSource = descripcion;
        }
        private void btnexportar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string textoHtml = Properties.Resources.PlantillaPresupuesto.ToString();
            textoHtml = textoHtml.Replace("@numeropresupuesto", _oPresupuesto.NumeroPresupuesto);
            textoHtml = textoHtml.Replace("@nombrecliente", _oPresupuesto.oCliente.NombreCompleto);
            textoHtml = textoHtml.Replace("@telefonocliente", _oPresupuesto.oCliente.Telefono);
            textoHtml = textoHtml.Replace("@fecharegistro", _oPresupuesto.FechaRegistro.ToString("dd/MM/yyyy"));
            textoHtml = textoHtml.Replace("@descripcion", _oPresupuesto.Descripcion);

            string filas = "";
            foreach (DataGridViewRow fila in datagridview.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + fila.Cells["codigo"].Value + "</td>";
                filas += "<td>" + fila.Cells["nombre"].Value + "</td>";
                filas += "<td>" + fila.Cells["precio"].Value + "</td>";
                filas += "<td>" + fila.Cells["cantidad"].Value + "</td>";
                filas += "<td>" + fila.Cells["subTotal"].Value + "</td>";
                filas += "</tr>";
            }
            textoHtml = textoHtml.Replace("@filas", filas);
            textoHtml = textoHtml.Replace("@montototal", _oPresupuesto.MontoTotal.ToString());

            string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreArchivo = "Presupuesto_" + _oPresupuesto.NumeroPresupuesto + ".pdf";
            string rutaCarpeta = Path.Combine(escritorio, "Presupuestos");
            string rutaArchivo = Path.Combine(rutaCarpeta, nombreArchivo);

            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }
            if (File.Exists(rutaArchivo))
            {
                File.Delete(rutaArchivo);
            }

            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
            {
                using (Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 10f))
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (TextReader reader = new StringReader(textoHtml))
                        {
                            iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, reader);
                        }
                    }
                    doc.Close();
                }
            }
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Presupuesto exportado correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(rutaArchivo);
        }
        private void datagridview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (datagridview.Columns[e.ColumnIndex].Name == "cantidad")
                {
                    string value = datagridview.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString();
                    if (!int.TryParse(value, out int cantidad) || cantidad == 0)
                    {
                        datagridview.Rows[e.RowIndex].Cells["cantidad"].Value = 1;
                        return;
                    }
                    int cantidadC = Convert.ToInt32(datagridview.Rows[e.RowIndex].Cells["cantidad"].Value);
                    decimal precio = Convert.ToDecimal(datagridview.Rows[e.RowIndex].Cells["precio"].Value);

                    datagridview.Rows[e.RowIndex].Cells["subTotal"].Value = cantidadC * precio;

                    CalcularMontoTotal();
                }
            }
        }
    }
}
