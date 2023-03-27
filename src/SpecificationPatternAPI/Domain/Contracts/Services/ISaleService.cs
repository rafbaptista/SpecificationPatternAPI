using SpecificationPatternAPI.Domain.Entities;
using System.Linq.Expressions;

namespace SpecificationPatternAPI.Domain.Contracts.Services
{
    public interface ISaleService
    {
        Task<List<Sale>> FindBy(Expression<Func<Sale, bool>> predicate);
    }
}
