namespace CapaPresentacion
{
    partial class frmGrupo
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
            this.cbobusqueda = new System.Windows.Forms.ComboBox();
            this.lblbuscarpor = new System.Windows.Forms.Label();
            this.datagridview = new System.Windows.Forms.DataGridView();
            this.btnseleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.IdGrupoPermiso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdComponente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estadoValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblsubtitulo = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtidcomponente = new System.Windows.Forms.TextBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuvergrupo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuagregargrupo = new System.Windows.Forms.ToolStripMenuItem();
            this.menumodificargrupo = new System.Windows.Forms.ToolStripMenuItem();
            this.menueliminargrupo = new System.Windows.Forms.ToolStripMenuItem();
            this.contenedor = new System.Windows.Forms.Panel();
            this.btnactualizar = new FontAwesome.Sharp.IconButton();
            this.btnlimpiar = new FontAwesome.Sharp.IconButton();
            this.btnbuscar = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).BeginInit();
            this.panel1.SuspendLayout();
            this.menu.SuspendLayout();
            this.contenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtbusqueda
            // 
            this.txtbusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbusqueda.Location = new System.Drawing.Point(1035, 94);
            this.txtbusqueda.Name = "txtbusqueda";
            this.txtbusqueda.Size = new System.Drawing.Size(142, 22);
            this.txtbusqueda.TabIndex = 13;
            this.txtbusqueda.TextChanged += new System.EventHandler(this.txtbusqueda_TextChanged);
            // 
            // cbobusqueda
            // 
            this.cbobusqueda.BackColor = System.Drawing.SystemColors.Window;
            this.cbobusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbobusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbobusqueda.FormattingEnabled = true;
            this.cbobusqueda.Location = new System.Drawing.Point(887, 94);
            this.cbobusqueda.Name = "cbobusqueda";
            this.cbobusqueda.Size = new System.Drawing.Size(142, 24);
            this.cbobusqueda.TabIndex = 12;
            this.cbobusqueda.SelectedIndexChanged += new System.EventHandler(this.cbobusqueda_SelectedIndexChanged);
            // 
            // lblbuscarpor
            // 
            this.lblbuscarpor.AutoSize = true;
            this.lblbuscarpor.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblbuscarpor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblbuscarpor.Location = new System.Drawing.Point(809, 97);
            this.lblbuscarpor.Name = "lblbuscarpor";
            this.lblbuscarpor.Size = new System.Drawing.Size(72, 16);
            this.lblbuscarpor.TabIndex = 11;
            this.lblbuscarpor.Text = "Buscar por";
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
            this.IdGrupoPermiso,
            this.IdComponente,
            this.nombre,
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
            this.datagridview.Location = new System.Drawing.Point(256, 133);
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
            this.datagridview.Size = new System.Drawing.Size(1228, 500);
            this.datagridview.TabIndex = 9;
            this.datagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_CellClick);
            this.datagridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.datagridview_CellDoubleClick);
            this.datagridview.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.datagridview_CellPainting);
            // 
            // btnseleccionar
            // 
            this.btnseleccionar.HeaderText = "";
            this.btnseleccionar.Name = "btnseleccionar";
            this.btnseleccionar.ReadOnly = true;
            this.btnseleccionar.Width = 50;
            // 
            // IdGrupoPermiso
            // 
            this.IdGrupoPermiso.HeaderText = "IdGrupoPermiso";
            this.IdGrupoPermiso.Name = "IdGrupoPermiso";
            this.IdGrupoPermiso.ReadOnly = true;
            this.IdGrupoPermiso.Visible = false;
            this.IdGrupoPermiso.Width = 120;
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
            // lblsubtitulo
            // 
            this.lblsubtitulo.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblsubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtitulo.Location = new System.Drawing.Point(256, 79);
            this.lblsubtitulo.Name = "lblsubtitulo";
            this.lblsubtitulo.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblsubtitulo.Size = new System.Drawing.Size(1228, 47);
            this.lblsubtitulo.TabIndex = 8;
            this.lblsubtitulo.Text = "Lista de Grupos";
            this.lblsubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.label1.Location = new System.Drawing.Point(0, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Grupos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel1.Controls.Add(this.txtidcomponente);
            this.panel1.Controls.Add(this.txtid);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.menu);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 646);
            this.panel1.TabIndex = 3;
            // 
            // txtidcomponente
            // 
            this.txtidcomponente.Location = new System.Drawing.Point(75, 283);
            this.txtidcomponente.Name = "txtidcomponente";
            this.txtidcomponente.Size = new System.Drawing.Size(100, 20);
            this.txtidcomponente.TabIndex = 3;
            this.txtidcomponente.Visible = false;
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.menu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuvergrupo,
            this.menuagregargrupo,
            this.menumodificargrupo,
            this.menueliminargrupo});
            this.menu.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menu.Location = new System.Drawing.Point(0, 430);
            this.menu.Name = "menu";
            this.menu.Padding = new System.Windows.Forms.Padding(6, 10, 0, 40);
            this.menu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menu.Size = new System.Drawing.Size(235, 216);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuvergrupo
            // 
            this.menuvergrupo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuvergrupo.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.menuvergrupo.Name = "menuvergrupo";
            this.menuvergrupo.Padding = new System.Windows.Forms.Padding(4);
            this.menuvergrupo.Size = new System.Drawing.Size(228, 33);
            this.menuvergrupo.Text = "Ver Detalle";
            this.menuvergrupo.Click += new System.EventHandler(this.menuvergrupo_Click);
            // 
            // menuagregargrupo
            // 
            this.menuagregargrupo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuagregargrupo.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.menuagregargrupo.Name = "menuagregargrupo";
            this.menuagregargrupo.Padding = new System.Windows.Forms.Padding(4);
            this.menuagregargrupo.Size = new System.Drawing.Size(228, 33);
            this.menuagregargrupo.Text = "Agregar";
            this.menuagregargrupo.Click += new System.EventHandler(this.menuagregargrupo_Click);
            // 
            // menumodificargrupo
            // 
            this.menumodificargrupo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menumodificargrupo.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.menumodificargrupo.Name = "menumodificargrupo";
            this.menumodificargrupo.Padding = new System.Windows.Forms.Padding(4);
            this.menumodificargrupo.Size = new System.Drawing.Size(228, 33);
            this.menumodificargrupo.Text = "Modificar";
            this.menumodificargrupo.Click += new System.EventHandler(this.menumodificargrupo_Click);
            // 
            // menueliminargrupo
            // 
            this.menueliminargrupo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menueliminargrupo.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.menueliminargrupo.Name = "menueliminargrupo";
            this.menueliminargrupo.Padding = new System.Windows.Forms.Padding(4);
            this.menueliminargrupo.Size = new System.Drawing.Size(228, 33);
            this.menueliminargrupo.Text = "Eliminar";
            this.menueliminargrupo.Click += new System.EventHandler(this.menueliminargrupo_Click);
            // 
            // contenedor
            // 
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
            this.contenedor.TabIndex = 4;
            // 
            // btnactualizar
            // 
            this.btnactualizar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnactualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnactualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnactualizar.IconChar = FontAwesome.Sharp.IconChar.ClockRotateLeft;
            this.btnactualizar.IconColor = System.Drawing.Color.Black;
            this.btnactualizar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnactualizar.IconSize = 19;
            this.btnactualizar.Location = new System.Drawing.Point(1312, 94);
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
            this.btnlimpiar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiar.IconColor = System.Drawing.Color.Black;
            this.btnlimpiar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnlimpiar.IconSize = 19;
            this.btnlimpiar.Location = new System.Drawing.Point(1252, 94);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(54, 24);
            this.btnlimpiar.TabIndex = 15;
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // btnbuscar
            // 
            this.btnbuscar.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnbuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscar.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnbuscar.IconColor = System.Drawing.Color.Black;
            this.btnbuscar.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnbuscar.IconSize = 19;
            this.btnbuscar.Location = new System.Drawing.Point(1192, 94);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(54, 24);
            this.btnbuscar.TabIndex = 14;
            this.btnbuscar.UseVisualStyleBackColor = false;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // frmGrupo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1568, 646);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.contenedor);
            this.Name = "frmGrupo";
            this.Text = "frmGrupo";
            this.Load += new System.EventHandler(this.frmPermiso_Load);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.contenedor.ResumeLayout(false);
            this.contenedor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtbusqueda;
        private FontAwesome.Sharp.IconButton btnactualizar;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private System.Windows.Forms.ComboBox cbobusqueda;
        private System.Windows.Forms.Label lblbuscarpor;
        private FontAwesome.Sharp.IconButton btnbuscar;
        private System.Windows.Forms.DataGridView datagridview;
        private System.Windows.Forms.Label lblsubtitulo;
        private System.Windows.Forms.TextBox txtid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuvergrupo;
        private System.Windows.Forms.ToolStripMenuItem menuagregargrupo;
        private System.Windows.Forms.ToolStripMenuItem menumodificargrupo;
        private System.Windows.Forms.ToolStripMenuItem menueliminargrupo;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.DataGridViewButtonColumn btnseleccionar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdGrupoPermiso;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComponente;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn estadoValor;
        private System.Windows.Forms.TextBox txtidcomponente;
    }
}