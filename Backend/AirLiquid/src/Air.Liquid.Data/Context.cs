using Air.Liquide.Data.Mappings.Person;
using Microsoft.EntityFrameworkCore;

namespace Air.Liquide.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMapping());
        }
    }
}
