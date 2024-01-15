﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Usuario
    {
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdUsuario,Clave,Estado,");
                    query.AppendLine("Persona.IdPersona,Persona.NombreCompleto,Persona.Correo,Persona.Documento ");
                    query.AppendLine("from Usuario ");
                    query.AppendLine("inner join Persona on Usuario.IdPersona = Persona.IdPersona");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                        usuario.Clave = dr["Clave"].ToString();
                        usuario.Estado = Convert.ToBoolean(dr["Estado"]);
                        usuario.IdPersona = Convert.ToInt32(dr["IdPersona"]);
                        usuario.NombreCompleto = dr["NombreCompleto"].ToString();
                        usuario.Correo = dr["Correo"].ToString();
                        usuario.Documento = dr["Documento"].ToString();

                        listaUsuarios.Add(usuario);
                    }
                    DataAccessObject.CerrarConexion();
                }
                catch (Exception ex)
                {
                    listaUsuarios = new List<Usuario>();
                }
            }
            return listaUsuarios;
        }
        public int AgregarUsuario(Usuario oUsuario, out string mensaje)
        {
            int idUsuarioRegistrado = 0;
            mensaje = string.Empty;

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarUsuario", conexion);

                    //PARAMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("NombreCompleto", oUsuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                    cmd.Parameters.AddWithValue("Documento", oUsuario.Documento);
                    cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                    cmd.Parameters.AddWithValue("Estado", oUsuario.Estado);
                    //PARAMETRO DE SALIDA
                    cmd.Parameters.Add("Mensaje", System.Data.SqlDbType.VarChar, 400).Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add("IdUsuarioRegistrado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    //TIPO DE COMANDO
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    idUsuarioRegistrado = Convert.ToInt32(cmd.Parameters["IdUsuarioRegistrado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                    DataAccessObject.CerrarConexion();
                }
                catch (Exception ex)
                {
                    idUsuarioRegistrado = 0;
                    mensaje = ex.Message;
                }
            }
            return idUsuarioRegistrado;
        }
        public bool EditarUsuario(Usuario oUsuario, out string mensaje)
        {
            bool usuarioEditado = false;
            mensaje = string.Empty;

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarUsuario", conexion);

                    //PARAMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("IdUsuario", oUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("IdPersona", oUsuario.IdPersona);
                    cmd.Parameters.AddWithValue("NombreCompleto", oUsuario.NombreCompleto);
                    cmd.Parameters.AddWithValue("Correo", oUsuario.Correo);
                    cmd.Parameters.AddWithValue("Documento", oUsuario.Documento);
                    cmd.Parameters.AddWithValue("Clave", oUsuario.Clave);
                    cmd.Parameters.AddWithValue("Estado", oUsuario.Estado);
                    //PARAMETRO DE SALIDA
                    cmd.Parameters.Add("Mensaje", System.Data.SqlDbType.VarChar, 400).Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;
                    //TIPO DE COMANDO
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    usuarioEditado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();

                    DataAccessObject.CerrarConexion();
                }
                catch (Exception ex)
                {
                    usuarioEditado = false;
                    mensaje = ex.Message;
                }
            }
            return usuarioEditado;
        }
    }
}
