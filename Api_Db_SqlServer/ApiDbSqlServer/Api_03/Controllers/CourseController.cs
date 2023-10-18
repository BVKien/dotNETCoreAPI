/*
using Api_03.Models;
using Api_03.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_03.Repositories;

namespace Api_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly CourseRepository repository;

        public CourseController(CourseRepository repository)
        {
            this.repository = repository;
        }

        // get / all courses
        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            var courses = repository.GetCourses();
            return Ok(courses);
        }

    }
}
*/

using Api_03.DTO;
using Api_03.Models;
using Api_03.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly ApiDB_03Context db;

        private readonly CourseRepository repository;

        public CourseController(CourseRepository repository)
        {
            this.repository = repository;
        }

        // GET: api/course
        [HttpGet]
        public ActionResult<IEnumerable<Course>> Get()
        {
            var courses = repository.GetCourses();

            // Set the response header to allow requests from http://localhost:3000
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            // end

            return Ok(courses);
        }

        // GET: api/course/{id}
        [HttpGet("{id}")]
        public ActionResult<Course> GetById(int id)
        {
            var course = repository.GetCourseById(id);

            if (course == null)
            {
                return NotFound(); // Trả về 404 Not Found nếu không tìm thấy
            }

            return Ok(course);
        }

        /*
        // POST: api/course
        [HttpPost]
        public ActionResult<Course> Post([FromBody] Course course)
        {
            if (course == null)
            {
                return BadRequest("Invalid data"); // Trả về lỗi BadRequest nếu dữ liệu không hợp lệ
            }

            // Thêm khóa học mới vào cơ sở dữ liệu
            repository.AddCourse(course);
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }
        */

        [HttpPost]
        public ActionResult<Course> Post([FromBody] CourseDTO courseDto)
        {
            if (courseDto == null)
            {
                return BadRequest("Invalid data");
            }

            // Tạo mới đối tượng Course từ DTO
            var course = new Course
            {
                Id = courseDto.Id,
                Name = courseDto.Name,
                Category = courseDto.Category,
                //Category = courseDto.Category
            };

            // Thêm khóa học mới vào cơ sở dữ liệu
            repository.AddCourse(course);

            // Trả về mã 201 Created và đường dẫn đến khóa học vừa tạo
            return CreatedAtAction(nameof(GetById), new { id = course.Id }, course);
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var course = repository.GetCourseById(id);

            if (course == null)
            {
                return NotFound(); // Trả về mã 404 Not Found nếu không tìm thấy khóa học
            }

            repository.DeleteCourse(course);
            return NoContent(); // Trả về mã 204 No Content sau khi xóa thành công
        }

        /*
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] CourseDTO courseDto)
        {
            if (courseDto == null || id != courseDto.Id)
            {
                return BadRequest("Invalid data");
            }

            var existingCourse = repository.GetCourseById(id);

            if (existingCourse == null)
            {
                return NotFound(); // Trả về mã 404 Not Found nếu không tìm thấy khóa học
            }

            // Cập nhật thông tin của khóa học từ DTO
            existingCourse.Id = courseDto.Id;
            existingCourse.Name = courseDto.Name;
            existingCourse.Category = courseDto.Category;

            // Lấy Category theo CategoryName (giữ nguyên nếu không tìm thấy)
            //var category = db.Categories.FirstOrDefault(c => c.Name == courseDto.CategoryName);
            //if (category != null)
            //{
            //    existingCourse.Category = category.Id;
            //}

            repository.UpdateCourse(existingCourse);

            return NoContent(); // Trả về mã 204 No Content sau khi cập nhật thành công
        }
        */

        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] CourseDTO courseDto)
        {
            if (courseDto == null || id != courseDto.Id)
            {
                return BadRequest("Invalid data");
            }

            var existingCourse = repository.GetCourseById(id);

            if (existingCourse == null)
            {
                return NotFound(); // Trả về mã 404 Not Found nếu không tìm thấy khóa học
            }

            existingCourse.Id = courseDto.Id;
            existingCourse.Name = courseDto.Name;
            existingCourse.Category = courseDto.Category;

            repository.UpdateCourse(existingCourse);

            return NoContent(); // Trả về mã 204 No Content sau khi cập nhật thành công
        }

    }
}

/*
 * namespace Api_03.Controllers
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

        //// http
        //// get all 
        //[HttpGet]
        //public ActionResult<IEnumerable<Course>> Get()
        //{
        //    var course = db.Courses.ToList();
        //    return Ok(course);
        //}

        // get / all

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
        public ActionResult<Course> Post([FromBody] Course course)
        {
            // check null -> bad request 
            if(course == null || !ModelState.IsValid) return BadRequest("Invalid data");

            //// add
            //course.Id = db.Courses.Count() + 1;
            db.Add(course);
            db.SaveChanges();

            return Ok(course);
        }

    }
}
 */