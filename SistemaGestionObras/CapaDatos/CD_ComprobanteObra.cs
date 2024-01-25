using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_ComprobanteObra
    {
        public List<ComprobanteObra> ListarComprobante()
        {
            List<ComprobanteObra> listaComprobantes = new List<ComprobanteObra>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("select NumeroComprobante, NombreCliente, Direccion, MontoTotal, EstadoObra, TelefonoCliente, Localidad, FechaRegistro, Saldo, Adelanto ");
                    query.Append("from ComprobanteObra ");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ComprobanteObra oComprobante = new ComprobanteObra();
                        oComprobante.NumeroComprobante = dr["NumeroComprobante"].ToString();
                        oComprobante.NombreCliente = dr["NombreCliente"].ToString();
                        oComprobante.Direccion = dr["Direccion"].ToString();
                        oComprobante.MontoTotal = Convert.ToDecimal(dr["MontoTotal"]);
                        oComprobante.EstadoObra = dr["EstadoObra"].ToString();
                        oComprobante.TelefonoCliente = dr["TelefonoCliente"].ToString();
                        oComprobante.Localidad = dr["Localidad"].ToString();
                        oComprobante.FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]);
                        oComprobante.Saldo = Convert.ToDecimal(dr["Saldo"]);
                        oComprobante.Adelanto = Convert.ToDecimal(dr["Adelanto"]);
                    }
                }
                catch
                {
                    throw;
                }
            }
            DataAccessObject.CerrarConexion();
            return listaComprobantes;
        }
    }
}
