using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Air.Liquide.Domain.Model.Person;

namespace Air.Liquide.Data.Mappings.Person
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.Property(f => f.Id).IsRequired();
            builder.Property(f => f.Name).IsRequired().HasMaxLength(45);
            builder.Property(f => f.Age).IsRequired();
        }
    }
}
