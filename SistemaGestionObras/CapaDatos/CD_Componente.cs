using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Componente
    {
        public List<Permiso> ListarPermisos(int idUsuario)
        {
            List<Permiso> listaPermisos = new List<Permiso>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.Append("select Componente.IdComponente, Nombre, TipoComponente, Estado,");
                    query.AppendLine("Permiso.IdPermiso, NombreMenu ");
                    query.AppendLine("from UsuarioComponente ");
                    query.AppendLine("inner join Componente on UsuarioComponente.IdComponente = Componente.IdComponente ");
                    query.AppendLine("left join Permiso on Permiso.IdPermiso = Componente.IdComponente ");
                    query.AppendLine("where IdUsuario = @IdUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", idUsuario);
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Permiso permiso = new Permiso();
                        permiso.IdComponente = Convert.ToInt32(dr["IdComponente"]);
                        permiso.Nombre = dr["Nombre"].ToString();
                        permiso.TipoComponente = dr["TipoComponente"].ToString();
                        permiso.Estado = Convert.ToBoolean(dr["Estado"]);
                        permiso.IdPermiso = Convert.ToInt32(dr["IdPermiso"]);
                        permiso.NombreMenu = dr["NombreMenu"].ToString();

                        listaPermisos.Add(permiso);
                    }
                    DataAccessObject.CerrarConexion();
                }
                catch (Exception ex)
                {
                    listaPermisos = new List<Permiso>();
                }
            }



            return listaPermisos;
        }

    }
}
