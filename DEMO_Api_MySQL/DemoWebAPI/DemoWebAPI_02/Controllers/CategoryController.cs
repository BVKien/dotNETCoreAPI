using DemoWebAPI_02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        // khai bao db
        private readonly f8dbContext dbContext;
        // constructor
        public CategoryController(f8dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // http 
        // get all category
        [HttpGet("/GetAllCategories")]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var categories = dbContext.Categories.ToList();
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            return Ok(categories);
        }
    }
}
