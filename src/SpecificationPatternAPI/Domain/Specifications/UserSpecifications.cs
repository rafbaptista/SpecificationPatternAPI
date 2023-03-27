using NSpecifications;
using SpecificationPatternAPI.Domain.Entities;

namespace SpecificationPatternAPI.Domain.Specifications
{
    public static class UserSpecifications
    {
        public static ASpec<User> ByUserId(int userId)
        {
            return Active() & new Spec<User>(u => u.Id == userId);
        }

        public static ASpec<User> Active()
        {
            return new Spec<User>(u => u.Active);
        }
    }
}
