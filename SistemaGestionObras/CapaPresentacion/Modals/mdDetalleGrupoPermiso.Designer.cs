namespace CapaPresentacion.Modals
{
    partial class mdDetalleGrupoPermiso
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblsubtitulo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnvolver = new FontAwesome.Sharp.IconButton();
            this.datagridview = new System.Windows.Forms.DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IdComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoPermiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.txtnombregrupo = new System.Windows.Forms.TextBox();
            this.lblnombre = new System.Windows.Forms.Label();
            this.lblestado = new System.Windows.Forms.Label();
            this.cboestado = new System.Windows.Forms.ComboBox();
            this.btnagregar = new FontAwesome.Sharp.IconButton();
            this.btneliminar = new FontAwesome.Sharp.IconButton();
            this.txtid = new System.Windows.Forms.TextBox();
            this.btnaccion = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // lblsubtitulo
            // 
            this.lblsubtitulo.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblsubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtitulo.Location = new System.Drawing.Point(12, 40);
            this.lblsubtitulo.Name = "lblsubtitulo";
            this.lblsubtitulo.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblsubtitulo.Size = new System.Drawing.Size(1228, 47);
            this.lblsubtitulo.TabIndex = 56;
            this.lblsubtitulo.Text = "Detalle del Grupo";
            this.lblsubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 162);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
            this.label3.Size = new System.Drawing.Size(1228, 415);
            this.label3.TabIndex = 57;
            this.label3.Text = "Lista de Permisos";
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
            this.btnvolver.Location = new System.Drawing.Point(1068, 54);
            this.btnvolver.Name = "btnvolver";
            this.btnvolver.Size = new System.Drawing.Size(115, 25);
            this.btnvolver.TabIndex = 62;
            this.btnvolver.Text = "Volver";
            this.btnvolver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnvolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnvolver.UseVisualStyleBackColor = false;
            this.btnvolver.Click += new System.EventHandler(this.btnvolver_Click);
            // 
            // datagridview
            // 
            this.datagridview.AllowUserToAddRows = false;
            this.datagridview.BackgroundColor = System.Drawing.Color.PaleGoldenrod;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridview.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.btnseleccionar,
            this.IdComponente,
            this.nombre,
            this.tipoPermiso,
            this.estado,
            this.estadoValor});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.datagridview.DefaultCellStyle = dataGridViewCellStyle14;
            this.datagridview.EnableHeadersVisualStyles = false;
            this.datagridview.GridColor = System.Drawing.SystemColors.Control;
            this.datagridview.Location = new System.Drawing.Point(32, 208);
            this.datagridview.MultiSelect = false;
            this.datagridview.Name = "datagridview";
            this.datagridview.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.datagridview.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dataGridViewCellStyle16.Padding = new System.Windows.Forms.Padding(3);
            this.datagridview.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.datagridview.RowTemplate.Height = 28;
            this.datagridview.RowTemplate.ReadOnly = true;
            this.datagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.datagridview.Size = new System.Drawing.Size(884, 336);
            this.datagridview.TabIndex = 63;
            this.datagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_CellClick);
            this.datagridview.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.datagridview_CellPainting);
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.HeaderText = "";
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.Width = 50;
            // 
            // IdComponente
            // 
            this.IdComponente.HeaderText = "IdComponente";
            this.IdComponente.Name = "IdComponente";
            this.IdComponente.ReadOnly = true;
            this.IdComponente.Visible = false;
            // 
            // nombre
            // 
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 250;
            // 
            // tipoPermiso
            // 
            this.tipoPermiso.HeaderText = "Tipo de Permiso";
            this.tipoPermiso.Name = "tipoPermiso";
            this.tipoPermiso.ReadOnly = true;
            this.tipoPermiso.Width = 150;
            // 
            // estado
            // 
            this.estado.HeaderText = "Estado";
            this.estado.Name = "estado";
            this.estado.ReadOnly = true;
            this.estado.Visible = false;
            this.estado.Width = 120;
            // 
            // estadoValor
            // 
            this.estadoValor.HeaderText = "Estado";
            this.estadoValor.Name = "estadoValor";
            this.estadoValor.ReadOnly = true;
            this.estadoValor.Width = 150;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 96);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
            this.label1.Size = new System.Drawing.Size(1228, 52);
            this.label1.TabIndex = 64;
            this.label1.Text = "Información del Grupo";
            // 
            // txtnombregrupo
            // 
            this.txtnombregrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombregrupo.Location = new System.Drawing.Point(369, 109);
            this.txtnombregrupo.Name = "txtnombregrupo";
            this.txtnombregrupo.Size = new System.Drawing.Size(171, 22);
            this.txtnombregrupo.TabIndex = 65;
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.Location = new System.Drawing.Point(248, 112);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(115, 16);
            this.lblnombre.TabIndex = 66;
            this.lblnombre.Text = "Nombre de Grupo";
            // 
            // lblestado
            // 
            this.lblestado.AutoSize = true;
            this.lblestado.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblestado.Location = new System.Drawing.Point(649, 112);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(50, 16);
            this.lblestado.TabIndex = 68;
            this.lblestado.Text = "Estado";
            // 
            // cboestado
            // 
            this.cboestado.BackColor = System.Drawing.SystemColors.Window;
            this.cboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboestado.FormattingEnabled = true;
            this.cboestado.Location = new System.Drawing.Point(705, 109);
            this.cboestado.Name = "cboestado";
            this.cboestado.Size = new System.Drawing.Size(173, 24);
            this.cboestado.TabIndex = 69;
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
            this.btnagregar.Location = new System.Drawing.Point(940, 208);
            this.btnagregar.Name = "btnagregar";
            this.btnagregar.Size = new System.Drawing.Size(152, 45);
            this.btnagregar.TabIndex = 70;
            this.btnagregar.Text = "Agregar Permiso";
            this.btnagregar.UseVisualStyleBackColor = false;
            this.btnagregar.Click += new System.EventHandler(this.btnagregar_Click);
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
            this.btneliminar.Location = new System.Drawing.Point(940, 268);
            this.btneliminar.Name = "btneliminar";
            this.btneliminar.Size = new System.Drawing.Size(152, 45);
            this.btneliminar.TabIndex = 71;
            this.btneliminar.Text = "Eliminar Permiso";
            this.btneliminar.UseVisualStyleBackColor = false;
            this.btneliminar.Click += new System.EventHandler(this.btneliminar_Click);
            // 
            // txtid
            // 
            this.txtid.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtid.Location = new System.Drawing.Point(390, 171);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(83, 22);
            this.txtid.TabIndex = 72;
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
            this.btnaccion.Location = new System.Drawing.Point(940, 500);
            this.btnaccion.Name = "btnaccion";
            this.btnaccion.Size = new System.Drawing.Size(152, 45);
            this.btnaccion.TabIndex = 73;
            this.btnaccion.Text = "Accion";
            this.btnaccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnaccion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnaccion.UseVisualStyleBackColor = false;
            this.btnaccion.Click += new System.EventHandler(this.btnaccion_Click);
            // 
            // mdDetalleGrupoPermiso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(1317, 586);
            this.Controls.Add(this.btnaccion);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.btneliminar);
            this.Controls.Add(this.btnagregar);
            this.Controls.Add(this.cboestado);
            this.Controls.Add(this.lblestado);
            this.Controls.Add(this.txtnombregrupo);
            this.Controls.Add(this.lblnombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.datagridview);
            this.Controls.Add(this.btnvolver);
            this.Controls.Add(this.lblsubtitulo);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "mdDetalleGrupoPermiso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mdDetalleGrupoPermiso";
            this.Load += new System.EventHandler(this.mdDetalleGrupoPermiso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private FontAwesome.Sharp.IconButton btnvolver;
        private System.Windows.Forms.Label lblsubtitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView datagridview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtnombregrupo;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.ComboBox cboestado;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoPermiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoValor;
        private FontAwesome.Sharp.IconButton btnagregar;
        private FontAwesome.Sharp.IconButton btneliminar;
        private System.Windows.Forms.TextBox txtid;
        private FontAwesome.Sharp.IconButton btnaccion;
    }
}