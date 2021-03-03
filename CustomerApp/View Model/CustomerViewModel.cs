using CustomerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.ViewModels
{
    public class CustomerViewModel
    {
        public Customer customer { get; set; }
        public List<ValidationResult> errors { get; set; }
        public CustomerViewModel() //this is a constructor, will have same name as class.
        {
            customer = new Customer();
            errors = new List<ValidationResult>();
        }
    }
}
