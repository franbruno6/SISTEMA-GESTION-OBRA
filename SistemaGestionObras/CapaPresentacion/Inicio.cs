﻿using CapaControladora;
using CapaEntidad;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Inicio : Form
    {
        private static Usuario _usuarioActual;
        private static IconMenuItem _menuActivo = null;
        private static Form _formularioActivo = null;

        public Inicio(Usuario oUsuario)
        {
            _usuarioActual = oUsuario;
            _usuarioActual.SetPermisos(new CC_Permiso().ListarPermisosPorId(_usuarioActual.IdUsuario));

            InitializeComponent();
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
            List<Permiso> listaPermisos = _usuarioActual.GetPermisos();

            if (listaPermisos.Count == 0)
            {
                MessageBox.Show("El usuario no tiene permisos asignados", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
            
            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool encontrado = listaPermisos.Any(p => p.NombreMenu == iconmenu.Name);

                if (encontrado)
                {
                    iconmenu.Visible = true;
                }
                else
                {
                    iconmenu.Visible = false;
                }
            }

            foreach (ToolStripMenuItem menu in menupermiso.DropDownItems)
            {
                bool encontrado = listaPermisos.Any(p => p.NombreMenu == menu.Name);

                if (encontrado)
                {
                    menu.Visible = true;
                }
                else
                {
                    menu.Visible = false;
                }
            }

            foreach (ToolStripMenuItem menu in menureporte.DropDownItems)
            {
                bool encontrado = listaPermisos.Any(p => p.NombreMenu == menu.Name);

                if (encontrado)
                {
                    menu.Visible = true;
                }
                else
                {
                    menu.Visible = false;
                }
            }

            lblusuario.Text = "Usuario: " + _usuarioActual.NombreCompleto;
        }
        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if(_menuActivo != null)
            {
                _menuActivo.BackColor = Color.PaleGoldenrod;
            }

            if (_formularioActivo != null)
            {
                _formularioActivo.Close();
            }

            menu.BackColor = Color.Silver;
            _menuActivo = menu;

            _formularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.Khaki;

            contenedor.Controls.Add(formulario);
            formulario.Show();

            formulario.FormClosing += Form_FormClosing;
        }
        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            _menuActivo.BackColor = Color.PaleGoldenrod;
            _menuActivo = null;
            _formularioActivo = null;
        }
        private void menuusarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmUsuario(_usuarioActual));
        }
        private void menuclientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmCliente(_usuarioActual));
        }
        private void menuproductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmProducto(_usuarioActual));
        }
        private void menupresupuestos_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmPresupuesto(_usuarioActual));
        }
        private void menucomprobantes_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new frmComprobante(_usuarioActual));
        }
        private void menupermisosimple_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menupermiso, new frmPermiso(_usuarioActual));
        }
        private void menugrupo_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menupermiso, new frmGrupo(_usuarioActual));
        }
        private void menu_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, menu.ClientRectangle,
                Color.Black, 0, ButtonBorderStyle.None,
                Color.Black, 0, ButtonBorderStyle.None,
                Color.Black, 0, ButtonBorderStyle.None,
                Color.Black, 1, ButtonBorderStyle.Solid);
        }
        private void menusalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void menureportepresupuesto_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menureporte, new frmReportePresupuesto());
        }
        private void menureportecomprobante_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menureporte, new frmReporteComprobante());
        }
    }
}
