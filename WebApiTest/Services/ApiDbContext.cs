using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiTest.Entities;

namespace WebApiTest.Services
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions options) : base(options) {
            
        }
        
        public DbSet<ApiItem> Aspirantes { get; set; }
    }
}
