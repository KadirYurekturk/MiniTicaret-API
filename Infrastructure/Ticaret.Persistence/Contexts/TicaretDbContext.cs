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

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries<BaseEntity>()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            //foreach (var entity in entities)
            //{
            //    var now = DateTime.UtcNow; // current datetime

            //    if (entity.State == EntityState.Added)
            //        ((BaseEntity)entity.Entity).CreatedAt = now;
            //    ((BaseEntity)entity.Entity).UpdatedAt = now;
            //}
            foreach (var entity in entities)
            {
                _ = entity.State switch
                {
                    EntityState.Added => entity.Entity.CreatedAt = DateTime.UtcNow,
                    EntityState.Modified => entity.Entity.UpdatedAt = DateTime.UtcNow,
                    _ => throw new InvalidOperationException("Unexpected entity state")
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
