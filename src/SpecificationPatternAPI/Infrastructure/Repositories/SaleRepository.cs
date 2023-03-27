using Microsoft.EntityFrameworkCore;
using SpecificationPatternAPI.Domain.Contracts.Repositories;
using SpecificationPatternAPI.Domain.Entities;
using SpecificationPatternAPI.Infrastructure.Context;
using System.Linq.Expressions;

namespace SpecificationPatternAPI.Infrastructure.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly ApplicationContext _context;

        public SaleRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Sale>> FindBy(Expression<Func<Sale,bool>> predicate)
        {
            return await _context.Set<Sale>()
                .Include(s => s.User)
                .Where(predicate)
                .ToListAsync();
        }
    }
}
