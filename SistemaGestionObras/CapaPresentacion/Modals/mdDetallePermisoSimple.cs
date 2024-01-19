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

namespace CapaPresentacion.Modals
{
    public partial class mdDetallePermisoSimple : Form
    {
        private int _idPermiso;
        private CC_Permiso oCCPermiso = new CC_Permiso();
        private Permiso oPermiso = new Permiso();
        public mdDetallePermisoSimple(int idPermiso)
        {
            _idPermiso = idPermiso;
            oPermiso = oCCPermiso.ListarPermisos().Where(p => p.IdPermiso == _idPermiso).FirstOrDefault();
            InitializeComponent();
        }
        private void mdListaPermisoSimple_Load(object sender, EventArgs e)
        {
            txtnombremenu.Text = oPermiso.NombreMenu;
            txtnombre.Text = oPermiso.Nombre;

            cboestado.Items.Add(new OpcionCombo(1, "Activo"));
            cboestado.Items.Add(new OpcionCombo(0, "Inactivo"));
            cboestado.SelectedIndex = 0;
            cboestado.DisplayMember = "Texto";
            cboestado.ValueMember = "Valor";
        }
        private void btnvolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
