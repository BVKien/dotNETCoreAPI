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

        [HttpGet]
        public ActionResult<IEnumerable<CourseDTO>> Get()
        {
            var courses = repo.GetAll();
            return Ok(courses);
        }
    }
}