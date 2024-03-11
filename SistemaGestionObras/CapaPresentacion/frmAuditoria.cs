using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Modals;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmAuditoria : Form
    {
        private ComprobanteObra _oComprobanteObra;
        private List<Hist_ComprobanteObra> _listaHistorica;
        private CC_ComprobanteObra oCC_ComprobanteObra = new CC_ComprobanteObra();
        private CC_Auditoria oCC_Auditoria = new CC_Auditoria();
        public frmAuditoria()
        {
            InitializeComponent();
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            using (var modal = new mdListaComprobante())
            {
                var resultado = modal.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    _oComprobanteObra = oCC_ComprobanteObra.ListarComprobante().Where(c => c.IdComprobanteObra == modal.IdComprobante).FirstOrDefault();
                    _listaHistorica = oCC_Auditoria.ListarHistComprobante(modal.IdComprobante);

                    txtnombrecliente.Text = _oComprobanteObra.oCliente.NombreCompleto;
                    txttelefono.Text = _oComprobanteObra.oCliente.Telefono;
                    txtcorreo.Text = _oComprobanteObra.oCliente.Correo;
                    txtdireccion.Text = _oComprobanteObra.Direccion;
                    txtlocalidad.Text = _oComprobanteObra.Localidad;
                    txtprovincia.Text = _oComprobanteObra.Provincia;
                    txtdescripcion.Text = _oComprobanteObra.Descripcion;
                    lblsubtitulo.Text = "Auditoría de Comprobante N° " + _oComprobanteObra.NumeroComprobante;

                    datagridview.Rows.Clear();
                    
                    foreach (Hist_ComprobanteObra historico in _listaHistorica)
                    {
                        datagridview.Rows.Add(
                        historico.Fecha.ToString("dd/MM/yyyy"),
                        historico.EstadoActual,
                        historico.EstadoPrevio,
                        historico.Adelanto,
                        historico.Saldo,
                        historico.MontoTotal,
                        historico.oComprobanteObra.oUsuario.NombreCompleto,
                        historico.Operacion
                        );
                    }

                }
            }
        }
        private void btnexportar_Click(object sender, EventArgs e)
        {
            string textoHtml = Properties.Resources.PlantillaAuditoria.ToString();
            textoHtml = textoHtml.Replace("@numerocomprobante", _oComprobanteObra.NumeroComprobante);
            textoHtml = textoHtml.Replace("@nombrecliente", _oComprobanteObra.oCliente.NombreCompleto);
            textoHtml = textoHtml.Replace("@telefonocliente", _oComprobanteObra.oCliente.Telefono);
            textoHtml = textoHtml.Replace("@direccion", _oComprobanteObra.Direccion);
            textoHtml = textoHtml.Replace("@localidad", _oComprobanteObra.Localidad);
            textoHtml = textoHtml.Replace("@provincia", _oComprobanteObra.Provincia);
            textoHtml = textoHtml.Replace("@descripcion", _oComprobanteObra.Descripcion);

            string filas = "";
            foreach (DataGridViewRow fila in datagridview.Rows)
            {
                filas += "<tr>";
                filas += "<td>" + fila.Cells["fecha"].Value + "</td>";
                filas += "<td>" + fila.Cells["estadoactual"].Value + "</td>";
                filas += "<td>" + fila.Cells["estadoprevio"].Value + "</td>";
                filas += "<td>" + fila.Cells["montototal"].Value + "</td>";
                filas += "<td>" + fila.Cells["adelanto"].Value + "</td>";
                filas += "<td>" + fila.Cells["saldo"].Value + "</td>";
                filas += "<td>" + fila.Cells["nombreusuario"].Value + "</td>";
                filas += "<td>" + fila.Cells["operacion"].Value + "</td>";
                filas += "</tr>";
            }
            textoHtml = textoHtml.Replace("@filas", filas);

            string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreArchivo = String.Format("AuditoriaComprobante_{0}.pdf", _oComprobanteObra.NumeroComprobante);
            string rutaCarpeta = Path.Combine(escritorio, "Auditorias Comprobantes");
            string rutaArchivo = Path.Combine(rutaCarpeta, nombreArchivo);

            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }
            try
            {
                if (File.Exists(rutaArchivo))
                {
                    File.Delete(rutaArchivo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al exportar el comprobante: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
            MessageBox.Show("Auditoría exportada correctamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(rutaArchivo);
        }
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
