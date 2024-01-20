namespace CapaPresentacion.CP_Usuario
{
    partial class mdDetalleUsuario
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
            this.lblsubtitulo = new System.Windows.Forms.Label();
            this.lblnombrecompleto = new System.Windows.Forms.Label();
            this.txtnombrecompleto = new System.Windows.Forms.TextBox();
            this.txtdocumento = new System.Windows.Forms.TextBox();
            this.lbldocumento = new System.Windows.Forms.Label();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.lblcorreo = new System.Windows.Forms.Label();
            this.lblestado = new System.Windows.Forms.Label();
            this.cboestado = new System.Windows.Forms.ComboBox();
            this.btnvolver = new FontAwesome.Sharp.IconButton();
            this.panelclave = new System.Windows.Forms.Panel();
            this.btnverclave = new FontAwesome.Sharp.IconButton();
            this.txtconfirmarclave = new System.Windows.Forms.TextBox();
            this.txtclave = new System.Windows.Forms.TextBox();
            this.lblclave = new System.Windows.Forms.Label();
            this.lblconfirmarclave = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnaccion = new FontAwesome.Sharp.IconButton();
            this.panelclave.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblsubtitulo
            // 
            this.lblsubtitulo.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblsubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtitulo.Location = new System.Drawing.Point(12, 40);
            this.lblsubtitulo.Name = "lblsubtitulo";
            this.lblsubtitulo.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblsubtitulo.Size = new System.Drawing.Size(1161, 47);
            this.lblsubtitulo.TabIndex = 8;
            this.lblsubtitulo.Text = "Detalle del Usuario";
            this.lblsubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblnombrecompleto
            // 
            this.lblnombrecompleto.AutoSize = true;
            this.lblnombrecompleto.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblnombrecompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombrecompleto.Location = new System.Drawing.Point(36, 174);
            this.lblnombrecompleto.Name = "lblnombrecompleto";
            this.lblnombrecompleto.Size = new System.Drawing.Size(117, 16);
            this.lblnombrecompleto.TabIndex = 17;
            this.lblnombrecompleto.Text = "Nombre Completo";
            // 
            // txtnombrecompleto
            // 
            this.txtnombrecompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombrecompleto.Location = new System.Drawing.Point(39, 202);
            this.txtnombrecompleto.Name = "txtnombrecompleto";
            this.txtnombrecompleto.Size = new System.Drawing.Size(171, 22);
            this.txtnombrecompleto.TabIndex = 1;
            // 
            // txtdocumento
            // 
            this.txtdocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdocumento.Location = new System.Drawing.Point(265, 202);
            this.txtdocumento.Name = "txtdocumento";
            this.txtdocumento.Size = new System.Drawing.Size(171, 22);
            this.txtdocumento.TabIndex = 2;
            this.txtdocumento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdocumento_KeyPress);
            // 
            // lbldocumento
            // 
            this.lbldocumento.AutoSize = true;
            this.lbldocumento.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lbldocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldocumento.Location = new System.Drawing.Point(262, 174);
            this.lbldocumento.Name = "lbldocumento";
            this.lbldocumento.Size = new System.Drawing.Size(146, 16);
            this.lbldocumento.TabIndex = 19;
            this.lbldocumento.Text = "Numero de Documento";
            // 
            // txtcorreo
            // 
            this.txtcorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcorreo.Location = new System.Drawing.Point(493, 202);
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.Size = new System.Drawing.Size(171, 22);
            this.txtcorreo.TabIndex = 3;
            // 
            // lblcorreo
            // 
            this.lblcorreo.AutoSize = true;
            this.lblcorreo.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblcorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcorreo.Location = new System.Drawing.Point(490, 174);
            this.lblcorreo.Name = "lblcorreo";
            this.lblcorreo.Size = new System.Drawing.Size(118, 16);
            this.lblcorreo.TabIndex = 21;
            this.lblcorreo.Text = "Correo Electrónico";
            // 
            // lblestado
            // 
            this.lblestado.AutoSize = true;
            this.lblestado.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblestado.Location = new System.Drawing.Point(710, 174);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(50, 16);
            this.lblestado.TabIndex = 23;
            this.lblestado.Text = "Estado";
            // 
            // cboestado
            // 
            this.cboestado.BackColor = System.Drawing.SystemColors.Window;
            this.cboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboestado.FormattingEnabled = true;
            this.cboestado.Location = new System.Drawing.Point(713, 202);
            this.cboestado.Name = "cboestado";
            this.cboestado.Size = new System.Drawing.Size(173, 24);
            this.cboestado.TabIndex = 4;
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
            this.btnvolver.Location = new System.Drawing.Point(1034, 54);
            this.btnvolver.Name = "btnvolver";
            this.btnvolver.Size = new System.Drawing.Size(115, 25);
            this.btnvolver.TabIndex = 25;
            this.btnvolver.Text = "Volver";
            this.btnvolver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnvolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnvolver.UseVisualStyleBackColor = false;
            this.btnvolver.Click += new System.EventHandler(this.btnvolver_Click);
            // 
            // panelclave
            // 
            this.panelclave.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panelclave.Controls.Add(this.btnverclave);
            this.panelclave.Controls.Add(this.txtconfirmarclave);
            this.panelclave.Controls.Add(this.txtclave);
            this.panelclave.Controls.Add(this.lblclave);
            this.panelclave.Controls.Add(this.lblconfirmarclave);
            this.panelclave.Location = new System.Drawing.Point(12, 276);
            this.panelclave.Name = "panelclave";
            this.panelclave.Size = new System.Drawing.Size(1161, 100);
            this.panelclave.TabIndex = 32;
            this.panelclave.Visible = false;
            // 
            // btnverclave
            // 
            this.btnverclave.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnverclave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnverclave.FlatAppearance.BorderSize = 0;
            this.btnverclave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnverclave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnverclave.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btnverclave.IconColor = System.Drawing.Color.Black;
            this.btnverclave.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnverclave.IconSize = 18;
            this.btnverclave.Location = new System.Drawing.Point(430, 50);
            this.btnverclave.Name = "btnverclave";
            this.btnverclave.Size = new System.Drawing.Size(39, 27);
            this.btnverclave.TabIndex = 32;
            this.btnverclave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnverclave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnverclave.UseVisualStyleBackColor = false;
            this.btnverclave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnverclave_MouseDown);
            this.btnverclave.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnverclave_MouseUp);
            // 
            // txtconfirmarclave
            // 
            this.txtconfirmarclave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtconfirmarclave.Location = new System.Drawing.Point(253, 52);
            this.txtconfirmarclave.Name = "txtconfirmarclave";
            this.txtconfirmarclave.PasswordChar = '*';
            this.txtconfirmarclave.Size = new System.Drawing.Size(171, 22);
            this.txtconfirmarclave.TabIndex = 6;
            // 
            // txtclave
            // 
            this.txtclave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtclave.Location = new System.Drawing.Point(22, 52);
            this.txtclave.Name = "txtclave";
            this.txtclave.PasswordChar = '*';
            this.txtclave.Size = new System.Drawing.Size(171, 22);
            this.txtclave.TabIndex = 5;
            // 
            // lblclave
            // 
            this.lblclave.AutoSize = true;
            this.lblclave.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblclave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclave.Location = new System.Drawing.Point(16, 21);
            this.lblclave.Name = "lblclave";
            this.lblclave.Size = new System.Drawing.Size(76, 16);
            this.lblclave.TabIndex = 27;
            this.lblclave.Text = "Contraseña";
            // 
            // lblconfirmarclave
            // 
            this.lblconfirmarclave.AutoSize = true;
            this.lblconfirmarclave.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblconfirmarclave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblconfirmarclave.Location = new System.Drawing.Point(247, 21);
            this.lblconfirmarclave.Name = "lblconfirmarclave";
            this.lblconfirmarclave.Size = new System.Drawing.Size(136, 16);
            this.lblconfirmarclave.TabIndex = 29;
            this.lblconfirmarclave.Text = "Confirmar Contraseña";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 108);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
            this.label3.Size = new System.Drawing.Size(1161, 149);
            this.label3.TabIndex = 16;
            this.label3.Text = "Información del usuario";
            // 
            // btnaccion
            // 
            this.btnaccion.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.btnaccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaccion.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnaccion.IconColor = System.Drawing.Color.Black;
            this.btnaccion.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnaccion.IconSize = 18;
            this.btnaccion.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnaccion.Location = new System.Drawing.Point(976, 200);
            this.btnaccion.Name = "btnaccion";
            this.btnaccion.Size = new System.Drawing.Size(173, 27);
            this.btnaccion.TabIndex = 7;
            this.btnaccion.Text = "Accion";
            this.btnaccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnaccion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnaccion.UseVisualStyleBackColor = false;
            this.btnaccion.Click += new System.EventHandler(this.btnaccion_Click);
            // 
            // mdDetalleUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(1199, 420);
            this.Controls.Add(this.panelclave);
            this.Controls.Add(this.btnaccion);
            this.Controls.Add(this.btnvolver);
            this.Controls.Add(this.cboestado);
            this.Controls.Add(this.lblestado);
            this.Controls.Add(this.txtcorreo);
            this.Controls.Add(this.lblcorreo);
            this.Controls.Add(this.txtdocumento);
            this.Controls.Add(this.lbldocumento);
            this.Controls.Add(this.txtnombrecompleto);
            this.Controls.Add(this.lblnombrecompleto);
            this.Controls.Add(this.lblsubtitulo);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "mdDetalleUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mdDetalleUsuario";
            this.Load += new System.EventHandler(this.frmDetalleUsuario_Load);
            this.panelclave.ResumeLayout(false);
            this.panelclave.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblsubtitulo;
        private System.Windows.Forms.Label lblnombrecompleto;
        private System.Windows.Forms.TextBox txtnombrecompleto;
        private System.Windows.Forms.TextBox txtdocumento;
        private System.Windows.Forms.Label lbldocumento;
        private System.Windows.Forms.TextBox txtcorreo;
        private System.Windows.Forms.Label lblcorreo;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.ComboBox cboestado;
        private FontAwesome.Sharp.IconButton btnvolver;
        private System.Windows.Forms.Panel panelclave;
        private FontAwesome.Sharp.IconButton btnverclave;
        private System.Windows.Forms.TextBox txtconfirmarclave;
        private System.Windows.Forms.TextBox txtclave;
        private System.Windows.Forms.Label lblclave;
        private System.Windows.Forms.Label lblconfirmarclave;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnaccion;
    }
}