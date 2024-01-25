using CapaControladora;
using CapaEntidad;
using CapaPresentacion.Modals;
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
    public partial class frmComprobante : Form
    {
        private CC_ComprobanteObra oCC_ComprobanteObra = new CC_ComprobanteObra();
        private CC_Presupuesto oCC_Presupuesto = new CC_Presupuesto();
        private Usuario _usuarioActual;
        public frmComprobante(Usuario oUsuario)
        {
            _usuarioActual = oUsuario;
            InitializeComponent();
        }

        private void frmComprobante_Load(object sender, EventArgs e)
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

            //foreach (ToolStripMenuItem menu in menu.Items)
            //{
            //    bool encontrado = _usuarioActual.GetPermisos().Any(p => p.NombreMenu == menu.Name);

            //    if (encontrado)
            //    {
            //        menu.Visible = true;
            //    }
            //    else
            //    {
            //        menu.Visible = false;
            //    }
            //}
            //menuvercomprobante.Visible = true;
        }
        private void btnactualizar_Click(object sender, EventArgs e)
        {
            datagridview.Rows.Clear();

            //MOSTRAR LOS PRESUPUESTOS
            //List<ComprobanteObra> listaComprobante = oCC_ComprobanteObra.ListarComprobante();
            //listaPresupuestos = listaPresupuestos.OrderBy(p => p.NumeroPresupuesto).ToList();

            //foreach (Presupuesto oPresupuesto in listaPresupuestos)
            //{
            //    datagridview.Rows.Add(
            //        "",
            //        oPresupuesto.IdPresupuesto,
            //        oPresupuesto.oUsuario.IdUsuario,
            //        oPresupuesto.NumeroPresupuesto,
            //        oPresupuesto.NombreCliente,
            //        oPresupuesto.TelefonoCliente,
            //        oPresupuesto.Direccion,
            //        oPresupuesto.Localidad,
            //        oPresupuesto.MontoTotal,
            //        oPresupuesto.FechaRegistro.ToString("dd-MM-yyyy")
            //        );
            //}

            //CONFIGURA QUE NO ESTE SELECCIONADA NINGUNA FILA
            datagridview.ClearSelection();

            txtid.Text = "";
            txtidusuario.Text = "";
        }

        private void menuagregarcomprobante_Click(object sender, EventArgs e)
        {
            using (var modal = new mdListaPresupuestos())
            {
                var resultado = modal.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    Presupuesto oPresupuesto = oCC_Presupuesto.ListarPresupuestos().Where(p => p.IdPresupuesto == modal.IdPresupuesto).FirstOrDefault();
                    AbrirModal("Agregar", 0, _usuarioActual);
                }
            }
        }
        private void AbrirModal(string tipoModal, int idComprobante, Usuario _usuarioActual)
        {
            using (var modal = new mdDetalleComprobante(tipoModal, idComprobante, _usuarioActual))
            {
                var resultado = modal.ShowDialog();
            }
        }
    }
}
