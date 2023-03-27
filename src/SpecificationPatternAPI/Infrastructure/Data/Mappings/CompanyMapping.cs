using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecificationPatternAPI.Domain.Entities;

namespace SpecificationPatternAPI.Infrastructure.Data.Mappings
{
    public class CompanyMapping : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Users).WithOne(u => u.Company).IsRequired(false);
            builder.HasData(GetCompanies());
        }

        private List<Company> GetCompanies()
        {
            return new List<Company>
            {
                new Company{Id = 1, Name = "Coca-Cola", Active = true},
                new Company{Id = 2, Name = "Pepsi", Active = true},
            };
        }

    }
}
