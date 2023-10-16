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
        [HttpGet("/GetAllCourses")]
        public ActionResult<IEnumerable<Course>> Get()
        {
            var courses = dbContext.Courses.ToList();

            // Set the response header to allow requests from http://localhost:3000
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");

            return Ok(courses);
            //return Ok(courses).WithHeaders(new { Access_Control_Allow_Origin = "http://localhost:3000" });
        }

        // get course by id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            // find id
            var course = dbContext.Courses.Find(id);

            // check null
            if (course == null) return NotFound();

            // Set the response header to allow requests from http://localhost:3000
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");

            return Ok(course);
        }

        // add new course
        [HttpPost]
        public ActionResult Post(Course course)
        {
            // check null -> bad request
            if (course == null) return BadRequest();
            // tang id
            course.CourseId = dbContext.Courses.Count() + 1;
            // add
            dbContext.Add(course);
            // save changes to database 
            dbContext.SaveChanges();
            return Ok(course);
        }

        // update 
        [HttpPut("{id}")]
        public ActionResult Put(int id, Course course)
        {
            // khoi tao de tim course hien tai bang id
            var recentCourse = dbContext.Courses.Find(id);
            // check null
            if (recentCourse == null) return NotFound();

            // update cac properties tai recentCourse bang properties cua course vua duoc update thong tin
            recentCourse.Name = course.Name;
            recentCourse.Image = course.Image;
            recentCourse.CourseInfo = course.CourseInfo;
            recentCourse.Description = course.Description;
            recentCourse.Status = course.Status;
            recentCourse.UserUserId = course.UserUserId;
            recentCourse.CategoryCategoryId = course.CategoryCategoryId;
            recentCourse.FeeStatus = course.FeeStatus;
            recentCourse.VideoIntro = course.VideoIntro;
            // save change 
            dbContext.SaveChanges();

            // tra ve 204 No Content – Trả về khi Resource xoá thành công.
            return NoContent();
        }

        // delete 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // tim course co id 
            var course = dbContext.Courses.Find(id);
            // check null 
            if (course == null) return NotFound();
            // remove 
            dbContext.Courses.Remove(course);
            // save changes 
            dbContext.SaveChanges();
            return NoContent();
        }

    }
}

/*
        public int CourseId { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
        public string? CourseInfo { get; set; }
        public string? Description { get; set; }
        public int? Status { get; set; }
        public int UserUserId { get; set; }
        public int CategoryCategoryId { get; set; }
        public int? FeeStatus { get; set; }
        public string? VideoIntro { get; set; }
 */
