namespace CapaPresentacion.Modals
{
    partial class mdDetalleCliente
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
            this.cboestado = new System.Windows.Forms.ComboBox();
            this.lblestado = new System.Windows.Forms.Label();
            this.txtcorreo = new System.Windows.Forms.TextBox();
            this.lblcorreo = new System.Windows.Forms.Label();
            this.txtdocumento = new System.Windows.Forms.TextBox();
            this.lbldocumento = new System.Windows.Forms.Label();
            this.txtnombrecompleto = new System.Windows.Forms.TextBox();
            this.lblnombrecompleto = new System.Windows.Forms.Label();
            this.lblsubtitulo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txttelefono = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdireccion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnaccion = new FontAwesome.Sharp.IconButton();
            this.btnvolver = new FontAwesome.Sharp.IconButton();
            this.txtlocalidad = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtprovincia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboestado
            // 
            this.cboestado.BackColor = System.Drawing.SystemColors.Window;
            this.cboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboestado.FormattingEnabled = true;
            this.cboestado.Location = new System.Drawing.Point(713, 171);
            this.cboestado.Name = "cboestado";
            this.cboestado.Size = new System.Drawing.Size(173, 24);
            this.cboestado.TabIndex = 4;
            // 
            // lblestado
            // 
            this.lblestado.AutoSize = true;
            this.lblestado.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblestado.Location = new System.Drawing.Point(710, 143);
            this.lblestado.Name = "lblestado";
            this.lblestado.Size = new System.Drawing.Size(50, 16);
            this.lblestado.TabIndex = 41;
            this.lblestado.Text = "Estado";
            // 
            // txtcorreo
            // 
            this.txtcorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcorreo.Location = new System.Drawing.Point(493, 171);
            this.txtcorreo.Name = "txtcorreo";
            this.txtcorreo.Size = new System.Drawing.Size(171, 22);
            this.txtcorreo.TabIndex = 3;
            // 
            // lblcorreo
            // 
            this.lblcorreo.AutoSize = true;
            this.lblcorreo.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblcorreo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcorreo.Location = new System.Drawing.Point(490, 143);
            this.lblcorreo.Name = "lblcorreo";
            this.lblcorreo.Size = new System.Drawing.Size(118, 16);
            this.lblcorreo.TabIndex = 39;
            this.lblcorreo.Text = "Correo Electrónico";
            // 
            // txtdocumento
            // 
            this.txtdocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdocumento.Location = new System.Drawing.Point(265, 171);
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
            this.lbldocumento.Location = new System.Drawing.Point(262, 143);
            this.lbldocumento.Name = "lbldocumento";
            this.lbldocumento.Size = new System.Drawing.Size(146, 16);
            this.lbldocumento.TabIndex = 37;
            this.lbldocumento.Text = "Numero de Documento";
            // 
            // txtnombrecompleto
            // 
            this.txtnombrecompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnombrecompleto.Location = new System.Drawing.Point(39, 171);
            this.txtnombrecompleto.Name = "txtnombrecompleto";
            this.txtnombrecompleto.Size = new System.Drawing.Size(171, 22);
            this.txtnombrecompleto.TabIndex = 1;
            // 
            // lblnombrecompleto
            // 
            this.lblnombrecompleto.AutoSize = true;
            this.lblnombrecompleto.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblnombrecompleto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnombrecompleto.Location = new System.Drawing.Point(36, 143);
            this.lblnombrecompleto.Name = "lblnombrecompleto";
            this.lblnombrecompleto.Size = new System.Drawing.Size(117, 16);
            this.lblnombrecompleto.TabIndex = 35;
            this.lblnombrecompleto.Text = "Nombre Completo";
            // 
            // lblsubtitulo
            // 
            this.lblsubtitulo.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblsubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtitulo.Location = new System.Drawing.Point(12, 9);
            this.lblsubtitulo.Name = "lblsubtitulo";
            this.lblsubtitulo.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblsubtitulo.Size = new System.Drawing.Size(898, 47);
            this.lblsubtitulo.TabIndex = 33;
            this.lblsubtitulo.Text = "Detalle del Cliente";
            this.lblsubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
            this.label3.Size = new System.Drawing.Size(898, 272);
            this.label3.TabIndex = 34;
            this.label3.Text = "Información del cliente";
            // 
            // txttelefono
            // 
            this.txttelefono.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttelefono.Location = new System.Drawing.Point(39, 255);
            this.txttelefono.Name = "txttelefono";
            this.txttelefono.Size = new System.Drawing.Size(171, 22);
            this.txttelefono.TabIndex = 5;
            this.txttelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdocumento_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 16);
            this.label1.TabIndex = 46;
            this.label1.Text = "Numero de Teléfono";
            // 
            // txtdireccion
            // 
            this.txtdireccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdireccion.Location = new System.Drawing.Point(265, 255);
            this.txtdireccion.Name = "txtdireccion";
            this.txtdireccion.Size = new System.Drawing.Size(171, 22);
            this.txtdireccion.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(262, 227);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 48;
            this.label2.Text = "Dirección";
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
            this.btnaccion.Location = new System.Drawing.Point(713, 307);
            this.btnaccion.Name = "btnaccion";
            this.btnaccion.Size = new System.Drawing.Size(173, 27);
            this.btnaccion.TabIndex = 9;
            this.btnaccion.Text = "Accion";
            this.btnaccion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnaccion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnaccion.UseVisualStyleBackColor = false;
            this.btnaccion.Click += new System.EventHandler(this.btnaccion_Click);
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
            this.btnvolver.Location = new System.Drawing.Point(771, 23);
            this.btnvolver.Name = "btnvolver";
            this.btnvolver.Size = new System.Drawing.Size(115, 25);
            this.btnvolver.TabIndex = 10;
            this.btnvolver.Text = "Volver";
            this.btnvolver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnvolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnvolver.UseVisualStyleBackColor = false;
            this.btnvolver.Click += new System.EventHandler(this.btnvolver_Click);
            // 
            // txtlocalidad
            // 
            this.txtlocalidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtlocalidad.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtlocalidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtlocalidad.Location = new System.Drawing.Point(493, 255);
            this.txtlocalidad.Name = "txtlocalidad";
            this.txtlocalidad.Size = new System.Drawing.Size(171, 22);
            this.txtlocalidad.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(490, 227);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 50;
            this.label4.Text = "Localidad";
            // 
            // txtprovincia
            // 
            this.txtprovincia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtprovincia.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtprovincia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprovincia.Location = new System.Drawing.Point(713, 255);
            this.txtprovincia.Name = "txtprovincia";
            this.txtprovincia.Size = new System.Drawing.Size(171, 22);
            this.txtprovincia.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(710, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 16);
            this.label5.TabIndex = 52;
            this.label5.Text = "Provincia";
            // 
            // mdDetalleCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(928, 358);
            this.Controls.Add(this.txtprovincia);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtlocalidad);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtdireccion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txttelefono);
            this.Controls.Add(this.label1);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mdDetalleCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "mdDetalleCliente";
            this.Load += new System.EventHandler(this.mdDetalleCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnaccion;
        private FontAwesome.Sharp.IconButton btnvolver;
        private System.Windows.Forms.ComboBox cboestado;
        private System.Windows.Forms.Label lblestado;
        private System.Windows.Forms.TextBox txtcorreo;
        private System.Windows.Forms.Label lblcorreo;
        private System.Windows.Forms.TextBox txtdocumento;
        private System.Windows.Forms.Label lbldocumento;
        private System.Windows.Forms.TextBox txtnombrecompleto;
        private System.Windows.Forms.Label lblnombrecompleto;
        private System.Windows.Forms.Label lblsubtitulo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txttelefono;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtdireccion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtlocalidad;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtprovincia;
        private System.Windows.Forms.Label label5;
    }
}