using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    internal class DataAccessObject
    {
        public static readonly string cadena = ConfigurationManager.ConnectionStrings["cadena_conexion"].ToString();
        private static SqlConnection conexion;
        public static SqlConnection ObtenerConexion()
        {
            try
            {
                if (conexion == null || conexion.State == ConnectionState.Closed)
                {
                    conexion = new SqlConnection(cadena);
                    conexion.Open();
                }
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en la base de datos " + ex.Message);
            }
        }
        public static void CerrarConexion()
        {
            try
            {
                if (conexion != null && conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                    conexion.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Hay un error en la base de datos " + ex.Message);
            }
        }
    }
}
