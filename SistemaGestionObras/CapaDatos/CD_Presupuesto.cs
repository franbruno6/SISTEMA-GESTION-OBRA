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
                    query.AppendLine("select IdPresupuesto, NumeroPresupuesto, NombreCliente, Direccion, MontoTotal, FechaRegistro, ");
                    query.AppendLine("Usuario.IdUsuario, Persona.IdPersona, Persona.NombreCompleto, Persona.Correo, Persona.Documento ");
                    query.AppendLine("from Presupuesto ");
                    query.AppendLine("inner join Usuario on Presupuesto.IdUsuario = Usuario.IdUsuario ");
                    query.AppendLine("inner join Persona on Usuario.IdPersona = Persona.IdPersona ");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Presupuesto presupuesto = new Presupuesto()
                        {
                            IdPresupuesto = Convert.ToInt32(dr["IdPresupuesto"]),
                            NumeroPresupuesto = dr["NumeroPresupuesto"].ToString(),
                            NombreCliente = dr["NombreCliente"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                            FechaRegistro = dr["FechaRegistro"].ToString(),

                            oUsuario = new Usuario()
                            {
                                IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                                IdPersona = Convert.ToInt32(dr["IdPersona"]),
                                NombreCompleto = dr["NombreCompleto"].ToString(),
                                Correo = dr["Correo"].ToString(),
                                Documento = dr["Documento"].ToString()
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
                    query.AppendLine("select count(*) + 1 from Presupuesto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

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
                    cmd.Parameters.AddWithValue("NumeroPresupuesto", oPresupuesto.NumeroPresupuesto);
                    cmd.Parameters.AddWithValue("NombreCliente", oPresupuesto.NombreCliente);
                    cmd.Parameters.AddWithValue("TelefonoCliente", oPresupuesto.TelefonoCliente);
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
    }
}
