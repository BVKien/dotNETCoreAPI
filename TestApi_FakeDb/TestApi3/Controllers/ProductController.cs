using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestApiFakeDB.Models;

namespace TestApiFakeDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Kien", Year = 2002},
            new Product { Id = 2, Name = "Bui", Year = 2002},
            new Product { Id = 3, Name = "Van", Year = 2002},
            new Product { Id = 4, Name = "Dep Zai", Year = 2002}
        };

        [HttpGet("/GetAll")]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(products);
        }

        // Get/Read
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        // Post/Add
        [HttpPost]
        public ActionResult<Product> AddProduct(Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            product.Id = products.Count + 1;
            products.Add(product);
            return Ok(product);
        }

        // Put/Update
        [HttpPut("{id}")]
        public ActionResult Put(int id, Product updateProduct)
        {
            var exitingProduct = products.FirstOrDefault(p => p.Id == id);

            if(exitingProduct == null)
            {
                return NotFound();
            }

            exitingProduct.Name = updateProduct.Name;
            exitingProduct.Year = updateProduct.Year;

            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound(product);
            }

            products.Remove(product);

            return NoContent();
        }

    }
}
