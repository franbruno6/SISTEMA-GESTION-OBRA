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
using System.Windows.Forms.DataVisualization.Charting;

namespace CapaPresentacion.Modals
{
    public partial class mdReportePresupuesto : Form
    {
        private DataTable _dataTable;
        private string _periodo;
        public mdReportePresupuesto(DataTable dataTable, string periodo)
        {
            _dataTable = dataTable;
            _periodo = periodo;
            InitializeComponent();
        }
        private void mdReportePresupuesto_Load(object sender, EventArgs e)
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
            chartreporte.Titles.Add("Reporte de Presupuesto");
            chartreporte.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chartreporte.ChartAreas[0].AxisX.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chartreporte.ChartAreas[0].AxisY.TitleFont = new Font("Arial", 12, FontStyle.Bold);
            chartreporte.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.LightGray;
            chartreporte.ChartAreas[0].AxisY.Title = "Cantidad";
            chartreporte.ChartAreas[0].AxisX.Title = cbocolumna.Text;
            chartreporte.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Arial", 10);
            chartreporte.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 10);
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
    }
}
