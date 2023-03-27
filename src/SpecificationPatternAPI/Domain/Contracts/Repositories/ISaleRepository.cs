using SpecificationPatternAPI.Domain.Entities;
using System.Linq.Expressions;

namespace SpecificationPatternAPI.Domain.Contracts.Repositories
{
    public interface ISaleRepository
    {
        Task<List<Sale>> FindBy(Expression<Func<Sale, bool>> predicate);
    }
}
