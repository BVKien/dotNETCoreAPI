using DemoWebAPI_03.DTO;
using DemoWebAPI_03.Models;
using DemoWebAPI_03.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DemoWebAPI_03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepository repo;
        public CourseController(ICourseRepository repo)
        {
            this.repo = repo;
        }
        // http 
        // get
        [HttpGet]
        public ActionResult<IEnumerable<CourseDTO>> GetAllCourses()
        {
            var courses = repo.GetAllCourses();
            return Ok(courses);
        }
        // get by id
        [HttpGet("{id}")]
        public ActionResult GetCourseById(int id)
        {
            var course = repo.GetCourseById(id);
            return Ok(course);
        }

        // insert 
        [HttpPost]
        public ActionResult InsertCourse([FromBody] CourseDTO courseDTO)
        {
            if (courseDTO == null) return BadRequest();
            repo.InsertCourse(courseDTO);
            // return Ok(courseDTO); // tra ve 200, cung ok nhung ko tot, ko dc goi la tieu chuan RESTful
            // tra ve 201 Created – Trả về khi một Resource được tạo thành công.
            return CreatedAtAction("GetCourseById", new { id = courseDTO.CourseId }, courseDTO);
        }

        // update
        [HttpPut("{id}")]
        public ActionResult UpdateCourse(int id, [FromBody] CourseDTO courseDTO)
        {
            // check null -> badrequest
            if(courseDTO == null || courseDTO.CourseId != id) return BadRequest();
            // get existing course by id
            var existingCourse = repo.GetCourseById(id);
            // check null existing course -> notfound
            if(existingCourse == null) return NotFound();
            // update
            repo.UpdateCourse(courseDTO);
            // return nocontent
            return NoContent();
        }

        // delete 
        [HttpDelete("{id}")]
        public ActionResult DeleteCourse(int id)
        {
            var course = repo.GetCourseById(id);
            if(course == null) return NotFound();
            repo.DeleteCourse(id);
            return NoContent();
        }

    }
}