﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Cliente
    {
        public List<Cliente> ListarClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            using (SqlConnection connexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select Persona.IdPersona, NombreCompleto, Correo, Documento,");
                    query.AppendLine("IdCliente, Telefono, Direccion, Estado ");
                    query.AppendLine("from Persona ");
                    query.AppendLine("inner join Cliente on Persona.IdPersona = Cliente.IdPersona");

                    SqlCommand cmd = new SqlCommand(query.ToString(), connexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                        cliente.IdPersona = Convert.ToInt32(dr["IdPersona"]);
                        cliente.NombreCompleto = dr["NombreCompleto"].ToString();
                        cliente.Correo = dr["Correo"].ToString();
                        cliente.Documento = dr["Documento"].ToString();
                        cliente.Telefono = dr["Telefono"].ToString();
                        cliente.Direccion = dr["Direccion"].ToString();
                        cliente.Estado = Convert.ToBoolean(dr["Estado"]);

                        listaClientes.Add(cliente);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            DataAccessObject.CerrarConexion();
            return listaClientes;
        }
        public int AgregarCliente(Cliente oCliente, out string mensaje)
        {
            int idClienteRegistrado = 0;
            mensaje = string.Empty;

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarCliente", conexion);

                    //PARAMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("NombreCompleto", oCliente.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", oCliente.Correo);
                    cmd.Parameters.AddWithValue("Documento", oCliente.Documento);
                    cmd.Parameters.AddWithValue("Telefono", oCliente.Telefono);
                    cmd.Parameters.AddWithValue("Direccion", oCliente.Direccion);
                    cmd.Parameters.AddWithValue("Estado", oCliente.Estado);
                    //PARAMETRO DE SALIDA
                    cmd.Parameters.Add("Mensaje", System.Data.SqlDbType.VarChar, 400).Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add("IdClienteRegistrado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    //TIPO DE COMANDO
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    idClienteRegistrado = Convert.ToInt32(cmd.Parameters["IdClienteRegistrado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    idClienteRegistrado = 0;
                    mensaje = ex.Message;
                }
            }
            DataAccessObject.CerrarConexion();
            return idClienteRegistrado;
        }
        public bool EditarCliente(Cliente oCliente, out string mensaje)
        {
            bool usuarioEditado = false;
            mensaje = string.Empty;

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarCliente", conexion);

                    //PARAMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("IdCliente", oCliente.IdCliente);
                    cmd.Parameters.AddWithValue("IdPersona", oCliente.IdPersona);
                    cmd.Parameters.AddWithValue("NombreCompleto", oCliente.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", oCliente.Correo);
                    cmd.Parameters.AddWithValue("Documento", oCliente.Documento);
                    cmd.Parameters.AddWithValue("Telefono", oCliente.Telefono);
                    cmd.Parameters.AddWithValue("Direccion", oCliente.Direccion);
                    cmd.Parameters.AddWithValue("Estado", oCliente.Estado);
                    //PARAMETRO DE SALIDA
                    cmd.Parameters.Add("Mensaje", System.Data.SqlDbType.VarChar, 400).Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    //TIPO DE COMANDO
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    usuarioEditado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    usuarioEditado = false;
                    mensaje = ex.Message;
                }
            }
            DataAccessObject.CerrarConexion();
            return usuarioEditado;
        }
        public bool EliminarCliente(int idCliente, int idPersona, out string mensaje)
        {
            bool clienteEliminado = false;
            mensaje = string.Empty;

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarCliente", conexion);

                    //PARAMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("IdCliente", idCliente);
                    cmd.Parameters.AddWithValue("IdPersona", idPersona);
                    //PARAMETRO DE SALIDA
                    cmd.Parameters.Add("Mensaje", System.Data.SqlDbType.VarChar, 400).Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    //TIPO DE COMANDO
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    clienteEliminado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    clienteEliminado = false;
                    mensaje = ex.Message;
                }
            }
            DataAccessObject.CerrarConexion();
            return clienteEliminado;
        }
    }
}