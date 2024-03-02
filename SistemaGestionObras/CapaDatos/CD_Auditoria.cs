using CapaEntidad.State;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Auditoria
    {
        public List<Hist_ComprobanteObra> ListarHistComprobante(int idComprobanteObra)
        {
            List<Hist_ComprobanteObra> listaHistorica = new List<Hist_ComprobanteObra>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select Hist_ComprobanteObra.Adelanto, Hist_ComprobanteObra.Saldo, Hist_ComprobanteObra.MontoTotal, EstadoObraActual, EstadoObraPrevio, Hist_ComprobanteObra.FechaRegistro,");
                    query.AppendLine("ComprobanteObra.Direccion, ComprobanteObra.Localidad, ComprobanteObra.Provincia, ComprobanteObra.Descripcion,");
                    query.AppendLine("Cliente.Telefono, pcliente.NombreCompleto, pcliente.Correo,");
                    query.AppendLine("pusuario.NombreCompleto[NombreUsuario] ");
                    query.AppendLine("from Hist_ComprobanteObra ");
                    query.AppendLine("inner join ComprobanteObra on Hist_ComprobanteObra.IdComprobanteObra = ComprobanteObra.IdComprobanteObra ");
                    query.AppendLine("inner join Cliente on Hist_ComprobanteObra.IdCliente = Cliente.IdCliente ");
                    query.AppendLine("inner join Persona pcliente on Cliente.IdPersona = pcliente.IdPersona ");
                    query.AppendLine("inner join Usuario on Hist_ComprobanteObra.IdUsuario = Usuario.IdUsuario ");
                    query.AppendLine("inner join Persona pusuario on Usuario.IdPersona = pusuario.IdPersona ");
                    query.AppendLine("where Hist_ComprobanteObra.IdComprobanteObra = @IdComprobanteObra ");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@IdComprobanteObra", idComprobanteObra);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Hist_ComprobanteObra oHistorico = new Hist_ComprobanteObra
                        {
                            Adelanto = Convert.ToDecimal(dr["Adelanto"]),
                            Saldo = Convert.ToDecimal(dr["Saldo"]),
                            MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                            EstadoActual = dr["EstadoObraActual"].ToString(),
                            EstadoPrevio = dr["EstadoObraPrevio"].ToString(),
                            Fecha = Convert.ToDateTime(dr["FechaRegistro"]),
                            oComprobanteObra = new ComprobanteObra
                            {
                                Direccion = dr["Direccion"].ToString(),
                                Localidad = dr["Localidad"].ToString(),
                                Provincia = dr["Provincia"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                oCliente = new Cliente
                                {
                                    Telefono = dr["Telefono"].ToString(),
                                    NombreCompleto = dr["NombreCompleto"].ToString(),
                                    Correo = dr["Correo"].ToString()
                                },
                                oUsuario = new Usuario
                                {
                                    NombreCompleto = dr["NombreUsuario"].ToString()
                                }
                            }
                        };

                        listaHistorica.Add(oHistorico);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            DataAccessObject.CerrarConexion();
            return listaHistorica;
        }

    }
}
