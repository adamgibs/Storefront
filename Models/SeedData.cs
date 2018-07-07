using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreFront.Data;
using System;
using System.Linq;

namespace StoreFront.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StoreFrontContext(
                serviceProvider.GetRequiredService<DbContextOptions<StoreFrontContext>>()))
            {
                // Look for any Products.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }
                
                //Populates database with default products
                context.Product.AddRange(
                     new Product
                     {
                        
                         Name = "Book",
                         Price = 12.49M,
                         Import = false,
                         Exempt = true
                     },

                    new Product
                    {
                       
                        Name = "Music CD",
                        Price = 14.99M,
                        Import = false,
                        Exempt = false
                    },

                      new Product
                      {
                          
                          Name = "Chocolate Bar",
                          Price = .85M,
                          Import = false,
                          Exempt = true
                      },

                    new Product
                    {
                        
                        Name = "Imported Box of Chocolates",
                        Price = 10.00M,
                        Import = true,
                        Exempt = true
                    },

                     new Product
                     {

                         Name = "Imported Bottle of Perfume",
                         Price = 47.5M,
                         Import = true,
                         Exempt = false
                     }, 
                     new Product
                     {
                         
                         Name = "Imported Bottle of Perfume",
                         Price = 27.99M,
                         Import = true,
                         Exempt = false
                     },
                      new Product
                      {
                          
                          Name = "Packet of Headache pills",
                          Price = 9.75M,
                          Import = false,
                          Exempt = true
                      },
                       new Product
                       {
                           
                           Name = "Bottle of Perfume",
                           Price = 18.99M,
                           Import = false,
                           Exempt = false
                       },
                       new Product
                       {

                           Name = "Box of Imported Chocolates",
                           Price = 11.25M,
                           Import = true,
                           Exempt = true
                       });
                   

                context.SaveChanges();
            }
        }
    }
}
