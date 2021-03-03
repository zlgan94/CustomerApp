using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CustomerApp.DbContext1;
using CustomerApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CustomerApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAPIController : ControllerBase
    {
        CustomerDbContext custDbContext = null;
        public CustomerAPIController(CustomerDbContext _custDbContext, IConfiguration configuration)
        {
            custDbContext = _custDbContext;
            string str = configuration["ConnString"];
        }
        // GET: api/<CustomerAPIController>
        [HttpGet]
        public IActionResult Get() //we want to do a search here
        {
            List<Customer> custs = custDbContext.
                                       Customers.ToList<Customer>();
            return Ok(custs);
        }

        // GET api/<CustomerAPIController>/5
        [HttpGet("{id}")]
        public IEnumerable<Customer> Get(string customerName)
        {
            List<Customer> custs = (from temp in custDbContext.Customers //FROM source 
                                    where temp.customerName == customerName
                                    select temp).ToList<Customer>(); //Give it back to list of collection
            return custs;
        }

        // POST api/<CustomerAPIController>
        [HttpPost]
        public IActionResult Post([FromBody] Customer obj)
        {
            var context = new ValidationContext(obj, null, null);
            var errorresult = new List<ValidationResult>();
            var check = Validator.TryValidateObject(obj,
                context,
                errorresult, true);

            if (check)
            //The ModelState represents a collection of name and value pairs that were submitted to the server during a POST. 
            //It also contains a collection of error messages for each value submitted
            {
                //adding data           

                custDbContext.Customers.Add(obj);
                custDbContext.SaveChanges();

                List<Customer> custs = custDbContext.Customers
                                       .Include(p => p.products)
                                       .ToList<Customer>();
                return Ok(custs);
            }
            else
            {

                return StatusCode(StatusCodes.Status500InternalServerError, 
                    errorresult);

            }
        }

        // PUT api/<CustomerAPIController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return "value";
        }

        // DELETE api/<CustomerAPIController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
