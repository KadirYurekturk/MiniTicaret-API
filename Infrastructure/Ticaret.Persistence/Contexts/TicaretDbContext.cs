using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticaret.Domain.Entities;

namespace Ticaret.Persistence.Contexts
{
    public class TicaretDbContext : DbContext
    {
        public TicaretDbContext(DbContextOptions<TicaretDbContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }

        
    }
}
