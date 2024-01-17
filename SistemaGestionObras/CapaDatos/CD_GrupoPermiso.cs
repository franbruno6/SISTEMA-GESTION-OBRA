using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_GrupoPermiso
    {
        public List<GrupoPermiso> ListarGrupoPermisos()
        {
            List<GrupoPermiso> listaGrupoPermisos = new List<GrupoPermiso>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select Componente.IdComponente, Nombre, Estado,");
                    query.AppendLine("GrupoPermiso.IdGrupoPermiso ");
                    query.AppendLine("from Componente ");
                    query.AppendLine("inner join GrupoPermiso on Componente.IdComponente = GrupoPermiso.IdComponente");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        GrupoPermiso grupoPermiso = new GrupoPermiso();
                        grupoPermiso.IdGrupoPermiso = Convert.ToInt32(dr["IdGrupoPermiso"]);
                        grupoPermiso.IdComponente = Convert.ToInt32(dr["IdComponente"]);
                        grupoPermiso.Nombre = dr["Nombre"].ToString();
                        grupoPermiso.Estado = Convert.ToBoolean(dr["Estado"]);
                        grupoPermiso.NombreGrupo = dr["Nombre"].ToString();

                        listaGrupoPermisos.Add(grupoPermiso);
                    }
                }
                catch (Exception ex)
                {
                    listaGrupoPermisos = new List<GrupoPermiso>();
                }
            }
            DataAccessObject.CerrarConexion();
            return listaGrupoPermisos;
        }
    }
}
