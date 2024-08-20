using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Negocio
{
    public class ProductsApi
    {
        public List<Product> getAll()
        {
            return new List<Product>();
        }
        public Product Create(string Name, int Price)
        {
            Random random = new Random();
            int randomId = random.Next(0, 100);
            string name = Name;
            int price = Price;
            Product product = new Product(price, name, randomId);

            return product;
        }

        /*
        public Product GetById(int id)
        {
            return new Product();
        }

        public Product Update(int id)
        {
            return new Product();
        }

        public Product Delete(int id)
        {
            return new Product();
        }
        */
    }
}
