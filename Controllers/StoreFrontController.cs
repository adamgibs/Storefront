using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StoreFront.Data;
using StoreFront.Logic;
using StoreFront.Models;


namespace StoreFront.Controllers
{
    [Route("api/[controller]")]
    public class StoreFrontController : ControllerBase
    {
        private readonly StoreFrontContext _context;

        public StoreFrontController(StoreFrontContext context)
        {
            _context = context;


        }
        
        //GET
        [HttpGet]
        public List<Product> GetAll()
        {
            return _context.Product.ToList();
        }

        //POST
        [HttpPost]
        public IActionResult Post([FromBody]Product[] products)
        {
            Order order = new Order(products);

            return new JsonResult(order);
        }

        
    }
}
