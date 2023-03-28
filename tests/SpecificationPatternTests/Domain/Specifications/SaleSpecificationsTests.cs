using SpecificationPatternAPI.Domain.Entities;
using SpecificationPatternAPI.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SpecificationPatternTests.Domain.Specifications
{
    public class SaleSpecificationsTests
    {
        private List<Sale> GetSales()
        {
           return new List<Sale>
            {
                new Sale{ Id = 1, Active = true, User = new User { Id = 1, Active = true, CompanyId = 1 } },
                new Sale{ Id = 2, Active = true, User = new User { Id = 2, Active = true, CompanyId = 2 } },
                new Sale{ Id = 3, Active = true, User = new User { Id = 3, Active = true, CompanyId = 3 } },
            };
        }
        [Fact]
        public void GivenSystemAdministrator_WhenSearchForSales_Then_MustReturnAllSalesOfTheSystem()
        {
            //Arrange
            var admin = new User { CompanyId = null };
            var sales = GetSales();

            //Act
            var result = sales.Where(SaleSpecifications.BySystemAdministrator(admin)).ToList();

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(result.Count, sales.Count);
        }

        [Fact]
        public void GivenCompanyAdministrator_WhenSearchForSales_Then_MustReturnAllSalesOfTheCustomer()
        {
            //Arrange
            int companyId = 1;
            var customerAdmin = new User { CompanyId = companyId, IsCompanyAdministrator = true};
            var sales = GetSales();

            //Act
            var result = sales.Where(SaleSpecifications.ByCompanyAdministrator(customerAdmin)).ToList();

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(sales.Where(x => x.User.CompanyId == companyId).Count(), result.Count);
        }

        [Fact]
        public void GivenCompanyEmployee_WhenSearchForSales_Then_MustReturnSalesWhereTheEmployeeIsOwner()
        {
            //Arrange
            int companyId = 1;
            var employee = new User { Id = 1, CompanyId = companyId, IsCompanyAdministrator = false };
            var sales = GetSales();

            //Act
            var result = sales.Where(SaleSpecifications.ByOwner(employee.Id)).ToList();

            //Assert
            Assert.NotEmpty(result);
            Assert.Equal(sales.Where(x => x.User.Id == companyId).Count(), result.Count);
        }
    }
}
