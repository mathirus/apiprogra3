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

       public static Product FindById(int Id)
        {   
            return productos.FirstOrDefault(p => p.Id == Id);

        }
    }
}
