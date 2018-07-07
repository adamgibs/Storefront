using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreFront.Models
{
    public class Product
    {

        public Int64 Id { get; set; }
        public string Name { get; set;}
        public Decimal Price { get; set; }
        public Boolean Import { get; set;}
        public Boolean Exempt { get; set; } 

    }
}
