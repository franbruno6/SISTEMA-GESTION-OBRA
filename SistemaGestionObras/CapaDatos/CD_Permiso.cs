using CapaEntidad;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace CapaDatos
{
    public class CD_Permiso
    {
        public List<Permiso> ListarPermisos(int idUsuario)
        {
            List<Componente> listaComponentes = new List<Componente>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select Componente.IdComponente, Nombre, TipoComponente, Estado ");
                    query.AppendLine("from UsuarioComponente ");
                    query.AppendLine("inner join Componente on UsuarioComponente.IdComponente = Componente.IdComponente ");
                    query.AppendLine("where UsuarioComponente.IdUsuario = @IdUsuario");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.Parameters.AddWithValue("IdUsuario", idUsuario);
                    cmd.CommandType = CommandType.Text;

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
                }
                catch (Exception ex)
                {
                    List<Permiso> listaPermisos = new List<Permiso>();
                    DataAccessObject.CerrarConexion();
                    return listaPermisos;
                }
            }
            DataAccessObject.CerrarConexion();
            return DiferenciarComponentes(listaComponentes);
        }
        private List<Permiso> DiferenciarComponentes(List<Componente> listaComponentes)
        {
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
                    using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
                    {
                        DataAccessObject.ObtenerConexion();
                        try
                        {
                            StringBuilder query = new StringBuilder();
                            query.AppendLine("select IdPermiso, NombreMenu ");
                            query.AppendLine("from Permiso ");
                            query.AppendLine("inner join Componente on Permiso.IdComponente = Componente.IdComponente ");
                            query.AppendLine("where Permiso.IdComponente = @IdComponente");

                            SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                            cmd.Parameters.AddWithValue("IdComponente", componentePermiso.IdComponente);

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
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Hay un error en la base de datos " + ex.Message);
                        }
                        DataAccessObject.CerrarConexion();
                    }
                }

                foreach (Componente componenteGrupoPermiso in listaGrupoPermisoComponente)
                {
                    string idGrupoPermiso = "";
                    using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
                    {
                        DataAccessObject.ObtenerConexion();
                        try
                        {
                            StringBuilder query = new StringBuilder();
                            query.AppendLine("select GrupoPermiso.IdGrupoPermiso, Nombre ");
                            query.AppendLine("from GrupoPermiso ");
                            query.AppendLine("inner join Componente on GrupoPermiso.IdComponente = Componente.IdComponente ");
                            query.AppendLine("where GrupoPermiso.IdComponente = @IdComponente");

                            SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                            cmd.Parameters.AddWithValue("IdComponente", componenteGrupoPermiso.IdComponente);

                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                idGrupoPermiso = dr["IdGrupoPermiso"].ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            throw new Exception("Hay un error en la base de datos " + ex.Message);
                        }
                        DataAccessObject.CerrarConexion();
                    }
                    using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
                    {
                        DataAccessObject.ObtenerConexion();
                        try
                        {
                            StringBuilder query = new StringBuilder();
                            query.AppendLine("select Componente.IdComponente, Nombre, TipoComponente, Estado ");
                            query.AppendLine("from Componente ");
                            query.AppendLine("inner join GrupoPermisoComponente on GrupoPermisoComponente.IdComponente = Componente.IdComponente ");
                            query.AppendLine("where GrupoPermisoComponente.IdGrupoPermiso = @IdGrupoPermiso ");

                            SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                            cmd.Parameters.AddWithValue("IdGrupoPermiso", idGrupoPermiso);

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
                        DataAccessObject.CerrarConexion();
                    }
                }

                listaPermisoComponente.Clear();
                listaGrupoPermisoComponente.Clear();

            }
            while (listaComponentes.Count != 0);

            return listaPermisos;
        }
        //public List<Permiso> ListarPermisosCompleta()
        //{
        //    List<Permiso> listaPermisos = new List<Permiso>();

        //    using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
        //    {
        //        DataAccessObject.ObtenerConexion();
        //        try
        //        {
        //            StringBuilder query = new StringBuilder();
        //            query.AppendLine("select IdPermiso, NombreMenu, ");
        //            query.AppendLine("Componente.IdComponente, Nombre, TipoComponente, Estado");
        //            query.AppendLine("from Permiso ");
        //            query.AppendLine("inner join Componente on Permiso.IdComponente = Componente.IdComponente ");

        //            SqlCommand cmd = new SqlCommand(query.ToString(), conexion);

        //            SqlDataReader dr = cmd.ExecuteReader();
        //            while (dr.Read())
        //            {
        //                Permiso permiso = new Permiso()
        //                {
        //                    IdComponente = Convert.ToInt32(dr["IdComponente"]),
        //                    Nombre = dr["Nombre"].ToString(),
        //                    TipoComponente = dr["TipoComponente"].ToString(),
        //                    Estado = Convert.ToBoolean(dr["Estado"]),
        //                    IdPermiso = Convert.ToInt32(dr["IdPermiso"]),
        //                    NombreMenu = dr["NombreMenu"].ToString()
        //                };
        //                listaPermisos.Add(permiso);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new Exception("Hay un error en la base de datos " + ex.Message);
        //        }
        //    }
        //    DataAccessObject.CerrarConexion();
        //    return listaPermisos;
        //}
    }
}
