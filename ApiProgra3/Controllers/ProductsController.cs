using Microsoft.AspNetCore.Mvc;
using Negocio;
using System.Xml.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiProgra3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        ProductsApi productsApi = new Negocio.ProductsApi();

        // GET: api/<ValuesController>
        [HttpGet]
        public List<Product> Get()
        {
            return productsApi.getAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Product product = productsApi.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }



        // POST api/<ValuesController>
        [HttpPost]
        public Product Post(string name,int price)
        {
            
            return productsApi.Create(name, price);

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, string name, int price)
        {
            Product product = productsApi.Update(id,name,price);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool isDeleted = productsApi.Delete(id);
            if (!isDeleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
