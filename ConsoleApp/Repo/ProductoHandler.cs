using ConsoleApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp
{
    public class ProductoHandler : DBHandler
    {
    
        public List<Producto> GetProducto()
        {
            List<Producto> products = new List<Producto>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM PRODUCTO";
                
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Producto producto = new Producto();
                                producto.Id = Convert.ToInt32(dr["Id"]);
                                producto.Descripciones = Convert.ToString(dr["Descripciones"]);
                                producto.Costo = Convert.ToDouble(dr["Costo"]);
                                producto.PrecioVenta = Convert.ToDouble(dr["PrecioVenta"]);
                                producto.Stock = Convert.ToInt32(dr["Stock"]);
                                producto.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);

                                products.Add(producto);
                            }
                        }
                    }
                    conn.Close();
                }
            }

            return products;
        }


    }

}

