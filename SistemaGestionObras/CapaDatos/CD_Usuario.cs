using CapaEntidad;
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
                    query.AppendLine("select IdUsuario,Clave,Estado,FechaRegistro,");
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
                        usuario.FechaRegistro = dr["FechaRegistro"].ToString();
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
    }
}
