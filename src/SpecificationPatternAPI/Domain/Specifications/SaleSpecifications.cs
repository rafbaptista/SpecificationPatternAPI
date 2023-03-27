using NSpecifications;
using SpecificationPatternAPI.Domain.Entities;

namespace SpecificationPatternAPI.Domain.Specifications
{
    public static class SaleSpecifications
    {
        public static ASpec<Sale> ByUser(User user)
        {
            if (user.IsSystemAdministrator)
                return BySystemAdministrator(user) & Active();

            return new Spec<Sale>(Active() & (ByCompanyAdministrator(user) | ByOwner(user.Id)));
        }

        public static ASpec<Sale> BySystemAdministrator(User user)
        {
            if (user.IsSystemAdministrator)
                return new Spec<Sale>(s => true);

            return new Spec<Sale>(s => false);
        }

        public static ASpec<Sale> ByCompanyAdministrator(User user)
        {
            return new Spec<Sale>(s => user.IsCompanyAdministrator && s.User.CompanyId == user.CompanyId);
        }
        public static ASpec<Sale> ByOwner(int userId)
        {
            return new Spec<Sale>(s => s.User.Id == userId);
        }

        public static ASpec<Sale> Active()
        {
            return new Spec<Sale>(s => s.Active);
        }


    }
}
