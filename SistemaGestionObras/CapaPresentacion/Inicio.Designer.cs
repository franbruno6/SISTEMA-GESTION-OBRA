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
            this.menutitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.menucomprobantes = new FontAwesome.Sharp.IconMenuItem();
            this.menupresupuestos = new FontAwesome.Sharp.IconMenuItem();
            this.menuproductos = new FontAwesome.Sharp.IconMenuItem();
            this.menuclientes = new FontAwesome.Sharp.IconMenuItem();
            this.menupermisos = new FontAwesome.Sharp.IconMenuItem();
            this.menuusarios = new FontAwesome.Sharp.IconMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuusarios,
            this.menupermisos,
            this.menuclientes,
            this.menuproductos,
            this.menupresupuestos,
            this.menucomprobantes});
            this.menu.Location = new System.Drawing.Point(0, 74);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1584, 64);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menutitulo
            // 
            this.menutitulo.AutoSize = false;
            this.menutitulo.BackColor = System.Drawing.Color.Goldenrod;
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
            this.label1.BackColor = System.Drawing.Color.Goldenrod;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema Gestión de Obras";
            // 
            // menucomprobantes
            // 
            this.menucomprobantes.AutoSize = false;
            this.menucomprobantes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menucomprobantes.IconChar = FontAwesome.Sharp.IconChar.FileCircleCheck;
            this.menucomprobantes.IconColor = System.Drawing.Color.Black;
            this.menucomprobantes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menucomprobantes.IconSize = 40;
            this.menucomprobantes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menucomprobantes.Name = "menucomprobantes";
            this.menucomprobantes.Size = new System.Drawing.Size(122, 60);
            this.menucomprobantes.Text = "Comprobantes";
            this.menucomprobantes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menupresupuestos
            // 
            this.menupresupuestos.AutoSize = false;
            this.menupresupuestos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menupresupuestos.IconChar = FontAwesome.Sharp.IconChar.Tag;
            this.menupresupuestos.IconColor = System.Drawing.Color.Black;
            this.menupresupuestos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menupresupuestos.IconSize = 40;
            this.menupresupuestos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menupresupuestos.Name = "menupresupuestos";
            this.menupresupuestos.Size = new System.Drawing.Size(122, 60);
            this.menupresupuestos.Text = "Presupuestos";
            this.menupresupuestos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuproductos
            // 
            this.menuproductos.AutoSize = false;
            this.menuproductos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuproductos.IconChar = FontAwesome.Sharp.IconChar.Tools;
            this.menuproductos.IconColor = System.Drawing.Color.Black;
            this.menuproductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuproductos.IconSize = 40;
            this.menuproductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuproductos.Name = "menuproductos";
            this.menuproductos.Size = new System.Drawing.Size(122, 60);
            this.menuproductos.Text = "Productos";
            this.menuproductos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuclientes
            // 
            this.menuclientes.AutoSize = false;
            this.menuclientes.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuclientes.IconChar = FontAwesome.Sharp.IconChar.UserGroup;
            this.menuclientes.IconColor = System.Drawing.Color.Black;
            this.menuclientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuclientes.IconSize = 40;
            this.menuclientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuclientes.Name = "menuclientes";
            this.menuclientes.Size = new System.Drawing.Size(122, 60);
            this.menuclientes.Text = "Clientes";
            this.menuclientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menupermisos
            // 
            this.menupermisos.AutoSize = false;
            this.menupermisos.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menupermisos.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.menupermisos.IconColor = System.Drawing.Color.Black;
            this.menupermisos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menupermisos.IconSize = 40;
            this.menupermisos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menupermisos.Name = "menupermisos";
            this.menupermisos.Size = new System.Drawing.Size(122, 60);
            this.menupermisos.Text = "Permisos";
            this.menupermisos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menuusarios
            // 
            this.menuusarios.AutoSize = false;
            this.menuusarios.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuusarios.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.menuusarios.IconColor = System.Drawing.Color.Black;
            this.menuusarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuusarios.IconSize = 40;
            this.menuusarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuusarios.Name = "menuusarios";
            this.menuusarios.Size = new System.Drawing.Size(122, 60);
            this.menuusarios.Text = "Usuarios";
            this.menuusarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 761);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menutitulo);
            this.MainMenuStrip = this.menu;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema Gestion de Obras";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menutitulo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menucomprobantes;
        private FontAwesome.Sharp.IconMenuItem menuusarios;
        private FontAwesome.Sharp.IconMenuItem menupermisos;
        private FontAwesome.Sharp.IconMenuItem menuclientes;
        private FontAwesome.Sharp.IconMenuItem menuproductos;
        private FontAwesome.Sharp.IconMenuItem menupresupuestos;
    }
}

