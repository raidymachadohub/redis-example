using Microsoft.EntityFrameworkCore;
using RedisExample.Model;

namespace RedisExample.Context
{
    public class RedisContext : DbContext
    {
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
        public RedisContext(DbContextOptions<RedisContext> options) : base(options){}
    }
}
