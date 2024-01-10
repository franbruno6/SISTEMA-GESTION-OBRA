namespace CapaPresentacion
{
    partial class frmUsuario
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuverusuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuagregarusuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menumodificarusuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menueliminarusuario = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuverusuario,
            this.menuagregarusuario,
            this.menumodificarusuario,
            this.menueliminarusuario});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 368);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 10, 0, 40);
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.menuStrip1.Size = new System.Drawing.Size(235, 216);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuverusuario
            // 
            this.menuverusuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuverusuario.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.menuverusuario.Name = "menuverusuario";
            this.menuverusuario.Padding = new System.Windows.Forms.Padding(4);
            this.menuverusuario.Size = new System.Drawing.Size(228, 33);
            this.menuverusuario.Text = "Ver Detalle";
            // 
            // menuagregarusuario
            // 
            this.menuagregarusuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuagregarusuario.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.menuagregarusuario.Name = "menuagregarusuario";
            this.menuagregarusuario.Padding = new System.Windows.Forms.Padding(4);
            this.menuagregarusuario.Size = new System.Drawing.Size(228, 33);
            this.menuagregarusuario.Text = "Agregar";
            // 
            // menumodificarusuario
            // 
            this.menumodificarusuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menumodificarusuario.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.menumodificarusuario.Name = "menumodificarusuario";
            this.menumodificarusuario.Padding = new System.Windows.Forms.Padding(4);
            this.menumodificarusuario.Size = new System.Drawing.Size(228, 33);
            this.menumodificarusuario.Text = "Modificar";
            // 
            // menueliminarusuario
            // 
            this.menueliminarusuario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menueliminarusuario.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.menueliminarusuario.Name = "menueliminarusuario";
            this.menueliminarusuario.Padding = new System.Windows.Forms.Padding(4);
            this.menueliminarusuario.Size = new System.Drawing.Size(228, 33);
            this.menueliminarusuario.Text = "Eliminar";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(235, 584);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Usuarios";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(235, 0);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1333, 584);
            this.contenedor.TabIndex = 2;
            // 
            // frmUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1568, 584);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmUsuario";
            this.Text = "frmUsuario";
            this.Load += new System.EventHandler(this.frmUsuario_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuverusuario;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem menuagregarusuario;
        private System.Windows.Forms.ToolStripMenuItem menumodificarusuario;
        private System.Windows.Forms.ToolStripMenuItem menueliminarusuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel contenedor;
    }
}