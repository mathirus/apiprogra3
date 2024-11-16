namespace Negocio
{
    public class ProductsApi
    {
        private Datos datos = new Datos();

        public List<Product> getAll()
        {
            return datos.GetAll();
        }

        public Product Create(string Name, int Price)
        {
            return datos.Create(Name, Price);
        }

        public Product GetById(int id)
        {
            return datos.GetById(id);
        }

        public Product Update(int id, string Name, int Price)
        {
            return datos.Update(id, Name, Price);
        }

        public bool Delete(int id)
        {
            return datos.Delete(id);
        }
    }
}
