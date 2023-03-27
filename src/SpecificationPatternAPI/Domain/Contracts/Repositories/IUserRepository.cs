using SpecificationPatternAPI.Domain.Entities;
using System.Linq.Expressions;

namespace SpecificationPatternAPI.Domain.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> FindBy(Expression<Func<User, bool>> predicate);
        Task<User> Single(Expression<Func<User, bool>> predicate);
    }
}
