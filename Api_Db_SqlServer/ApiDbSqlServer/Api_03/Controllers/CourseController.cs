using Api_03.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ApiDB_03Context db;
        public CourseController(ApiDB_03Context db)
        {
            this.db = db;
        }
        // http
        // get all 
        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get() 
        {
            var course = db.Courses.ToList();
            return Ok(course);
        }
    }
}
