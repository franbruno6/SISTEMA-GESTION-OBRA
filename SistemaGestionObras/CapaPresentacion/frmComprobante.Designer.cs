namespace CapaPresentacion
{
    partial class frmComprobante
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
            this.menucancelarcomprobante = new System.Windows.Forms.ToolStripMenuItem();
            this.menuagregarcomprobante = new System.Windows.Forms.ToolStripMenuItem();
            this.menuvercomprobante = new System.Windows.Forms.ToolStripMenuItem();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menumodificarcomprobante = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtidpresupuesto = new System.Windows.Forms.TextBox();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnactualizar = new FontAwesome.Sharp.IconButton();
            this.btnlimpiar = new FontAwesome.Sharp.IconButton();
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            this.contenedor = new System.Windows.Forms.Panel();
            this.btncerrar = new FontAwesome.Sharp.IconButton();
            this.txtbusqueda = new System.Windows.Forms.TextBox();
            this.cbobusqueda = new System.Windows.Forms.ComboBox();
            this.lblbuscarpor = new System.Windows.Forms.Label();
            this.datagridview = new System.Windows.Forms.DataGridView();
            this.lblsubtitulo = new System.Windows.Forms.Label();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.idComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPresupuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idUsuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroComprobante = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.localidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provincia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contenedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // menucancelarcomprobante
            // 
            this.menucancelarcomprobante.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menucancelarcomprobante.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.menucancelarcomprobante.Name = "menucancelarcomprobante";
            this.menucancelarcomprobante.Padding = new System.Windows.Forms.Padding(4);
            this.menucancelarcomprobante.Size = new System.Drawing.Size(228, 33);
            this.menucancelarcomprobante.Text = "Cancelar Comprobante";
            this.menucancelarcomprobante.Click += new System.EventHandler(this.menucancelarcomprobante_Click);
            // 
            // menuagregarcomprobante
            // 
            this.menuagregarcomprobante.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuagregarcomprobante.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.menuagregarcomprobante.Name = "menuagregarcomprobante";
            this.menuagregarcomprobante.Padding = new System.Windows.Forms.Padding(4);
            this.menuagregarcomprobante.Size = new System.Drawing.Size(228, 33);
            this.menuagregarcomprobante.Text = "Agregar";
            this.menuagregarcomprobante.Click += new System.EventHandler(this.menuagregarcomprobante_Click);
            // 
            // menuvercomprobante
            // 
            this.menuvercomprobante.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.menuvercomprobante.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuvercomprobante.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.menuvercomprobante.Name = "menuvercomprobante";
            this.menuvercomprobante.Padding = new System.Windows.Forms.Padding(4);
            this.menuvercomprobante.Size = new System.Drawing.Size(228, 33);
            this.menuvercomprobante.Text = "Ver Detalle";
            this.menuvercomprobante.Click += new System.EventHandler(this.menuvercomprobante_Click);
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.menu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuvercomprobante,
            this.menuagregarcomprobante,
            this.menumodificarcomprobante,
            this.menucancelarcomprobante});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menu.Location = new System.Drawing.Point(0, 430);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(6, 10, 0, 40);
            this.menu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menu.Size = new System.Drawing.Size(235, 216);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menumodificarcomprobante
            // 
            this.menumodificarcomprobante.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menumodificarcomprobante.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.menumodificarcomprobante.Name = "menumodificarcomprobante";
            this.menumodificarcomprobante.Padding = new System.Windows.Forms.Padding(4);
            this.menumodificarcomprobante.Size = new System.Drawing.Size(228, 33);
            this.menumodificarcomprobante.Text = "Modificar Estado";
            this.menumodificarcomprobante.Click += new System.EventHandler(this.menumodificarcomprobante_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel1.Controls.Add(this.txtidpresupuesto);
            this.panel1.Controls.Add(this.txtid);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.menu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 646);
            this.panel1.TabIndex = 5;
            // 
            // txtidpresupuesto
            // 
            this.txtidpresupuesto.Location = new System.Drawing.Point(75, 278);
            this.txtidpresupuesto.Name = "txtidpresupuesto";
            this.txtidpresupuesto.Size = new System.Drawing.Size(100, 20);
            this.txtidpresupuesto.TabIndex = 3;
            this.txtidpresupuesto.Visible = false;
            // 
            // txtid
            // 
            this.txtid.Location = new System.Drawing.Point(75, 216);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(100, 20);
            this.txtid.TabIndex = 2;
            this.txtid.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 56);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comprobantes de Obra";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnactualizar
            // 
            this.btnactualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnactualizar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnactualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnactualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnactualizar.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
            this.btnactualizar.IconColor = System.Drawing.Color.Black;
            this.btnactualizar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnactualizar.IconSize = 19;
            this.btnactualizar.Location = new System.Drawing.Point(1289, 94);
            this.btnactualizar.Name = "btnactualizar";
            this.btnactualizar.Size = new System.Drawing.Size(157, 24);
            this.btnactualizar.TabIndex = 16;
            this.btnactualizar.Text = "Actualizar Lista";
            this.btnactualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnactualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnactualizar.UseVisualStyleBackColor = false;
            this.btnactualizar.Click += new System.EventHandler(this.btnactualizar_Click);
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
            this.btnlimpiar.Location = new System.Drawing.Point(1229, 94);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(54, 24);
            this.btnlimpiar.TabIndex = 15;
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
            this.btnbuscar.Location = new System.Drawing.Point(1169, 94);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(54, 24);
            this.btnbuscar.TabIndex = 14;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // contenedor
            // 
            this.contenedor.Controls.Add(this.btncerrar);
            this.contenedor.Controls.Add(this.btnactualizar);
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
            this.contenedor.TabIndex = 6;
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
            this.btncerrar.Location = new System.Drawing.Point(1464, 94);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(79, 24);
            this.btncerrar.TabIndex = 18;
            this.btncerrar.Text = "Cerrar";
            this.btncerrar.UseVisualStyleBackColor = false;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbusqueda.Location = new System.Drawing.Point(1012, 94);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(142, 22);
            this.txtbusqueda.TabIndex = 13;
            this.txtbusqueda.TextChanged += new System.EventHandler(this.txtbusqueda_TextChanged);
            // 
            // cbobusqueda
            // 
            this.cbobusqueda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbobusqueda.BackColor = System.Drawing.SystemColors.Window;
            this.cbobusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbobusqueda.FormattingEnabled = true;
            this.cbobusqueda.Location = new System.Drawing.Point(833, 94);
            this.cbobusqueda.Name = "cbobusqueda";
            this.cbobusqueda.Size = new System.Drawing.Size(173, 24);
            this.cbobusqueda.TabIndex = 12;
            this.cbobusqueda.SelectedIndexChanged += new System.EventHandler(this.cbobusqueda_SelectedIndexChanged);
            // 
            // lblbuscarpor
            // 
            this.lblbuscarpor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblbuscarpor.AutoSize = true;
            this.lblbuscarpor.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblbuscarpor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbuscarpor.Location = new System.Drawing.Point(756, 97);
            this.lblbuscarpor.Name = "lblbuscarpor";
            this.lblbuscarpor.Size = new System.Drawing.Size(72, 16);
            this.lblbuscarpor.TabIndex = 11;
            this.lblbuscarpor.Text = "Buscar por";
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
            this.btnseleccionar,
            this.idComprobante,
            this.idPresupuesto,
            this.idUsuario,
            this.numeroComprobante,
            this.nombreCliente,
            this.telefono,
            this.direccion,
            this.localidad,
            this.provincia,
            this.montoTotal,
            this.estado,
            this.fechaRegistro});
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
            this.datagridview.Location = new System.Drawing.Point(250, 133);
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
            this.datagridview.Size = new System.Drawing.Size(1306, 500);
            this.datagridview.TabIndex = 9;
            this.datagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_CellClick);
            this.datagridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_CellDoubleClick);
            this.datagridview.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.datagridview_CellPainting);
            // 
            // lblsubtitulo
            // 
            this.lblsubtitulo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblsubtitulo.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblsubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtitulo.Location = new System.Drawing.Point(250, 79);
            this.lblsubtitulo.Name = "lblsubtitulo";
            this.lblsubtitulo.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblsubtitulo.Size = new System.Drawing.Size(1306, 47);
            this.lblsubtitulo.TabIndex = 8;
            this.lblsubtitulo.Text = "Lista de Comprobantes de Obra";
            this.lblsubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.FillWeight = 35.62946F;
            this.btnseleccionar.HeaderText = "";
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.Width = 50;
            // 
            // idComprobante
            // 
            this.idComprobante.HeaderText = "IdComprobante";
            this.idComprobante.Name = "idComprobante";
            this.idComprobante.ReadOnly = true;
            this.idComprobante.Visible = false;
            this.idComprobante.Width = 120;
            // 
            // idPresupuesto
            // 
            this.idPresupuesto.HeaderText = "IdPresupuesto";
            this.idPresupuesto.Name = "idPresupuesto";
            this.idPresupuesto.ReadOnly = true;
            this.idPresupuesto.Visible = false;
            // 
            // idUsuario
            // 
            this.idUsuario.HeaderText = "IdUsuario";
            this.idUsuario.Name = "idUsuario";
            this.idUsuario.ReadOnly = true;
            this.idUsuario.Visible = false;
            // 
            // numeroComprobante
            // 
            this.numeroComprobante.FillWeight = 68.18409F;
            this.numeroComprobante.HeaderText = "Numero";
            this.numeroComprobante.Name = "numeroComprobante";
            this.numeroComprobante.ReadOnly = true;
            this.numeroComprobante.Width = 96;
            // 
            // nombreCliente
            // 
            this.nombreCliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nombreCliente.FillWeight = 155.3674F;
            this.nombreCliente.HeaderText = "Nombre Cliente";
            this.nombreCliente.Name = "nombreCliente";
            this.nombreCliente.ReadOnly = true;
            // 
            // telefono
            // 
            this.telefono.FillWeight = 94.51579F;
            this.telefono.HeaderText = "Telefono";
            this.telefono.Name = "telefono";
            this.telefono.ReadOnly = true;
            this.telefono.Width = 132;
            // 
            // direccion
            // 
            this.direccion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.direccion.FillWeight = 145.0864F;
            this.direccion.HeaderText = "Direccion";
            this.direccion.Name = "direccion";
            this.direccion.ReadOnly = true;
            // 
            // localidad
            // 
            this.localidad.FillWeight = 95.72913F;
            this.localidad.HeaderText = "Localidad";
            this.localidad.Name = "localidad";
            this.localidad.ReadOnly = true;
            this.localidad.Width = 134;
            // 
            // provincia
            // 
            this.provincia.HeaderText = "Provincia";
            this.provincia.Name = "provincia";
            this.provincia.ReadOnly = true;
            this.provincia.Width = 140;
            // 
            // montoTotal
            // 
            this.montoTotal.FillWeight = 95.3689F;
            this.montoTotal.HeaderText = "Monto Total";
            this.montoTotal.Name = "montoTotal";
            this.montoTotal.ReadOnly = true;
            this.montoTotal.Width = 134;
            // 
            // estado
            // 
            this.estado.FillWeight = 95.04862F;
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Width = 134;
            // 
            // fechaRegistro
            // 
            this.fechaRegistro.FillWeight = 115.0703F;
            this.fechaRegistro.HeaderText = "Fecha Registro";
            this.fechaRegistro.Name = "fechaRegistro";
            this.fechaRegistro.ReadOnly = true;
            this.fechaRegistro.Width = 161;
            // 
            // frmComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1568, 646);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.contenedor);
            this.Name = "frmComprobante";
            this.Text = "frmComprobante";
            this.Load += new System.EventHandler(this.frmComprobante_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contenedor.ResumeLayout(false);
            this.contenedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem menucancelarcomprobante;
        private System.Windows.Forms.ToolStripMenuItem menuagregarcomprobante;
        private System.Windows.Forms.ToolStripMenuItem menuvercomprobante;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menumodificarcomprobante;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtidpresupuesto;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnactualizar;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.TextBox txtbusqueda;
        private System.Windows.Forms.ComboBox cbobusqueda;
        private System.Windows.Forms.Label lblbuscarpor;
        private System.Windows.Forms.DataGridView datagridview;
        private System.Windows.Forms.Label lblsubtitulo;
        private FontAwesome.Sharp.IconButton btncerrar;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPresupuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroComprobante;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn telefono;
        private System.Windows.Forms.DataGridViewTextBoxColumn direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn localidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn provincia;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaRegistro;
    }
}