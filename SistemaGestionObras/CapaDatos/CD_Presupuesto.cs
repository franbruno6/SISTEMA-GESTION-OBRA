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
    public class CD_Presupuesto
    {
        public List<Presupuesto> ListarPresupuestos()
        {
            List<Presupuesto> listaPresupuestos = new List<Presupuesto>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdPresupuesto, Presupuesto.IdUsuario, Presupuesto.IdCliente, NumeroPresupuesto, Presupuesto.Direccion, MontoTotal, FechaRegistro, Presupuesto.Localidad,");
                    query.AppendLine("NombreCompleto, Telefono, Documento, Correo ");
                    query.AppendLine("from Presupuesto ");
                    query.AppendLine("inner join Cliente on Presupuesto.IdCliente = Cliente.IdCliente ");
                    query.AppendLine("inner join Persona on Cliente.IdPersona = Persona.IdPersona");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Presupuesto presupuesto = new Presupuesto()
                        {
                            IdPresupuesto = Convert.ToInt32(dr["IdPresupuesto"]),
                            NumeroPresupuesto = dr["NumeroPresupuesto"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Localidad = dr["Localidad"].ToString(),
                            MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),

                            oUsuario = new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"])
                            },
                            oCliente = new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Documento = dr["Documento"].ToString(),
                                Correo = dr["Correo"].ToString()
                            }
                        };
                        listaPresupuestos.Add(presupuesto);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            DataAccessObject.CerrarConexion();
            return listaPresupuestos;
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
                    query.AppendLine("select IDENT_CURRENT('Presupuesto') + 1");

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
        public bool AgregarPresupuesto(Presupuesto oPresupuesto, DataTable listaDetalle, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarPresupuesto", conexion);

                    //PARAMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("IdUsuario", oPresupuesto.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdCliente", oPresupuesto.oCliente.IdCliente);
                    cmd.Parameters.AddWithValue("NumeroPresupuesto", oPresupuesto.NumeroPresupuesto);
                    cmd.Parameters.AddWithValue("Direccion", oPresupuesto.Direccion);
                    cmd.Parameters.AddWithValue("Localidad", oPresupuesto.Localidad);
                    cmd.Parameters.AddWithValue("MontoTotal", oPresupuesto.MontoTotal);
                    cmd.Parameters.AddWithValue("FechaRegistro", oPresupuesto.FechaRegistro);
                    cmd.Parameters.AddWithValue("DetallePresupuesto", listaDetalle);

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
        public List<DetallePresupuesto> ListarDetalle(int idPresupuesto)
        {
            List<DetallePresupuesto> listaDetalle = new List<DetallePresupuesto>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    StringBuilder query = new StringBuilder();

                    query.AppendLine("select DetallePresupuesto.IdProducto,DetallePresupuesto.Precio,Cantidad,MontoTotal,");
                    query.AppendLine("Nombre,Codigo ");
                    query.AppendLine("from DetallePresupuesto ");
                    query.AppendLine("inner join Producto on DetallePresupuesto.IdProducto = Producto.IdProducto ");
                    query.AppendLine("where IdPresupuesto = @IdPresupuesto");
                    
                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("@IdPresupuesto", idPresupuesto);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        DetallePresupuesto detalle = new DetallePresupuesto
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
                    listaDetalle = new List<DetallePresupuesto>();
                }
            }
            DataAccessObject.CerrarConexion();
            return listaDetalle;
        }
        public bool EditarPresupuesto(Presupuesto oPresupuesto, DataTable listaDetalle, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarPresupuesto", conexion);

                    //PARAMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("IdPresupuesto", oPresupuesto.IdPresupuesto);
                    cmd.Parameters.AddWithValue("IdUsuario", oPresupuesto.oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdCliente", oPresupuesto.oCliente.IdCliente);
                    cmd.Parameters.AddWithValue("Direccion", oPresupuesto.Direccion);
                    cmd.Parameters.AddWithValue("Localidad", oPresupuesto.Localidad);
                    cmd.Parameters.AddWithValue("MontoTotal", oPresupuesto.MontoTotal);
                    cmd.Parameters.AddWithValue("DetallePresupuesto", listaDetalle);

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
        public bool EliminarPresupuesto(int idPresupuesto, out string mensaje)
        {
            bool resultado = false;
            mensaje = string.Empty;

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarPresupuesto", conexion);

                    //PARAMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("IdPresupuesto", idPresupuesto);

                    //PARAMETROS DE SALIDA
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 400).Direction = ParameterDirection.Output;

                    //EJECUTAR COMANDO
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    //OBTENER PARAMETROS DE SALIDA
                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
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
        public List<Presupuesto> ListarPresupuestoSinComprobante()
        {
            List<Presupuesto> listaPresupuestos = new List<Presupuesto>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdPresupuesto, Presupuesto.IdUsuario, Presupuesto.IdCliente, NumeroPresupuesto, Presupuesto.Direccion, MontoTotal, FechaRegistro, Presupuesto.Localidad,");
                    query.AppendLine("NombreCompleto, Telefono, Documento, Correo ");
                    query.AppendLine("from Presupuesto ");
                    query.AppendLine("inner join Cliente on Presupuesto.IdCliente = Cliente.IdCliente ");
                    query.AppendLine("inner join Persona on Cliente.IdPersona = Persona.IdPersona ");
                    query.AppendLine("where not exists(");
                    query.AppendLine("select 1");
                    query.AppendLine("from ComprobanteObra");
                    query.AppendLine("where ComprobanteObra.IdPresupuesto = Presupuesto.IdPresupuesto");
                    query.AppendLine(")");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Presupuesto presupuesto = new Presupuesto()
                        {
                            IdPresupuesto = Convert.ToInt32(dr["IdPresupuesto"]),
                            NumeroPresupuesto = dr["NumeroPresupuesto"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Localidad = dr["Localidad"].ToString(),
                            MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),

                            oUsuario = new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"])
                            },
                            oCliente = new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["IdCliente"]),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Telefono = dr["Telefono"].ToString(),
                                Documento = dr["Documento"].ToString(),
                                Correo = dr["Correo"].ToString()
                            }
                        };
                        listaPresupuestos.Add(presupuesto);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            DataAccessObject.CerrarConexion();
            return listaPresupuestos;
        }

    }
}
