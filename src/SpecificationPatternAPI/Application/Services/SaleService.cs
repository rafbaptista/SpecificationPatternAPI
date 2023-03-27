using SpecificationPatternAPI.Domain.Contracts.Repositories;
using SpecificationPatternAPI.Domain.Contracts.Services;
using SpecificationPatternAPI.Domain.Entities;
using System.Linq.Expressions;

namespace SpecificationPatternAPI.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public async Task<List<Sale>> FindBy(Expression<Func<Sale, bool>> predicate)
        {
            return await _saleRepository.FindBy(predicate);
        }

    }
}
