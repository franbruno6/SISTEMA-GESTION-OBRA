namespace CapaPresentacion.Modals
{
    partial class mdModificarComprobante
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
            this.btnvolver = new FontAwesome.Sharp.IconButton();
            this.cboestado = new System.Windows.Forms.ComboBox();
            this.lblsubtitulo = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
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
            this.btnvolver.Location = new System.Drawing.Point(785, 39);
            this.btnvolver.Name = "btnvolver";
            this.btnvolver.Size = new System.Drawing.Size(115, 25);
            this.btnvolver.TabIndex = 65;
            this.btnvolver.Text = "Volver";
            this.btnvolver.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnvolver.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnvolver.UseVisualStyleBackColor = false;
            // 
            // cboestado
            // 
            this.cboestado.BackColor = System.Drawing.SystemColors.Window;
            this.cboestado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboestado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboestado.FormattingEnabled = true;
            this.cboestado.Location = new System.Drawing.Point(275, 105);
            this.cboestado.Name = "cboestado";
            this.cboestado.Size = new System.Drawing.Size(195, 24);
            this.cboestado.TabIndex = 54;
            // 
            // lblsubtitulo
            // 
            this.lblsubtitulo.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lblsubtitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubtitulo.Location = new System.Drawing.Point(26, 25);
            this.lblsubtitulo.Name = "lblsubtitulo";
            this.lblsubtitulo.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.lblsubtitulo.Size = new System.Drawing.Size(898, 47);
            this.lblsubtitulo.TabIndex = 59;
            this.lblsubtitulo.Text = "Modificar Comprobante";
            this.lblsubtitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 93);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(20, 12, 0, 0);
            this.label3.Size = new System.Drawing.Size(898, 50);
            this.label3.TabIndex = 60;
            this.label3.Text = "Estado de la obra";
            // 
            // mdModificarComprobante
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Khaki;
            this.ClientSize = new System.Drawing.Size(988, 450);
            this.Controls.Add(this.btnvolver);
            this.Controls.Add(this.cboestado);
            this.Controls.Add(this.lblsubtitulo);
            this.Controls.Add(this.label3);
            this.Name = "mdModificarComprobante";
            this.Text = "Modificar Comprobante";
            this.ResumeLayout(false);

        }

        #endregion
        private FontAwesome.Sharp.IconButton btnvolver;
        private System.Windows.Forms.ComboBox cboestado;
        private System.Windows.Forms.Label lblsubtitulo;
        private System.Windows.Forms.Label label3;
    }
}