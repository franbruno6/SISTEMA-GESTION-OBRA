using CapaPresentacion.Utilidades;
using iTextSharp.text.pdf;
using iTextSharp.text;
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
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Controls;

namespace CapaPresentacion.Modals
{
    public partial class mdReporteComprobante : Form
    {
        private DataTable _dataTable;
        private string _periodo;
        public mdReporteComprobante(DataTable dataTable, string periodo)
        {
            _dataTable = dataTable;
            _periodo = periodo;
            InitializeComponent();
        }
        private void mdReporteComprobante_Load(object sender, EventArgs e)
        {
            lblperiodo.Text = _periodo;

            foreach (DataColumn columna in _dataTable.Columns)
            {
                cbocolumna.Items.Add(new OpcionCombo(columna.ColumnName, columna.ColumnName));
            }
            cbocolumna.SelectedIndex = 5;
            cbocolumna.DisplayMember = "Texto";
            cbocolumna.ValueMember = "Valor";

            CargarChart();
        }
        private void CargarChart()
        {
            chartreporte.Series.Clear();
            chartreporte.Titles.Clear();
            chartreporte.BackColor = Color.PaleGoldenrod;
            chartreporte.Titles.Add("Reporte de Comprobantes de Obra");
            chartreporte.Titles[0].Font = new System.Drawing.Font("Arial", 16, FontStyle.Bold);
            chartreporte.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            chartreporte.ChartAreas[0].AxisY.TitleFont = new System.Drawing.Font("Arial", 12, FontStyle.Bold);
            chartreporte.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartreporte.ChartAreas[0].AxisY.Title = "Cantidad";
            chartreporte.ChartAreas[0].AxisX.Title = cbocolumna.Text;
            chartreporte.ChartAreas[0].AxisY.LabelStyle.Font = new System.Drawing.Font("Arial", 10);
            chartreporte.ChartAreas[0].AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 10);
            chartreporte.ChartAreas[0].AxisX.TitleAlignment = StringAlignment.Far;
            chartreporte.ChartAreas[0].AxisY.TitleAlignment = StringAlignment.Far;

            Dictionary<string, int> diccionario = new Dictionary<string, int>();

            foreach (DataRow fila in _dataTable.Rows)
            {
                string valor = fila[cbocolumna.SelectedIndex].ToString();
                if (diccionario.ContainsKey(valor))
                {
                    diccionario[valor]++;
                }
                else
                {
                    diccionario.Add(valor, 1);
                }
            }

            Color[] colores = new Color[] { Color.Salmon, Color.LightSeaGreen, Color.YellowGreen, Color.Gold, Color.Orange, Color.Violet };

            int i = 0;

            chartreporte.Series.Add("Reporte");
            // Agregar los datos al Chart
            foreach (var kvp in diccionario)
            {
                string serie = kvp.Key;
                int cantidad = kvp.Value;

                chartreporte.Series["Reporte"].Points.AddXY(i, cantidad);
                chartreporte.Series["Reporte"].Points[i].Color = colores[i % colores.Length];
                chartreporte.Series["Reporte"].Points[i].AxisLabel = serie;
                chartreporte.Series["Reporte"]["PointWidth"] = "0.6";

                i++;
            }

            chartreporte.Legends.Clear();
            chartreporte.Legends.Add(new Legend("Legend1"));
            chartreporte.Legends["Legend1"].Docking = Docking.Bottom;

