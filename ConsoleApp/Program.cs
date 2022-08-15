using ConsoleApp.Models;

namespace ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            /*ProductoHandler prod = new ProductoHandler();
            
            List<Producto> lista = prod.GetProducto();

            foreach(Producto p in lista)
            {
                Console.WriteLine(p.Id.ToString()+ "    " + p.Descripciones.ToString());
            }*/


            UsuarioHandler usu = new UsuarioHandler();

            List<Usuario> lista = usu.GetUsuario();

            foreach (Usuario u in lista)
            {
                Console.WriteLine(u.Id.ToString() + "   " + u.Nombre.ToString());
            }
        }
    }



}