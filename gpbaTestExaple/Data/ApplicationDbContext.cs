using gpbaTestExaple.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace gpbaTestExaple.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
