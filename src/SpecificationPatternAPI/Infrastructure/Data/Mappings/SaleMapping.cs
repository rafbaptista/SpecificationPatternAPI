using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecificationPatternAPI.Domain.Entities;

namespace SpecificationPatternAPI.Infrastructure.Data.Mappings
{
    public class SaleMapping : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");
            builder.HasKey(s => s.Id);
            builder.HasOne(s => s.User);
            builder.Property(s => s.FinancialValue).HasColumnType("decimal(18,2)");
            builder.HasData(GetSales());
        }

        private List<Sale> GetSales()
        {
            return new List<Sale>
            {
                new Sale { Id = 1, Active = true, UserId = 3, FinancialValue = 20_000 },
                new Sale { Id = 2, Active = true, UserId = 4, FinancialValue = 15_000 },
                new Sale { Id = 3, Active = true, UserId = 5, FinancialValue = 5_000 },
            };
        }

    }
}
