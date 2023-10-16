using DemoWebAPI_02.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI_02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserroleController : ControllerBase
    {
        // khai bao db
        private readonly f8dbContext dbContext;
        // constructor
        public UserroleController(f8dbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        // http
        // get 
        [HttpGet("/GetAllUserRoles")]
        public ActionResult<IEnumerable<Userrole>> Get() 
        {
            var userroles = dbContext.Userroles.ToList();
            return Ok(userroles);
        }
    }
}
