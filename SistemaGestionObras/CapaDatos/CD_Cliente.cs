using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Cliente
    {
        public List<Cliente> ListarClientes()
        {
            List<Cliente> listaClientes = new List<Cliente>();

            using (SqlConnection connexion = DataAccessObject.ObtenerConexion())
            {
                DataAccessObject.ObtenerConexion();
                try
                {
                    StringBuilder query = new StringBuilder();
                    query.AppendLine("select Persona.IdPersona, NombreCompleto, Correo, Documento,");
                    query.AppendLine("IdCliente, Telefono, Direccion, Estado ");
                    query.AppendLine("from Persona ");
                    query.AppendLine("inner join Cliente on Persona.IdPersona = Cliente.IdPersona");

                    SqlCommand cmd = new SqlCommand(query.ToString(), connexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Cliente cliente = new Cliente();
                        cliente.IdCliente = Convert.ToInt32(dr["IdCliente"]);
                        cliente.IdPersona = Convert.ToInt32(dr["IdPersona"]);
                        cliente.NombreCompleto = dr["NombreCompleto"].ToString();
                        cliente.Correo = dr["Correo"].ToString();
                        cliente.Documento = dr["Documento"].ToString();
                        cliente.Telefono = dr["Telefono"].ToString();
                        cliente.Direccion = dr["Direccion"].ToString();
                        cliente.Estado = Convert.ToBoolean(dr["Estado"]);

                        listaClientes.Add(cliente);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            DataAccessObject.CerrarConexion();
            return listaClientes;
        }
    }
}