            chartreporte.ChartAreas[0].AxisX.Interval = 1; // Espaciar las etiquetas en el eje X
            chartreporte.ChartAreas[0].AxisY.Interval = 1; // Espaciar las etiquetas en el eje Y
        }
        private void cbocolumna_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarChart();
        }
        private void btnexportar_Click(object sender, EventArgs e)
        {
            string headerHtml = Properties.Resources.PlantillaReporte.ToString();
            headerHtml = headerHtml.Replace("@tiporeporte", "Reporte de Comprobantes");
            headerHtml = headerHtml.Replace("@periodo", _periodo);

            string tablaHtml = Properties.Resources.TablaReporteComprobante.ToString();
            string filas = "";
            foreach (DataRow fila in _dataTable.Rows)
            {
                filas += "<tr>";
                foreach (DataColumn columna in _dataTable.Columns)
                {
                    filas += "<td>" + fila[columna].ToString() + "</td>";
                }
                filas += "</tr>";
            }
            tablaHtml = tablaHtml.Replace("@filas", filas);

            Document doc = new Document(PageSize.A4.Rotate());
            string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreArchivo = String.Format("ReporteComprobantes_{0}_{1}.pdf", cbocolumna.Text, DateTime.Now.ToString("dd-MM-yyyy"));
            string rutaCarpeta = Path.Combine(escritorio, "Reportes Comprobantes");
            string rutaArchivo = Path.Combine(rutaCarpeta, nombreArchivo);

            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = nombreArchivo;
            saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
            saveFileDialog.Title = "Guardar Reporte";
            saveFileDialog.InitialDirectory = rutaCarpeta;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    doc.Open();

                    // Encabezado
                    MemoryStream ms = new MemoryStream();
                    using (TextReader reader = new StringReader(headerHtml))
                    {
                        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, reader);
                    }

                    AgregarGrafico(doc);
                    doc.NewPage();

                    //Tabla
                    using (TextReader reader = new StringReader(tablaHtml))
                    {
                        iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, reader);
                    }

                    doc.Close();
                    CargarChart();
                    MessageBox.Show("Archivo exportado correctamente", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    CargarChart();
                    MessageBox.Show("Error al exportar el archivo: " + ex.Message, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            //Document doc = new Document(PageSize.A4.Rotate());

            //string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //string nombreArchivo = String.Format("ReporteComprobantes_{0}_{1}.pdf", cbocolumna.Text, DateTime.Now.ToString("dd-MM-yyyy"));
            //string rutaCarpeta = Path.Combine(escritorio, "Reportes Comprobantes");

            //if (!Directory.Exists(rutaCarpeta))
            //{
            //    Directory.CreateDirectory(rutaCarpeta);
            //}

            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.FileName = nombreArchivo;
            //saveFileDialog.Filter = "Archivo PDF (*.pdf)|*.pdf";
            //saveFileDialog.Title = "Guardar Reporte";
            //saveFileDialog.InitialDirectory = rutaCarpeta;

            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        PdfWriter.GetInstance(doc, new FileStream(saveFileDialog.FileName, FileMode.Create));
            //        doc.Open();

            //        // Encabezado
            //        Paragraph titulo = new Paragraph("Reporte de Comprobantes", FontFactory.GetFont("Arial", 16));
            //        titulo.Alignment = Element.ALIGN_CENTER;
            //        doc.Add(titulo);

            //        Paragraph periodo = new Paragraph("Periodo: " + _periodo, FontFactory.GetFont("Arial", 12));
            //        periodo.Alignment = Element.ALIGN_CENTER;
            //        doc.Add(periodo);

            //        doc.Add(new Paragraph("\n"));

            //        AgregarGrafico(doc);

            //        doc.NewPage();

            //        AgregarTabla(doc);

            //        doc.Close();
            //        CargarChart();
            //        MessageBox.Show("Archivo exportado correctamente", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        Process.Start(saveFileDialog.FileName);
            //    }
            //    catch (Exception ex)
            //    {
            //        CargarChart();
            //        MessageBox.Show("Error al exportar el archivo: " + ex.Message, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
            //}
        }
        private void AgregarGrafico(Document doc)
        {
            MemoryStream ms = new MemoryStream();
            chartreporte.BackColor = Color.White;
            chartreporte.Titles.Clear();
            chartreporte.SaveImage(ms, ChartImageFormat.Png);
            iTextSharp.text.Image chart = iTextSharp.text.Image.GetInstance(ms.GetBuffer());
            chart.ScaleToFit(doc.PageSize.Width - 50, doc.PageSize.Height - 50); // Ajustar tamaño
            chart.Alignment = Element.ALIGN_CENTER;
            doc.Add(chart);
        }
        private void AgregarTabla(Document doc)
        {
            // Tabla
            PdfPTable tabla = new PdfPTable(_dataTable.Columns.Count);
            tabla.WidthPercentage = 100;

            // Encabezados
            foreach (DataColumn columna in _dataTable.Columns)
            {
                PdfPCell celda = new PdfPCell(new Phrase(columna.ColumnName, FontFactory.GetFont("Arial", 12)));
                celda.BackgroundColor = new BaseColor(240, 240, 240);
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                tabla.AddCell(celda);
            }

            // Filas
            foreach (DataRow fila in _dataTable.Rows)
            {
                foreach (DataColumn columna in _dataTable.Columns)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(fila[columna].ToString(), FontFactory.GetFont("Arial", 10)));
                    celda.HorizontalAlignment = Element.ALIGN_CENTER;
                    tabla.AddCell(celda);
                }
            }

            doc.Add(tabla);
        }
        private void btnvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
