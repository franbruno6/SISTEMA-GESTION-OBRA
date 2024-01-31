using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
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
                    query.AppendLine("select NumeroComprobante, ComprobanteObra.Direccion, MontoTotal, EstadoObra, ComprobanteObra.Localidad, FechaRegistro, Saldo, Adelanto, IdUsuario, ComprobanteObra.IdCliente, IdPresupuesto, IdComprobanteObra,");
                    query.AppendLine("NombreCompleto, Telefono, Correo ");
                    query.AppendLine("from ComprobanteObra ");
                    query.AppendLine("inner join Cliente on ComprobanteObra.IdCliente = Cliente.IdCliente ");
                    query.AppendLine("inner join Persona on Cliente.IdPersona = Persona.IdPersona ");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ComprobanteObra oComprobante = new ComprobanteObra
                        {
                            IdComprobanteObra = Convert.ToInt32(dr["IdComprobanteObra"]),
                            NumeroComprobante = dr["NumeroComprobante"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                            EstadoObra = dr["EstadoObra"].ToString(),
                            Localidad = dr["Localidad"].ToString(),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                            Saldo = Convert.ToDecimal(dr["Saldo"]),
                            Adelanto = Convert.ToDecimal(dr["Adelanto"]),
                            oUsuario = new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"])
                            },
                            oCliente = new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Correo = dr["Correo"].ToString()
                            },
                            oPresupuesto = new Presupuesto()
                            {
                                IdPresupuesto = Convert.ToInt32(dr["IdPresupuesto"])
                            }
                        };

                        listaComprobantes.Add(oComprobante);
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
        public int ObtenerCorrelativo()
        {
            int idCorrelativo = 0;

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IDENT_CURRENT('ComprobanteObra') + 1");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;

                    idCorrelativo = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (Exception ex)
                {
                    idCorrelativo = 0;
                }
            }
            DataAccessObject.CerrarConexion();
            return idCorrelativo;
        }
        public bool AgregarComprobante(ComprobanteObra oComprobante, DataTable listaDetalle, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarComprobanteObra", conexion);

                    //PARAMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("IdUsuario", oComprobante.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdCliente", oComprobante.oCliente.IdCliente);
                    cmd.Parameters.AddWithValue("IdPresupuesto", oComprobante.oPresupuesto.IdPresupuesto);
                    cmd.Parameters.AddWithValue("NumeroComprobante", oComprobante.NumeroComprobante);
                    cmd.Parameters.AddWithValue("Direccion", oComprobante.Direccion);
                    cmd.Parameters.AddWithValue("Localidad", oComprobante.Localidad);
                    cmd.Parameters.AddWithValue("MontoTotal", oComprobante.MontoTotal);
                    cmd.Parameters.AddWithValue("FechaRegistro", oComprobante.FechaRegistro);
                    cmd.Parameters.AddWithValue("Adelanto", oComprobante.Adelanto);
                    cmd.Parameters.AddWithValue("Saldo", oComprobante.Saldo);
                    cmd.Parameters.AddWithValue("DetalleComprobanteObra", listaDetalle);


                    //PARAMETROS DE SALIDA
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 400).Direction = ParameterDirection.Output;

                    //EJECUTAR COMANDO
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    //OBTENER PARAMETROS DE SALIDA
                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                    resultado = false;
                }
            }
            DataAccessObject.CerrarConexion();
            return resultado;
        }
        public List<DetalleComprobanteObra> ListarDetalle(int idComprobante)
        {
            List<DetalleComprobanteObra> listaDetalle = new List<DetalleComprobanteObra>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select DetalleComprobanteObra.IdProducto,DetalleComprobanteObra.Precio,Cantidad,MontoTotal,");
                    query.AppendLine("Nombre,Codigo ");
                    query.AppendLine("from DetalleComprobanteObra ");
                    query.AppendLine("inner join Producto on DetalleComprobanteObra.IdProducto = Producto.IdProducto ");
                    query.AppendLine("where IdComprobanteObra = @IdComprobanteObra");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@IdComprobanteObra", idComprobante);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DetalleComprobanteObra detalle = new DetalleComprobanteObra
                        {
                            oProducto = new Producto()
                            {
                                IdProducto = Convert.ToInt32(dr["IdProducto"]),
                                Nombre = dr["Nombre"].ToString(),
                                Codigo = dr["Codigo"].ToString()
                            },
                            Precio = Convert.ToDecimal(dr["Precio"].ToString()),
                            Cantidad = Convert.ToInt32(dr["Cantidad"].ToString()),
                            MontoTotal = Convert.ToDecimal(dr["MontoTotal"].ToString())
                        };

                        listaDetalle.Add(detalle);
                    }
                }
                catch (Exception ex)
                {
                    listaDetalle = new List<DetalleComprobanteObra>();
                }
            }
            DataAccessObject.CerrarConexion();
            return listaDetalle;
        }
        public bool ModificarEstadoComprobante(int idComprobante, int idUsuario, string estadoObra, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarEstadoComprobante", conexion);

                    //PARAMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("IdComprobanteObra", idComprobante);
                    cmd.Parameters.AddWithValue("EstadoObra", estadoObra);
                    cmd.Parameters.AddWithValue("IdUsuario", idUsuario);

                    //PARAMETROS DE SALIDA
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 400).Direction = ParameterDirection.Output;

                    //EJECUTAR COMANDO
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    //OBTENER PARAMETROS DE SALIDA
                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                }
                catch (Exception ex)
                {
                    mensaje = ex.Message;
                    resultado = false;
                }
            }
            DataAccessObject.CerrarConexion();
            return resultado;
        }

    }
}
