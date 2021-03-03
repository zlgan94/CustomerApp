using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using CustomerApp.Models;
using CustomerApp.DbContext1;
using System.ComponentModel.DataAnnotations;
using CustomerApp.ViewModels;
using Microsoft.AspNetCore.Cors;

namespace CustomerApp.Controllers
{
    //CORS :- Cross Origin Resource Sharing
    [EnableCors("MyPolicy")]
    public class CustomerController : Controller
    {
        CustomerDbContext custDbContext = null;
        public CustomerController(CustomerDbContext _custDbContext)
        {
            custDbContext = _custDbContext;
        }

        int i = 0;
        public IActionResult AddScreen() //Display the screen
        {
            //Get the current value
            if (HttpContext.Session.GetInt32("variablei") != null)
            {
                i = (int)HttpContext.Session.GetInt32("variablei");
            }
            i++; //Do your operation
            HttpContext.Session.SetInt32("variablei", i); //Send to the browser to store it in cookies

            return View("CustomerAdd", new CustomerViewModel()); //Customerview model is null everything will crash from here so need to pass empty CVM
        }
        public IActionResult SearchScreen() //Display the Search Screen
        {
            return View("DisplayCustomer");
        }
        public IActionResult Search(string customerName)  //Execute the Search Query
        {

            //LINQ Query - FROM, WHERE, SELECT
            List<Customer> custs = (from temp in custDbContext.Customers //FROM source 
                                    where temp.customerName == customerName
                                    select temp).ToList<Customer>(); //Give it back to list of collection

            return View("DisplayCustomer", custs);
        }

        //       public IActionResult Add([FromBody] Customer obj) //Adds to DB using EF core
        //        {
        //            //Customer obj = new Customer();
        //            //obj.customerName = Request.Form["txtcustomerName"];// custom mapping
        //            //obj.address = Request.Form["txtaddress"];

        //            //we would need to check validation
        //           var context = new ValidationContext(obj, null, null);
        //        var errorresult = new List<ValidationResult>();
        //        var check = Validator.TryValidateObject(obj,
        //            context,
        //            errorresult, true);

        //            if (check)
        //            //The ModelState represents a collection of name and value pairs that were submitted to the server during a POST. 
        //            //It also contains a collection of error messages for each value submitted
        //            {
        //                //adding data           

        //                custDbContext.Customers.Add(obj);
        //                custDbContext.SaveChanges();

        //                List<Customer> custs = custDbContext.Customers.ToList<Customer>();
        //                return StatusCode(StatusCodes.Status200OK, custs);
        //    }
        //            else
        //            {
        //                //get all the records from table and load to the list
        //                //select call to the table
        //                CustomerViewModel custvm = new CustomerViewModel();
        //    custvm.customer = obj;
        //                custvm.errors = errorresult;
        //                //return View("CustomerAdd", custvm);
        //                return StatusCode(StatusCodes.Status500InternalServerError, errorresult);

        //}
        //        }
        //    }
    }
}
