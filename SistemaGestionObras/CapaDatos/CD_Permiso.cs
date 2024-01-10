using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> ObtenerPermisos(int idUsuario)
        {
            List<Componente> listaComponentes = new List<Componente>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select Componente.IdComponente, Nombre, TipoComponente, Estado ");
                    query.AppendLine("from UsuarioComponente ");
                    query.AppendLine("inner join Componente on UsuarioComponente.IdComponente = Componente.IdComponente ");
                    query.AppendLine("where UsuarioComponente.IdUsuario = @IdUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", idUsuario);
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Componente componente = new Componente();
                        componente.IdComponente = Convert.ToInt32(dr["IdComponente"]);
                        componente.Nombre = dr["Nombre"].ToString();
                        componente.TipoComponente = dr["TipoComponente"].ToString();
                        componente.Estado = Convert.ToBoolean(dr["Estado"]);

                        listaComponentes.Add(componente);
                    }
                    DataAccessObject.CerrarConexion();
                }
                catch (Exception ex)
                {
                    List<Permiso> listaPermisos = new List<Permiso>();
                    return listaPermisos;
                }
            }
            return DiferenciarComponentes(listaComponentes);
        }
        private List<Permiso> DiferenciarComponentes(List<Componente> listaComponentes)
        {
            List<Componente> listaComponentesDiferenciados = new List<Componente>();
            List<Permiso> listaPermisos = new List<Permiso>();
            List<Componente> listaPermisoComponente = new List<Componente>();
            List<Componente> listaGrupoPermisoComponente = new List<Componente>();

            do 
            {
                foreach (Componente componente in listaComponentes)
                {
                    if (componente.TipoComponente == "Permiso") {
                        listaPermisoComponente.Add(componente);
                    }
                    else if (componente.TipoComponente == "GrupoPermiso")
                    {
                        listaGrupoPermisoComponente.Add(componente);
                    }
                }

                listaComponentes.Clear();

                foreach (Componente componentePermiso in listaPermisoComponente)
                {
                    if (componentePermiso.TipoComponente == "Permiso")
                    {
                        using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
                        {
                            try
                            {
                                StringBuilder query = new StringBuilder();
                                query.AppendLine("select IdPermiso, NombreMenu ");
                                query.AppendLine("from Permiso ");
                                query.AppendLine("inner join Componente on Permiso.IdPermiso = Componente.IdComponente ");
                                query.AppendLine("where IdPermiso = @IdPermiso");

                                SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                                cmd.Parameters.AddWithValue("IdPermiso", componentePermiso.IdComponente);

                                SqlDataReader dr = cmd.ExecuteReader();
                                while (dr.Read())
                                {
                                    Permiso permiso = new Permiso()
                                    {
                                        IdComponente = componentePermiso.IdComponente,
                                        Nombre = componentePermiso.Nombre,
                                        TipoComponente = componentePermiso.TipoComponente,
                                        Estado = componentePermiso.Estado,
                                        IdPermiso = Convert.ToInt32(dr["IdPermiso"]),
                                        NombreMenu = dr["NombreMenu"].ToString()
                                    };
                                    listaPermisos.Add(permiso);
                                }
                                DataAccessObject.CerrarConexion();
                            }
                            catch (Exception ex)
                            {
                                throw new Exception("Hay un error en la base de datos " + ex.Message);
                            }
                        }
                    }
                }

                foreach (Componente componenteGrupoPermiso in listaGrupoPermisoComponente)
                {
                    using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
                    {
                        try
                        {
                            StringBuilder query = new StringBuilder();
                            query.AppendLine("select Componente.IdComponente, Nombre, TipoComponente, Estado ");
                            query.AppendLine("from Componente ");
                            query.AppendLine("inner join GrupoPermisoComponente on Componente.IdComponente = GrupoPermisoComponente.IdComponente ");
                            query.AppendLine("where IdGrupoPermiso = @IdComponente");

                            SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                            cmd.Parameters.AddWithValue("IdComponente", componenteGrupoPermiso.IdComponente);

                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                Componente componenteDiferenciado = new Componente()
                                {
                                    IdComponente = Convert.ToInt32(dr["IdComponente"]),
                                    Nombre = dr["Nombre"].ToString(),
                                    TipoComponente = dr["TipoComponente"].ToString(),
                                    Estado = Convert.ToBoolean(dr["Estado"])
                                };
                                listaComponentes.Add(componenteDiferenciado);
                            }
                            DataAccessObject.CerrarConexion();
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Hay un error en la base de datos " + ex.Message);
                        }
                    }
                }

                listaPermisoComponente.Clear();
                listaGrupoPermisoComponente.Clear();

            }
            while (listaComponentes.Count != 0) ;

            return listaPermisos;
        }
    }
}
