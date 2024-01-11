using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Utilidades;
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
    public partial class frmListaUsuario : Form
    {
        public frmListaUsuario()
        {
            InitializeComponent();
        }

        private void frmListaUsuario_Load(object sender, EventArgs e)
        {
            //CONFIGURACION DEL OPCION COMBO SELECCIONAR
            foreach (DataGridViewColumn columna in datagridview.Columns)
            {
                if (columna.Visible && columna.Name != "btnseleccionar")
                {
                    cbobusqueda.Items.Add(new OpcionCombo(columna.Name, columna.HeaderText));
                }
            }
            cbobusqueda.SelectedIndex = 0;
            cbobusqueda.DisplayMember = "Texto";
            cbobusqueda.ValueMember = "Valor";

            //MOSTRAR LOS USUARIOS
            List<Usuario> listaUsuarios = new CC_Usuario().ListarUsuarios();

            foreach (Usuario oUsuario in listaUsuarios)
            {
                datagridview.Rows.Add(
                    "",
                    oUsuario.IdUsuario, 
                    oUsuario.NombreCompleto, 
                    oUsuario.Correo, 
                    oUsuario.Documento, 
                    oUsuario.Clave, 
                    oUsuario.Estado == true ? 1 : 0, 
                    oUsuario.Estado == true ? "Activo" : "Inactivo" 
                    );
            }
        }
    }
}
