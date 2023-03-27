using Microsoft.EntityFrameworkCore;
using SpecificationPatternAPI.Domain.Contracts.Repositories;
using SpecificationPatternAPI.Domain.Entities;
using SpecificationPatternAPI.Infrastructure.Context;
using System.Linq.Expressions;

namespace SpecificationPatternAPI.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<User>> FindBy(Expression<Func<User, bool>> predicate)
        {
            return await _context.Set<User>()
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<User> Single(Expression<Func<User, bool>> predicate)
        {
            return await _context.Set<User>()
                .SingleOrDefaultAsync(predicate);
        }
    }
}
