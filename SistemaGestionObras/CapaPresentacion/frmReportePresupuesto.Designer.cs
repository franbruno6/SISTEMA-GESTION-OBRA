namespace CapaPresentacion
{
    partial class frmReportePresupuesto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.btnlimpiar = new FontAwesome.Sharp.IconButton();
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            this.datagridview = new System.Windows.Forms.DataGridView();
            this.lblsubtitulo = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.btncerrar = new FontAwesome.Sharp.IconButton();
            this.btngrafico = new FontAwesome.Sharp.IconButton();
            this.btnexportar = new FontAwesome.Sharp.IconButton();
            this.dtpfechafin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpfechainicio = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cbobusqueda = new System.Windows.Forms.ComboBox();
            this.lblbuscarpor = new System.Windows.Forms.Label();
            this.fecharegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombrecliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.correo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montototal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).BeginInit();
            this.contenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbusqueda.Location = new System.Drawing.Point(906, 126);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(142, 22);
            this.txtbusqueda.TabIndex = 13;
            this.txtbusqueda.TextChanged += new System.EventHandler(this.txtbusqueda_TextChanged);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnlimpiar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiar.IconColor = System.Drawing.Color.Black;
            this.btnlimpiar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnlimpiar.IconSize = 19;
            this.btnlimpiar.Location = new System.Drawing.Point(1054, 126);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(118, 24);
            this.btnlimpiar.TabIndex = 15;
            this.btnlimpiar.Text = "Limpiar filtro";
            this.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // btnbuscar
            // 
            this.btnbuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnbuscar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscar.IconColor = System.Drawing.Color.Black;
            this.btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnbuscar.IconSize = 19;
            this.btnbuscar.Location = new System.Drawing.Point(541, 126);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(105, 24);
            this.btnbuscar.TabIndex = 14;
            this.btnbuscar.Text = "Buscar";
            this.btnbuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // datagridview
            // 
            this.datagridview.AllowUserToAddRows = false;
            this.datagridview.AllowUserToDeleteRows = false;
            this.datagridview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridview.BackgroundColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.fecharegistro,
            this.numero,
            this.nombrecliente,
            this.correo,
            this.direccion,
            this.localidad,
            this.provincia,
            this.montototal,
            this.descripcion,
            this.usuario});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DarkKhaki;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridview.DefaultCellStyle = dataGridViewCellStyle2;
            this.datagridview.EnableHeadersVisualStyles = false;
            this.datagridview.GridColor = System.Drawing.SystemColors.Control;
            this.datagridview.Location = new System.Drawing.Point(16, 172);
            this.datagridview.MultiSelect = false;
            this.datagridview.Name = "datagridview";
            this.datagridview.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            this.datagridview.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.datagridview.RowTemplate.Height = 28;
            this.datagridview.RowTemplate.ReadOnly = true;
            this.datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridview.Size = new System.Drawing.Size(1541, 461);
            this.datagridview.TabIndex = 9;
            // 
            // lblsubtitulo
            // 
            this.lblsubtitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsubtitulo.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblsubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtitulo.Location = new System.Drawing.Point(16, 79);
            this.lblsubtitulo.Name = "lblsubtitulo";
            this.lblsubtitulo.Padding = new System.Windows.Forms.Padding(20, 10, 0, 0);
            this.lblsubtitulo.Size = new System.Drawing.Size(1541, 79);
            this.lblsubtitulo.TabIndex = 8;
            this.lblsubtitulo.Text = "Reportes de Presupuestos";
            // 
            // contenedor
            // 
            this.contenedor.Controls.Add(this.btncerrar);
            this.contenedor.Controls.Add(this.btngrafico);
            this.contenedor.Controls.Add(this.btnexportar);
            this.contenedor.Controls.Add(this.dtpfechafin);
            this.contenedor.Controls.Add(this.label2);
            this.contenedor.Controls.Add(this.dtpfechainicio);
            this.contenedor.Controls.Add(this.label1);
            this.contenedor.Controls.Add(this.btnlimpiar);
            this.contenedor.Controls.Add(this.txtbusqueda);
            this.contenedor.Controls.Add(this.cbobusqueda);
            this.contenedor.Controls.Add(this.lblbuscarpor);
            this.contenedor.Controls.Add(this.btnbuscar);
            this.contenedor.Controls.Add(this.datagridview);
            this.contenedor.Controls.Add(this.lblsubtitulo);
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 0);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1568, 646);
            this.contenedor.TabIndex = 4;
            // 
            // btncerrar
            // 
            this.btncerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btncerrar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btncerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncerrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncerrar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btncerrar.IconColor = System.Drawing.Color.Black;
            this.btncerrar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btncerrar.IconSize = 19;
            this.btncerrar.Location = new System.Drawing.Point(1463, 96);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(79, 24);
            this.btncerrar.TabIndex = 19;
            this.btncerrar.Text = "Cerrar";
            this.btncerrar.UseVisualStyleBackColor = false;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // btngrafico
            // 
            this.btngrafico.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btngrafico.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btngrafico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btngrafico.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngrafico.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            this.btngrafico.IconColor = System.Drawing.Color.Black;
            this.btngrafico.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btngrafico.IconSize = 19;
            this.btngrafico.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btngrafico.Location = new System.Drawing.Point(1377, 126);
            this.btngrafico.Name = "btngrafico";
            this.btngrafico.Size = new System.Drawing.Size(165, 25);
            this.btngrafico.TabIndex = 22;
            this.btngrafico.Text = "Generear Gráfico";
            this.btngrafico.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btngrafico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btngrafico.UseVisualStyleBackColor = false;
            this.btngrafico.Click += new System.EventHandler(this.btngrafico_Click);
            // 
            // btnexportar
            // 
            this.btnexportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnexportar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnexportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexportar.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            this.btnexportar.IconColor = System.Drawing.Color.SeaGreen;
            this.btnexportar.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnexportar.IconSize = 19;
            this.btnexportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnexportar.Location = new System.Drawing.Point(1222, 126);
            this.btnexportar.Name = "btnexportar";
            this.btnexportar.Size = new System.Drawing.Size(140, 25);
            this.btnexportar.TabIndex = 21;
            this.btnexportar.Text = "Exportar Excel";
            this.btnexportar.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.btnexportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnexportar.UseVisualStyleBackColor = false;
            this.btnexportar.Click += new System.EventHandler(this.btnexportar_Click);
            // 
            // dtpfechafin
            // 
            this.dtpfechafin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpfechafin.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfechafin.CustomFormat = "dd/MM/yyyy";
            this.dtpfechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechafin.Location = new System.Drawing.Point(409, 128);
            this.dtpfechafin.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.dtpfechafin.Name = "dtpfechafin";
            this.dtpfechafin.Size = new System.Drawing.Size(107, 20);
            this.dtpfechafin.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(324, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "Fecha Fin:";
            // 
            // dtpfechainicio
            // 
            this.dtpfechainicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpfechainicio.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfechainicio.CustomFormat = "dd/MM/yyyy";
            this.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechainicio.Location = new System.Drawing.Point(175, 128);
            this.dtpfechainicio.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.dtpfechainicio.Name = "dtpfechainicio";
            this.dtpfechainicio.Size = new System.Drawing.Size(115, 20);
            this.dtpfechainicio.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Fecha Inicio:";
            // 
            // cbobusqueda
            // 
            this.cbobusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbobusqueda.BackColor = System.Drawing.SystemColors.Window;
            this.cbobusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbobusqueda.FormattingEnabled = true;
            this.cbobusqueda.Location = new System.Drawing.Point(758, 126);
            this.cbobusqueda.Name = "cbobusqueda";
            this.cbobusqueda.Size = new System.Drawing.Size(142, 24);
            this.cbobusqueda.TabIndex = 12;
            this.cbobusqueda.SelectedIndexChanged += new System.EventHandler(this.txtbusqueda_TextChanged);
            // 
            // lblbuscarpor
            // 
            this.lblbuscarpor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbuscarpor.AutoSize = true;
            this.lblbuscarpor.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblbuscarpor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbuscarpor.Location = new System.Drawing.Point(705, 129);
            this.lblbuscarpor.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.lblbuscarpor.Name = "lblbuscarpor";
            this.lblbuscarpor.Size = new System.Drawing.Size(40, 16);
            this.lblbuscarpor.TabIndex = 11;
            this.lblbuscarpor.Text = "Filtrar";
            // 
            // fecharegistro
            // 
            this.fecharegistro.HeaderText = "Fecha";
            this.fecharegistro.Name = "fecharegistro";
            this.fecharegistro.ReadOnly = true;
            this.fecharegistro.Width = 120;
            // 
            // numero
            // 
            this.numero.HeaderText = "Numero";
            this.numero.Name = "numero";
            this.numero.ReadOnly = true;
            // 
            // nombrecliente
            // 
            this.nombrecliente.HeaderText = "Nombre Cliente";
            this.nombrecliente.Name = "nombrecliente";
            this.nombrecliente.ReadOnly = true;
            this.nombrecliente.Width = 200;
            // 
            // correo
            // 
            this.correo.HeaderText = "Correo";
            this.correo.Name = "correo";
            this.correo.ReadOnly = true;
            this.correo.Width = 180;
            // 
            // direccion
            // 
            this.direccion.HeaderText = "Direccion";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            this.direccion.Width = 180;
            // 
            // localidad
            // 
            this.localidad.HeaderText = "Localidad";
            this.localidad.Name = "localidad";
            this.localidad.ReadOnly = true;
            this.localidad.Width = 165;
            // 
            // provincia
            // 
            this.provincia.HeaderText = "Provincia";
            this.provincia.Name = "provincia";
            this.provincia.ReadOnly = true;
            this.provincia.Width = 165;
            // 
            // montototal
            // 
            this.montototal.HeaderText = "Monto Total";
            this.montototal.Name = "montototal";
            this.montototal.ReadOnly = true;
            this.montototal.Width = 135;
            // 
            // descripcion
            // 
            this.descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // usuario
            // 
            this.usuario.HeaderText = "Usuario";
            this.usuario.Name = "usuario";
            this.usuario.ReadOnly = true;
            // 
            // frmReportePresupuesto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1568, 646);
            this.Controls.Add(this.contenedor);
            this.Name = "frmReportePresupuesto";
            this.Text = "ReportePresupuesto";
            this.Load += new System.EventHandler(this.frmReportePresupuesto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).EndInit();
            this.contenedor.ResumeLayout(false);
            this.contenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtbusqueda;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private System.Windows.Forms.DataGridView datagridview;
        private System.Windows.Forms.Label lblsubtitulo;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.DateTimePicker dtpfechainicio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpfechafin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbobusqueda;
        private System.Windows.Forms.Label lblbuscarpor;
        private FontAwesome.Sharp.IconButton btnexportar;
        private FontAwesome.Sharp.IconButton btngrafico;
        private FontAwesome.Sharp.IconButton btncerrar;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecharegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombrecliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn correo;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn localidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn provincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn montototal;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuario;
    }
}