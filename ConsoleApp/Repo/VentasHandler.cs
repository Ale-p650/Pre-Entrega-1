using ConsoleApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp
{
    public class VentasHandler : DBHandler
    {
        public List<Venta> GetVentas()
        {
            List<Venta> ventas = new List<Venta>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM VENTA";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Venta venta = new Venta();
                                venta.Id = Convert.ToInt32(dr["Id"]);


                                ventas.Add(venta);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            return ventas;
        }
    }
}
