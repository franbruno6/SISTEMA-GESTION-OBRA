using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Modals;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
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
    public partial class frmReporteComprobante : Form
    {
        private CC_Reporte oCC_Reporte = new CC_Reporte();
        public frmReporteComprobante()
        {
            InitializeComponent();
        }
        private void frmReporteComprobante_Load(object sender, EventArgs e)
        {
            foreach (DataGridViewColumn columna in datagridview.Columns)
            {
                if (columna.Visible)
                {
                    cbobusqueda.Items.Add(new OpcionCombo(columna.Name, columna.HeaderText));
                }
            }
            cbobusqueda.SelectedIndex = 0;
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            if (datagridview.Rows.Count > 0)
            {
                datagridview.Rows.Clear();
            }
            if (dtpfechafin.Value.Date < dtpfechainicio.Value.Date)
            {
                MessageBox.Show("La fecha de fin no puede ser menor a la fecha de inicio", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<ReporteComprobante> listaReporteComprobante = oCC_Reporte.ListarReporteComprobante(dtpfechainicio.Value.ToString("dd-MM-yyyy"), dtpfechafin.Value.ToString("dd-MM-yyyy"));

            if (listaReporteComprobante.Count < 1)
            {
                MessageBox.Show("No se encontraron registros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (ReporteComprobante reporteComprobante in listaReporteComprobante)
            {
                datagridview.Rows.Add(
                    reporteComprobante.FechaRegistro.ToString("dd-MM-yyyy"),
                    reporteComprobante.NumeroComprobante,
                    reporteComprobante.NombreCliente,
                    reporteComprobante.Correo,
                    reporteComprobante.Direccion,
                    reporteComprobante.Localidad,
                    reporteComprobante.Provincia,
                    reporteComprobante.Estado,
                    reporteComprobante.MontoTotal,
                    reporteComprobante.Descripcion,
                    reporteComprobante.NombreUsuario
                    );
            }
            foreach (DataGridViewColumn columna in datagridview.Columns)
            {
                if (columna.HeaderText == "Descripcion" || columna.HeaderText == "Usuario")
                {
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                else
                {
                    columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                    columna.Width = columna.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
                }
            }
            datagridview.ClearSelection();
        }
        private void txtbusqueda_TextChanged(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)cbobusqueda.SelectedItem).Valor.ToString();

            if (datagridview.Rows.Count > 0)
            {
                foreach (DataGridViewRow fila in datagridview.Rows)
                {
                    if (fila.Cells[columnaFiltro].Value.ToString().Trim().ToUpper().Contains(txtbusqueda.Text.Trim().ToUpper()))
                    {
                        fila.Visible = true;
                    }
                    else
                    {
                        fila.Visible = false;
                    }
                }
            }
        }
        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtbusqueda.Text = "";

            foreach (DataGridViewRow fila in datagridview.Rows)
            {
                fila.Visible = true;
            }

            datagridview.ClearSelection();
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (datagridview.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string escritorio = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string nombreArchivo = String.Format("ReporteComprobantes_{0}.xlsx", DateTime.Now.ToString("dd-MM-yyyy"));
            string rutaCarpeta = Path.Combine(escritorio, "Reportes Comprobantes");

            if (!Directory.Exists(rutaCarpeta))
            {
                Directory.CreateDirectory(rutaCarpeta);
            }

            DataTable dt = CrearDataTable();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = nombreArchivo;
            saveFileDialog.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Guardar Reporte";
            saveFileDialog.InitialDirectory = rutaCarpeta;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XLWorkbook libro = new XLWorkbook();
                    var hoja = libro.Worksheets.Add(dt, "ReporteComprobante");
                    var rango = hoja.Range(hoja.FirstCellUsed(), hoja.LastCellUsed());

                    hoja.Row(1).Style.Font.Bold = true;
                    hoja.ColumnsUsed().AdjustToContents();

                    libro.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Archivo exportado correctamente", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Process.Start(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar el archivo: " + ex.Message, "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private DataTable CrearDataTable()
        {
            DataTable dt = new DataTable();

            foreach (DataGridViewColumn columna in datagridview.Columns)
            {
                dt.Columns.Add(columna.HeaderText, typeof(string));
            }

            foreach (DataGridViewRow fila in datagridview.Rows)
            {
                if (fila.Visible)
                {
                    DataRow dr = dt.NewRow();

                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        dr[celda.ColumnIndex] = celda.Value;
                    }

                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }
        private void btngrafico_Click(object sender, EventArgs e)
        {
            if (datagridview.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para generar el gráfico", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dt = CrearDataTable();
            string periodo = string.Format("Del {0} al {1}", dtpfechainicio.Value.ToString("dd/MM/yyyy"), dtpfechafin.Value.ToString("dd/MM/yyyy"));
            using (var modal = new mdReporteComprobante(dt, periodo))
            {
                var resultado = modal.ShowDialog();
            }
        }
        private void btncerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
