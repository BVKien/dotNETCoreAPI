using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api1.Models;
using Microsoft.EntityFrameworkCore;

namespace Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        // khai bao db
        private readonly ApiDBContext dbcontext;

        // tao constructor
        public ProductController(ApiDBContext context)
        {
            dbcontext = context;
        }

        // code function

        // Get / Read All 
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            var products = dbcontext.Products.ToList();
            return Ok(products);
        }

        // Get / Read
        [HttpGet("{id}")]
        public ActionResult<Product> GetProductById(int id)
        {
            var product = dbcontext.Products.Find(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        // Post / Add
        [HttpPost]
        public ActionResult<Product> Post(Product product)
        {
            if(product == null)
                return BadRequest();

            // tang id
            product.Id = dbcontext.Products.Count() +1;
            dbcontext.Products.Add(product);
            dbcontext.SaveChanges();
            return Ok(product);
        }

        // Put / Update
        [HttpPut("{id}")]
        public ActionResult Put(int id, Product product) 
        {
            var recentProduct = dbcontext.Products.Find(id);
            if (recentProduct == null)
                return NotFound();

            recentProduct.Name = product.Name;
            dbcontext.SaveChanges();

            // 204
            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = dbcontext.Products.Find(id);
            if(product == null) 
                return NotFound();
            dbcontext.Products.Remove(product);
            dbcontext.SaveChanges();
            return NoContent();
        }

    }
}


/*
 HTTP Status Code 204 No Content: Điều này ngụ ý rằng yêu cầu đã được xử lý thành công và không có nội dung được trả về. 
Trong trường hợp PUT (cập nhật), đây là một cách để nói rằng dữ liệu đã được cập nhật thành công, nhưng không cần phải trả về dữ liệu đã được cập nhật.

Cần trả về gì nếu không dùng NoContent(): Nếu không trả về NoContent(), 
một lựa chọn khác có thể là trả về đối tượng Product đã được cập nhật (hoặc một phiên bản mới của nó). 
Tuy nhiên, trong nhiều trường hợp, khi đã xác nhận rằng cập nhật thành công, không cần thiết phải trả lại dữ liệu đã cập nhật.

Việc sử dụng NoContent() cho phương thức PUT cũng giúp tối ưu tài nguyên mạng bởi vì không cần gửi lại dữ liệu đã được cập nhật nếu client không cần thiết.
 */