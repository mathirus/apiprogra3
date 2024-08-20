using System;

namespace Negocio
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }

        public Product(int Price, string Name, int Id)
        {
            this.Price = Price;
            this.Name = Name;
            this.Id = Id;
        }
    }
}