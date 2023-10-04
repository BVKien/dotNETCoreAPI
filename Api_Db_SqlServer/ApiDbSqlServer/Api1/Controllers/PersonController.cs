using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api1.Models;
using Microsoft.EntityFrameworkCore;

namespace Api1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        // khai bao db
        private readonly ApiDBContext dbcontext;
        // constructor 
        public PersonController(ApiDBContext context)
        {
            this.dbcontext = context;
        }
        //code function [Http] cho Api
        // Get / Read All
        [HttpGet("/AllPerson")]
        public ActionResult<IEnumerable<Person>> Get()
        {
            var persons = dbcontext.People.ToList();
            return Ok(persons);
        }

        // Get / Read / by id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            // check
            if(id == 0)
                return NotFound();
            var persons = dbcontext.People.FirstOrDefault(p => p.Id==id);
            return Ok(persons);
        }

        // Post / Add 
        [HttpPost]
        public ActionResult<Person> Post(Person person)
        {
            if (person == null)
                return BadRequest();

            // tang id
            dbcontext.People.Add(person);
            dbcontext.SaveChanges();
            return Ok(person);
        }

        // Put / Update / by id / tra ve NoContent
        [HttpPut("{id}")]
        public ActionResult Put(int id, Person updatePerson)
        {
            var recentPerson = dbcontext.People.Find(id);
            if(recentPerson == null)
                return NotFound();

            recentPerson.Name = updatePerson.Name;
            recentPerson.Age = updatePerson.Age;
            dbcontext.SaveChanges();
            return NoContent();
        }

        // Delete
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var persons = dbcontext.People.Find(id);
            if (persons == null)
                return NotFound();
            dbcontext.People.Remove(persons);
            dbcontext.SaveChanges();
            return NoContent();
        }

    }
}
