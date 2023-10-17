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

        // get by id 
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            // find course by id
            var course = db.Courses.Find(id);
            // check null
            if (course == null) return NotFound();
            // return 
            return Ok(course);
        }

        // delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // find course by id 
            var course = db.Courses.Find(id);
            // check null
            if (course == null) return NotFound(course);
            db.Courses.Remove(course);
            db.SaveChanges();
            return NoContent();
        }

        // update
        [HttpPut("{id}")]
        public ActionResult Put(int id, Course updateCourse)
        {
            var curCourse = db.Courses.Find(id);
            if (curCourse == null) return NotFound();

            curCourse.Id = updateCourse.Id;
            curCourse.Name = updateCourse.Name;
            db.SaveChanges();

            // return 204
            return NoContent();
        }

        // add
        [HttpPost]
        public ActionResult<Course> Post(Course course)
        {
            // check null -> bad request 
            if(course == null) return BadRequest();

            // add
            course.Id = db.Courses.Count() + 1;
            db.Add(course);
            db.SaveChanges();

            return Ok(course);
        }

    }
}
