using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Reporte
    {
        public List<ReportePresupuesto> ListarReportePresupuesto(string fechaInicio, string fechaFin)
        {
            List<ReportePresupuesto> lista = new List<ReportePresupuesto>();

            using (SqlConnection conexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    SqlCommand cmd = new SqlCommand("SP_ReportePresupuesto", conexion);

                    //PARAMETROS DE ENTRADA
                    cmd.Parameters.AddWithValue("FechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("FechaFin", fechaFin);

                    //EJECUTAR COMANDO
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        lista.Add(new ReportePresupuesto
                        {
                            NumeroPresupuesto = dr["NumeroPresupuesto"].ToString(),
                            NombreCliente = dr["NombreCompleto"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Direccion = dr["Direccion"].ToString(),
                            Localidad = dr["Localidad"].ToString(),
                            MontoTotal = Convert.ToDecimal(dr["MontoTotal"]),
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"]),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                    }
                }
                catch (Exception ex)
                {
                    lista = new List<ReportePresupuesto>();
                }
            }
            DataAccessObject.CerrarConexion();

            return lista;
        }
    }
}
