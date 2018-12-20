using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi_DotNetCore.DAL;
using WebApi_DotNetCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace WebApi_DotNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Vote>> Get()
        {

            var context = new ApplicationDBContext();
            var votes = await context.Votes.ToListAsync();

            context.Dispose();
            return votes;
        }

        // GET api/values/5
        [HttpGet("{id:int}")]
        public ActionResult<Vote> Get(int id)
        {
            var context = new ApplicationDBContext();
            var vote = context.Votes.Where(x => x.Id == id).FirstOrDefault();

            context.Dispose();

            return vote;
        }

        // POST api/values
        [HttpPost]
        [Produces(typeof(Vote))]
        public ActionResult Post([FromBody] Vote value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var context = new ApplicationDBContext();
            context.Votes.Add(value);
            context.SaveChanges();
            context.Dispose();

            return CreatedAtAction("Get", new { id = value.Id}, value.Id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
