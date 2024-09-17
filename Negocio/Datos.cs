using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Datos
    {
        public static List<Product> productos = new List<Product>();

        public static List<Product> GetAll()
        {
            return productos;
        }

        public static Product Create(string Name, int Price)
        {
            Random random = new Random();
            int randomId = random.Next(0, 100);
            string name = Name;
            int price = Price;
            Product product = new Product(price, name, randomId);

            productos.Add(product);

            return product;
        }

       public static Product GetById(int Id)
       {
            Product product =  Datos.FindById(Id);
            return product;
       }

        public static Product? Update(int Id, string Name, int Price)
        {
            Product product = Datos.FindById(Id); product.Name = Name;
            if (product == null)
            {
                return null;
            }

            product.Name = Name;
            product.Price = Price;    
            return product;
        }

        private static Product? FindById(int Id)
        {
            return productos.FirstOrDefault(p => p.Id == Id);
        }

    }
}
