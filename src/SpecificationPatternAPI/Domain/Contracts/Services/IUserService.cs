using SpecificationPatternAPI.Domain.Entities;
using System.Linq.Expressions;

namespace SpecificationPatternAPI.Domain.Contracts.Services
{
    public interface IUserService
    {
        Task<List<User>> FindBy(Expression<Func<User, bool>> predicate);
        Task<User> Single(Expression<Func<User, bool>> predicate);
    }
}
