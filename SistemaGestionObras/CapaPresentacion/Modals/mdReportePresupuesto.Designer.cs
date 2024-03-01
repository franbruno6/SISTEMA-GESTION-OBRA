namespace CapaPresentacion.Modals
{
    partial class mdReportePresupuesto
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.chartreporte = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.cbocolumna = new System.Windows.Forms.ComboBox();
            this.lblperiodo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartreporte)).BeginInit();
            this.SuspendLayout();
            // 
            // chartreporte
            // 
            this.chartreporte.BackColor = System.Drawing.Color.PaleGoldenrod;
            chartArea4.Name = "ChartArea1";
            this.chartreporte.ChartAreas.Add(chartArea4);
            this.chartreporte.Location = new System.Drawing.Point(30, 58);
            this.chartreporte.Name = "chartreporte";
            this.chartreporte.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Pastel;
            this.chartreporte.Size = new System.Drawing.Size(816, 475);
            this.chartreporte.TabIndex = 0;
            this.chartreporte.Text = "chart1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Khaki;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(247, 18);
            this.label2.TabIndex = 20;
            this.label2.Text = "Seleccione la variable para el gráfico";
            // 
            // cbocolumna
            // 
            this.cbocolumna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbocolumna.BackColor = System.Drawing.SystemColors.Window;
            this.cbocolumna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbocolumna.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbocolumna.FormattingEnabled = true;
            this.cbocolumna.Location = new System.Drawing.Point(288, 21);
            this.cbocolumna.Name = "cbocolumna";
            this.cbocolumna.Size = new System.Drawing.Size(178, 24);
            this.cbocolumna.TabIndex = 21;
            this.cbocolumna.SelectedIndexChanged += new System.EventHandler(this.cbocolumna_SelectedIndexChanged);
            // 
            // lblperiodo
            // 
            this.lblperiodo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblperiodo.AutoSize = true;
            this.lblperiodo.BackColor = System.Drawing.Color.Khaki;
            this.lblperiodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblperiodo.Location = new System.Drawing.Point(599, 22);
            this.lblperiodo.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.lblperiodo.Name = "lblperiodo";
            this.lblperiodo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblperiodo.Size = new System.Drawing.Size(247, 18);
            this.lblperiodo.TabIndex = 22;
            this.lblperiodo.Text = "Seleccione la variable para el gráfico";
            this.lblperiodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mdReportePresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(882, 545);
            this.Controls.Add(this.lblperiodo);
            this.Controls.Add(this.cbocolumna);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chartreporte);
            this.Name = "mdReportePresupuesto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mdReportePresupuesto";
            this.Load += new System.EventHandler(this.mdReportePresupuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartreporte)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartreporte;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbocolumna;
        private System.Windows.Forms.Label lblperiodo;
    }
}