using DemoWebAPI_02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        // initialize db context 
        private readonly f8dbContext dbContext;

        // constructor for controllers
        public CourseController(f8dbContext f8dbContext)
        {
            this.dbContext = f8dbContext;
        }

        // Http
        // get all
        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            var courses = dbContext.Courses.ToList();
            return Ok(courses);
        }

    }
}
