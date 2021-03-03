using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CustomerApp.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required] //data annotation > customername is required
        public string? customerName { get; set; }
        [Required] //data annotation > address is required
        public string address { get; set; }

        public List<Product> products { get; set; }

    }
}
