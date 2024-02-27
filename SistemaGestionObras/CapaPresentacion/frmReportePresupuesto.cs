using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmReportePresupuesto : Form
    {
        private CC_Reporte oCC_Reporte = new CC_Reporte();
        public frmReportePresupuesto()
        {
            InitializeComponent();
        }
        private void btnbuscar_Click(object sender, EventArgs e)
        {
            List<ReportePresupuesto> listaReportePresupuesto = oCC_Reporte.ListarReportePresupuesto(dtpfechainicio.Value.ToString("dd-MM-yyyy"), dtpfechafin.Value.ToString("dd-MM-yyyy"));

            foreach (ReportePresupuesto reportePresupuesto in listaReportePresupuesto)
            {
                datagridview.Rows.Add(
                    reportePresupuesto.FechaRegistro.ToString("dd-MM-yyyy"), 
                    reportePresupuesto.NumeroPresupuesto, 
                    reportePresupuesto.NombreCliente, 
                    reportePresupuesto.Correo,
                    reportePresupuesto.Direccion, 
                    reportePresupuesto.Localidad, 
                    reportePresupuesto.MontoTotal, 
                    reportePresupuesto.Descripcion
                    );
            }
        }
        private void frmReportePresupuesto_Load(object sender, EventArgs e)
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

            DataTable dt = CrearDataTable();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = string.Format("ReportePresupuesto_{0}.xlsx", DateTime.Now.ToString("dd-MM-yyyy"));
            saveFileDialog.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Guardar Reporte";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XLWorkbook libro = new XLWorkbook();
                    var hoja = libro.Worksheets.Add(dt, "ReportePresupuesto");

                    hoja.Row(1).Style.Font.Bold = true;
                    hoja.ColumnsUsed().AdjustToContents();

                    libro.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Archivo exportado correctamente", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dt.Columns.Add(columna.HeaderText,typeof(string));
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
    }
}
