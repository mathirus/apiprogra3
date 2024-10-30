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
            Datos informacion = new Datos();
            List<Product> info = informacion.GetAll();
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


        public bool Delete(int id)
        {
            return Datos.Delete(id);
        }


    }
}
