using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace Negocio
{
    public class ProductsApi
    {
        
        public List<Product> getAll()
        {
            List<Product> info = Datos.GetAll();
            return info;
        }
        public Product Create(string Name, int Price)
        {
            Product product = Datos.Create(Name,Price); 

            return product;
        }

        
        public Product GetById(int id)
        {
            Product product = Datos.GetById(id);

            return product;
        }
        
        public Product Update(int id, string Name, int Price)
        {
            Product product = Datos.Update(id, Name, Price);

            return product;
        }
        
        /*
        public Product Delete(int id)
        {
            return new Product();
        }*/
        
    }
}
