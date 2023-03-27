using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SpecificationPatternAPI.Domain.Entities;

namespace SpecificationPatternAPI.Infrastructure.Data.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.HasData(GetUsers());
        }

        private List<User> GetUsers()
        {
            return new List<User>
            {
                new User { Id = 1, Active = true, CompanyId = null, Name = "Rafael" },
                new User { Id = 2, Active = true, CompanyId = 1, Name = "Bruno", IsCompanyAdministrator = true },
                new User { Id = 3, Active = true, CompanyId = 1, Name = "Fernando", IsCompanyAdministrator = false },
                new User { Id = 4, Active = true, CompanyId = 2, Name = "Daniel", IsCompanyAdministrator = false },
                new User { Id = 5, Active = true, CompanyId = 1, Name = "Gabriel", IsCompanyAdministrator = false },
            };
        }
    }
}