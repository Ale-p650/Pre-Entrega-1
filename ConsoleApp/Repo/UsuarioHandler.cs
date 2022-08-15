using ConsoleApp.Models;
using System.Data;
using System.Data.SqlClient;

namespace ConsoleApp
{
    public class UsuarioHandler : DBHandler
    {
        public List<Usuario> GetUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = "SELECT * FROM USUARIO";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader dr = command.ExecuteReader())
                    {
                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                Usuario usuario = new Usuario();
                                usuario.Id = Convert.ToInt32(dr["ID"]);
                                usuario.Nombre = Convert.ToString(dr["Nombre"]);
                                usuario.Apellido = Convert.ToString(dr["Apellido"]);
                                usuario.NombreUsuario = Convert.ToString(dr["NombreUsuario"]);
                                usuario.Mail = Convert.ToString(dr["Mail"]);
                                usuario.Contraseña = Convert.ToString(dr["Contraseña"]);

                                usuarios.Add(usuario);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            return usuarios;
        }
    }
}

