namespace CapaPresentacion
{
    partial class frmAuditoria
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
            this.btncerrar = new FontAwesome.Sharp.IconButton();
            this.btnexportar = new FontAwesome.Sharp.IconButton();
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            this.datagridview = new System.Windows.Forms.DataGridView();
            this.contenedor = new System.Windows.Forms.Panel();
            this.txtdescripcion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtprovincia = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtlocalidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtnombrecliente = new System.Windows.Forms.TextBox();
            this.lblnombre = new System.Windows.Forms.Label();
            this.lblsubtitulo = new System.Windows.Forms.Label();
            this.fecharegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoactual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoprevio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adelanto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montototal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreusuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).BeginInit();
            this.contenedor.SuspendLayout();
            this.SuspendLayout();
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
            this.btncerrar.Location = new System.Drawing.Point(1462, 90);
            this.btncerrar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.btncerrar.Name = "btncerrar";
            this.btncerrar.Size = new System.Drawing.Size(79, 30);
            this.btncerrar.TabIndex = 19;
            this.btncerrar.Text = "Cerrar";
            this.btncerrar.UseVisualStyleBackColor = false;
            this.btncerrar.Click += new System.EventHandler(this.btncerrar_Click);
            // 
            // btnexportar
            // 
            this.btnexportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnexportar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnexportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexportar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexportar.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            this.btnexportar.IconColor = System.Drawing.Color.Firebrick;
            this.btnexportar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnexportar.IconSize = 19;
            this.btnexportar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnexportar.Location = new System.Drawing.Point(1401, 166);
            this.btnexportar.Name = "btnexportar";
            this.btnexportar.Size = new System.Drawing.Size(140, 30);
            this.btnexportar.TabIndex = 21;
            this.btnexportar.Text = "Exportar PDF";
            this.btnexportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnexportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnexportar.UseVisualStyleBackColor = false;
            this.btnexportar.Click += new System.EventHandler(this.btnexportar_Click);
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
            this.btnbuscar.Location = new System.Drawing.Point(458, 90);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(178, 30);
            this.btnbuscar.TabIndex = 14;
            this.btnbuscar.Text = "Buscar Comprobante";
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
            this.estadoactual,
            this.estadoprevio,
            this.adelanto,
            this.saldo,
            this.montototal,
            this.nombreusuario});
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
            this.datagridview.Location = new System.Drawing.Point(16, 224);
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
            this.datagridview.Size = new System.Drawing.Size(1541, 409);
            this.datagridview.TabIndex = 9;
            // 
            // contenedor
            // 
            this.contenedor.Controls.Add(this.txtdescripcion);
            this.contenedor.Controls.Add(this.label8);
            this.contenedor.Controls.Add(this.txtprovincia);
            this.contenedor.Controls.Add(this.label11);
            this.contenedor.Controls.Add(this.txtcorreo);
            this.contenedor.Controls.Add(this.label7);
            this.contenedor.Controls.Add(this.txttelefono);
            this.contenedor.Controls.Add(this.label6);
            this.contenedor.Controls.Add(this.txtlocalidad);
            this.contenedor.Controls.Add(this.label5);
            this.contenedor.Controls.Add(this.txtdireccion);
            this.contenedor.Controls.Add(this.label2);
            this.contenedor.Controls.Add(this.txtnombrecliente);
            this.contenedor.Controls.Add(this.lblnombre);
            this.contenedor.Controls.Add(this.btncerrar);
            this.contenedor.Controls.Add(this.btnexportar);
            this.contenedor.Controls.Add(this.btnbuscar);
            this.contenedor.Controls.Add(this.datagridview);
            this.contenedor.Controls.Add(this.lblsubtitulo);
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 0);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1568, 646);
            this.contenedor.TabIndex = 6;
            // 
            // txtdescripcion
            // 
            this.txtdescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdescripcion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtdescripcion.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtdescripcion.Enabled = false;
            this.txtdescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescripcion.Location = new System.Drawing.Point(1117, 138);
            this.txtdescripcion.Name = "txtdescripcion";
            this.txtdescripcion.Size = new System.Drawing.Size(424, 22);
            this.txtdescripcion.TabIndex = 144;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(980, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 16);
            this.label8.TabIndex = 145;
            this.label8.Text = "Descripción de Obra";
            // 
            // txtprovincia
            // 
            this.txtprovincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtprovincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtprovincia.Enabled = false;
            this.txtprovincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprovincia.Location = new System.Drawing.Point(458, 172);
            this.txtprovincia.Name = "txtprovincia";
            this.txtprovincia.Size = new System.Drawing.Size(192, 22);
            this.txtprovincia.TabIndex = 142;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(389, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 16);
            this.label11.TabIndex = 143;
            this.label11.Text = "Provincia";
            // 
            // txtcorreo
            // 
            this.txtcorreo.Enabled = false;
            this.txtcorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcorreo.Location = new System.Drawing.Point(761, 138);
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.Size = new System.Drawing.Size(192, 22);
            this.txtcorreo.TabIndex = 140;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(672, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 141;
            this.label7.Text = "Correo";
            // 
            // txttelefono
            // 
            this.txttelefono.Enabled = false;
            this.txttelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttelefono.Location = new System.Drawing.Point(459, 138);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(192, 22);
            this.txttelefono.TabIndex = 138;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(389, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 16);
            this.label6.TabIndex = 139;
            this.label6.Text = "Telefono";
            // 
            // txtlocalidad
            // 
            this.txtlocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtlocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtlocalidad.Enabled = false;
            this.txtlocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlocalidad.Location = new System.Drawing.Point(761, 172);
            this.txtlocalidad.Name = "txtlocalidad";
            this.txtlocalidad.Size = new System.Drawing.Size(192, 22);
            this.txtlocalidad.TabIndex = 136;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(672, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 137;
            this.label5.Text = "Localidad";
            // 
            // txtdireccion
            // 
            this.txtdireccion.Enabled = false;
            this.txtdireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdireccion.Location = new System.Drawing.Point(165, 172);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(207, 22);
            this.txtdireccion.TabIndex = 134;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(42, 175);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 135;
            this.label2.Text = "Direccion";
            // 
            // txtnombrecliente
            // 
            this.txtnombrecliente.Enabled = false;
            this.txtnombrecliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombrecliente.Location = new System.Drawing.Point(165, 138);
            this.txtnombrecliente.Name = "txtnombrecliente";
            this.txtnombrecliente.Size = new System.Drawing.Size(207, 22);
            this.txtnombrecliente.TabIndex = 132;
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblnombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombre.Location = new System.Drawing.Point(42, 141);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(122, 16);
            this.lblnombre.TabIndex = 133;
            this.lblnombre.Text = "Nombre del Cliente";
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
            this.lblsubtitulo.Size = new System.Drawing.Size(1541, 129);
            this.lblsubtitulo.TabIndex = 8;
            this.lblsubtitulo.Text = "Auditoría de Comprobantes";
            // 
            // fecharegistro
            // 
            this.fecharegistro.HeaderText = "Fecha";
            this.fecharegistro.Name = "fecharegistro";
            this.fecharegistro.ReadOnly = true;
            this.fecharegistro.Width = 150;
            // 
            // estadoactual
            // 
            this.estadoactual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.estadoactual.HeaderText = "Estado Actual";
            this.estadoactual.Name = "estadoactual";
            this.estadoactual.ReadOnly = true;
            // 
            // estadoprevio
            // 
            this.estadoprevio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.estadoprevio.HeaderText = "Estado Previo";
            this.estadoprevio.Name = "estadoprevio";
            this.estadoprevio.ReadOnly = true;
            // 
            // adelanto
            // 
            this.adelanto.HeaderText = "Adelanto";
            this.adelanto.Name = "adelanto";
            this.adelanto.ReadOnly = true;
            this.adelanto.Width = 180;
            // 
            // saldo
            // 
            this.saldo.HeaderText = "Saldo";
            this.saldo.Name = "saldo";
            this.saldo.ReadOnly = true;
            this.saldo.Width = 180;
            // 
            // montototal
            // 
            this.montototal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.montototal.HeaderText = "Monto Total";
            this.montototal.Name = "montototal";
            this.montototal.ReadOnly = true;
            this.montototal.Width = 180;
            // 
            // nombreusuario
            // 
            this.nombreusuario.HeaderText = "Nombre Usuario";
            this.nombreusuario.Name = "nombreusuario";
            this.nombreusuario.ReadOnly = true;
            this.nombreusuario.Width = 190;
            // 
            // frmAuditoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1568, 646);
            this.Controls.Add(this.contenedor);
            this.Name = "frmAuditoria";
            this.Text = "frmAuditoria";
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).EndInit();
            this.contenedor.ResumeLayout(false);
            this.contenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private FontAwesome.Sharp.IconButton btncerrar;
        private FontAwesome.Sharp.IconButton btnexportar;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private System.Windows.Forms.DataGridView datagridview;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label lblsubtitulo;
        private System.Windows.Forms.TextBox txtprovincia;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtcorreo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtlocalidad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtdireccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtnombrecliente;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.TextBox txtdescripcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridViewTextBoxColumn fecharegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoactual;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoprevio;
        private System.Windows.Forms.DataGridViewTextBoxColumn adelanto;
        private System.Windows.Forms.DataGridViewTextBoxColumn saldo;
        private System.Windows.Forms.DataGridViewTextBoxColumn montototal;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreusuario;
    }
}