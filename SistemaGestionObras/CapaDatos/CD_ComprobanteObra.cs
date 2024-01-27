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
    }
}
