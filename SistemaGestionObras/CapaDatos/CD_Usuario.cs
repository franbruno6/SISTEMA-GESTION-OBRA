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
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("select IdUsuario,Clave,Estado,FechaRegistro,");
                    query.Append("Persona.IdPersona,Persona.NombreCompleto,Persona.Correo,Persona.Documento ");
                    query.Append("from Usuario ");
                    query.Append("inner join Persona on Usuario.IdPersona = Persona.IdPersona");

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

                        usuario.oPersona.IdPersona = Convert.ToInt32(dr["IdPersona"]);
                        usuario.oPersona.NombreCompleto = dr["NombreCompleto"].ToString();
                        usuario.oPersona.Correo = dr["Correo"].ToString();
                        usuario.oPersona.Documento = dr["Documento"].ToString();

                        usuarios.Add(usuario);
                    }
                }
                catch (Exception ex)
                {
                    usuarios = new List<Usuario>();
                }
            }
            return usuarios;
        }
    }
}
