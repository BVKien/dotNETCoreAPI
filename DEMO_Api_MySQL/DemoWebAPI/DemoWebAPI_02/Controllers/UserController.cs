using DemoWebAPI_02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoWebAPI_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // initialize db context 
        private readonly f8dbContext dbContext;

        // constructor for controllers
        public UserController(f8dbContext f8dbContext)
        {
            this.dbContext = f8dbContext;
        }

        // Http
        // get all
        [HttpGet("/GetAllUsers")]
        public ActionResult<IEnumerable<User>> Get()
        {
            var users = dbContext.Users.ToList();

            // new
            // Set the response header to allow requests from http://localhost:3000
            Response.Headers.Add("Access-Control-Allow-Origin", "http://localhost:3000");
            // end new 

            return Ok(users);
            //return Ok(courses).WithHeaders(new { Access_Control_Allow_Origin = "http://localhost:3000" });
        }
    }
}