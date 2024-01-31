namespace CapaPresentacion.Modals
{
    partial class mdDetallePermisoUsuario
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
            this.txtid = new System.Windows.Forms.TextBox();
            this.cboestado = new System.Windows.Forms.ComboBox();
            this.lblestado = new System.Windows.Forms.Label();
            this.txtnombrecompleto = new System.Windows.Forms.TextBox();
            this.lblnombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.estadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoPermiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.datagridview = new System.Windows.Forms.DataGridView();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.lblsubtitulo = new System.Windows.Forms.Label();
            this.btnaccion = new FontAwesome.Sharp.IconButton();
            this.btneliminar = new FontAwesome.Sharp.IconButton();
            this.btnagregar = new FontAwesome.Sharp.IconButton();
            this.btnvolver = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // txtid
            // 
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(390, 172);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(83, 22);
            this.txtid.TabIndex = 85;
            this.txtid.Visible = false;
            // 
            // cboestado
            // 
            this.cboestado.BackColor = System.Drawing.SystemColors.Window;
            this.cboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboestado.FormattingEnabled = true;
            this.cboestado.Location = new System.Drawing.Point(705, 110);
            this.cboestado.Name = "cboestado";
            this.cboestado.Size = new System.Drawing.Size(173, 24);
            this.cboestado.TabIndex = 82;
            // 
            // lblestado
            // 
            this.lblestado.AutoSize = true;
            this.lblestado.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblestado.Location = new System.Drawing.Point(649, 113);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(50, 16);
            this.lblestado.TabIndex = 81;
            this.lblestado.Text = "Estado";
            // 
            // txtnombrecompleto
            // 
            this.txtnombrecompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombrecompleto.Location = new System.Drawing.Point(371, 110);
            this.txtnombrecompleto.Name = "txtnombrecompleto";
            this.txtnombrecompleto.Size = new System.Drawing.Size(185, 22);
            this.txtnombrecompleto.TabIndex = 79;
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.Location = new System.Drawing.Point(248, 113);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(117, 16);
            this.lblnombre.TabIndex = 80;
            this.lblnombre.Text = "Nombre Completo";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 97);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
            this.label1.Size = new System.Drawing.Size(1105, 52);
            this.label1.TabIndex = 78;
            this.label1.Text = "Información del Usuario";
            // 
            // estadoValor
            // 
            this.estadoValor.HeaderText = "Estado";
            this.estadoValor.Name = "estadoValor";
            this.estadoValor.ReadOnly = true;
            this.estadoValor.Width = 150;
            // 
            // tipoPermiso
            // 
            this.tipoPermiso.HeaderText = "Tipo de Permiso";
            this.tipoPermiso.Name = "tipoPermiso";
            this.tipoPermiso.ReadOnly = true;
            this.tipoPermiso.Width = 150;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 250;
            // 
            // IdComponente
            // 
            this.IdComponente.HeaderText = "IdComponente";
            this.IdComponente.Name = "IdComponente";
            this.IdComponente.ReadOnly = true;
            this.IdComponente.Visible = false;
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.HeaderText = "";
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.Width = 50;
            // 
            // datagridview
            // 
            this.datagridview.AllowUserToAddRows = false;
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
            this.IdComponente,
            this.nombre,
            this.tipoPermiso,
            this.estado,
            this.estadoValor});
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
            this.datagridview.Location = new System.Drawing.Point(32, 209);
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
            this.datagridview.Size = new System.Drawing.Size(884, 336);
            this.datagridview.TabIndex = 77;
            this.datagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_CellClick);
            this.datagridview.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.datagridview_CellPainting);
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Visible = false;
            this.estado.Width = 120;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 163);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
            this.label3.Size = new System.Drawing.Size(1105, 415);
            this.label3.TabIndex = 75;
            this.label3.Text = "Lista de Permisos";
            // 
            // lblsubtitulo
            // 
            this.lblsubtitulo.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblsubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtitulo.Location = new System.Drawing.Point(12, 41);
            this.lblsubtitulo.Name = "lblsubtitulo";
            this.lblsubtitulo.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblsubtitulo.Size = new System.Drawing.Size(1106, 47);
            this.lblsubtitulo.TabIndex = 74;
            this.lblsubtitulo.Text = "Permisos del Usuario";
            this.lblsubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnaccion
            // 
            this.btnaccion.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaccion.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnaccion.IconColor = System.Drawing.Color.Black;
            this.btnaccion.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnaccion.IconSize = 19;
            this.btnaccion.Location = new System.Drawing.Point(940, 501);
            this.btnaccion.Name = "btnaccion";
            this.btnaccion.Size = new System.Drawing.Size(152, 45);
            this.btnaccion.TabIndex = 86;
            this.btnaccion.Text = "Accion";
            this.btnaccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnaccion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnaccion.UseVisualStyleBackColor = false;
            this.btnaccion.Click += new System.EventHandler(this.btnaccion_Click);
            // 
            // btneliminar
            // 
            this.btneliminar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btneliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btneliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btneliminar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btneliminar.IconColor = System.Drawing.Color.Black;
            this.btneliminar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btneliminar.IconSize = 18;
            this.btneliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btneliminar.Location = new System.Drawing.Point(940, 269);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(152, 45);
            this.btneliminar.TabIndex = 84;
            this.btneliminar.Text = "Eliminar Permiso";
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // btnagregar
            // 
            this.btnagregar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnagregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnagregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnagregar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnagregar.IconColor = System.Drawing.Color.Black;
            this.btnagregar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnagregar.IconSize = 18;
            this.btnagregar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnagregar.Location = new System.Drawing.Point(940, 209);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(152, 45);
            this.btnagregar.TabIndex = 83;
            this.btnagregar.Text = "Agregar Permiso";
            this.btnagregar.UseVisualStyleBackColor = false;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
            // 
            // btnvolver
            // 
            this.btnvolver.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnvolver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnvolver.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.btnvolver.IconColor = System.Drawing.Color.Black;
            this.btnvolver.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnvolver.IconSize = 18;
            this.btnvolver.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnvolver.Location = new System.Drawing.Point(940, 55);
            this.btnvolver.Name = "btnvolver";
            this.btnvolver.Size = new System.Drawing.Size(152, 25);
            this.btnvolver.TabIndex = 76;
            this.btnvolver.Text = "Volver";
            this.btnvolver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnvolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnvolver.UseVisualStyleBackColor = false;
            this.btnvolver.Click += new System.EventHandler(this.btnvolver_Click);
            // 
            // mdDetallePermisoUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(1149, 586);
            this.Controls.Add(this.btnaccion);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.cboestado);
            this.Controls.Add(this.lblestado);
            this.Controls.Add(this.txtnombrecompleto);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datagridview);
            this.Controls.Add(this.btnvolver);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblsubtitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "mdDetallePermisoUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mdDetallePermisoUsuario";
            this.Load += new System.EventHandler(this.mdDetallePermisoUsuario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnaccion;
        private System.Windows.Forms.TextBox txtid;
        private FontAwesome.Sharp.IconButton btneliminar;
        private FontAwesome.Sharp.IconButton btnagregar;
        private System.Windows.Forms.ComboBox cboestado;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.TextBox txtnombrecompleto;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoPermiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComponente;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridView datagridview;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private FontAwesome.Sharp.IconButton btnvolver;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblsubtitulo;
    }
}