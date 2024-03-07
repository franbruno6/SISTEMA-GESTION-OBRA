using CapaEntidad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Producto
    {
        public List<Producto> ListarProductos()
        {
            List<Producto> listaProductos = new List<Producto>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select IdProducto, Codigo, Nombre, Descripcion, Categoria, Precio, Estado ");
                    query.AppendLine("from Producto ");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Producto producto = new Producto();
                        producto.IdProducto = Convert.ToInt32(dr["IdProducto"]);
                        producto.Codigo = dr["Codigo"].ToString();
                        producto.Nombre = dr["Nombre"].ToString();
                        producto.Descripcion = dr["Descripcion"].ToString();
                        producto.Categoria = dr["Categoria"].ToString();
                        producto.Precio = Convert.ToDecimal(dr["Precio"]);
                        producto.Estado = Convert.ToBoolean(dr["Estado"]);

                        listaProductos.Add(producto);
                    }
                }
                catch (Exception ex)
                {
                    listaProductos = new List<Producto>();
                }
            }
            DataAccessObject.CerrarConexion();
            return listaProductos;
        }
        public int AgregarProducto(Producto oProducto, out string mensaje)
        {
            int idProductoRegistrado = 0;
            mensaje = string.Empty;

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_RegistrarProducto", conexion);

                    //PARAMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("Nombre", oProducto.Nombre);
                    cmd.Parameters.AddWithValue("Codigo", oProducto.Codigo);
                    cmd.Parameters.AddWithValue("Descripcion", oProducto.Descripcion);
                    cmd.Parameters.AddWithValue("Categoria", oProducto.Categoria);
                    cmd.Parameters.AddWithValue("Precio", oProducto.Precio);
                    cmd.Parameters.AddWithValue("Estado", oProducto.Estado);

                    //PARAMETRO DE SALIDA
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 400).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("idProductoRegistrado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    //TIPO DE COMANDO
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    idProductoRegistrado = Convert.ToInt32(cmd.Parameters["idProductoRegistrado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    idProductoRegistrado = 0;
                    mensaje = ex.Message;
                }
            }
            DataAccessObject.CerrarConexion();
            return idProductoRegistrado;
        }
        public bool EditarProducto(Producto oProducto, out string mensaje)
        {
            bool productoEditado = false;
            mensaje = string.Empty;

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_EditarProducto", conexion);

                    //PARAMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("IdProducto", oProducto.IdProducto);
                    cmd.Parameters.AddWithValue("Nombre", oProducto.Nombre);
                    cmd.Parameters.AddWithValue("Codigo", oProducto.Codigo);
                    cmd.Parameters.AddWithValue("Descripcion", oProducto.Descripcion);
                    cmd.Parameters.AddWithValue("Categoria", oProducto.Categoria);
                    cmd.Parameters.AddWithValue("Precio", oProducto.Precio);
                    cmd.Parameters.AddWithValue("Estado", oProducto.Estado);
                    //PARAMETRO DE SALIDA
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 400).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    //TIPO DE COMANDO
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    productoEditado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    productoEditado = false;
                    mensaje = ex.Message;
                }
            }
            DataAccessObject.CerrarConexion();
            return productoEditado;
        }
        public bool EliminarProducto(int idProducto, out string mensaje)
        {
            bool productoEliminado = false;
            mensaje = string.Empty;

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_EliminarProducto", conexion);

                    //PARAMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("IdProducto", idProducto);
                    //PARAMETRO DE SALIDA
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 400).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    //TIPO DE COMANDO
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.ExecuteNonQuery();

                    productoEliminado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
                catch (Exception ex)
                {
                    productoEliminado = false;
                    mensaje = ex.Message;
                }
            }
            DataAccessObject.CerrarConexion();
            return productoEliminado;
        }
        public List<string> ListarCategorias()
        {
            List<string> lista = new List<string>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select distinct Categoria from Producto");

                    SqlCommand cmd = new SqlCommand(query.ToString(), conexion);
                    cmd.CommandType = CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(dr["Categoria"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                DataAccessObject.CerrarConexion();
            }
            return lista;
        }
    }
}
