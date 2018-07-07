using Microsoft.EntityFrameworkCore;
using StoreFront.Models;

namespace StoreFront.Data
{
    public class StoreFrontContext : DbContext
    {
      

        
            public StoreFrontContext(DbContextOptions<StoreFrontContext> options) : base(options) { }

            
            public DbSet<Product> Product { get; set; }
         

            


        
    }
}

