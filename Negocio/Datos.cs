using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using Dapper;


namespace Negocio
{
    public class Datos
    {

        public string myConnectionString = "Server=sql10.freemysqlhosting.net;Database=sql10741376;Uid=sql10741376;Pwd=vqRiz5UenI;";

        public static List<Product> productos = new List<Product>();

        public List<Product> GetAll()
        {
            List<Product> productos = new List<Product>();

            using (MySqlConnection conn = new MySqlConnection(myConnectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Products";
                productos = conn.Query<Product>(sql).ToList();
            }
                        
            return productos;
        }


        public static Product Create(string Name, int Price)
        {
            Random random = new Random();
            int randomId = random.Next(0, 100);
            string name = Name;
            string description = Name;
            string category = Name;
            decimal price = Price;
            Product product = new Product(randomId, name, description, category , price);

            productos.Add(product);

            return product;
        }

       public static Product GetById(int Id)
       {
            Product product =  Datos.FindById(Id);
            return product;
       }

        public static Product? Update(int Id, string Title, int Price)
        {
            Product product = Datos.FindById(Id); product.Title = Title;
            if (product == null)
            {
                return null;
            }

            product.Title = Title;
            product.Price = Price;    
            return product;
        }
        public static bool Delete(int Id)
        {
            Product? product = FindById(Id);
            if (product == null)
            {
                return false; // Producto no encontrado
            }

            productos.Remove(product);
            return true; // Producto eliminado
        }

        private static Product? FindById(int Id)
        {
            return productos.FirstOrDefault(p => p.Id == Id);
        }

    }
}
