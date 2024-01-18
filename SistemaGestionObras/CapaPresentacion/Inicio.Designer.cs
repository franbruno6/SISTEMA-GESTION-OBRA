namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuusuario = new FontAwesome.Sharp.IconMenuItem();
            this.menupermiso = new FontAwesome.Sharp.IconMenuItem();
            this.menucliente = new FontAwesome.Sharp.IconMenuItem();
            this.menuproducto = new FontAwesome.Sharp.IconMenuItem();
            this.menupresupuesto = new FontAwesome.Sharp.IconMenuItem();
            this.menucomprobante = new FontAwesome.Sharp.IconMenuItem();
            this.menutitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.menugrupo = new System.Windows.Forms.ToolStripMenuItem();
            this.menupermisosimple = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.contenedor.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuusuario,
            this.menupermiso,
            this.menucliente,
            this.menuproducto,
            this.menupresupuesto,
            this.menucomprobante});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1584, 64);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            this.menu.Paint += new System.Windows.Forms.PaintEventHandler(this.menu_Paint);
            // 
            // menuusuario
            // 
            this.menuusuario.AutoSize = false;
            this.menuusuario.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuusuario.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.menuusuario.IconColor = System.Drawing.Color.Black;
            this.menuusuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuusuario.IconSize = 40;
            this.menuusuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuusuario.Name = "menuusuario";
            this.menuusuario.Size = new System.Drawing.Size(122, 60);
            this.menuusuario.Text = "Usuarios";
            this.menuusuario.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuusuario.Click += new System.EventHandler(this.menuusarios_Click);
            // 
            // menupermiso
            // 
            this.menupermiso.AutoSize = false;
            this.menupermiso.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menupermisosimple,
            this.menugrupo});
            this.menupermiso.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menupermiso.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.menupermiso.IconColor = System.Drawing.Color.Black;
            this.menupermiso.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menupermiso.IconSize = 40;
            this.menupermiso.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menupermiso.Name = "menupermiso";
            this.menupermiso.Size = new System.Drawing.Size(122, 60);
            this.menupermiso.Text = "Permisos";
            this.menupermiso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menucliente
            // 
            this.menucliente.AutoSize = false;
            this.menucliente.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menucliente.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menucliente.IconColor = System.Drawing.Color.Black;
            this.menucliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menucliente.IconSize = 40;
            this.menucliente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menucliente.Name = "menucliente";
            this.menucliente.Size = new System.Drawing.Size(122, 60);
            this.menucliente.Text = "Clientes";
            this.menucliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menucliente.Click += new System.EventHandler(this.menuclientes_Click);
            // 
            // menuproducto
            // 
            this.menuproducto.AutoSize = false;
            this.menuproducto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuproducto.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.menuproducto.IconColor = System.Drawing.Color.Black;
            this.menuproducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuproducto.IconSize = 40;
            this.menuproducto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuproducto.Name = "menuproducto";
            this.menuproducto.Size = new System.Drawing.Size(122, 60);
            this.menuproducto.Text = "Productos";
            this.menuproducto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuproducto.Click += new System.EventHandler(this.menuproductos_Click);
            // 
            // menupresupuesto
            // 
            this.menupresupuesto.AutoSize = false;
            this.menupresupuesto.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menupresupuesto.IconChar = FontAwesome.Sharp.IconChar.Tag;
            this.menupresupuesto.IconColor = System.Drawing.Color.Black;
            this.menupresupuesto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menupresupuesto.IconSize = 40;
            this.menupresupuesto.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menupresupuesto.Name = "menupresupuesto";
            this.menupresupuesto.Size = new System.Drawing.Size(122, 60);
            this.menupresupuesto.Text = "Presupuestos";
            this.menupresupuesto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menupresupuesto.Click += new System.EventHandler(this.menupresupuestos_Click);
            // 
            // menucomprobante
            // 
            this.menucomprobante.AutoSize = false;
            this.menucomprobante.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menucomprobante.IconChar = FontAwesome.Sharp.IconChar.FileCircleCheck;
            this.menucomprobante.IconColor = System.Drawing.Color.Black;
            this.menucomprobante.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menucomprobante.IconSize = 40;
            this.menucomprobante.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menucomprobante.Name = "menucomprobante";
            this.menucomprobante.Size = new System.Drawing.Size(122, 60);
            this.menucomprobante.Text = "Comprobantes";
            this.menucomprobante.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menucomprobante.Click += new System.EventHandler(this.menucomprobantes_Click);
            // 
            // menutitulo
            // 
            this.menutitulo.AutoSize = false;
            this.menutitulo.BackColor = System.Drawing.Color.Khaki;
            this.menutitulo.Location = new System.Drawing.Point(0, 0);
            this.menutitulo.Name = "menutitulo";
            this.menutitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menutitulo.Size = new System.Drawing.Size(1584, 74);
            this.menutitulo.TabIndex = 1;
            this.menutitulo.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Khaki;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema Gestión de Obras";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Khaki;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1330, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Usuario:";
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.Color.Khaki;
            this.lblusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.Location = new System.Drawing.Point(1391, 31);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(71, 18);
            this.lblusuario.TabIndex = 4;
            this.lblusuario.Text = "lblusuario";
            // 
            // contenedor
            // 
            this.contenedor.Controls.Add(this.menu);
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 74);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1584, 687);
            this.contenedor.TabIndex = 5;
            // 
            // menugrupo
            // 
            this.menugrupo.Name = "menugrupo";
            this.menugrupo.Size = new System.Drawing.Size(192, 24);
            this.menugrupo.Text = "Grupos";
            this.menugrupo.Click += new System.EventHandler(this.menugrupo_Click);
            // 
            // menupermisosimple
            // 
            this.menupermisosimple.Name = "menupermisosimple";
            this.menupermisosimple.Size = new System.Drawing.Size(192, 24);
            this.menupermisosimple.Text = "Permisos Simples";
            this.menupermisosimple.Click += new System.EventHandler(this.menupermisosimple_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 761);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menutitulo);
            this.MainMenuStrip = this.menu;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Gestion de Obras";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.contenedor.ResumeLayout(false);
            this.contenedor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menutitulo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menucomprobante;
        private FontAwesome.Sharp.IconMenuItem menuusuario;
        private FontAwesome.Sharp.IconMenuItem menupermiso;
        private FontAwesome.Sharp.IconMenuItem menucliente;
        private FontAwesome.Sharp.IconMenuItem menuproducto;
        private FontAwesome.Sharp.IconMenuItem menupresupuesto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblusuario;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.ToolStripMenuItem menupermisosimple;
        private System.Windows.Forms.ToolStripMenuItem menugrupo;
    }
}

